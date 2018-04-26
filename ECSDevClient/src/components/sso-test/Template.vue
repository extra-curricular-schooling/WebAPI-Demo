<template>
  <div>
    <section class="section">
        <div class="container">
          <h1 class="title">Sso Tests</h1>
        </div>
      </section>
    <div class="container">
      <div class="notification">
        <input class="input" v-model="jwt" type="text" placeholder="JWT">
      </div>
    </div>
    <div>
      <button class="button is-primary" v-on:click="submitRegistration">Send Post to Sso/Registration</button>
      <button class="button is-primary" v-on:click="submitLogin">Send Post to Sso/Login</button>
      <button class="button is-primary" v-on:click="submitResetPassword">Send Post to Sso/ResetPassword</button>
    </div>
    <body>
      <section class="section">
        <div class="container">
          <h1 class="title">Pwned Tests</h1>
        </div>
      </section>
    </body>
    <div class="container">
      <div class="notification">
        <input class="input" v-model="passwordForPwned" type="text" placeholder="Password">
      </div>
    </div>
    <button class="button is-primary" v-on:click="testPwnd">have i been pwned?</button><br>
    <div class="container">
      <p class="breaches">Number of breaches: {{ hits }}</p>
    </div>
  </div>
</template>

<script>
/* eslint-diable */
import PwnedHelper from '@/assets/js/pwnedChecker'
import SsoMockRequest from './mockRequest'
import Swal from 'sweetalert2'
import Axios from 'axios'

export default {
  data: function () {
    return {
      jwt: '',
      passwordForPwned: '',
      hits: ''
    }
  },
  methods: {
    submitRegistration () {
      this.$store.dispatch('updateToken', this.jwt)
      SsoMockRequest.submitRegistration()
    },
    submitLogin () {
      this.$store.dispatch('updateToken', this.jwt)
      SsoMockRequest.submitLogin()
    },
    submitResetPassword () {
      this.$store.dispatch('updateToken', this.jwt)
      SsoMockRequest.submitResetPassword()
    },
    alert () {
      Swal({
        type: 'error',
        title: 'We Apologize',
        text: 'Fetching your information took too long.'})
    },
    testPwnd () {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBasePwnedUrl + PwnedHelper.getHashedPrefix(this.passwordForPwned),
        headers: this.$store.getters.getRequestHeaders
      })
        .then(response => {
          this.$data.hits = PwnedHelper.getHits(this.passwordForPwned, response.data)
          if (this.$data.hits > 0 && this.$data.hits < 100) {
            Swal({
              type: 'warning',
              title: 'Yikes',
              html: 'It looks like your password is associated with many publicly known breaches.  We <b>strongly advise</b> you change it.'
            })
          } else if (this.$data.hits >= 100) {
            Swal({
              type: 'error',
              title: 'Yikes',
              html: 'It looks like your password is associated with <b>too many</b> publicly known breaches.  We ask you to please choose a different password.'
            })
            this.$data.passwordForPwned = ''
          }
        })
        .catch(error => {
          console.log(error.response)
        })
    }
  }
}
</script>

<style scoped>
.breaches {
  text-align: left;
  font-size: 14pt;
}
</style>
