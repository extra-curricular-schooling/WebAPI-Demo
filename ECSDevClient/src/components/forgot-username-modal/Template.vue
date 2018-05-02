<template>
  <div class="modal" v-bind:class="{ 'is-active' : isActive }">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box">

        <span class="header">
          <h1>Forgot Username</h1><br>
        </span>

        <loading-modal></loading-modal>
        <div class="body" v-if="body==='firstStep'">
          <p>Forgot your username?  No worries.</p>
          <p>We just need the email you used to register.</p><br>
          <div class="field email">
            <label class="label field-element is-required">Email</label>
            <div class="control has-icons-left has-icons-right">
              <input v-model="email" id="email" class="input" type="email" @keyup="validateEmail" placeholder="Email Address">
              <span class="icon is-small is-left">
                <i class="fas fa-envelope"></i>
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
import Swal from 'sweetalert2'
import EventBus from '@/assets/js/EventBus'
import LoadingModal from '@/components/loading-modal/Template'

export default {
  name: 'ForgotUsername',
  components: {
    'loading-modal': LoadingModal
  },
  created () {
    EventBus.$on('forgetUsername', () => {
      this.toggle()
    })
  },
  data () {
    return {
      // Request Data
      email: '',

      // Response Data
      username: '',

      // Validation Messages
      emailMessage: '',

      // Regular Expressions
      EMAIL_REGEX: this.$store.getters.getEmailRegex,

      // Event Properties
      isActive: false,
      body: 'firstStep'
    }
  },
  methods: {
    // ************************* Togglers *************************
    /**
     * @description
     * toggles/activates and deactivates forgot username modal
     */
    toggle () {
      if (this.body == 'firstStep') {
        document.getElementById('email').className = 'input'
      }
      this.isActive = !this.isActive
      this.emailMessage = ''
    },
    /**
     * @description
     * closes modal if user clicks 'cancel'
     */
    cancel () {
      this.close()
    },
    /**
     * @description
     * makes request to server to submit email and search for username
     */
    submit () {
      this.submitEmail()
    },
    /**
     * @description
     * closes modal if modal is closed
     */
    close () {
      this.toggle()
      this.body = 'firstStep'
      this.email = ''
      this.username = ''
    },
    // ************************* Data Validators *************************
    /**
     * @description
     * validates if user enters correctly formatted email as defined by the
     * constraint of the email regular expression
     * regex: EMAIL_REGEX
     */
    validateEmail () {
      if (!this.$data.EMAIL_REGEX.test(this.$data.email) && this.$data.email != '') {
        document.getElementById('email').className = 'input';
        document.getElementById('emailControl').className = 'help is-info';
        this.$data.emailMessage = this.$store.getters.getEmailMessage;
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
    /**
     * @description
     * validates if input is completed and information is ready for submission
     * @returns {boolean} true - If input is valid
     * @returns {boolean} false - If input is not valid
     */
    isValid () {
      if (document.getElementById('email').className == 'input is-success' && this.email != null) {
        return true
      } else {
        return false
      }
    },
    // ************************* APIs *************************
    /**
     * @description
     * GET request to get username from account using email
     * @throws {ECONNABORTED} If request/response timed out
     * @throws {Conflict} Throws exception if user is not found
     * @throws {InteralServerError} Throws general exception if exception thrown in server
     */
    submitEmail () {
      this.$store.commit('clearAuthorizationHeader')
      if (this.isValid()) {

        // Hide modal
        this.toggle()

        // Enable loading screen
        EventBus.$emit('loading')

        // Get username
        Axios({
          method: 'GET',
          url: this.$store.getters.getBaseAppUrl + 'ForgetCredentials/GetUsername?email=' + this.email,
          headers: this.$store.getters.getRequestHeaders,
          timeout: this.$store.getters.getDefaultTimeout
        })
          .then(response => {
            console.log(response)
            if (response.status === 200) {
              this.$data.username = response.data

              // Disable loading screen
              EventBus.$emit('loading')

              // Show modal
              this.toggle()
              this.$data.body = 'success'

              // Clear
              this.$data.email = ''
            }
          })
          .catch(error => {
            console.log(error)

            // Disable loading screen
            EventBus.$emit('loading')

            // Connection timeout
            if (error.code == 'ECONNABORTED') {
              Swal({
                type: 'error',
                title: 'We Apologize',
                text: 'Fetching your information took too long.'})
            }

            // HTTP Status 409
            if (error.response.status === 409) {
              this.toggle()
              this.$data.body = 'noEmail'
            }

            // HTTP Status 500
            if (error.response.status === 500) {
              Swal({
                type: 'error',
                title: 'We Apologize',
                text: 'We are unable to process your request at this time.'})
            }

            // Clear
            this.$data.email = ''
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
