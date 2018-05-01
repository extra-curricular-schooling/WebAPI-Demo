import Vue from 'vue'
import Router from 'vue-router'
import jsonwebtoken from 'jsonwebtoken'
// import Store from '@/store/index'

Vue.use(Router)

export default new Router({
  // mode: 'history',
  routes: [
    {
      path: '/about',
      name: 'About',
      meta: {
        title: 'About - ECSchooling'
      },
      component: () => import('@/pages/About'),
      beforeEnter: function (to, from, next) {
        document.title = to.meta.title
        next()
      }
    },
    {
      path: '/account',
      name: 'Account',
      meta: {
        title: 'Account - ECSchooling'
      },
      component: () => import('@/pages/Account'),
      beforeEnter: function (to, from, next) {
        document.title = to.meta.title
        next()
      }
    },
    {
      path: '/account-admin',
      name: 'AccountAdmin',
      meta: {
        title: 'Account Admin - ECSchooling'
      },
      component: () => import('@/pages/AccountAdmin'),
      beforeEnter: function (to, from, next) {
        document.title = to.meta.title
        next()
      }
    },
    {
      path: '/api-tests',
      name: 'ApiTests',
      meta: {
        title: 'Api Tests - ECSchooling'
      },
      component: () => import('@/pages/ApiTests'),
      beforeEnter: function (to, from, next) {
        document.title = to.meta.title
        next()
      }
    },
    // Catch all error page.
    {
      path: '*',
      name: 'Error',
      meta: {
        title: 'Error'
      },
      component: () => import('@/pages/Error'),
      beforeEnter: function (to, from, next) {
        document.title = to.meta.title
        next()
      }
    },
    {
      path: '/home',
      name: 'Home',
      meta: {
        title: 'Home - ECSchooling'
      },
      component: () => import('@/pages/Home'),
      beforeEnter: function (to, from, next) {
        document.title = to.meta.title
        next()
      }
    },
    {
      path: '/linkedin',
      name: 'LinkedIn',
      meta: {
        title: 'LinkedIn - ECSchooling'
      },
      component: () => import('@/pages/LinkedIn'),
      beforeEnter: function (to, from, next) {
        document.title = to.meta.title
        next()
      }
    },
    {
      path: '/',
      name: 'Main',
      meta: {
        title: 'Main - ECSchooling'
      },
      component: () => import('@/pages/Main'),
      beforeEnter: function (to, from, next) {
        document.title = to.meta.title
        next()
      }
    },
    /**
     * Requires Decodable JWT Token to enter
     * Example: https://localhost/partial-registration/evnskqwovu992818j.wlwnvwe...
     */
    {
      path: '/partial-registration/:jwt',
      name: 'PartialRegistration',
      meta: {
        title: 'Partial Registration - ECSchooling'
      },
      component: () => import('@/pages/PartialRegistration'),
      beforeEnter: function (to, from, next) {
        let jwt = to.params.jwt
        if (jsonwebtoken.decode(jwt)) {
          document.title = to.meta.title
          next()
        } else {
          next(from.fullPath)
        }
      }
    },
    {
      path: '/registration',
      name: 'Registration',
      meta: {
        title: 'Registration - ECSchooling'
      },
      component: () => import('@/pages/Registration'),
      beforeEnter: function (to, from, next) {
        document.title = to.meta.title
        next()
      }
    },
    /**
     * Requires Decodable JWT Token to enter
     * Example: https://localhost/singlesignon/?jwt=evnskqwovu992818j.wlwnvwe...
     */
    {
      path: '/singlesignon',
      name: 'SingleSignOn',
      meta: {
        title: 'Single Sign On - ECSchooling'
      },
      component: () => import('@/pages/SingleSignOn'),
      beforeEnter: function (to, from, next) {
        let jwt = to.query.jwt
        if (jsonwebtoken.decode(jwt)) {
          document.title = to.meta.title
          next()
        } else {
          next(from.fullPath)
        }
      }
    },
    {
      path: '/sweepstake-admin',
      name: 'SweepstakeAdmin',
      meta: {
        title: 'Sweepstake Admin - ECSchooling'
      },
      component: () => import('@/pages/SweepstakeAdmin'),
      beforeEnter: function (to, from, next) {
        document.title = to.meta.title
        next()
      }
    },
    {
      path: '/sweepstake',
      name: 'Sweepstake',
      meta: {
        title: 'Sweepstake - ECSchooling'
      },
      component: () => import('@/pages/Sweepstake'),
      beforeEnter: function (to, from, next) {
        document.title = to.meta.title
        next()
      }
    }
  ]
})
