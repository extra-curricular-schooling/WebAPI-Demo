<template>
  <div>
    <button v-on:click="submitRegistration">Send Post to SSO/Registration</button>
    <button v-on:click="submitResetPassword">Send Post to SSO/ResetPassword</button>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  methods: {
    submitRegistration: () => {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/SSO/Registration',
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
    submitResetPassword: () => {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/SSO/ResetPassword',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true,
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        data: {
          'username': 'Scott',
          'password': 'Blob'
        }
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    }
  }
}
</script>

<style>

</style>
