<template>
  <div>
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

export default {
  name: 'LoginPanel',
  data () {
    return {
      username: '',
      password: '',
      isDisabled: true,
      headers: this.$store.getters.getRequestHeaders,
      loginURI: this.$store.getters.getLoginPortal
    }
  },
  methods: {
    postCredentials: function () {
      if (this.username != null) {
        if (this.password != null) {
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
              this.$store.dispatch('signIn', response.data.AuthToken)
              this.$router.push('/Home')
            })
            .catch(function (error) {
              console.log(error)
              return error
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
