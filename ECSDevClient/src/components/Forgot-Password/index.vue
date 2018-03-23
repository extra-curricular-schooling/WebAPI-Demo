<template>
  <div class="modal" v-bind:class="{ 'is-active' : isActive }">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box">
        <span class="header">
          <h1>Forgot Password</h1>
        </span>
        <div class="body" v-if="isFirst">
          <p>Forgot your password?  No worries.</p><br>
        </div>
        <div class="body" v-else>
          <div class="field username">
            <label class="label field-element is-required">Username</label>
            <div class="control has-icons-left has-icons-right">
              <!-- <input v-model="username" id="username" class="input" type="text" @keyup="validateUsername" autocomplete="username" placeholder="Username" required> -->
              <input class="input" type="text" placeholder="Username">
              <span class="icon is-small is-left">
                <i class="fas fa-user"></i>
              </span>
            </div>
          </div>
        </div>
        <div class="field is-grouped is-grouped-centered form-buttons">
          <p class="control">
            <button class="button is-link cancel-button" v-on:click.prevent="toggle">
            Cancel
            </button>
          </p>
          <p class="control" v-if="isFirst">
            <button class="button is-primary submit-button" v-on:click.prevent="next">
            Next
            </button>
          </p>
          <p class="control" v-else>
            <button class="button is-primary submit-button" v-on:click.prevent="submit">
            Submit
            </button>
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ForgotPassword',
  data () {
    return {
      isActive: false,
      isFirst: true
    }
  },
  methods: {
    toggle () {
      this.isActive = !this.isActive
    },
    next () {
      this.isFirst = false
    },
    submit () {
      this.toggle()
      this.isFirst = true
    }
  }
}
</script>

<style>
.modal-card {
  top: 20px;
}
</style>
