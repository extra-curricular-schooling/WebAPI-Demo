<template>
  <div class="this-form">
    <p class="msg-to-user">Please provide your information to get started!</p>
    <welcome-message ref="welcome"/>
    <registration-form/>
  </div>
</template>

<script>
import WelcomeMessage from '@/components/partial-registration-form/elements/WelcomeMessage'
import RegistrationForm from '@/components/partial-registration-form/Template'

export default {
  name: 'PartialRegistration',
  components: {
    'welcome-message': WelcomeMessage,
    'registration-form': RegistrationForm
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

p {
  background-color: #363636;
  color: white;
  font-weight: bold;
  padding-top: 10px;
  padding-left: 50px;
  padding-right: 50px;
  padding-bottom: 10px;
}
</style>
