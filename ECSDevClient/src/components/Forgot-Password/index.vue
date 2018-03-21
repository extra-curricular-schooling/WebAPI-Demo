<template>
  <div class="modal" v-bind:class="{ 'is-active' : isActive }">
    <div class="modal-background">
      <div class="modal-card">
        <header class="modal-card-head">
          <p class="modal-card-title">So you forgot your password too, huh?</p>
          <button v-on:click.prevent="toggle" class="delete" aria-label="close"></button>
        </header>
        <section class="modal-card-body">
          <p class="body">
            Dumbass...
          </p>
        </section>
        <!-- <footer class="modal-card-foot">
        </footer> -->
      </div>
    </div>
  </div>
</template>

<script>
export default {
  // The forgot password component should request to the portal that
  // the password will be changed.
  name: 'ForgotPassword',
  data () {
    return {
      isActive: false
    }
  },
  methods: {
    toggle () {
      this.isActive = !this.isActive
    }
  }
  // mounted () {
  //   console.log('Forgot password component mounted')
  // }
}
</script>

<style>
.modal-card {
  top: 20px;
}
</style>
