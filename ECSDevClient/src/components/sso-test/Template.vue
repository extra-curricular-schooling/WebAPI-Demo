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
  </div>
</template>

<script>
/* eslint-diable */
import PwnedHasher from '@/assets/js/pwnedChecker'
import SsoMockRequest from './mockRequest'
import Axios from 'axios'

export default {
  data: function () {
    return {
      jwt: '',
      passwordForPwned: ''
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
    testPwnd () {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBasePwnedUrl + PwnedHasher.getPwnedParameter(this.passwordForPwned),
        // url: 'https://api.pwnedpasswords.com/range/21BD1',
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Access-Control-Allow-Credentials': true,
          'Accept': 'application/json',
          'Content-Type': 'text/plain',
          'Authorization': 'null',
          'X-Requested-With': 'XMLHttpRequest'
        }
      })
        .then(response => {
          console.log(response)
        })
        .catch(error => {
          console.log(error.response)
        })
    }
  }
}
</script>
