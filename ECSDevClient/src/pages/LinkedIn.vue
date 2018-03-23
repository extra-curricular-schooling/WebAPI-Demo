<template>
  <div>
    <connect-to-linkedin/>
    <LinkedInPostModal/>
  </div>
</template>

<script>
import Vue from 'vue'
import LinkedInPostModal from '@/components/LinkedIn-Modal/Index'

// We need this global button in order to link a user to their LinkedIn account
Vue.component('connect-to-linkedin', {
  template:
    '<button v-on:click="redirectToLinkedIn" class="button is-primary">Use LinkedIn!</button>',
  methods: {
    redirectToLinkedIn: function () {
      window.location.assign(
        'https://localhost:44311/OAuth/RedirectToLinkedIn?authtoken=' +
          this.$store.getters.getAuthToken + '&returnuri=' + encodeURIComponent(window.location.href)
      )
    }
  }
})

export default {
  name: 'LinkedIn',
  components: {
    LinkedInPostModal
  }
}
</script>
