<template>
  <!-- Main Registration Form -->
  <form class="registration-form" method="post">
    <p class="warning field-element">* indicates a required field</p>

    <!-- BEGIN required fields for basic information -->
    <div class="is-field-group">
      <div class="field first-name">
        <label class="label field-element is-required">First Name</label>
        <div class="control">
          <input v-model="firstName" id="firstName" class="input" type="text" autocomplete="given-name" placeholder="First Name" required>
        </div>
      </div>

      <div class="field last-name">
        <label class="label field-element is-required">Last Name</label>
        <div class="control">
          <input v-model="lastName" id="lastName" class="input" type="text" autocomplete="family-name" placeholder="Last Name" required>
        </div>
      </div>

      <div class="field username">
        <label class="label field-element is-required">Username</label>
        <div class="control has-icons-left has-icons-right">
          <input v-model="username" id="username" class="input" type="text" autocomplete="username" placeholder="Username" required>
          <span class="icon is-small is-left">
            <i class="fas fa-user"></i>
          </span>
          <span class="icon is-small is-right">
            <i class="fas fa-check"></i>
          </span>
        </div>
      </div>

      <div class="field email-address">
        <label class="label field-element is-required">Email</label>
        <div class="control has-icons-left has-icons-right">
          <input v-model="email" id="email" class="input" type="email" autocomplete="email" placeholder="Email" required>
          <span class="icon is-small is-left">
            <i class="fas fa-envelope"></i>
          </span>
          <span class="icon is-small is-right">
            <i class="fas fa-exclamation-triangle"></i>
          </span>
        </div>
      </div>

      <div class="field password">
        <label class="label field-element is-required">Password</label>
        <div class="control has-icons-left">
          <input id="password" class="input" type="password" autocomplete="new-password" placeholder="************" required>
          <span class="icon is-small is-left">
            <i class="fas fa-lock"></i>
          </span>
        </div>
      </div>

      <div class="field confirm-password">
        <label class="label field-element is-required">Confirm Password</label>
        <div class="control has-icons-left">
          <input id="confirmPassword" class="input" type="password" autocomplete="new-password" placeholder="************" required>
          <span class="icon is-small is-left">
            <i class="fas fa-lock"></i>
          </span>
        </div>
      </div>
    </div>
    <!-- END basic info fields -->

    <!-- BEGIN optional fields for mailing address -->
    <div class="is-field-group">
      <div class="field mailing-address">
        <label class="label field-element">Mailing Address</label>
        <div class="control">
          <input v-model="address" id="address" class="input" type="text" autocomplete="street-address" placeholder="Street Address">
        </div>
      </div>
      <div class="field mailing-address">
        <div class="control">
          <input v-model="city" id="city" class="input" type="text" autocomplete="address-line2" placeholder="City">
        </div>
      </div>
      <div class="field is-grouped mailing-adress">
        <p class="control">
          <input v-model="state" id="state" class="input" text="text" autocomplete="address-line2" placeholder="State">
          <!-- <span class="select">
            <select>
              <option selected>State</option>
            </select>
          </span> -->
        </p>
        <p class="control">
          <input v-model="zipCode" id="zipCode" class="input" type="number" autocomplete="postal-code" placeholder="Zip Code">
        </p>
      </div>
    </div>
    <!-- END mailing address fields -->

    <!-- BEGIN required security questions -->
    <div class="is-field-group">
      <div class="field security-questions">
        <label class="label field-element is-required">Security Questions</label>
        <div class="control">
          <input v-model="question1" class="input" type="number" placeholder="Question 1" required>
          <!-- <span class="select">
            <select>
              <option selected>--select--</option>
            </select>
          </span> -->
        </div>
      </div>
      <div class="field security-questions-answers">
        <div class="control">
          <input id="answer1" class="input" type="text" placeholder="Answer 1" required>
        </div>
      </div>

      <div class="field security-questions">
        <div class="control">
          <input v-model="question2" class="input" type="number" placeholder="Question 2" required>
          <!-- <span class="select">
            <select>
              <option selected>--select--</option>
            </select>
          </span> -->
        </div>
      </div>
      <div class="field security-questions-answers">
        <div class="control">
          <input id="answer2" class="input" type="text" placeholder="Answer 2" required>
        </div>
      </div>

      <div class="field security-questions">
        <div class="control">
          <input v-model="question3" class="input" type="number" placeholder="Question 1" required>
          <!-- <span class="select">
            <select>
              <option selected>--select--</option>
            </select>
          </span> -->
        </div>
      </div>
      <div class="field security-questions-answers">
        <div class="control">
          <input id="answer3" class="input" type="text" placeholder="Answer 3" required>
        </div>
      </div>
    </div>
    <!-- END security questions -->

    <div class="field form-agreements">
      <label class="checkbox">
        <input type="checkbox" checked="checked">
        Remember me
      </label><br>
      <label class="checkbox">
        <agreement-modal></agreement-modal>
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
        <!-- NOTE: Issues with properly checking if required fields have been entered -->
        <!-- <registration-alert v-on:click="submit"></registration-alert> -->
        <!-- <router-link to="/" tag="button" class="button is-primary submit-button" v-on:click="submit">
        Submit
        </router-link> -->
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
import axios from 'axios'
import agreementModal from '@/components/AgreementModal'
// import registrationAlert from '@/components/RegistrationAlert'

export default {
  name: 'RegistrationForm',
  components: {
    'agreement-modal': agreementModal,
    // 'registration-alert': registrationAlert
  },
  data () {
    return {
      // Primary Data
      firstName: '',
      lastName: '',
      username: '',
      email: '',
      address: '',
      city: '',
      state: '',
      zipCode: '',
      question1: '',
      question2: '',
      question3: ''

      // Validation Messages
    }
  },
  methods: {
    // Data Getters
    getPassword () {
      return document.getElementById('password').value;
    },
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
    submit () {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/Registration/SubmitRegistration',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true,
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
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
              'question': Number(this.$data.question1),
              'answer': this.getSecurityAnswer(1)
            },
            {
              'question': Number(this.$data.question2),
              'answer': this.getSecurityAnswer(2)
            },
            {
              'question': Number(this.$data.question3),
              'answer': this.getSecurityAnswer(3)
            }
          ]
        }
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    }
    /* fetchSecurityQuestions: () => {
      axios({
        method: 'GET',
        url: 'https://localhost:44313/registration/RequestSecurityQuestions'
      })
        .then(response => {
          this.security_qas = response.data
        })
        .catch(response => console.log(response))
    } */
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

.modal-content {
  padding-top: 100px;
}

.warning {
  color: red;
  font-size: 12px;
}

button {
  width: 175px;
}
</style>
