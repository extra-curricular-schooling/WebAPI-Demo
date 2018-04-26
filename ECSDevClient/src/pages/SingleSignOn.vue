<template>
  <div>
    <error-modal/>
    <loading-modal/>
  </div>
</template>

<script>
import Axios from 'axios'
import ErrorModal from '@/components/error-modal/Template'
import EventBus from '@/assets/js/EventBus'
import LoadingModal from '@/components/loading-modal/Template'
import MockRequest from '@/components/sso-test/mockRequest'

export default {
  components: {
    Axios,
    ErrorModal,
    EventBus,
    LoadingModal
  },
  created () {
    this.$store.dispatch('updateToken', this.$route.query.jwt)
    MockRequest.submitLogin()
  },
  mounted () {
    EventBus.$emit('loading')
  },
  methods: {
    toggleErrorModal (message) {
      this.$store.dispatch('updateErrorMessage', message)
      EventBus.$emit('error')
    }
  }
}
</script>

<style>

</style>
