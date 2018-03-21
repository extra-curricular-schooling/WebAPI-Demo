<template>
  <div class="modal" v-bind:class="{ 'is-active' : isActive }">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box">
        <span>
          <h1>Welcome to Extracurricular Schooling!</h1><br>
          <p>We will need additional information before you can get started.</p><br>
        </span>
        <button class="button" @click.prevent="toggle">Continue Registration</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'WelcomeMessage',
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
}
</script>

<style>
.modal-card {
  top: 100px;
}
</style>
