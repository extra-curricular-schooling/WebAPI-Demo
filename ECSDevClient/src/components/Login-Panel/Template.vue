<template>
  <div v-if="!isAuth">
    <error-modal/>
    <loading-modal/>
    <div class="field">
      <label class="label field-element is-required">Username</label>
      <div class="control has-icons-left has-icons-right">
        <input class="input" type="text" placeholder="Username" v-model="username" required>
        <span class="icon is-small is-left">
          <i class="fas fa-user"></i>
        </span>
      </div>
    </div>
    <div class="field password">
      <label class="label field-element is-required">Password</label>
      <div class="control has-icons-left">
        <input class="input" type="password" placeholder="************" v-model="password" required @keyup.enter="postCredentials">
        <span class="icon is-small is-left">
          <i class="fas fa-lock"></i>
        </span>
      </div>
    </div>
    <div class="forgot-credentials">
      <span class="forgot-username">
        <forgot-username ref="username"/>
        <a class="forget-links" @click.prevent="rememberUsername">Forgot Username?</a><br>
      </span>
      <span class="forgot-password">
        <forgot-password ref="password"/>
        <a class="forget-links" @click.prevent="changePassword">Forgot Password?</a>
      </span>
    </div>
    <div class="field is-grouped is-grouped-centered">
      <p class="control">
        <button class="button is-primary login-button" v-on:click="postCredentials" :disabled="isDisabled">
          Login
        </button>
      </p>
      <p class="control">
        <router-link to="/Registration" tag="button" class="button is-link register-button">
          Sign Up
        </router-link>
      </p>
    </div>
  </div>
</template>

<script>
import Axios from 'axios'
import ErrorModal from '@/components/error-modal/Template'
import EventBus from '@/assets/js/EventBus.js'
import forgotPassword from '@/components/forgot-password-modal/Template'
import forgotUsername from '@/components/Forgot-Username-Modal/Template'
import LoadingModal from '@/components/loading-modal/Template'
import UrlHelper from '@/assets/js/urlHelper'
import Swal from 'sweetalert2'
import JwtService from '@/assets/js/jwtService'
import jwt from 'jsonwebtoken'

export default {
  name: 'LoginPanel',
  components: {
    'error-modal': ErrorModal,
    'forgot-password': forgotPassword,
    'forgot-username': forgotUsername,
    'loading-modal': LoadingModal
  },
  data () {
    return {
      username: '',
      password: '',
      isDisabled: true,
      headers: this.$store.getters.getRequestHeaders,
      loginURI: this.$store.getters.getLoginPortal,
      currentRole: '',
      isAuth: ''
    }
  },
  mounted () {
    this.updateLocalSecurityState()
  },
  updated () {
    this.updateLocalSecurityState()
  },
  methods: {
    updateLocalSecurityState () {
      this.currentRole = this.$store.getters.getRole
      this.isAuth = this.$store.getters.isAuth
    },
    changePassword () {
      this.$refs.password.toggle()
      EventBus.$on('forgetUsername', () => {
        this.rememberUsername()
      })
    },
    rememberUsername () {
      this.$refs.username.toggle()
    },
    toggleErrorModal: function (message) {
      this.$store.dispatch('updateErrorMessage', message)
      EventBus.$emit('error')
    },
    toggleLoadingModal: function () {
      EventBus.$emit('loading')
    },
    postCredentials: function () {
      if (this.username != null) {
        if (this.password != null) {
          this.toggleLoadingModal()
          Axios({
            method: 'POST',
            url: this.$store.getters.getLoginPortal,
            headers: this.$store.getters.getRequestHeaders,
            data: {
              username: this.username,
              password: this.password
            }
          })
            .then((response) => {
              if (response.status === 200) {
                let url = response.data
                let parsedQuery = UrlHelper.parseUrlQuery(url)
                let token = parsedQuery['jwt']
                console.log(token)
                if (token !== undefined) {
                  this.handlePartialAccount(url, token)
                } else {
                  var decoded = jwt.decode(response.data.AuthToken, {complete: true})
                  if (decoded.payload.iss !== '') {
                    var validIssuers = this.$store.getters.getValidIssuers
                    var trustworthy = false
                    for (var x in validIssuers) {
                      if (validIssuers[x] === decoded.payload.iss) {
                        trustworthy = true
                      }
                    }
                    if (!trustworthy) {
                      this.toggleLoadingModal()
                      this.toggleErrorModal('An error has occurred, please try again later!')
                    } else {
                      this.$store.dispatch('updateRole', decoded.payload.role)
                      this.$store.dispatch('updateUsername', this.username)
                      this.$store.dispatch('signIn', response.data.AuthToken)
                      this.$store.dispatch('updateToken', response.data.AuthToken)
                      this.toggleLoadingModal()
                      EventBus.$emit('loggedIn')
                      this.$router.push('/Home')
                    }
                  } else {
                    this.toggleLoadingModal()
                    this.toggleErrorModal('An error has occurred, please try again later!')
                  }
                }
              }
            })
            .catch((error) => {
              this.toggleLoadingModal()
              if (error.response) {
                // The request was made and the server responded with a status code
                // that falls out of the range of 2xx
                if (error.response.data.message === 'SUSPENDED') {
                  Swal({
                    type: 'error',
                    title: 'Bad News',
                    text: 'According to our records, you have been suspended. Please contact an administrator for more information'})
                } else if (error.response.status === 400) {
                  Swal({
                    type: 'error',
                    title: 'Uh-Oh',
                    text: 'Invalid credentials. Please try again.'})
                } else if (error.response.status === 500) {
                  Swal({
                    type: 'error',
                    title: 'We Apologize',
                    text: 'We are unable to process your request at this time.'})
                } else {
                  Swal({
                    type: 'error',
                    title: 'Bad News',
                    text: 'Something has gone wrong. Please try again.'})
                }
              } else if (error.request) {
                console.log('problems with request')
                Swal({
                  type: 'error',
                  title: 'We Apologize',
                  text: 'Our server is currently not responding.'})
                // The request was made but no response was received
                // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
                // http.ClientRequest in node.js
                console.log(error.request)
              } else {
                // Something happened in setting up the request that triggered an Error
                Swal({
                  type: 'error',
                  title: 'Bad News',
                  text: 'Something has gone wrong. Please try again.'})
              }
            })
        }
      }
    },
    handlePartialAccount (url, token) {
      let claims = JwtService.myDecode(token)
      if (UrlHelper.getUrlPath(url) === 'partial-registration') {
        this.$store.dispatch('updateRole', claims['roleType'])
        this.$store.dispatch('updateUsername', claims['username'])
        this.$store.commit('setAuthToken', token)
        this.$router.push({
          name: 'PartialRegistration',
          params: {
            jwt: token
          }
        })
      }
      if (UrlHelper.getUrlPath(url) === 'home') {
        this.$store.dispatch('updateRole', claims['role'])
        this.$store.dispatch('updateUsername', claims['unique_name'])
        this.$store.dispatch('updateToken', token)
        this.$store.commit('signIn', token)
        this.$router.push({
          name: 'Home'
        })
      }
    }
  },
  watch: {
    username: function () {
      if (this.username !== '' && this.password !== '') {
        this.isDisabled = false
      } else {
        this.isDisabled = true
      }
    },
    password: function () {
      if (this.username !== '' && this.password !== '') {
        this.isDisabled = false
      } else {
        this.isDisabled = true
      }
    }
  }
}
</script>

<style scoped>
.forget-links {
  font-size: 11pt
}
</style>
