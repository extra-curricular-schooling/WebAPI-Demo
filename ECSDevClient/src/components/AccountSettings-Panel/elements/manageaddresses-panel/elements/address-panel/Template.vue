<template>
  <div class="modal" v-bind:class="{ 'is-active' : isActive }">
    <div v-on:click="isActive = false" class="modal-background"></div>
    <div class="modal-card">
      <header class="modal-card-head">
        <p class="modal-card-title">{{modalTitle}}</p>
        <button v-on:click="isActive = false" class="delete" aria-label="close"></button>
      </header>
      <section v-if="!fromSubmitted" class="modal-card-body">
        <!-- BEGIN optional fields for mailing address -->
        <div class="is-field-group">
          <div class="field mailing-address">
            <span class="icon">
              <i class="fas fa-home"></i>
            </span>
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
      </section>
      <section v-else class="modal-card-body">
        Success!
      </section>
      <footer class="modal-card-foot">
        <div v-if="!fromSubmitted">
          <button v-on:click="postAddress" class="button is-success is-outlined" :disabled="!isValidForm">Submit</button>
          <button v-on:click="isActive = false" class="button">Cancel</button>
        </div>
        <div v-else>
          <button v-on:click="isActive = false" class="button is-success is-outlined">Done</button>
        </div>
      </footer>
    </div>
  </div>
</template>

<script>
import Axios from 'axios'
import EventBus from '../../../../../../assets/js/EventBus'

export default {
  name: 'AddressPanel',
  created () {
    EventBus.$on('AddressToggle', () => {
      this.toggleView()
    })
  },
  data () {
    return {
      modalTitle: '',
      isActive: false,
      fromSubmitted: false,
      zipCodeId: this.$store.getters.getZipCodeId,
      states: this.$store.getters.getUnitedStatesAbbrevs,
      address: this.$store.getters.getAddress,
      city: this.$store.getters.getCity,
      state: this.$store.getters.getState,
      zipCode: this.$store.getters.getZipCode,
      addressMessage: '',
      cityMessage: '',
      zipCodeMessage: '',
      ADDRESS_REGEX: this.$store.getters.getAddressRegex,
      CITY_REGEX: this.$store.getters.getCityRegex,
      ZIPCODE_REGEX: this.$store.getters.getZipCodeRegex
    }
  },
  computed: {
    isValidAddress: function () {
      if (this.ADDRESS_REGEX.test(this.address) && this.address !== '') {
        return true
      } else {
        return false
      }
    },
    isValidCity: function () {
      if (this.CITY_REGEX.test(this.city) && this.city !== '') {
        return true
      } else {
        return false
      }
    },
    isValidZipCode: function () {
      if (this.ZIPCODE_REGEX.test(this.zipCode) && this.zipCode !== '') {
        return true
      } else {
        return false
      }
    },
    isValidState: function () {
      if (this.state !== '') {
        return true
      } else {
        return false
      }
    },
    isValidForm: function () {
      if (this.isValidAddress && this.isValidCity && this.isValidState && this.isValidZipCode) {
        return true
      } else {
        return false
      }
    }
  },
  methods: {
    toggleView: function () {
      this.zipCodeId = this.$store.getters.getZipCodeId
      this.address = this.$store.getters.getAddress
      this.city = this.$store.getters.getCity
      this.state = this.$store.getters.getState
      this.zipCode = this.$store.getters.getZipCode
      if (this.zipCodeId !== -1) {
        this.modalTitle = 'Edit Existing Address'
      } else {
        this.modalTitle = 'Add New Address'
      }
      this.isActive = true
    },
    postAddress: function () {
      Axios({
        method: 'POST',
        url: this.$store.getters.getBaseAppUrl + 'Account/PostUserAddress',
        headers: this.$store.getters.getRequestHeaders,
        data: {
          ZipCodeID: this.zipCodeId,
          Address: this.address,
          City: this.city,
          State: this.state,
          ZipCode: this.zipCode
        }
      })
        .then(() => {
          if (this.zipCodeId !== -1) {
            this.$store.dispatch('updateSettingsNotificationMessage', 'Successfully changed this address!')
          } else {
            this.$store.dispatch('updateSettingsNotificationMessage', 'Successfully added new address!')
          }
          EventBus.$emit('showSettingsNotification')
          this.fromSubmitted = true
        })
        .catch(() => {
          this.$store.dispatch('updateSettingsNotificationMessage', 'The server seems to not have reacted properly to your address, please try again later!')
          EventBus.$emit('showSettingsNotification')
        })
    },
    validateAddress () {
      if (!this.$data.ADDRESS_REGEX.test(this.$data.address) && this.$data.address !== '') {
        document.getElementById('address').className = 'input'
        document.getElementById('addressControl').className = 'help is-info'
        this.$data.addressMessage = 'The address you entered contains invalid characters.'
      } else if (this.$data.address === '') {
        document.getElementById('address').className = 'input'
        document.getElementById('addressControl').className = 'help'
        this.$data.addressMessage = ''
      } else {
        document.getElementById('address').className = 'input is-success'
        document.getElementById('addressControl').className = 'help'
        this.$data.addressMessage = ''
      }
    },
    validateCity () {
      if (!this.$data.CITY_REGEX.test(this.$data.city) && this.$data.city !== '') {
        document.getElementById('city').className = 'input'
        document.getElementById('cityControl').className = 'help is-info'
        this.$data.cityMessage = 'The city you entered contains invalid characters.'
      } else if (this.$data.city === '') {
        document.getElementById('city').className = 'input'
        document.getElementById('cityControl').className = 'help'
        this.$data.cityMessage = ''
      } else {
        document.getElementById('city').className = 'input is-success'
        document.getElementById('cityControl').className = 'help'
        this.$data.cityMessage = ''
      }
    },
    validateZipCode () {
      if (!this.$data.ZIPCODE_REGEX.test(this.$data.zipCode) && this.$data.zipCode !== '') {
        document.getElementById('zipCode').className = 'input'
        document.getElementById('zipCodeControl').className = 'help is-info'
        this.$data.zipCodeMessage = 'ZIP Code must be a valid ZIP Code'
      } else if (this.$data.zipCode === '') {
        document.getElementById('zipCode').className = 'input'
        document.getElementById('zipCodeControl').className = 'help'
        this.$data.zipCodeMessage = ''
      } else {
        document.getElementById('zipCode').className = 'input is-success'
        document.getElementById('zipCodeControl').className = 'help'
        this.$data.zipCodeMessage = ''
      }
    }
  }
}
</script>
