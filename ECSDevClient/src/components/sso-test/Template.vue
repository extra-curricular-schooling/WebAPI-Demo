<template>
  <div>
    <h1>SSO TESTS</h1>
    <button v-on:click="submitRegistration">Send Post to Sso/Registration</button><br>
    <button v-on:click="submitLogin">Send Post to Sso/Login</button><br>
    <button v-on:click="submitResetPassword">Send Post to Sso/ResetPassword</button><br>
    <br>
    <input v-model="passwordForPwned">
    <button v-on:click="testPwnd">have i been pwned?</button><br>
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
      password: 'aaa',
      application: 'ecs',
      passwordForPwned: ''
    }
  },
  methods: {
    submitRegistration () {
      this.$store.dispatch('updateToken', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InNjb290ZXItZHVkZSIsInBhc3N3b3JkIjoiYSIsImFwcGxpY2F0aW9uIjoiZWNzIiwicm9sZVR5cGUiOiJwdWJsaWMiLCJpYXQiOjE1MTYyMzkwMjJ9.G-ucGta2B5R_0A5CGewhKz_rQBsesvrvcLkShfVgqGc')
      SsoMockRequest.submitRegistration(
        this.$store.getters.getUsername,
        this.$data.password,
        this.$data.application)
    },
    submitLogin () {
      this.$store.dispatch('updateToken', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InNjb290ZXItZHVkZSIsInBhc3N3b3JkIjoiYWEiLCJhcHBsaWNhdGlvbiI6ImVjcyIsInJvbGVUeXBlIjoicHVibGljIiwiaWF0IjoxNTE2MjM5MDIyfQ.nkWwmcQhb0M8JehpjuTvEhGtlMOAISOOvJdcpck2vuU')
      SsoMockRequest.submitLogin(
        this.$store.getters.getUsername,
        this.$data.password)
      // Nothing after this because of redirect in api call.
    },
    submitResetPassword () {
      this.$store.dispatch('updateToken', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InNjb290ZXItZHVkZSIsInBhc3N3b3JkIjoiYSIsImFwcGxpY2F0aW9uIjoiZWNzIiwicm9sZVR5cGUiOiJwdWJsaWMiLCJpYXQiOjE1MTYyMzkwMjJ9.G-ucGta2B5R_0A5CGewhKz_rQBsesvrvcLkShfVgqGc')
      SsoMockRequest.submitResetPassword(
        this.$store.getters.getUsername,
        this.$data.password)
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
