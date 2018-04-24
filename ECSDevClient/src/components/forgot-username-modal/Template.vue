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
              <!-- <input v-model="email" id="email" class="input" type="email" @keyup="validateEmail" autocomplete="email" placeholder="Email" required> -->
              <input v-model="email" id="email" class="input" type="email" @keyup="validateEmail" placeholder="Email Address">
              <span class="icon is-small is-left">
                <i class="fas fa-user"></i>
              </span>
            </div>
            <p id="emailControl" class="help">{{ emailMessage }}</p>
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

        <div class="body" v-if="body==='error'">
          <p>Sorry.  We are unable to process your request at this time.</p><br>
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
/* eslint-disable */
import Axios from 'axios'

export default {
  name: 'ForgotUsername',
  data () {
    return {
      // Request Data
      email: '',

      // Response Data
      username: 'test',

      // Validation Messages
      emailMessage: '',

      // Reg Ex
      EMAIL_REGEX: /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,

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
    validateEmail () {
      if (!this.$data.EMAIL_REGEX.test(this.$data.email) && this.$data.email != '') {
        document.getElementById('email').className = 'input';
        document.getElementById('emailControl').className = 'help is-info';
        this.$data.emailMessage = 'Please enter a valid email.';
      } else if (this.$data.email == '') {
        document.getElementById('email').className = 'input';
        document.getElementById('emailControl').className = 'help';
        this.$data.emailMessage = '';
      } else {
        document.getElementById('email').className = 'input is-success';
        document.getElementById('emailControl').className = 'help';
        this.$data.emailMessage = '';
      }
    },
    isValid () {
      if (document.getElementById('email').className == 'input is-success') {
        return true
      } else {
        return false
      }
    },
    submitEmail () {
      if (this.isValid()) {
        Axios({
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
            } else {
              this.$data.body = 'error'
            }
          })
      }
    }
  }
}
</script>

<style scoped>
label.field-element {
  text-align: left;
}
</style>
