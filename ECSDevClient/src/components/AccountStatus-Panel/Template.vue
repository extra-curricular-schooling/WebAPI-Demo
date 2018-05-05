<template>
  <div>
    <component v-bind:is="currentComponent"/>
    <error-modal/>
  </div>
</template>

<script>
import AdminAccountStatusPanel from './elements/AdminAccountStatus-Panel/Template'
import ErrorModal from '../../components/error-modal/Template'
import EventBus from '@/assets/js/EventBus.js'
import SelectUserPanel from './elements/SelectUser-AccountStatus/Template'

export default {
  name: 'AccountStatusPanel',
  components: {
    AdminAccountStatusPanel,
    ErrorModal,
    SelectUserPanel
  },
  created () {
    EventBus.$on('ToggleAdminAccountStatusView', () => {
      this.toggleView()
    })
  },
  data () {
    return {
      requestHeaders: this.$store.getters.getRequestHeaders,
      requestUserInfoUri: this.$store.getters.getBaseAppUrl + this.$store.getters.getRequestUserInfoUri,
      username: '',
      currentComponent: 'select-user-panel'
    }
  },
  methods: {
    toggleView: function () {
      if (this.currentComponent === 'select-user-panel') {
        this.currentComponent = 'admin-account-status-panel'
      } else {
        this.currentComponent = 'select-user-panel'
      }
    }
  }
}
</script>
