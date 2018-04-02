<template>
  <div>
    <h1>SSO TESTS</h1>
    <button v-on:click="submitRegistration">Send Post to Sso/Registration</button><br>
    <button v-on:click="submitLogin">Send Get to Sso/Login</button><br>
    <button v-on:click="submitResetPassword">Send Post to Sso/ResetPassword</button><br>
  </div>
</template>

<script>
import ssoMockRequest from './api/mockRequest'

export default {
  data: function () {
    return {
      password: 'aaa',
      application: 'ecs'
    }
  },
  methods: {
    submitRegistration () {
      ssoMockRequest.submitRegistration(
        this.$store.getters.getUsername,
        this.$data.password,
        this.$data.application)
    },
    submitLogin () {
      ssoMockRequest.submitLogin(
        this.$store.getters.getUsername,
        this.$data.password)
    },
    submitResetPassword () {
      ssoMockRequest.submitResetPassword(
        this.$store.getters.getUsername,
        this.$data.password)
    }
  }
}
</script>
