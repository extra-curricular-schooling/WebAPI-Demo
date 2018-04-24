<template>
  <div class="card" style="border-radius:5px;">
    <header class="card-header">
      <p class="card-header-title">
        Manage Account Status
      </p>
    </header>
    <div class="card-content">
      <label class="label" style="text-align:left;">Username</label>
      <input v-model="username" class="input" type="text" autocomplete="user-name" placeholder="Username" required>
    </div>
    <footer class="card-footer">
      <a v-on:click="retrieveUserInfo" class="card-footer-item">Retrieve Account</a>
    </footer>
  </div>
</template>

<script>
import Axios from 'axios'
import EventBus from '@/assets/js/EventBus.js'

export default {
  name: 'SelectUserPanel',
  data () {
    return {
      username: ''
    }
  },
  methods: {
    retrieveUserInfo: function () {
      Axios({
        method: 'POST',
        url: this.$store.getters.getRequestAccountInfoUri,
        headers: this.$store.getters.getRequestHeaders,
        data: {
          username: this.username
        }
      })
        .then((response) => {
          this.$store.dispatch('updateAccountStatus', response.data.AccountStatus)
          this.$store.dispatch('updateAdminSelectedUsername', this.username)
          EventBus.$emit('ToggleAdminAccountStatusView')
        })
        .catch((error) => {
          console.log(error)
        })
    }
  }
}
</script>
