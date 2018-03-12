import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Main',
      component: () => import('@/components/pages/Main')
    },
    {
      path: '/About',
      name: 'About',
      component: () => import('@/components/pages/About')
    },
    {
      path: '/Registration',
      name: 'Registration',
      component: () => import('@/components/pages/Registration')
    },
    {
      path: '/Home',
      name: 'Home',
      component: () => import('@/components/pages/Home')
    },
    {
      path: '/Account',
      name: 'Account',
      component: () => import('@/components/pages/Account')
    },
    {
      path: '/Sweepstake',
      name: 'Sweepstake',
      component: () => import('@/components/pages/Sweepstake')
    },
    // Does not know how to handle 404 errors. Might want to build in a catch all page right here.
    {
      path: '/404',
      name: 'MissingPage',
      component: () => import('@/components/pages/MissingPage')
    },
    {
      path: '/LinkedIn',
      name: 'LinkedIn',
      component: () => import('@/components/pages/LinkedIn')
    },
    {
      path: '/ApiTests',
      name: 'ApiTests',
      component: () => import('@/components/pages/ApiTests')
    }
  ]
})
