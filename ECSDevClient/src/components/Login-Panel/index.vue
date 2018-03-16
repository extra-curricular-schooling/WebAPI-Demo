<template>
  <div>
    <div class="field">
      <label class="label field-element is-required">Username</label>
      <div class="control has-icons-left has-icons-right">
        <input class="input" type="text" placeholder="Username" required>
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
        <input class="input" type="password" placeholder="************" required>
        <span class="icon is-small is-left">
          <i class="fas fa-lock"></i>
        </span>
      </div>
    </div>
    <div class="field is-grouped is-grouped-centered">
      <p class="control">
        <button class="button is-primary login-button">
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
export default {
  name: 'LoginPanel'
}
</script>
