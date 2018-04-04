<template>
  <button v-on:click="logOut" class="button">Log out</button>
</template>

<script>
export default {
  name: 'Logout-Button',
  methods: {
    logOut: function () {
      window.sessionStorage.removeItem('ECSStore')
      this.$store.dispatch('updateUsername', '')
      this.$store.dispatch('signOut')
      this.$store.dispatch('updateToken', '')
      if (this.$router.currentRoute.path !== '/') {
        this.$router.push('/')
      } else {
        this.$router.go()
      }
    }
  }
}
</script>
