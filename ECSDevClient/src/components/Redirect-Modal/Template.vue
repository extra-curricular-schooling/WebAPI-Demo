<template>
  <div class="modal" v-bind:class="{ 'is-active' : visible }">
    <div v-on:click="toggleRedirectModal" class="modal-background"></div>
    <div class="modal-card">
      <header class="modal-card-head">
        <p class="modal-card-title">Redirection Notice</p>
        <button v-on:click="toggleRedirectModal" class="delete" aria-label="close"></button>
      </header>
      <section class="modal-card-body">
        {{errorMessage}}
      </section>
      <footer class="modal-card-foot">
        <button v-on:click="redirect" class="button is-success">Redirect</button>
        <button v-on:click="toggleRedirectModal" class="button">Cancel</button>
      </footer>
    </div>
  </div>
</template>

<script>
import EventBus from '@/assets/js/eventBus.js'

export default {
  name: 'RedirectModal',
  data () {
    return {
      redirectUri: '',
      errorMessage: '',
      visible: false
    }
  },
  mounted () {
    EventBus.$on('redirect', () => {
      this.toggleRedirectModal()
    })
  },
  methods: {
    redirect: function () {
      window.location.assign(this.redirectUri)
    },
    toggleRedirectModal: function () {
      this.updateData()
      this.visible = !this.visible
    },
    updateData: function () {
      this.redirectUri = this.$store.getters.getRedirectUri
      this.errorMessage = this.$store.getters.getErrorMessage
    }
  }
}
</script>
