<template>
  <div class="modal" v-bind:class="{ 'is-active' : isActive }">
    <div class="modal-background"></div>
    <div class="modal-content">
      <div class="box">

        <span class="header">
          <h1>Forgot Password</h1><br>
        </span>

        <div class="body" v-if="body==='firstStep'">
          <p>Forgot your password?  No worries.</p>
          <p>We just need information you used to register.</p><br>
          <div class="field username">
            <label class="label field-element is-required">Username</label>
            <div class="control has-icons-left has-icons-right">
              <!-- <input v-model="username" id="username" class="input" type="text" @keyup="validateUsername" autocomplete="username" placeholder="Username" required> -->
              <input v-model="username" class="input" type="text" placeholder="Username">
              <span class="icon is-small is-left">
                <i class="fas fa-user"></i>
              </span>
            </div>
          </div>
          <!-- <forgot-username ref="username"/>
          <a class="no-username" @click.prevent="getUsername">I don't remember my username.</a><br> -->
        </div>

        <div class="body" v-if="body==='secondStep'">
          <!-- BEGIN required security questions -->
          <div class="is-field-group">
            <div class="field security-questions">
              <label class="label field-element is-required">Security Questions</label>
              <div class="control">
                <!-- <input v-model="question1" class="input" type="number" placeholder="Question 1" required> -->
                <p>{{ questions[0].SecQuestion }}</p>
              </div>
            </div>
            <div class="field security-questions-answers">
              <div class="control">
                <!-- <input id="answer1" class="input" type="text" @keyup="validateAnswers" placeholder="Answer 1" required> -->
                <input id="answer1" class="input" type="text" placeholder="Answer 1" required>
              </div>
            </div>

            <div class="field security-questions">
              <div class="control">
                <!-- <input v-model="question2" class="input" type="number" placeholder="Question 2" required> -->
                <p>{{ questions[1].SecQuestion }}</p>
              </div>
            </div>
            <div class="field security-questions-answers">
              <div class="control">
                <!-- <input id="answer2" class="input" type="text" @keyup="validateAnswers" placeholder="Answer 2" required> -->
                <input id="answer2" class="input" type="text" placeholder="Answer 2" required>
              </div>
            </div>

            <div class="field security-questions">
              <div class="control">
                <!-- <input v-model="question3" class="input" type="number" placeholder="Question 1" required> -->
                <p>{{ questions[2].SecQuestion }}</p>
              </div>
            </div>
            <div class="field security-questions-answers">
              <div class="control">
                <!-- <input id="answer3" class="input" type="text" @keyup="validateAnswers" placeholder="Answer 3" required> -->
                <input id="answer3" class="input" type="text" placeholder="Answer 3" required>
              </div>
            </div>
            <!-- <p id="answersControl" class="help">{{ answersMessage }}</p> -->
          </div>
          <!-- END security questions -->
        </div>

        <bad-password ref="alert"></bad-password>
        <div class="body" v-if="body==='thirdStep'">
          <p>Please enter a <strong>new password</strong><p>
          <div class="field password">
            <label class="label field-element is-required">New Password</label>
            <div class="control has-icons-left">
              <!-- <input id="password" class="input" type="password"  @keyup="validatePassword" autocomplete="new-password" placeholder="************" required> -->
              <input id="password" class="input" type="password" @keyup="validatePassword" placeholder="************" required>
              <span class="icon is-small is-left">
                <i class="fas fa-lock"></i>
              </span>
            </div>
            <p id="passwordControl" class="help">{{ passwordMessage }}</p>
          </div>

          <div class="field confirm-password">
            <label class="label field-element is-required">Confirm New Password</label>
            <div class="control has-icons-left">
              <!-- <input id="confirmPassword" class="input" type="password" @keyup="validateConfirmPassword" autocomplete="new-password" placeholder="************" required> -->
              <input id="confirmPassword" class="input" type="password" @keyup="passwordEventHelper(getPassword())" placeholder="************" required>
              <span class="icon is-small is-left">
                <i class="fas fa-lock"></i>
              </span>
            </div>
            <p id="confirmPasswordControl" class="help">{{ confirmPasswordMessage }}</p>
          </div>
        </div>

        <div class="body" v-if="body==='success'">
          <p>Congratulations!  You have successfully changed your password.</p>
        </div>

        <br>
        <div class="field is-grouped is-grouped-centered form-buttons">
          <p class="control" v-if="body!=='success'">
            <button class="button is-link cancel-button" v-on:click.prevent="cancel">
            Cancel
            </button>
          </p>

          <p class="control" v-if="body==='firstStep'">
            <button class="button is-primary submit-button" v-on:click.prevent="next">
            Next
            </button>
          </p>

          <p class="control" v-if="body==='secondStep'">
            <button class="button is-primary submit-button" v-on:click.prevent="submit">
            Submit
            </button>
          </p>

          <p class="control" v-if="body==='thirdStep'">
            <button class="button is-primary submit-button" v-on:click.prevent="complete">
            Complete
            </button>
          </p>

          <p class="control" v-if="body==='success'">
            <button class="button is-primary submit-button" v-on:click.prevent="close">
            Awesome!
            </button>
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
/* eslint-disable */
import Axios from 'axios'
import BadPassword from '@/components/bad-password-alert/Template'
import EventBus from '@/assets/js/EventBus'

export default {
  name: 'ForgotPassword',
  components: {
    'bad-password': BadPassword
  },
  data () {
    return {
      // Request Data
      username: '',

      // Reponse Data
      questions: [],

      // Validation Messages
      passwordMessage: '',
      confirmPasswordMessage: '',

      // Regular Expressions
      PASSWORD_REGEX: /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_])[a-zA-Z0-9!@#$%^&*()_]{8,64}$/,

      // Event Properties
      isActive: false,
      body: 'firstStep'
    }
  },
  methods: {
    // ************************* Getters *************************
    /**
     * @description
     * get security answers provided by user input
     * @param {number} i - The label of a security answer (i.e. if first, second, or third)
     */
    getSecurityAnswer (i) {
      var answer
      if (i == 1) {
        answer = 'answer1';
      } else if (i == 2) {
        answer = 'answer2';
      } else if (i == 3) {
        answer = 'answer3'
      }
      return document.getElementById(answer).value;
    },
    /**
     * @description
     * get password provided by user input
     */
    getPassword () {
      return document.getElementById('password').value;
    },
    // ************************* Data Validators *************************
    /**
     * @description
     * validates the password provided by a user as defined by the constraint
     * of a password regular expression
     * regex: PASSWORD_REGEX
     */
    validatePassword () {
      if (!this.$data.PASSWORD_REGEX.test(document.getElementById('password').value) && document.getElementById('password').value != '') {
        document.getElementById('password').className = 'input';
        document.getElementById('passwordControl').className = 'help is-info';
        this.$data.passwordMessage = 'Password must be 8-64 characters long, must not contain any spaces, and must contain at least 1 lowercase letter, 1 uppercase letter, 1 number, and 1 special character.';
      } else if (document.getElementById('password').value == '') {
        document.getElementById('password').className = 'input';
        document.getElementById('passwordControl').className = 'help';
        this.$data.passwordMessage = '';
      } else {
        document.getElementById('password').className = 'input is-success';
        document.getElementById('passwordControl').className = 'help';
        this.$data.passwordMessage = '';
      }
    },
    /**
     * @description
     * validates the confirmed password provided by a user is the same as the 
     * password originally entered
     */
    validateConfirmPassword () {
      if (document.getElementById('password').value != document.getElementById('confirmPassword').value && document.getElementById('confirmPassword').value != '') {
        document.getElementById('confirmPassword').className = 'input';
        document.getElementById('confirmPasswordControl').className = 'help is-info';
        this.$data.confirmPasswordMessage = 'Retype Password';
      } else if (document.getElementById('confirmPassword').value == '') {
        document.getElementById('confirmPassword').className = 'input';
        document.getElementById('confirmPasswordControl').className = 'help';
        this.$data.confirmPasswordMessage = '';
      } else if (document.getElementById('password').value == document.getElementById('confirmPassword').value) {
        document.getElementById('confirmPassword').className = 'input is-success';
        document.getElementById('confirmPasswordControl').className = 'help';
        this.$data.confirmPasswordMessage = '';
      }
    },
    /**
     * @description
     * validates that the user has successfully entered information
     * without particular validation errors
     * @return {boolean} true - If all information provided is valid
     * @return {boolean} false - If all information provided is not valid
     */
    isValidCredentials () {
      if (document.getElementById('password').className == 'input is-success' &&
        document.getElementById('confirmPassword').className == 'input is-success') {
        return true
      } else {
        return false
      }
    },
    // ************************* Togglers *************************
    /**
     * @description
     * toggles/activates and deactivates the modal
     */
    toggle () {
      this.isActive = !this.isActive
    },
    /**
     * @description
     * directs the user to the next step of the forget password process.
     * the user must provide security questions in the second step
     */
    next () {
      this.getSecurityQuestions()
    },
    /**
     * @description
     * deactivates the modal if the user clicks 'cancel'
     */
    cancel () {
      this.toggle()
      this.body = 'firstStep'
    },
    /**
     * @description
     * activates request to server to submit answers to account
     * security questions
     */
    submit () {
      this.submitAnswers()
    },
    /**
     * @description
     * activates request to server to submit new password credentials
     */
    complete () {
      this.submitNewPassword()
    },
    /**
     * @description
     * deactivates modal if modal is closed
     */
    close () {
      this.toggle()
      this.body = 'firstStep'
    },
    /**
     * @description
     * calls method to check if password has been pwned and activates alert if breached
     * @param {string} password - Pasword inputted by user
     */
    toggleAlert (password) {
      this.$refs.alert.toggle(password)
      EventBus.$on('click', (status) => {
        console.log(status)
        if (status == 'rejected') {
          document.getElementById('password').value = ''
          document.getElementById('password').className = 'input'
          document.getElementById('confirmPassword').value = ''
          document.getElementById('confirmPassword').className = 'input'
        }
      })
    },
    // ************************* Helpers *************************
    /**
     * @description
     * event helper to handle confirm validation and pwned password checker
     * on keyup
     * @param {string} password - Password inputted by user
     */
    passwordEventHelper(password) {
      this.validateConfirmPassword()
      if (document.getElementById('password').className == 'input is-success' &&
        document.getElementById('confirmPassword').className == 'input is-success') {
        this.toggleAlert(password)
      }
    },
    // ************************* APIs *************************
    /**
     * @description
     * GET request to get security questions from server
     * @throws {Conflict} Throws an exception if username is not found in resource
     */
    getSecurityQuestions () {
      Axios({
          method: 'GET',
          url: this.$store.getters.getBaseAppUrl + 'ForgetCredentials/GetSecurityQuestions?username=' + this.username,
          headers: this.$store.getters.getRequestHeaders
        })
          .then(response => {
            console.log(response)
            if (response.status === 200) {
              this.questions = response.data
              this.body = 'secondStep'
            }
          })
          .catch(error => {
            console.log(error.response)

            // HTTP Status 409
            if (error.response.status === 409) {
            }
          })
    },
    /**
     * @description
     * POST request to submit answers to account security questions
     * @throws {Forbidden} Throws exception if answers are incorrect and source access is denied
     * @throws {InternalServerError} Throws exception if request cannot be processed
     */
    submitAnswers () {
      Axios({
          method: 'POST',
          url: this.$store.getters.getBaseAppUrl + 'ForgetCredentials/SubmitAnswers',
          headers: this.$store.getters.getRequestHeaders,
          data: {
            'username': this.$data.username,
            'securityQuestions': [
              {
                'question': Number(this.$data.questions[0].SecurityQuestionID),
                'answer': this.getSecurityAnswer(1)
              },
              {
                'question': Number(this.$data.questions[1].SecurityQuestionID),
                'answer': this.getSecurityAnswer(2)
              },
              {
                'question': Number(this.$data.questions[2].SecurityQuestionID),
                'answer': this.getSecurityAnswer(3)
              }
            ]
          }
        })
          .then(response => {
            console.log(response)
            if (response.status === 200) {
              this.body = 'thirdStep'
            }
          })
          .catch(error => {
            console.log(error.response)
            //this.$data.error = JSON.parse(error.response.data)

            // HTTP Status 403
            if (error.response.status === 403) {
              alert('Incorrect answers...')
            }

            // HTTP Status 500
            if (error.response.status === 500) {
              alert('We apologize.  We are unable to process your request at this time.')
            }
          })
    },
    /**
     * @description
     * POST request to submit new password credentials
     * @throws {InternalServerError} Throws exception if request cannot be processed
     */
    submitNewPassword () {
      if (this.isValidCredentials()){
        Axios({
            method: 'POST',
            url: this.$store.getters.getBaseAppUrl + 'ForgetCredentials/SubmitNewPassword',
            headers: this.$store.getters.getRequestHeaders,
            data: {
              'username': this.username,
              'password': this.getPassword()
            }
          })
            .then(response => {
              console.log(response)
              if (response.status === 200) {
                this.questions = response.data
                this.body = 'success'
              }
            })
            .catch(error => {
              console.log(error.response)

              // HTTP Status 500
              if (error.response.status === 500) {
                alert('We apologize.  We are unable to process your request at this time.')
              }
            })
      }
    },
  }
}
</script>

<style scoped>
.field-element {
  text-align: left;
}

.no-username {
  float: left;
}
</style>
