<template>
  <!-- Main Registration Form -->
  <form class="registration-form" method="post">
    <p class="warning field-element">* indicates a required field</p>

    <!-- BEGIN required fields for basic information -->
    <div class="is-field-group">
      <div class="field first-name">
        <label class="label field-element is-required">First Name</label>
        <div class="control">
          <input v-model="firstName" id="firstName" class="input" type="text" @keyup="validateFirstName" autocomplete="given-name" placeholder="First Name" required>
        </div>
        <p id="firstNameControl" class="help">{{ firstNameMessage }}</p>
      </div>

      <div class="field last-name">
        <label class="label field-element is-required">Last Name</label>
        <div class="control">
          <input v-model="lastName" id="lastName" class="input" type="text" @keyup="validateLastName" autocomplete="family-name" placeholder="Last Name" required>
        </div>
        <p id="lastNameControl" class="help">{{ lastNameMessage }}</p>
      </div>

      <div class="field username">
        <label class="label field-element is-required">Username</label>
        <div class="control has-icons-left has-icons-right">
          <input v-model="username" id="username" class="input" type="text" @keyup="validateUsername" autocomplete="username" placeholder="Username" required>
          <span class="icon is-small is-left">
            <i class="fas fa-user"></i>
          </span>
          <span class="icon is-small is-right">
            <i class="fas fa-check"></i>
          </span>
        </div>
        <p id="usernameControl" class="help">{{ usernameMessage }}</p>
      </div>

      <div class="field email-address">
        <label class="label field-element is-required">Email</label>
        <div class="control has-icons-left has-icons-right">
          <input v-model="email" id="email" class="input" type="email" @keyup="validateEmail" autocomplete="email" placeholder="Email" required>
          <span class="icon is-small is-left">
            <i class="fas fa-envelope"></i>
          </span>
          <span class="icon is-small is-right">
            <i class="fas fa-check"></i>
          </span>
        </div>
        <p id="emailControl" class="help">{{ emailMessage }}</p>
      </div>

      <bad-password ref="alert"></bad-password>
      <div class="field password">
        <label class="label field-element is-required">Password</label>
        <div class="control has-icons-left">
          <input id="password" class="input" type="password"  @keyup="validatePassword" autocomplete="new-password" placeholder="************" required>
          <span class="icon is-small is-left">
            <i class="fas fa-lock"></i>
          </span>
        </div>
        <p id="passwordControl" class="help">{{ passwordMessage }}</p>
      </div>

      <div class="field confirm-password">
        <label class="label field-element is-required">Confirm Password</label>
        <div class="control has-icons-left">
          <input id="confirmPassword" class="input" type="password" @keyup="passwordEventHelper(getPassword())" autocomplete="new-password" placeholder="************" required>
          <span class="icon is-small is-left">
            <i class="fas fa-lock"></i>
          </span>
        </div>
        <p id="confirmPasswordControl" class="help">{{ confirmPasswordMessage }}</p>
      </div>
    </div>
    <!-- END basic info fields -->

    <!-- BEGIN optional fields for mailing address -->
    <div class="is-field-group">
      <div class="field mailing-address">
        <label class="label field-element">Mailing Address</label>
        <div class="control">
          <input v-model="address" id="address" class="input" type="text" @keyup="validateAddress" autocomplete="street-address" placeholder="Street Address">
        </div>
        <p id="addressControl" class="help">{{ addressMessage }}</p>
      </div>
      <div class="field mailing-address">
        <div class="control">
          <input v-model="city" id="city" class="input" type="text" @keyup="validateCity" autocomplete="address-line2" placeholder="City">
        </div>
        <p id="cityControl" class="help">{{ cityMessage }}</p>
      </div>
      <div class="is-table">
        <div class="field mailing-adress state">
          <p class="control">
            <input v-model="state" id="state" class="input" text="text" @keyup="validateState" autocomplete="address-line2" placeholder="State">
          </p>
          <p id="stateControl" class="help">{{ stateMessage }}</p>
        </div>
        <div class="field mailing-address zip">
          <p class="control">
            <input v-model="zipCode" id="zipCode" class="input" @keyup="validateZipCode" autocomplete="postal-code" placeholder="Zip Code">
          </p>
          <p id="zipCodeControl" class="help">{{ zipCodeMessage }}</p>
        </div>
      </div>
    </div>
    <!-- END mailing address fields -->

    <!-- BEGIN required security questions -->
    <div class="is-field-group">
      <div class="field security-questions">
        <label class="label field-element is-required">Security Questions</label>
        <div class="control">
          <span class="select">
            <select @change="getSelectionID(0, question1)" v-model="question1">
              <option disabled value="">--select--</option>
              <option v-for="question in questionSet1" v-bind:key="question.SecurityQuestionID"> {{ question.SecQuestion }} </option>
            </select>
          </span>
        </div>
      </div>
      <div class="field security-questions-answers">
        <div class="control">
          <input id="answer1" class="input" type="text" @keyup="validateAnswers" placeholder="Answer 1" required>
        </div>
      </div>

      <div class="field security-questions">
        <div class="control">
          <span class="select">
            <select @change="getSelectionID(1, question2)" v-model="question2">
              <option disabled value="">--select--</option>
              <option v-for="question in questionSet2" v-bind:key="question.SecurityQuestionID"> {{ question.SecQuestion }} </option>
            </select>
          </span>
        </div>
      </div>
      <div class="field security-questions-answers">
        <div class="control">
          <input id="answer2" class="input" type="text" @keyup="validateAnswers" placeholder="Answer 2" required>
        </div>
      </div>

      <div class="field security-questions">
        <div class="control">
          <span class="select">
            <select @change="getSelectionID(2, question3)" v-model="question3">
              <option disabled value="">--select--</option>
              <option v-for="question in questionSet3" v-bind:key="question.SecurityQuestionID"> {{ question.SecQuestion }} </option>
            </select>
          </span>
        </div>
      </div>
      <div class="field security-questions-answers">
        <div class="control">
          <input id="answer3" class="input" type="text" @keyup="validateAnswers" placeholder="Answer 3" required>
        </div>
      </div>
      <p id="answersControl" class="help">{{ answersMessage }}</p>
    </div>
    <!-- END security questions -->

    <div class="field form-agreements">
      <label class="checkbox">
        <input type="checkbox" checked="checked">
        Remember me
      </label><br>
      <label class="checkbox">
        <agreement-modal ref="modal"></agreement-modal>
        <input type="checkbox" @click="checkBox" v-bind:class="{ 'checked' : agreementIsChecked }">
        I agree to the <a @click.prevent="toggleModal">Terms and Conditions</a>.
      </label>
    </div>

    <!-- BEGIN form submission options -->
    <div class="field is-grouped is-grouped-centered form-buttons">
      <p class="control">
        <router-link to="/" tag="button" class="button is-link cancel-button">
        Cancel
        </router-link>
      </p>
      <p class="control">
        <button class="button is-primary submit-button" v-on:click.prevent="submit">
        Submit
        </button>
      </p>
    </div>
    <!-- END submission options -->
  </form>
</template>

<script>
/* eslint-disable */
import Axios from 'axios'
import AgreementModal from '@/components/registration-form/elements/AgreementModal'
import BadPassword from '@/components/bad-password-alert/Template'
import Shuffler from '@/assets/js/arrayShuffler'
import EventBus from '@/assets/js/EventBus'

export default {
  name: 'RegistrationForm',
  components: {
    'agreement-modal': AgreementModal,
    'bad-password': BadPassword
  },
  data () {
    return {
      // Properties
      question1: '',
      question2: '',
      question3: '',
      questionSet1: [],
      questionSet2: [],
      questionSet3: [],

      // Event Properties
      agreementIsChecked: false,

      // Request Data
      firstName: '',
      lastName: '',
      username: '',
      email: '',
      address: '',
      city: '',
      state: '',
      zipCode: '',
      questionIDs: [],

      // Response Data
      questions: [],
      error: {},

      // Validation Messages
      firstNameMessage: '',
      lastNameMessage: '',
      usernameMessage: '',
      passwordMessage: '',
      confirmPasswordMessage: '',
      emailMessage: '',
      addressMessage: '',
      cityMessage: '',
      stateMessage: '',
      zipCodeMessage: '',
      answersMessage: '',

      // Regular Expressions
      NAME_REGEX: /^[a-zA-Z ]{1,50}$/,
      USERNAME_REGEX: /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]{8,120}$/,
      PASSWORD_REGEX: /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_])[a-zA-Z0-9!@#$%^&*()_]{8,64}$/,
      EMAIL_REGEX: /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
      ADDRESS_REGEX: /^[a-zA-Z0-9#.,-/ ]{0,}$/,
      CITY_REGEX: /^[a-zA-Z ]{0,}$/,
      STATE_REGEX: /^[a-zA-Z]{0,2}$/,
      ZIPCODE_REGEX: /^\d{5}(?:[-\s]\d{4})?$/,
    }
  },
  created () {
    this.fetchSecurityQuestions()
  },
  methods: {
    // ************************* Getters *************************
    /**
     * @description
     * gets password inputted by user
     * @returns {string} Password
     */
    getPassword () {
      return document.getElementById('password').value;
    },
    /**
     * @description
     * gets a particular security answer
     * @param {number} i - The label of a security answer
     * @returns {string} Security answer
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
     * gets ID of a selected security question
     * @param {number} i - Index of a question ID
     * @param {string} selected - The selected security question
     */
    getSelectionID (i, selected) {
      for (var key in this.$data.questions) {
        var question = this.$data.questions[key]
        if (question.SecQuestion === selected) {
          var ID = question.SecurityQuestionID
        }
      }
      this.$data.questionIDs[i] = ID
    },
    // ************************* Data Validators *************************
    /**
     * @description
     * validates the first name of a user as defined by the constraint of the 
     * name regular expression
     * regex: NAME_REGEX
     */
    validateFirstName () {
      if (!this.$data.NAME_REGEX.test(this.$data.firstName) && this.$data.firstName != '') {
        document.getElementById('firstName').className = 'input';
        document.getElementById('firstNameControl').className = 'help is-info';
        this.$data.firstNameMessage = 'Sorry, the name you entered either contains invalid characters or is too long.';
      } else if (this.$data.firstName == '') {
        document.getElementById('firstName').className = 'input';
        document.getElementById('firstNameControl').className = 'help';
        this.$data.firstNameMessage = '';
      } else {
        document.getElementById('firstName').className = 'input is-success';
        document.getElementById('firstNameControl').className = 'help';
        this.$data.firstNameMessage = '';
      }
    },
    /**
     * @description
     * validates the last name of a user as defined by the constraint of the 
     * name regular expression
     * regex: NAME_REGEX
     */
    validateLastName () {
      if (!this.$data.NAME_REGEX.test(this.$data.lastName) && this.$data.lastName != '') {
        document.getElementById('lastName').className = 'input';
        document.getElementById('lastNameControl').className = 'help is-info';
        this.$data.lastNameMessage = 'Sorry, the name you entered either contains invalid characters or is too long.';
      } else if (this.$data.lastName == '') {
        document.getElementById('lastName').className = 'input';
        document.getElementById('lastNameControl').className = 'help';
        this.$data.lastNameMessage = '';
      } else {
        document.getElementById('lastName').className = 'input is-success';
        document.getElementById('lastNameControl').className = 'help';
        this.$data.lastNameMessage = '';
      }
    },
    /**
     * @description
     * validates the username of a user as defined by the constraint of the 
     * username regular expression
     * regex: USERNAME_REGEX
     */
    validateUsername () {
      if (!this.$data.USERNAME_REGEX.test(this.$data.username) && this.$data.username != '') {
        document.getElementById('username').className = 'input';
        document.getElementById('usernameControl').className = 'help is-info';
        this.$data.usernameMessage = 'Username must be 8-120 characters long, must not contain any spaces, and must contain at least 1 lowercase letter, 1 uppercase letter, and 1 number.';
      } else if (this.$data.username == '') {
        document.getElementById('username').className = 'input';
        document.getElementById('usernameControl').className = 'help';
        this.$data.usernameMessage = '';
      } else {
        document.getElementById('username').className = 'input is-success';
        document.getElementById('usernameControl').className = 'help';
        this.$data.usernameMessage = '';
      }
    },
    /**
     * @description
     * validates the email of a user as defined by the constraint of the 
     * email regular expression
     * regex: EMAIL_REGEX
     */
    validateEmail () {
      if (!this.$data.EMAIL_REGEX.test(this.$data.email) && this.$data.email != '') {
        document.getElementById('email').className = 'input';
        document.getElementById('emailControl').className = 'help is-info';
        this.$data.emailMessage = 'Email is not a valid email.';
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
     * validates the password of a user as defined by the constraint of the 
     * password regular expression
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
     * validates if the conifrmed password matches the inputted password
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
     * validates the address of a user as defined by the constraint of the 
     * address regular expression
     * regex: ADDRESS_REGEX
     */
    validateAddress () {
      if (!this.$data.ADDRESS_REGEX.test(this.$data.address) && this.$data.address != '') {
        document.getElementById('address').className = 'input';
        document.getElementById('addressControl').className = 'help is-info';
        this.$data.addressMessage = 'The address you entered contains invalid characters.';
      } else if (this.$data.address == '') {
        document.getElementById('address').className = 'input';
        document.getElementById('addressControl').className = 'help';
        this.$data.addressMessage = '';
      } else {
        document.getElementById('address').className = 'input is-success';
        document.getElementById('addressControl').className = 'help';
        this.$data.addressMessage = '';
      }
    },
    /**
     * @description
     * validates the city of a user as defined by the constraint of the 
     * city regular expression
     * regex: CITY_REGEX
     */
    validateCity () {
      if (!this.$data.CITY_REGEX.test(this.$data.city) && this.$data.city != '') {
        document.getElementById('city').className = 'input';
        document.getElementById('cityControl').className = 'help is-info';
        this.$data.cityMessage = 'The city you entered contains invalid characters.';
      } else if (this.$data.city == '') {
        document.getElementById('city').className = 'input';
        document.getElementById('cityControl').className = 'help';
        this.$data.cityMessage = '';
      } else {
        document.getElementById('city').className = 'input is-success';
        document.getElementById('cityControl').className = 'help';
        this.$data.cityMessage = '';
      }
    },
    /**
     * @description
     * validates the state of a user as defined by the constraint of the 
     * state regular expression
     * regex: STATE_REGEX
     */
    validateState () {
      if (!this.$data.STATE_REGEX.test(this.$data.state) && this.$data.state != '') {
        document.getElementById('state').className = 'input';
        document.getElementById('stateControl').className = 'help is-info';
        this.$data.stateMessage = 'State must be in abbreviated format (i.e. IA for Iowa).';
      } else if (this.$data.state == '') {
        document.getElementById('state').className = 'input';
        document.getElementById('stateControl').className = 'help';
        this.$data.stateMessage = '';
      } else {
        document.getElementById('state').className = 'input is-success';
        document.getElementById('stateControl').className = 'help';
        this.$data.stateMessage = '';
      }
    },
    /**
     * @description
     * validates the zip code of a user as defined by the constraint of the 
     * zip code regular expression
     * regex: ZIPCODE_REGEX
     */
    validateZipCode () {
      if (!this.$data.ZIPCODE_REGEX.test(this.$data.zipCode) && this.$data.zipCode != '') {
        document.getElementById('zipCode').className = 'input';
        document.getElementById('zipCodeControl').className = 'help is-info';
        this.$data.zipCodeMessage = 'ZIP Code must be a valid ZIP Code';
      } else if (this.$data.zipCode == '') {
        document.getElementById('zipCode').className = 'input';
        document.getElementById('zipCodeControl').className = 'help';
        this.$data.zipCodeMessage = '';
      } else {
        document.getElementById('zipCode').className = 'input is-success';
        document.getElementById('zipCodeControl').className = 'help';
        this.$data.zipCodeMessage = '';
      }
    },
    /**
     * @description
     * validates if all three answers have been provided
     */
    validateAnswers () {
      if (document.getElementById('answer1').value == '' && document.getElementById('answer2').value == '' && document.getElementById('answer3').value == '') {
        document.getElementById('answer1').className = 'input';
        document.getElementById('answer2').className = 'input';
        document.getElementById('answer3').className = 'input';
        document.getElementById('answersControl').className = 'help';
        this.$data.answersMessage = '';
      } else if (document.getElementById('answer1').value != '' && document.getElementById('answer2').value != '' && document.getElementById('answer3').value != '') {
        document.getElementById('answer1').className = 'input is-success';
        document.getElementById('answer2').className = 'input is-success';
        document.getElementById('answer3').className = 'input is-success';
        document.getElementById('answersControl').className = 'help';
        this.$data.answersMessage = '';
      } else {
        document.getElementById('answer1').className = 'input';
        document.getElementById('answer2').className = 'input';
        document.getElementById('answer3').className = 'input';
        document.getElementById('answersControl').className = 'help is-info';
        this.$data.answersMessage = 'Please provide answers to all questions.';
      }
    },
    /**
     * @description
     * validates if all information has been successfully filled and validated
     * @returns {boolean} true - If the form is valid
     * @returns {boolean} false - If the form is not valid
     */
    isValidForm () {
      if (document.getElementById('firstName').className == 'input is-success' &&
        document.getElementById('lastName').className == 'input is-success' &&
        document.getElementById('username').className == 'input is-success' &&
        document.getElementById('email').className == 'input is-success' &&
        document.getElementById('password').className == 'input is-success' &&
        document.getElementById('confirmPassword').className == 'input is-success' &&
        this.$data.questionIDs[0] != null &&
        document.getElementById('answer1').className == 'input is-success' &&
        this.$data.questionIDs[1] != null &&
        document.getElementById('answer2').className == 'input is-success' &&
        this.$data.questionIDs[2] != null &&
        document.getElementById('answer3').className == 'input is-success') {
        return true
      } else {
        return false
      }
    },
    // ************************* Togglers *************************
    /**
     * @description
     * toggles/activates and deactivates the agreement modal that contains
     * the site's terms and conditions
     */
    toggleModal () {
      this.$refs.modal.toggle()
    },
    /**
     * @description
     * toggles/activates and deactivates alert if password provided has been 
     * previously breached
     * @param {string} password - Password inputed by user
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
    /**
     * @description
     * toggles the checkbox of the form if clicked/selected
     */
    checkBox () {
      this.agreementIsChecked = !this.agreementIsChecked
    },
    // ************************* APIs *************************
    /**
     * @description
     * POST request to server to submit form to register a new user
     * @throws {Conflict} Throws exception if user already has an existing account
     * @throws {InternalServerError} Throws exception if request cannot be processed
     */
    submit () {
      if (!this.isValidForm()) { 
        alert('It seems either your form is incomplete or some of your inputs are invalid...') 
      } else if (!this.$data.agreementIsChecked) {
        alert('You must agree to our Terms and Conditions to continue...')
      } else {
        Axios({
          method: 'POST',
          url: this.$store.getters.getBaseAppUrl + 'Registration/SubmitRegistration',
          headers: this.$store.getters.getRequestHeaders,
          data: {
            'firstName': this.$data.firstName,
            'lastName': this.$data.lastName,
            'username': this.$data.username,
            'email': this.$data.email,
            'password': this.getPassword(),
            'address': this.$data.address,
            'city': this.$data.city,
            'state': this.$data.state,
            'zipCode': Number(this.$data.zipCode),
            'securityQuestions': [
              {
                'question': Number(this.$data.questionIDs[0]),
                'answer': this.getSecurityAnswer(1)
              },
              {
                'question': Number(this.$data.questionIDs[1]),
                'answer': this.getSecurityAnswer(2)
              },
              {
                'question': Number(this.$data.questionIDs[2]),
                'answer': this.getSecurityAnswer(3)
              }
            ]
          }
        })
          .then(response => {
            console.log(response)
            if (response.status === 200) {
              this.$router.push({
                name: 'Main',
                params: { isSuccess: true } 
              })
            }
          })
          .catch(error => {
            console.log(error.response)
            //this.$data.error = JSON.parse(error.response.data)

            // HTTP Status 409
            if (error.response.status === 409) {
              alert('Good news!  According to our records, you already have an account with us!')
            }

            // HTTP Status 500
            if (error.response.status === 500) {
              alert('We apologize.  We are unable to process your request at this time.')
            }
          })
      }
    },
    /**
     * @description
     * GET request to get security questions from database
     * @throws {InternalServerError} Throws exception if request cannot be processed
     */
    fetchSecurityQuestions () {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBaseAppUrl + 'Registration/GetSecurityQuestions',
        headers: this.$store.getters.getRequestHeaders
      })
        .then(response => {
          this.$data.questions = Shuffler.shuffleArray(JSON.parse(response.data))
          this.divideQuestions()
        })
        .catch(error => {
          console.log(error.response)

          // HTTP Status 503 - No questions in resource
          
          // HTTP Status 500
          if (error.response.status === 500) {
            alert('We apologize.  We are unable to process your request at this time.')
          }
        })
    },
    // ************************* Helpers *************************
    /**
     * @description
     * event helper to handle validation of confirm password and pwned password checker
     * on keyup
     */
    passwordEventHelper(password) {
      this.validateConfirmPassword()
      if (document.getElementById('password').className == 'input is-success' &&
        document.getElementById('confirmPassword').className == 'input is-success') {
        this.toggleAlert(password)
      }
    },
    /**
     * @description
     * divides security questions GET response from server into 3 groups to populate
     * form upon component creation
     */
    divideQuestions () {
      let partSize = this.$data.questions.length/3

      for (let i = 0; i < this.$data.questions.length; i+=partSize) {
        if (i == 0) {
          this.$data.questionSet1 = this.$data.questions.slice(i,i+partSize)
        } else if (i == partSize) {
          this.$data.questionSet2 = this.$data.questions.slice(i,i+partSize)
        } else if (i == partSize*2) {
          this.$data.questionSet3 = this.$data.questions.slice(i,i+partSize)
        }
      }
    }
  }
}
</script>

<style scoped>
.field-element {
  text-align: left;
}

.form-agreements {
  text-align: left;
}

.help {
  text-align: left;
}

.is-field-group:after {
  content: "\A";
  white-space: pre;
}

.is-field-group:before {
  content: "\A";
  white-space: pre;
}

.is-required:after {
  content: " *";
  color: red;
}

.is-table {
  width: 100%;
  display: table;
  table-layout: fixed;
}

.modal-content {
  padding-top: 100px;
}

.state {
  display: table-cell;
}

.warning {
  color: red;
  font-size: 12px;
}

.zip {
  display: table-cell;
}

button {
  width: 175px;
}
</style>
