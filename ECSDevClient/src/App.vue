<template>
  <div id="app">
    <admin-layout v-if="currentRole === 'Admin'"/>
    <scholar-layout v-else-if="currentRole === 'Scholar'"/>
    <default-layout v-else/>
    <router-view/>
  </div>
</template>

<script>
import Bulma from 'bulma'
// eslint-disable-next-line
import Vue from 'vue'
import DefaultLayout from './layouts/Default'
import AdminLayout from './layouts/Admin'
import ScholarLayout from './layouts/Scholar'

export default {
  name: 'App',
  components: {
    Bulma,
    DefaultLayout,
    AdminLayout,
    ScholarLayout
  },
  data () {
    return {
      authorizationRequired: ['/Home', '/LinkedIn', '/account', '/sweepstakeadmin', '/account-admin', '/sweepstake'],
      currentRole: '',
      adminAuthorizationRequired: ['/account-admin', '/sweepstakeadmin', '/LinkedIn'],
      scholarAuthorizedRequired: ['/sweepstake']
    }
  },
  methods: {
    checkCurrentLogin () {
      for (var path in this.authorizationRequired) {
        if (!this.$store.getters.isAuth && this.$route.path === this.authorizationRequired[path]) {
          this.$router.push('/?redirect=' + this.$route.path)
        }
      }
    },
    checkAdminLogin () {
      for (var path in this.adminAuthorizationRequired) {
        if (!this.$store.getters.isAuth && this.$store.getters.getRole === 'Admin' && this.$route.path === this.adminAuthorizationRequired[path]) {
          this.$router.push('/?redirect=' + this.$route.path)
        }
      }
    },
    checkScholarLogin () {
      for (var path in this.adminAuthorizationRequired) {
        if (this.$store.getters.getRole === 'Scholar' && this.$route.path === this.adminAuthorizationRequired[path]) {
          this.$router.push('/?redirect=' + this.$route.path)
        }
      }
    },
    checkCurrentRole () {
      this.currentRole = this.$store.getters.getRole
    }
  },
  // end of methods
  created () {
    if (this.currentRole === 'Scholar') {
      this.checkScholarLogin()
    } else if (this.currentRole === 'Admin') {
      this.checkAdminLogin()
    } else {
      this.checkCurrentLogin()
      this.checkCurrentRole()
    }
  },
  updated () {
    if (this.$store.getters.getRole === 'Scholar') {
      this.checkScholarLogin()
      this.checkCurrentRole()
    } else if (this.$store.getters.getRole === 'Admin') {
      this.checkAdminLogin()
      this.checkCurrentRole()
    } else {
      this.checkCurrentLogin()
      this.checkCurrentRole()
    }
    // this.checkCurrentLogin()
    // this.checkCurrentRole()
  }
}
</script>
<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #000000;
  margin-top: 10px;
}
h1 {
  font-family: "Days One";
  font-size: 24px;
  font-style: normal;
  font-variant: normal;
  font-weight: 500;
  line-height: 26.4px;
}

.registration-button {
  background-color: #209cee;
  padding: 15px 35px;
  color: white;
  font-size: 15px;
}
</style>
