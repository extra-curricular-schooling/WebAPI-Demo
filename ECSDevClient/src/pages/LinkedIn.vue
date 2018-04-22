<template>
  <div>
    <loading-modal/>
    <toggle-loading/>>
    <connect-to-linkedin/>
    <LinkedInPostModal/>
  </div>
</template>

<script>
import Vue from 'vue'
import EventBus from '@/assets/js/eventBus'
import LoadingModal from '@/components/loading-modal/Template'
import LinkedInPostModal from '@/components/linkedin-modal/Template'

// We need this global button in order to link a user to their LinkedIn account
Vue.component('connect-to-linkedin', {
  template:
    '<button v-on:click="redirectToLinkedIn" class="button is-primary">Use LinkedIn!</button>',
  methods: {
    redirectToLinkedIn: function () {
      window.location.assign(
        'https://localhost:44311/v1/OAuth/RedirectToLinkedIn?authtoken=' +
          this.$store.getters.getAuthToken + '&returnuri=' + encodeURIComponent(window.location.href)
      )
    }
  }
})

Vue.component('toggle-loading', {
  template:
    '<button v-on:click="toggleLoading" class="button is-primary">Toggle Loading!</button>',
  methods: {
    toggleLoading: function () {
      EventBus.$emit('loading')
    }
  }
})

export default {
  name: 'LinkedIn',
  components: {
    LinkedInPostModal,
    LoadingModal
  }
}
</script>
