<template>
  <div class="notification is-success" v-bind:class="{ 'is-hidden' : isHidden }">
    <button class="delete" v-on:click.prevent="toggleNotification"></button>
    <strong>Congratulations!</strong><br>
    <p>You've successfully registered your information.  Make sure to login to start learning!</P>
  </div>
</template>

<script>
/* eslint-disable */
export default {
 name: 'RegistrationAlert',
  data () {
    return {
      // Event properties
      isHidden: true
    }
  },
  methods: {
    // ************************* Togglers *************************
    /**
     * @description
     * toggles notification upon successful registration
     */
    toggleNotification: function () {
      this.isHidden = !this.isHidden
    }
  }
}
</script>

<style>
.notification {
  padding: 20px 20px 20px 20px;
}
</style>
