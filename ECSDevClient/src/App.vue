<template>
  <div id="app">
    <admin-layout v-if="currentRole === 'Admin'"/>
    <scholar-layout v-else-if="currentRole === 'Scholar'"/>
    <default-layout v-else/>
    <router-view/>
  </div>
</template>

<script>
import Axios from 'axios'
import Bulma from 'bulma'
// eslint-disable-next-line
import Vue from 'vue'
import DefaultLayout from './layouts/Default'
import AdminLayout from './layouts/Admin'
import ScholarLayout from './layouts/Scholar'
import EventBus from '@/assets/js/EventBus.js'

var renewal

export default {
  name: 'App',
  watch: {
    '$route' (to, from) {
      if (from.name === 'Home' && to.name !== 'Home') {
        const answer = window.confirm('Do you really want to leave? you may not earn points for this.')
        if (!answer) {
          this.$router.push({
            name: 'Home'
          })
        } else {
          EventBus.$emit('cancelInterval', this.cancelInterval)
        }
      }
    }
  },
  components: {
    Bulma,
    DefaultLayout,
    AdminLayout,
    ScholarLayout
  },
  data () {
    return {
      authorizationRequired: ['/Home', '/LinkedIn', '/account', '/account-admin', '/sweepstakeadmin', '/sweepstake'],
      currentRole: '',
      adminAuthorizationRequired: ['/sweepstakeadmin', '/LinkedIn', '/account-admin'],
      scholarAuthorizationRequired: ['/sweepstake']
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
    // Check users that are admins against routes that are only allowed for scholars
    checkAdminLogin () {
      for (var path in this.scholarAuthorizationRequired) {
        if (!this.$store.getters.isAuth && this.$store.getters.getRole === 'Admin' && this.$route.path === this.scholarAuthorizationRequired[path]) {
          this.$router.push('/?redirect=' + this.$route.path)
        }
      }
    },
    // Check users that are scholars against routes that are only allowed for admins
    checkScholarLogin () {
      for (var path in this.adminAuthorizationRequired) {
        if (this.$store.getters.getRole === 'Scholar' && this.$route.path === this.adminAuthorizationRequired[path]) {
          this.$router.push('/?redirect=' + this.$route.path)
        }
      }
    },
    checkCurrentRole () {
      this.currentRole = this.$store.getters.getRole
    },
    tokenRenewal: function () {
      Axios({
        method: 'GET',
        url: this.$store.getters.getBaseAppUrl + 'Account/RenewToken',
        headers: this.$store.getters.getRequestHeaders
      })
        .then((response) => {
          this.$store.dispatch('signIn', response.data.AuthToken)
          this.$store.dispatch('updateToken', response.data.AuthToken)
        })
        .catch((error) => {
          console.log(error)
        })
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

    // Set behavior once the window has been closed
    // window.onbeforeunload = () => {
    //   this.$store.dispatch('updateUsername', '')
    //   this.$store.dispatch('signOut')
    //   this.$store.dispatch('updateToken', '')
    //   clearInterval(renewal)
    // }

    // Set interval depending on whether or not a user is logged in
    if (this.$store.getters.isAuth) {
      renewal = setInterval(() => { this.tokenRenewal() }, 900000)
    } else {
      EventBus.$on('loggedIn', () => {
        renewal = setInterval(() => { this.tokenRenewal() }, 900000)
      })
    }

    // Clear interval on logout
    EventBus.$on('logOut', () => {
      clearInterval(renewal)
    })
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
