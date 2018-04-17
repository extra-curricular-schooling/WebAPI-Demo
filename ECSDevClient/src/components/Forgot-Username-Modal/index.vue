<template>
  <div class="modal" v-bind:class="{ 'is-active' : isActive }">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box">

        <span class="header">
          <h1>Forgot Username</h1><br>
        </span>

        <div class="body" v-if="body==='firstStep'">
          <p>Forgot your username?  No worries.</p>
          <p>We just need the email you used to register.</p><br>
          <div class="field email">
            <label class="label field-element is-required">Email</label>
            <div class="control has-icons-left has-icons-right">
              <!-- <input v-model="username" id="username" class="input" type="text" @keyup="validateUsername" autocomplete="username" placeholder="Username" required> -->
              <input v-model="email" class="input" type="text" placeholder="Email Address">
              <span class="icon is-small is-left">
                <i class="fas fa-user"></i>
              </span>
            </div>
          </div>
        </div>

        <div class="body" v-if="body==='success'">
          <p>Good news.  We found your username!</p><br>
          <div class="control">
            <input class="input" type="text" v-model="username" readonly>
          </div>
        </div>

        <div class="body" v-if="body==='noEmail'">
          <p>Uh-Oh.  It seems the email you entered does not exist.  Perhaps you may need to create an account.</p><br>
        </div>

        <br>
        <div class="field is-grouped is-grouped-centered form-buttons">
          <p class="control" v-if="body!=='success'">
            <button class="button is-link cancel-button" v-on:click.prevent="cancel">
            Cancel
            </button>
          </p>

          <p class="control" v-if="body==='firstStep'">
            <button class="button is-primary submit-button" v-on:click.prevent="submit">
            Submit
            </button>
          </p>

          <p class="control" v-if="body==='success'">
            <button class="button is-primary submit-button" v-on:click.prevent="close">
            Awesome!
            </button>
          </p>

          <p class="control" v-if="body==='noEmail'">
            <router-link to="/Registration" tag="button" class="button is-primary register-button">
            Create An Account
            </router-link>
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'ForgotUsername',
  data () {
    return {
      // Request Data
      email: '',

      // Response Data
      username: 'test',

      // Event Handling
      isActive: false,
      body: 'firstStep'
    }
  },
  methods: {
    toggle () {
      this.isActive = !this.isActive
    },
    cancel () {
      this.toggle()
      this.body = 'firstStep'
    },
    submit () {
      this.submitEmail()
    },
    close () {
      this.toggle()
      this.body = 'firstStep'
    },
    submitEmail () {
      axios({
        method: 'GET',
        url: this.$store.getters.getBaseAppUrl + 'ForgetCredentials/GetUsername?email=' + this.email,
        headers: this.$store.getters.getRequestHeaders
      })
        .then(response => {
          console.log(response)
          if (response.status === 200) {
            this.$data.username = response.data
            this.$data.body = 'success'
          }
        })
        .catch(error => {
          console.log(error.response)

          // HTTP Status 409
          if (error.response.status === 409) {
            this.$data.body = 'noEmail'
          }
        })
    }
  }
}
</script>

<style scoped>
label.field-element {
  text-align: left;
}
</style>
