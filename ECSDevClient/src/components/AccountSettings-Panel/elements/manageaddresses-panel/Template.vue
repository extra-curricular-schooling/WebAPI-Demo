<template>
  <div>
    <address-panel/>
    <div class="box">
      <button v-on:click="currentAddressId = -1;toggleView();" class="button is-link is-outlined">Add new address</button>
    </div>
    <div v-for="address in addresses" :key="address.ZipCodeId" class="box" ref="addresses">
      <span>
        <span class="icon">
          <i class="fas fa-home"></i>
        </span>
        <div>
          {{address.Address}}
        </div>
        <div>
          {{address.City}}, {{address.State}}, {{address.ZipCode}}
        </div>
      </span>
      <div>
        <button v-on:click="currentAddressId = address.ZipCodeId;toggleView();" class="button is-success is-outlined">Update</button>
        <button v-if="addresses.length > 1" class="button">Delete</button>
      </div>
    </div>
  </div>
</template>

<script>
import Axios from 'axios'
import AddressPanel from './elements/address-panel/Template'
import EventBus from '../../../../assets/js/EventBus'

export default {
  name: 'ManageAddresses',
  components: {
    AddressPanel
  },
  data () {
    return {
      addresses: [],
      currentAddressId: '',
      failedToLoadAddresses: false
    }
  },
  created () {
    Axios({
      method: 'GET',
      url: this.$store.getters.getBaseAppUrl + 'Account/GetUserInfo',
      headers: this.$store.getters.getRequestHeaders
    })
      .then((response) => {
        this.addresses = response.data.zipLocations
      })
      .catch(() => {
        this.failedToLoadAddresses = true
      })
  },
  methods: {
    toggleView: function () {
      if (this.currentAddressId !== -1) {
        var address
        for (var index in this.addresses) {
          if (this.addresses[index].ZipCodeId === this.currentAddressId) {
            address = this.addresses[index]
            break
          }
        }
        if (address !== null) {
          this.$store.dispatch('updateZipCodeId', this.currentAddressId)
          this.$store.dispatch('updateAddress', address.Address)
          this.$store.dispatch('updateCity', address.City)
          this.$store.dispatch('updateState', address.State)
          this.$store.dispatch('updateZipCode', address.ZipCode)
          EventBus.$emit('AddressToggle')
        } else {
          console.log(this.currentAddressId)
        }
      } else {
        this.$store.dispatch('updateZipCodeId', -1)
        this.$store.dispatch('updateAddress', '')
        this.$store.dispatch('updateCity', '')
        this.$store.dispatch('updateState', '')
        this.$store.dispatch('updateZipCode', '')
        EventBus.$emit('AddressToggle')
      }
    }
  }
}
</script>
