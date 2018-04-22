<template>
  <div class="modal" v-bind:class="{ 'is-active' : isActive }">
    <div class="modal-background">
      <div class="modal-card">
        <header class="modal-card-head">
          <p class="modal-card-title">Smh</p>
          <button v-on:click.prevent="toggle" class="delete" aria-label="close"></button>
        </header>
        <section class="modal-card-body">
          <p class="body">
            -_____-
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
  name: 'ForgotUsername',
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
  top: 20px;
}
</style>
