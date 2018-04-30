<template>
  <div class="modal" v-bind:class="{ 'is-active' : isActive }">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box">
        <div class="body" v-if="body==='isWarned'">
          <p>The password you have entered has been linked to publicly leaked breaches across the web.</p><br>
          <p>We <strong>strongly advise</strong> you enter a more secure password.</p>
        </div>

        <div class="body" v-if="body==='isRejected'">
          <p>The password you have entered has been linked to <strong>too many publicly leaked breaches across the web.</strong></p><br>
          <p>To protect your account with us, we <strong>cannot</strong> accept the password you entered.  Please provide a more secure password.</p>
        </div>
        <br>
        <div class="field is-grouped is-grouped-centered form-buttons">
          <p class="control" v-if="body==='isWarned'">
            <button class="button is-primary submit-button" @click.prevent="close(status)">
            Okay, thank you!
            </button>
          </p>

          <p class="control" v-if="body==='isRejected'">
            <button class="button is-primary submit-button" @click.prevent="close(status)">
            Okay, I will change my password.
            </button>
          </p>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
/* eslint-disable */
import PwnedHelper from '@/assets/js/pwnedChecker'
import EventBus from '@/assets/js/EventBus'
import Axios from 'axios'

export default {
  name: 'BadPassword',
  data () {
    return {
      // Properties
      status: '',

      // Event Properties
      isActive: false,
      body: ''
    }
  },
  methods: {
    // ************************* Togglers *************************
    /**
     * @description
     * toggles the bad password alert if response from API returns a number of breaches
     * greater than 0
     * if the number of breaches > 0 and < 100, toggle alert that suggests a user 
     * to provide a different password
     * if the number of breaches > 100, toggle alert that rejects the given password
     * and asks the user to provide a new password
     * @param {string} userPassword - The password the user provides to be tested if it has been pwned
     */
    toggle (userPassword) {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBasePwnedUrl + PwnedHelper.getHashedPrefix(userPassword) //use string 'password' for test
      })
        .then(response => {
          let hits = PwnedHelper.getHits(userPassword, response.data) //use string 'password' for test
          if (hits > 0 && hits < 100) {
            this.body = 'isWarned'
            this.isActive = true
            this.status = 'warned'
          } else if (hits >= 100) {
            this.body = 'isRejected'
            this.isActive = true
            this.status = 'rejected'
          }
        })
        .catch(error => {
          console.log(error.response)
        })
    },
    /**
     * @description
     * toggles the alert to close if a button is clicked
     * @param {string} status - The status (rejected or warned) of the password
     */
    close (status) {
      this.body = ''
      this.isActive = false
      EventBus.$emit('click', status)
    }
  }
}
</script>
