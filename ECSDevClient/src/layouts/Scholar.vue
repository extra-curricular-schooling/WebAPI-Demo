<template>
  <nav class="level is-transparent">
    <p class="level-item has-text-centered">
        <router-link to="/" class="link is-info">Main</router-link>
    </p>
    <p class ="level-item has-text-centered">
      <router-link to="/Home" class="link is-info">Home</router-link>
    <p class="level-item has-text-centered">
      <router-link to="/sweepstake" class="link is-info">Sweepstakes</router-link>
    </p>
    <h1 class="level-item has-text-centered">Extra Curricular Schooling</h1>
    <p class="level-item has-text-centered">
      <router-link to="/account" class="link is-info">Account</router-link>
    </p>
    <p class="level-item has-text-centered">
      <logout-button/>
    </p>
  </nav>
</template>

<script>
import LogoutButton from '@/components/logout-button/Template'

export default {
  name: 'Scholar-Navbar',
  components: {
    LogoutButton
  }
}
</script>

<style>

</style>
