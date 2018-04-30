<template>
  <nav class="level is-transparent" style="background-color: #fff; padding: 1em;">
    <p class="level-item has-text-centered">
        <router-link to="/" class="link is-info">Main</router-link>
    </p>
    <div class="navbar-item level-item has-dropdown is-hoverable">
      <a class="navbar-link" >Partner Sites</a>
      <div class="navbar-dropdown is-boxed">
        <a class="navbar-item" href="https://getusgrub.com/">GitGrub</a>
        <a class="navbar-item" href="https://careaway.me">Careaway</a>
        <a class="navbar-item" href="">WhatFits</a>
      </div>
    </div>
    <h1 class="level-item has-text-centered">Extra Curricular Schooling</h1>
    <p class="level-item has-text-centered">
      <router-link to="/about" class="link is-info">About Us</router-link>
    </p>
    <p class="level-item has-text-centered">
      <router-link to="/registration" tag="button" class="registration-button">Get Started</router-link>
    </p>
  </nav>
</template>

<script>

</script>

<style>

</style>
