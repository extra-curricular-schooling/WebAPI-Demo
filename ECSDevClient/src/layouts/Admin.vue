<template>
  <nav class="level is-transparent">
    <p class="level-item has-text-centered">
        <router-link to="/" class="link is-info">Main</router-link>
    </p>
    <div class="navbar-item level-item has-dropdown is-hoverable">
      <a class="navbar-link" >Partner Sites</a>
      <div class="navbar-dropdown is-boxed">
        <a class="navbar-item" href="">GitGrub</a>
        <a class="navbar-item" href="https://careaway.me">Careaway</a>
        <a class="navbar-item" href="">WhatFits</a>
      </div>
    </div>
    <p class="level-item has-text-centered">
      <router-link to="/sweepstake-admin" class="link is-info">Manage Sweepstakes</router-link>
    </p>
    <p class="level-item has-text-centered">
      <router-link to="/account-admin" class="link is-info">Manage Accounts</router-link>
    </p>
    <p class="level-item has-text-centered">
      <logout-button/>
    </p>
  </nav>
</template>

<script>
import LogoutButton from '@/components/logout-button/Template'

export default {
  name: 'Admin-Navbar',
  components: {
    LogoutButton
  }
}
</script>

<style>

</style>
