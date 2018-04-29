<template>
  <div style="height: 650px;">
    <account-settings-panel style="position:relative; top:10%;"/>
  </div>
</template>

<script>
import AccountSettingsPanel from '../components/AccountSettings-Panel/Template'

export default {
  name: 'Account',
  components: {
    AccountSettingsPanel
  }
}
</script>
