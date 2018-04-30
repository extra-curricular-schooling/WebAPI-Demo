<template>
  <div id="app">
    <admin-layout v-if="currentRole === 'Admin' && isAuth"/>
    <scholar-layout v-else-if="currentRole === 'Scholar' && isAuth"/>
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
import jwt from 'jsonwebtoken'
import Swal from 'sweetalert2'

var renewal

export default {
  name: 'App',
  // Watch is set to watch for routing from home. User will be asked to confirm. if they leave, emit to cancel interval. close slide menu
  watch: {
    '$route' (to, from) {
      var html = document.documentElement
      // Check if route is coming from home.
      if (from.name === 'Home' && to.name !== 'Home' && to.name !== 'Main') {
        // Cancel time interval and close slideout
        EventBus.$emit('cancelInterval', this.cancelInterval)
        html.classList.remove('slideout-open')
      } else if (to.name === 'Main' && (from.name === 'Home' || from.name === 'Sweepstake' || from.name === 'Account') && this.currentRole !== 'Admin') {
        Swal({
          title: 'We miss you already!',
          text: 'Come back soon!',
          imageUrl: '../static/images/sad-panda.jpg'
          // imageUrl: 'https://i.pinimg.com/736x/f0/ba/22/f0ba22c10f942fb16fae5f7850ddd70f--panda-tattoos-cute-tattoos.jpg'
        }).then(response => {
          html.classList.remove('slideout-open')
        })
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
      authorizationRequired: ['/Home', '/home', '/linkedIn', '/account', '/account-admin', '/sweepstake-admin', '/sweepstake'],
      adminAuthorizationRequired: ['/sweepstake-admin', '/linkedIn', '/account-admin'],
      currentRole: '',
      isAuth: false,
      scholarAuthorizationRequired: ['/sweepstake', '/account']
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
        if (this.$store.getters.getRole === 'Admin' && this.$route.path === this.scholarAuthorizationRequired[path]) {
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
    updateLocalAuthState () {
      this.currentRole = this.$store.getters.getRole
      this.isAuth = this.$store.getters.isAuth
    },
    checkTokenLife: function () {
      var decoded = jwt.decode(this.$store.getters.getAuthToken, {complete: true})
      if ((new Date().getTime() - new Date(decoded.payload.exp * 1000).getTime()) / 1000 > -120) {
        this.$store.dispatch('updateUsername', '')
        this.$store.dispatch('signOut')
        this.$store.dispatch('updateToken', '')
        clearInterval(renewal)
        if (this.$router.currentRoute.path !== '/') {
          this.$router.push('/')
        } else {
          this.$router.go()
        }
      }
    },
    tokenRenewal: function () {
      var decoded = jwt.decode(this.$store.getters.getAuthToken, {complete: true})
      if ((new Date().getTime() - new Date(decoded.payload.exp * 1000).getTime()) / 1000 > -360) {
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
      this.updateLocalAuthState()
    }

    // Set interval depending on whether or not a user is logged in
    if (this.$store.getters.isAuth) {
      this.checkTokenLife()
      renewal = setInterval(() => { this.tokenRenewal() }, 120000)
    } else {
      EventBus.$on('loggedIn', () => {
        renewal = setInterval(() => { this.tokenRenewal() }, 120000)
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
    } else if (this.$store.getters.getRole === 'Admin') {
      this.checkAdminLogin()
    } else {
      this.checkCurrentLogin()
    }
    this.updateLocalAuthState()
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
