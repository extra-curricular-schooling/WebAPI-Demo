<template>
  <div>
    <welcome-message ref="welcome"/>
  </div>
</template>

<script>
import WelcomeMessage from '@/components/Finish-Registration/elements/WelcomeMessage'

export default {
  name: 'PartialRegistration',
  components: {
    'welcome-message': WelcomeMessage
  },
  mounted () {
    this.welcomeUser()
  },
  methods: {
    welcomeUser () {
      this.$refs.welcome.toggle()
    }
  }
}
</script>

<style>
</style>
