<template>
  <button v-on:click="logOut" class="button">Log out</button>
</template>

<script>
import EventBus from '../../assets/js/EventBus'

export default {
  name: 'Logout-Button',
  methods: {
    logOut: function () {
      this.$store.dispatch('updateUsername', '')
      this.$store.dispatch('signOut')
      this.$store.dispatch('updateToken', '')
      EventBus.$emit('loggedOut')
      if (this.$router.currentRoute.path !== '/') {
        this.$router.push('/')
      } else {
        this.$router.go()
      }
    }
  }
}
</script>
