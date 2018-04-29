<template>
  <div class="card" style="border-radius:5px;">
    <header class="card-header">
      <p class="card-header-title">
        Change User Information
      </p>
    </header>
    <div class="card-content">
      <div>
        <label class="label field-element is-required">First Name</label>
        <div class="control">
          <input v-model="firstName" id="firstName" class="input" type="text" autocomplete="given-name" @keyup="validateFirstName" placeholder="First Name" required>
        </div>
        <p id="firstNameControl" class="help">{{ firstNameMessage }}</p>
      </div>
     <div>
        <label class="label field-element is-required">Last Name</label>
        <div class="control">
          <input v-model="lastName" id="lastName" class="input" type="text" autocomplete="family-name" @keyup="validateLastName" placeholder="Last Name" required>
        </div>
        <p id="lastNameControl" class="help">{{ lastNameMessage }}</p>
     </div>
    </div>
    <footer class="card-footer">
      <a v-if="isValidForm" v-on:click="postUserInfo" class="card-footer-item">Change User Info</a>
    </footer>
  </div>
</template>

<script>
/* eslint-disable */
import Axios from 'axios'
import EventBus from '../../../../assets/js/EventBus'

export default {
  name: 'EditInfo',
  data () {
    return {
      firstName: '',
      lastName: '',
      originalFirst: '',
      originalLast: '',
      firstNameMessage: '',
      lastNameMessage: '',
      NAME_REGEX: this.$store.getters.getNameRegex
    }
  },
  created () {
    this.fetchUserInfo()
  },
  computed: {
    isValidFirstName: function () {
      if (!this.NAME_REGEX.test(this.firstName) && this.firstName !== '') {
        return false
      } else if (this.firstName === '') {
        return false
      } else {
        return true
      }
    },
    isValidLastName: function () {
      if (!this.NAME_REGEX.test(this.lastName) && this.lastName !== '') {
        return false
      } else if (this.lastName === '') {
        return false
      } else {
        return true
      }
    },
    isValidForm: function () {
      if (this.isValidFirstName && this.isValidLastName && (this.firstName !== this.originalFirst || this.lastName !== this.originalLast)) {
        return true
      } else {
        return false
      }
    }
  },
  methods: {
    fetchUserInfo: function () {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBaseAppUrl + 'Account/GetUserInfo',
        headers: this.$store.getters.getRequestHeaders
      })
        .then((response) => {
          this.firstName = response.data.FirstName
          this.originalFirst = response.data.FirstName
          this.lastName = response.data.LastName
          this.originalLast = response.data.LastName
        })
    },
    postUserInfo: function () {
      Axios({
        method: 'POST',
        url: this.$store.getters.getBaseAppUrl + 'Account/PostUserInfo',
        headers: this.$store.getters.getRequestHeaders,
        data: {
          'FirstName': this.firstName,
          'LastName': this.lastName
        }
      })
        .then((response) => {
          this.$store.dispatch('updateSettingsNotificationMessage', 'Successfully changed user info!')
          this.firstName = ''
          this.lastName = ''
          EventBus.$emit('showSettingsNotification')
        })
        .catch(() => {
          this.$store.dispatch('updateSettingsNotificationMessage', 'It seems the server did not like your entries. Please try again later!')
          EventBus.$emit('showSettingsNotification')
        })
    },
    validateFirstName () {
      if (!this.$data.NAME_REGEX.test(this.$data.firstName) && this.$data.firstName != '') {
        document.getElementById('firstName').className = 'input';
        document.getElementById('firstNameControl').className = 'help is-info';
        this.$data.firstNameMessage = 'Sorry, the name you entered either contains invalid characters or is too long.';
      } else if (this.$data.firstName == '') {
        document.getElementById('firstName').className = 'input';
        document.getElementById('firstNameControl').className = 'help';
        this.$data.firstNameMessage = '';
      } else if (this.firstName === this.originalFirst) {
        this.$data.firstNameMessage = 'New name must be different from the name on record in order to make changes.';
      } else {
        document.getElementById('firstName').className = 'input is-success';
        document.getElementById('firstNameControl').className = 'help';
        this.$data.firstNameMessage = '';
      }
    },
    validateLastName () {
      if (!this.$data.NAME_REGEX.test(this.$data.lastName) && this.$data.lastName != '') {
        document.getElementById('lastName').className = 'input';
        document.getElementById('lastNameControl').className = 'help is-info';
        this.$data.lastNameMessage = 'Sorry, the name you entered either contains invalid characters or is too long.';
      } else if (this.$data.lastName == '') {
        document.getElementById('lastName').className = 'input';
        document.getElementById('lastNameControl').className = 'help';
        this.$data.lastNameMessage = '';
      } else if (this.lastName === this.originalLast) {
        this.$data.firstNameMessage = 'New last name must be different from the last name on record in order to make changes.';
      } else {
        document.getElementById('lastName').className = 'input is-success';
        document.getElementById('lastNameControl').className = 'help';
        this.$data.lastNameMessage = '';
      }
    }
  }
}
</script>
