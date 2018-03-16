<template>
  <nav class="level is-transparent">
    <p class="level-item has-text-centered">
        <router-link to="/" class="link is-info">Main</router-link>
    </p>
    <div class="navbar-item level-item has-dropdown is-hoverable">
      <a class="navbar-link" href="/documentation/overview/start/">Docs</a>
      <div class="navbar-dropdown is-boxed">
        <a class="navbar-item" href="/documentation/overview/start/">Overview</a>
        <a class="navbar-item" href="https://bulma.io/documentation/modifiers/syntax/">Modifiers</a>
        <a class="navbar-item" href="https://bulma.io/documentation/columns/basics/">Columns</a>
        <a class="navbar-item" href="https://bulma.io/documentation/layout/container/">Layout</a>
        <a class="navbar-item" href="https://bulma.io/documentation/form/general/">Form</a>
        <hr class="navbar-divider">
        <a class="navbar-item" href="https://bulma.io/documentation/elements/box/">Elements</a>
        <a class="navbar-item is-active" href="https://bulma.io/documentation/components/breadcrumb/">Components</a>
      </div>
    </div>
    <h1 class="level-item has-text-centered">Extra Curricular Schooling</h1>
    <p class="level-item has-text-centered">
      <router-link to="About" class="link is-info">About Us</router-link>
    </p>
    <p class="level-item has-text-centered">
      <router-link to="Registration" tag="button" class="registration-button">Get Started</router-link>
    </p>
  </nav>
</template>

<script>

</script>

<style>

</style>
