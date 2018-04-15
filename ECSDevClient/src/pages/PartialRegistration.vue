<template>
  <div class="this-form">
    <p class="msg-to-user">Please provide your information to get started!</p>
    <welcome-message ref="welcome"/>
    <registration-form/>
  </div>
</template>

<script>
import welcomeMessage from '@/components/partial-registration-form/elements/WelcomeMessage'
import registrationForm from '@/components/partial-registration-form/index'

export default {
  name: 'PartialRegistration',
  components: {
    'welcome-message': welcomeMessage,
    'registration-form': registrationForm
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

<style scoped>
.this-form {
  padding-left: 90px;
  padding-right: 90px;
  padding-bottom: 50px;
}
</style>
