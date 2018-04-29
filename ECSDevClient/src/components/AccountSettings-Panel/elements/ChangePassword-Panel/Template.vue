<template>
  <div class="card" style="border-radius:5px;">
    <header class="card-header">
      <p class="card-header-title">
        Change Current Password
      </p>
    </header>
    <div class="card-content">
      <label class="label" style="text-align:left;">Current Password</label>
      <input id="password" v-model="currentPassword" @keyup="validatePassword" class="input" type="password" autocomplete="password" placeholder="Current Password" required>
      <p id="passwordControl" class="help">{{ passwordMessage }}</p>

      <label class="label" style="text-align:left;">Confirm Current Password</label>
      <input id="confirmPassword" v-model="confirmCurrentPassword" @keyup="validateConfirmPassword" class="input" type="password" placeholder="Confirm Current Password" required>
      <p id="confirmPasswordControl" class="help">{{ confirmPasswordMessage }}</p>

      <label class="label" style="text-align:left;">New Password</label>
      <input id="newPassword" v-model="newPassword" @keyup="validateNewPassword" class="input" type="password" placeholder="New Password" required>
      <p id="newPasswordControl" class="help">{{ newPasswordMessage }}</p>

      <label class="label" style="text-align:left;">Confirm New Password</label>
      <input id="newConfirmPassword" v-model="confirmNewPassword" @keyup="validateNewConfirmPassword" class="input" type="password" placeholder="Confirm New Password" required>
      <p id="newConfirmPasswordControl" class="help">{{ newConfirmPasswordMessage }}</p>
    </div>
    <footer class="card-footer">
      <a v-if="validEntries" v-on:click="checkForPwnedPassword" class="card-footer-item">Change Password</a>
    </footer>
  </div>
</template>

<script>
import Axios from 'axios'
import EventBus from '../../../../assets/js/EventBus'
import PwnedHasher from '@/assets/js/pwnedChecker'
var crypto = require('crypto-js')

export default {
  name: 'ChangePasswordPanel',
  data () {
    return {
      PASSWORD_REGEX: this.$store.getters.getPasswordRegex,
      currentPassword: '',
      confirmCurrentPassword: '',
      newPassword: '',
      confirmNewPassword: '',
      passwordMessage: '',
      confirmPasswordMessage: '',
      newPasswordMessage: '',
      newConfirmPasswordMessage: '',
      showWarning: 0
    }
  },
  computed: {
    validEntries: function () {
      if (this.validPassword && this.validConfirmPassword && this.validNewPassword && this.validConfirmNewPassword) {
        return true
      } else {
        return false
      }
    },
    validPassword: function () {
      if (this.PASSWORD_REGEX.test(this.currentPassword) && this.currentPassword !== '') {
        return true
      } else {
        return false
      }
    },
    validConfirmPassword: function () {
      if (this.PASSWORD_REGEX.test(this.confirmCurrentPassword) && this.confirmCurrentPassword !== '' && this.currentPassword === this.confirmCurrentPassword) {
        return true
      } else {
        return false
      }
    },
    validNewPassword: function () {
      if (this.PASSWORD_REGEX.test(this.newPassword) && this.newPassword !== '' && this.currentPassword !== this.newPassword) {
        return true
      } else {
        return false
      }
    },
    validConfirmNewPassword: function () {
      if (this.PASSWORD_REGEX.test(this.confirmNewPassword) && this.confirmNewPassword !== '' && this.newPassword === this.confirmNewPassword) {
        return true
      } else {
        return false
      }
    }
  },
  methods: {
    checkForPwnedPassword: function () {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBasePwnedUrl + PwnedHasher.getHashedPrefix(this.newPassword)
      })
        .then((response) => {
          var hash = crypto.SHA1(this.newPassword).toString()
          var suffix = hash.substring(5, hash.length).toUpperCase()
          if (response.data.includes(suffix)) {
            var receivedHashes = response.data.substring(response.data.indexOf(suffix), response.data.length)
            var receivedHash = receivedHashes.substring(0, receivedHashes.indexOf(':'))
            console.log(receivedHash)
            var occurrences = receivedHashes.substring(receivedHashes.indexOf(':') + 1, receivedHashes.indexOf('\n'))
            console.log(occurrences)
            if (receivedHash === suffix && occurrences > 99) {
              this.$store.dispatch('updateSettingsNotificationMessage', 'The password you are attempting to use has been known to have been involved in considerable amount of data breaches! Regretably, your password request has been denied. Please consider another password, thank you for your understanding.')
              EventBus.$emit('showSettingsNotification')
            } else if (receivedHash === suffix && occurrences >= 1 && this.showWarning === 0) {
              this.$store.dispatch('updateSettingsNotificationMessage', 'The password you are attempting to use has been known to have been involved in several data breaches, please consider using another password. If you are adamant on using this password, press change password once more.')
              EventBus.$emit('showSettingsNotification')
              this.showWarning = 1
            } else {
              this.requestPasswordChange()
            }
          } else {
            this.requestPasswordChange()
          }
        })
        .catch((error) => {
          this.$store.dispatch('updateSettingsNotificationMessage', 'Password service is currently experiencing issues, please try again later!')
          EventBus.$emit('showSettingsNotification')
          console.log(error)
        })
    },
    requestPasswordChange: function () {
      Axios({
        method: 'POST',
        url: this.$store.getters.getBaseAppUrl + 'Account/ChangePassword/',
        headers: this.$store.getters.getRequestHeaders,
        data: {
          Username: this.$store.getters.getUsername,
          Password: this.currentPassword,
          NewPassword: this.newPassword
        }
      })
        .then((response) => {
          this.$store.dispatch('updateSettingsNotificationMessage', 'Successfully changed password!')
          this.currentPassword = ''
          this.newPassword = ''
          this.confirmCurrentPassword = ''
          this.confirmNewPassword = ''
          EventBus.$emit('showSettingsNotification')
        })
        .catch((error) => {
          this.$store.dispatch('updateSettingsNotificationMessage', 'Incorrect password!')
          EventBus.$emit('showSettingsNotification')
          console.log(error)
        })
    },
    validatePassword () {
      if (!this.$data.PASSWORD_REGEX.test(document.getElementById('password').value) && document.getElementById('password').value !== '') {
        document.getElementById('password').className = 'input'
        document.getElementById('passwordControl').className = 'help is-info'
        this.$data.passwordMessage = 'Password must be 8-64 characters long, must not contain any spaces, and must contain at least 1 lowercase letter, 1 uppercase letter, 1 number, and 1 special character.'
      } else if (document.getElementById('password').value === '') {
        document.getElementById('password').className = 'input'
        document.getElementById('passwordControl').className = 'help'
        this.$data.passwordMessage = ''
      } else {
        document.getElementById('password').className = 'input is-success'
        document.getElementById('passwordControl').className = 'help'
        this.$data.passwordMessage = ''
      }
    },
    validateConfirmPassword () {
      if (document.getElementById('password').value !== document.getElementById('confirmPassword').value && document.getElementById('confirmPassword').value !== '') {
        document.getElementById('confirmPassword').className = 'input'
        document.getElementById('confirmPasswordControl').className = 'help is-info'
        this.$data.confirmPasswordMessage = 'Retype Password'
      } else if (document.getElementById('confirmPassword').value === '') {
        document.getElementById('confirmPassword').className = 'input'
        document.getElementById('confirmPasswordControl').className = 'help'
        this.$data.confirmPasswordMessage = ''
      } else if (document.getElementById('password').value === document.getElementById('confirmPassword').value) {
        document.getElementById('confirmPassword').className = 'input is-success'
        document.getElementById('confirmPasswordControl').className = 'help'
        this.$data.confirmPasswordMessage = ''
      }
    },
    validateNewPassword () {
      if (!this.$data.PASSWORD_REGEX.test(document.getElementById('newPassword').value) && document.getElementById('newPassword').value !== '') {
        document.getElementById('newPassword').className = 'input'
        document.getElementById('newPasswordControl').className = 'help is-info'
        this.$data.newPasswordMessage = 'Password must be 8-64 characters long, must not contain any spaces, and must contain at least 1 lowercase letter, 1 uppercase letter, 1 number, and 1 special character.'
      } else if (document.getElementById('newPassword').value === '') {
        document.getElementById('newPassword').className = 'input'
        document.getElementById('newPasswordControl').className = 'help'
        this.$data.newPasswordMessage = ''
      } else if (this.currentPassword === this.newPassword) {
        this.$data.newPasswordMessage = 'The new password must be different than your current password!'
      } else {
        document.getElementById('newPassword').className = 'input is-success'
        document.getElementById('newPasswordControl').className = 'help'
        this.$data.newPasswordMessage = ''
      }
    },
    validateNewConfirmPassword () {
      if (document.getElementById('newPassword').value !== document.getElementById('newConfirmPassword').value && document.getElementById('newConfirmPassword').value !== '') {
        document.getElementById('newConfirmPassword').className = 'input'
        document.getElementById('newConfirmPasswordControl').className = 'help is-info'
        this.$data.newConfirmPasswordMessage = 'Retype Password'
      } else if (document.getElementById('newConfirmPassword').value === '') {
        document.getElementById('newConfirmPassword').className = 'input'
        document.getElementById('newConfirmPasswordControl').className = 'help'
        this.$data.newConfirmPasswordMessage = ''
      } else if (document.getElementById('newPassword').value === document.getElementById('newConfirmPassword').value) {
        document.getElementById('newConfirmPassword').className = 'input is-success'
        document.getElementById('newConfirmPasswordControl').className = 'help'
        this.$data.newConfirmPasswordMessage = ''
      }
    }
  }
}
</script>
