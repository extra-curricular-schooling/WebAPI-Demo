import Vue from 'vue'
import Router from 'vue-router'
// import jwtService from '@/assets/js/jwtService.js'
// import moment from 'moment'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Main',
      component: () => import('@/pages/Main')
    },
    {
      path: '/about',
      name: 'About',
      component: () => import('@/pages/About')
    },
    {
      path: '/registration',
      name: 'Registration',
      component: () => import('@/pages/Registration')
    },
    {
      path: '/partial-registration/:jwt',
      name: 'PartialRegistration',
      component: () => import('@/pages/PartialRegistration'),
      beforeEnter: function (to, from, next) {
        console.log('You made it!')
        if (to.params.jwt) {
          let jwt = to.params.jwt
          console.log(jwt)
          // Decode the jwt
          // Set the username
          // Set the role
          next()
        }
      }
    },
    {
      path: '/home',
      name: 'Home',
      component: () => import('@/pages/Home')
    },
    {
      path: '/account',
      name: 'Account',
      component: () => import('@/pages/Account')
    },
    {
      path: '/account-admin',
      name: 'AccountAdmin',
      component: () => import('@/pages/AccountAdmin')
    },
    {
      path: '/sweepstake-admin',
      name: 'SweepstakeAdmin',
      component: () => import('@/pages/SweepstakeAdmin')
    },
    {
      path: '/sweepstake',
      name: 'Sweepstake',
      component: () => import('@/pages/Sweepstake')
    },
    // Catch all error page.
    {
      path: '*',
      name: 'Error',
      component: () => import('@/pages/Error')
    },
    {
      path: '/linkedin',
      name: 'LinkedIn',
      component: () => import('@/pages/LinkedIn')
    },
    {
      path: '/api-tests',
      name: 'ApiTests',
      component: () => import('@/pages/ApiTests')
    }
  ]
})
