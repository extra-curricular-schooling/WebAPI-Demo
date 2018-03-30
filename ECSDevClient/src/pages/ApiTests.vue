<template>
  <div>
    <h2>SSO Registration API Calls</h2>
    <button v-on:click="submitRegistration">Send Post to Sso/Registration</button>
    <h2>SSO Login API Calls</h2>
    <button v-on:click="submitLogin">Send Get to Sso/Login</button>
    <h2>Reset Password API Calls</h2>
    <button v-on:click="requestQuestions">Send Get to ResetPassword/SecurityQuestions</button>
    <button v-on:click="submitAnswers">Send Post to ResetPassword/SecurityQuestions</button>
    <!-- Add your apis in here -->
    <h2>Sweepstake API Calls</h2>
    <h2>SweepstakeAdmin API Calls</h2>
    <h2>Account API Calls</h2>
    <h2>AccountAdmin API Calls</h2>
    <h2>Auth API Calls</h2>
    <h2>LinkedIn API Calls</h2>
    <h2>Article API Calls</h2>
  </div>
</template>

<script>
import axios from 'axios'
import store from '@/store/index'

export default {
  methods: {
    submitRegistration () {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/Sso/Registration',
        headers: store.getters.getRequestHeaders,
        data: {
          'username': 'Scott',
          'password': 'Blob',
          'securityQuestions': [
            {
              'question': 1,
              'answer': 'Hello'
            }
          ]
        }
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    },
    submitLogin () {
      axios({
        method: 'GET',
        url: 'https://localhost:44311/Sso/LoginRedirect',
        headers: store.getters.getRequestHeaders
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    },
    requestQuestions () {
      axios({
        method: 'GET',
        url: 'https://localhost:44311/ResetPassword/SecurityQuestions',
        headers: store.getters.getRequestHeaders
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    },
    submitAnswers () {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/ResetPassword/SecurityQuestions',
        headers: store.getters.getRequestHeaders,
        data: {
          'username': 'Scott',
          'securityQuestions': [
            {
              'question': 1,
              'answer': '1'
            },
            {
              'question': 2,
              'answer': '2'
            },
            {
              'question': 3,
              'answer': '3'
            }
          ]
        }
      })
        .then(response => {
          return this.resetPassword()
        })
        .catch(response => console.log(response))
    },
    resetPassword () {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/ResetPassword/NewPassword',
        headers: store.getters.getRequestHeaders,
        data: {
          'username': 'Scott',
          'newPassword': 'blah'
        }
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    }
  }
}
</script>
