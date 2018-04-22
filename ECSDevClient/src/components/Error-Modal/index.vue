<template>
  <div class="modal" v-bind:class="{ 'is-active' : isVisible }">
    <div v-on:click="toggleErrorModal" class="modal-background"></div>
    <div class="modal-card">
      <header class="modal-card-head">
        <p class="modal-card-title">Oh no! Something Happened.</p>
        <button v-on:click="toggleErrorModal" class="delete" aria-label="close"></button>
      </header>
      <section class="modal-card-body">
        {{errorMessage}}
      </section>
      <footer class="modal-card-foot">
        <button v-on:click="toggleErrorModal" v-on:keyup.enter="toggleErrorModal" class="button">Okay</button>
      </footer>
    </div>
  </div>
</template>

<script>
import EventBus from '../../assets/js/EventBus.js'

export default {
  name: 'ErrorModal',
  data () {
    return {
      errorMessage: '',
      isVisible: false
    }
  },
  mounted () {
    EventBus.$on('error', () => {
      this.toggleErrorModal()
    })
  },
  methods: {
    toggleErrorModal: function () {
      this.updateData()
      this.isVisible = !this.isVisible
    },
    updateData: function () {
      this.errorMessage = this.$store.getters.getErrorMessage
    }
  }
}
</script>
