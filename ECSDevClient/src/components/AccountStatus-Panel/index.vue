<template>
  <div>
    <component v-bind:is="currentComponent"/>
    <error-modal/>
  </div>
</template>

<script>
import AdminAccountStatusPanel from './elements/AdminAccountStatus-Panel/index'
import ErrorModal from '../../components/Error-Modal/index'
import EventBus from '../../assets/js/EventBus'
import SelectUserPanel from './elements/SelectUser-AccountStatus/index'

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
      requestUserInfoUri: this.$store.getters.getRequestUserInfoUri,
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
