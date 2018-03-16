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
        <button class="button is-primary login-button" v-on:click="logIn" :disabled="isDisabled">
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
import postCredentials from './api/postCredentials.js'

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
    logIn: function () {
      postCredentials.postCredentials(this.loginURI, this.headers, this.username, this.password)
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
