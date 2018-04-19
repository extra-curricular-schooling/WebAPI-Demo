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
import pwnedHasher from '../../assets/js/PwnedChecker.js'
import ssoMockRequest from './api/mockRequest'
import axios from 'axios'

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
      this.$store.dispatch('updateToken', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ijc3N0xhemVyNzc3IiwicGFzc3dvcmQiOiI3NzdMYXplcjc3NyIsImFwcGxpY2F0aW9uIjoiY2FyZWF3YXkiLCJyb2xlVHlwZSI6InB1YmxpYyIsImlhdCI6MTUyMjgwMTA3OH0.RyYeO1ekdzfLnntWfs_NHV-4Dl0Qa6T-m_HkBAWwsUY')
      ssoMockRequest.submitRegistration(
        this.$store.getters.getUsername,
        this.$data.password,
        this.$data.application)
    },
    submitLogin () {
      this.$store.dispatch('updateToken', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ijc3N0xhemVyNzc3IiwicGFzc3dvcmQiOiI3NzdMYXplcjc3NyIsImFwcGxpY2F0aW9uIjoiY2FyZWF3YXkiLCJyb2xlVHlwZSI6InB1YmxpYyIsImlhdCI6MTUyMjgwMTA3OH0.RyYeO1ekdzfLnntWfs_NHV-4Dl0Qa6T-m_HkBAWwsUY')
      ssoMockRequest.submitLogin(
        this.$store.getters.getUsername,
        this.$data.password)
      // Nothing after this because of redirect in api call.
    },
    submitResetPassword () {
      this.$store.dispatch('updateToken', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Ijc3N0xhemVyNzc3IiwicGFzc3dvcmQiOiI3NzdMYXplcjc3NyIsImFwcGxpY2F0aW9uIjoiY2FyZWF3YXkiLCJyb2xlVHlwZSI6InB1YmxpYyIsImlhdCI6MTUyMjgwMTA3OH0.RyYeO1ekdzfLnntWfs_NHV-4Dl0Qa6T-m_HkBAWwsUY')
      ssoMockRequest.submitResetPassword(
        this.$store.getters.getUsername,
        this.$data.password)
    },
    testPwnd () {
      axios({
        method: 'GET',
        url: this.$store.getters.getBasePwnedUrl + pwnedHasher.getPwnedParameter(this.passwordForPwned),
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
