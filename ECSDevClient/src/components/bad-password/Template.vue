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
      status: '',
      // Event Handling
      isActive: false,
      body: ''
    }
  },
  methods: {
    toggle (userPassword) {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBasePwnedUrl + PwnedHelper.getHashedPrefix(userPassword), //use string 'password' for test
        headers: this.$store.getters.getRequestHeaders
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
    close (status) {
      this.body = ''
      this.isActive = false
      EventBus.$emit('click', status)
    }
  }
}
</script>
