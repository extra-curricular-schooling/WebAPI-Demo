<template>
  <div>
    <button v-on:click="submitRegistration">Send Post to Sso/Registration</button>
    <button v-on:click="requestQuestions">Send Get to Sso/SecurityQuestions</button>
    <button v-on:click="submitAnswers">Send Post to Sso/SecurityQuestions</button>
    <button v-on:click="submitLogin">Send Post to Sso/Login</button>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  methods: {
    submitRegistration: () => {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/Sso/Registration',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true,
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
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
    requestQuestions: () => {
      axios({
        method: 'GET',
        url: 'https://localhost:44311/Sso/SecurityQuestions',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true,
          'Accept': 'application/json'
        }
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    },
    submitAnswers: () => {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/Sso/SecurityQuestions',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true,
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
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
        .then(this.resetPassword())
        .catch(response => console.log(response))
    },
    resetPassword: () => {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/Sso/ResetPassword',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true,
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        data: {
          'username': 'Scott',
          'newPassword': 'blah'
        }
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    },
    submitLogin: () => {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/Sso/Login',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true,
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        data: {
          'username': 'Scott',
          'newPassword': 'Blob'
        }
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    }
  }
}
</script>
