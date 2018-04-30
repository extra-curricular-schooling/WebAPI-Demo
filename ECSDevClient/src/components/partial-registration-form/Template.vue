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

      <div class="field email-address">
        <label class="label field-element is-required">Email</label>
        <div class="control has-icons-left has-icons-right">
          <input v-model="email" id="email" class="input" type="email" @keyup="validateEmail" autocomplete="email" placeholder="Email" required>
          <span class="icon is-small is-left">
            <i class="fas fa-envelope"></i>
          </span>
        </div>
        <p id="emailControl" class="help">{{ emailMessage }}</p>
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
          <div class="control left-cell">
            <span class="select select-state">
              <select class="select-state" v-model="state">
                  <option disabled value="">--select--</option>
                  <option v-for="s in states" v-bind:key="s"> {{ s }} </option>
              </select>
            </span>
          </div>
        </div>
        <div class="field mailing-address zip">
          <p class="control right-cell">
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
          <span class="select questions">
            <select class="pull-down" @change="getSelectionID(0, question1)" v-model="question1">
              <option disabled value="">--select--</option>
              <option v-for="question in questionSet1" v-bind:key="question.SecurityQuestionID"> {{ question.SecQuestion }} </option>
            </select>
          </span>
          <span v-if="!loadingIsDisabled" class="icon is-medium">
            <i id="loadingQuestions" class="fas fa-spinner fa-pulse"></i>
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
          <span class="select questions">
            <select class="pull-down" @change="getSelectionID(1, question2)" v-model="question2">
              <option disabled value="">--select--</option>
              <option v-for="question in questionSet2" v-bind:key="question.SecurityQuestionID"> {{ question.SecQuestion }} </option>
            </select>
          </span>
          <span v-if="!loadingIsDisabled" class="icon is-medium">
            <i id="loadingQuestions" class="fas fa-spinner fa-pulse"></i>
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
          <span class="select questions">
            <select class="pull-down" @change="getSelectionID(2, question3)" v-model="question3">
              <option disabled value="">--select--</option>
              <option v-for="question in questionSet3" v-bind:key="question.SecurityQuestionID"> {{ question.SecQuestion }} </option>
            </select>
          </span>
          <span v-if="!loadingIsDisabled" class="icon is-medium">
            <i id="loadingQuestions" class="fas fa-spinner fa-pulse"></i>
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
      <!-- <label class="checkbox">
        <input type="checkbox" checked="checked">
        Remember me
      </label><br> -->
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
import Shuffler from '@/assets/js/arrayShuffler'
import Swal from 'sweetalert2'

export default {
  name: 'RegistrationForm',
  components: {
    'agreement-modal': AgreementModal
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
      states: this.$store.getters.getUnitedStatesAbbrevs,

      // Event Properties
      agreementIsChecked: false,
      loadingIsDisabled: false,

      // Request Data
      firstName: '',
      lastName: '',
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
      emailMessage: '',
      addressMessage: '',
      cityMessage: '',
      zipCodeMessage: '',
      answersMessage: '',

      // Regular Expressions
      NAME_REGEX: this.$store.getters.getNameRegex,
      EMAIL_REGEX: this.$store.getters.getEmailRegex,
      ADDRESS_REGEX: this.$store.getters.getAddressRegex,
      CITY_REGEX: this.$store.getters.getCityRegex,
      ZIPCODE_REGEX: this.$store.getters.getZipCodeRegex,
    }
  },
  created () {
    // Ensure that the Axios authorization header is empty for anonymous access.
    this.$store.dispatch('updateToken', '')

    // Send Request to Server for updated security questions.
    this.fetchSecurityQuestions()
  },
  methods: {
    // ************************* Getters *************************
    /**
     * Gets a particular security answer
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
     * Gets ID of a selected security question
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
     * Validates the first name of a user as defined by the constraint of the 
     * name regular expression
     * @constant {regex} NAME_REGEX
     */
    validateFirstName () {
      if (!this.$data.NAME_REGEX.test(this.$data.firstName) && this.$data.firstName != '') {
        document.getElementById('firstName').className = 'input';
        document.getElementById('firstNameControl').className = 'help is-info';
        this.$data.firstNameMessage = this.$store.getters.getNameMessage;
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
     * Validates the last name of a user as defined by the constraint of the 
     * name regular expression.
     * @constant {regex} NAME_REGEX
     */
    validateLastName () {
      if (!this.$data.NAME_REGEX.test(this.$data.lastName) && this.$data.lastName != '') {
        document.getElementById('lastName').className = 'input';
        document.getElementById('lastNameControl').className = 'help is-info';
        this.$data.lastNameMessage = this.$store.getters.getNameMessage;
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
     * Validates the email of a user as defined by the constraint of the 
     * email regular expression.
     * @constant {regex} EMAIL_REGEX
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
     * Validates the address of a user as defined by the constraint of the 
     * address regular expression
     * @constant {regex} ADDRESS_REGEX
     */
    validateAddress () {
      if (!this.$data.ADDRESS_REGEX.test(this.$data.address) && this.$data.address != '') {
        document.getElementById('address').className = 'input';
        document.getElementById('addressControl').className = 'help is-info';
        this.$data.addressMessage = this.$store.getters.getAddressMessage;
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
     * Validates the city of a user as defined by the constraint of the 
     * city regular expression
     * @constant {regex} CITY_REGEX
     */
    validateCity () {
      if (!this.$data.CITY_REGEX.test(this.$data.city) && this.$data.city != '') {
        document.getElementById('city').className = 'input';
        document.getElementById('cityControl').className = 'help is-info';
        this.$data.cityMessage = this.$store.getters.getCityMessage;
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
     * Validates the zip code of a user as defined by the constraint of the 
     * zip code regular expression.
     * @param {regex} ZIPCODE_REGEX
     */
    validateZipCode () {
      if (!this.$data.ZIPCODE_REGEX.test(this.$data.zipCode) && this.$data.zipCode != '') {
        document.getElementById('zipCode').className = 'input';
        document.getElementById('zipCodeControl').className = 'help is-info';
        this.$data.zipCodeMessage = this.$store.getters.getZipCodeMessage;
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
     * Validates if all three security answers have been provided.
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
        this.$data.answersMessage = this.$store.getters.getAnswerMessage;
      }
    },
    /**
     * Validates if all information has been successfully filled and validated
     * @returns {boolean} true - If the form is valid
     * @returns {boolean} false - If the form is not valid
     */
    isValidForm () {
      if (document.getElementById('firstName').className == 'input is-success' &&
        document.getElementById('lastName').className == 'input is-success' &&
        document.getElementById('email').className == 'input is-success' &&
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
     * Toggles/activates and deactivates the agreement modal that contains
     * the site's terms and conditions
     */
    toggleModal () {
      this.$refs.modal.toggle()
    },
    /**
     * Toggles the checkbox of the form if clicked/selected
     */
    checkBox () {
      this.agreementIsChecked = !this.agreementIsChecked
    },
    // ************************* APIs *************************
    /**
     * POST request to server to submit form to register a new user
     */
    submit () {
      // Check if form is not valid.
      if (!this.isValidForm()) {
        Swal({
          type: 'warning',
          title: 'Uh-Oh',
          html: 'It seems either your form is <b>incomplete</b> or some of your inputs are <b>invalid</b>...'})
      } // Check if user has agreed to terms and conditions.
      else if (!this.$data.agreementIsChecked) {
        Swal({
          type: 'warning',
          title: 'Uh-Oh',
          html: 'You must <b>read and agree</b> to our Terms and Conditions to continue...'})
      } // Form is Valid.
      else {
        Axios({
          method: 'POST',
          url: this.$store.getters.getBaseAppUrl + 'Registration/SubmitPartialRegistration',
          headers: this.$store.getters.getRequestHeaders,
          data: {
            'firstName': this.$data.firstName,
            'lastName': this.$data.lastName,
            'username': this.$store.getters.getUsername,
            'email': this.$data.email,
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
            this.$store.dispatch('signIn', response.data)
            this.$store.dispatch('updateToken', response.data)
            this.$router.push({
              name: 'Home',
            })
          })
          .catch(error => {
            if (error.response) {
              // General client errors.
              if (error.response.status === 400) {
                Swal({
                  title: 'Bad News',
                  text: 'According to our records, you are not in our database',
                  footer: '<a href="/">Take me to the main page</a>'})
              }
              // Duplicate entry in account or user data tables.
              if (error.response.status === 409) {
                this.$store.dispatch('signOut')
                Swal({
                  title: 'Good News',
                  text: 'According to our records, you already have an account with us!',
                  footer: '<a href="/">Take me to the home page</a>'})
              }
            } else if (error.request) {
              Swal({
                type: 'error',
                title: 'We Apologize',
                text: 'We are unable to process your request at this time.'})
            } else {
              // General Error handling for promise.
            }
            console.log('Error: ', error.config)
          })
        }
    },
    /**
     * GET request to get security questions from database.
     */
    fetchSecurityQuestions () {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBaseAppUrl + 'Registration/GetSecurityQuestions',
        headers: this.$store.getters.getRequestHeaders,
        timeout: this.$store.getters.getFormTimeout
      })
        .then(response => {
          this.$data.questions = Shuffler.shuffleArray(response.data) 
          this.divideQuestions()
          this.loadingIsDisabled = true
        })
        .catch(error => {
          if (error.response) {
            // HTTP Status 503
            if (error.response.status === 503) {
              Swal({
                type: 'error',
                title: 'We Apologize',
                text: 'The resource your are requesting is not available.'})
            }
            // HTTP Status 500
            if (error.response.status === 500) {
              Swal({
                type: 'error',
                title: 'We Apologize',
                text: 'We are unable to process your request at this time.'})
            }
          } else if (error.request) {
            Swal({
              type: 'error',
              title: 'We Apologize',
              text: 'We are unable to process your request at this time.'})
          } else {
            // General Error handling for promise.
          }
          // Show the configuration.
          console.log(error.config)
        })
    },
    // ************************* Helpers *************************
    /**
     * Divides security questions GET response from server into 3 groups to populate
     * form upon component creation
     */
    divideQuestions () {
      let partSize = this.$data.questions.length/3 
 
      for (let i = 0; i < this.$data.questions.length; i+=partSize) { 
        if (i === 0) { 
          this.$data.questionSet1 = this.$data.questions.slice(i,i+partSize) 
        } else if (i === partSize) { 
          this.$data.questionSet2 = this.$data.questions.slice(i,i+partSize) 
        } else if (i === partSize*2) { 
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
  table-layout: unset;
}

.left-cell {
  padding-right: 10px;
}

.modal-content {
  padding-top: 100px;
}

.right-cell {
  padding-top: 0px;
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

form {
  background-color: white;
  padding-top: 15px;
  padding-left: 50px;
  padding-right: 50px;
  padding-bottom: 15px;
}

select.pull-down {
  width: 400px;
}

select.select-state {
  width: 100%;
}

span.select-state {
  width: 100%;
}
</style>
