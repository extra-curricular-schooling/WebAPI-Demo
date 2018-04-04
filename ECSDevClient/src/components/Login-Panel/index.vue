<template>
  <div v-if="currentRole === ''">
    <error-modal/>
    <loading-modal/>
    <div class="field">
      <label class="label field-element is-required">Username</label>
      <div class="control has-icons-left has-icons-right">
        <input class="input" type="text" placeholder="Username" v-model="username" required>
        <span class="icon is-small is-left">
          <i class="fas fa-user"></i>
        </span>
        <span class="icon is-small is-right">
          <i class="fas fa-check"></i>
        </span>
      </div>
    </div>
    <div class="field password">
      <label class="label field-element is-required">Password</label>
      <div class="control has-icons-left">
        <input class="input" type="password" placeholder="************" v-model="password" required>
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
        <button class="button is-primary login-button" @keyup.enter="postCredentials" v-on:click="postCredentials" :disabled="isDisabled">
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
import ErrorModal from '../Error-Modal/index'
import EventBus from '../../assets/js/EventBus.js'
import forgotPassword from '@/components/Forgot-Password-Modal/index'
import forgotUsername from '@/components/Forgot-Username-Modal/index'
import LoadingModal from '../Loading-Modal/index'
var jwt = require('jsonwebtoken')

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
      currentRole: ''
    }
  },
  mounted () {
    this.checkCurrentRole()
  },
  updated () {
    this.checkCurrentRole()
  },
  methods: {
    checkCurrentRole () {
      this.currentRole = this.$store.getters.getRole
    },
    changePassword () {
      this.$refs.password.toggle()
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
                  this.$router.push('/Home')
                }
              } else {
                this.toggleLoadingModal()
                this.toggleErrorModal('An error has occurred, please try again later!')
              }
            })
            .catch((error) => {
              console.log(error)
              this.toggleLoadingModal()
              this.toggleErrorModal('An error has occurred, please try again later!')
            })
        }
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
