<template>
  <div class="this-form">
    <p class="msg-to-user">Please provide your information to get started!</p>
    <registration-form></registration-form>
  </div>
</template>

<script>
import RegistrationForm from '@/components/registration-form/Template'

export default {
  components: {
    'registration-form': RegistrationForm
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
