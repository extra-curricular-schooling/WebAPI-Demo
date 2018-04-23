import Axios from 'axios'
import Store from '@/store/index'
import Router from '@/router/index'
import UrlHelper from '@/assets/js/urlHelper'
import JwtService from '@/assets/js/jwtService'
import urlHelper from '../../assets/js/urlHelper'

export default {
  submitRegistration: function () {
    // Test SSO Token
    Axios({
      method: 'POST',
      url: Store.getters.getBaseAppUrl + 'Sso/Registration',
      headers: Store.getters.getRequestHeaders
    })
      .then(function (response) {
        console.log(response)
        return response.data
      })
      .catch(function (response) {
        console.log(response)
        return response.data
      })
  },
  submitLogin () {
    // Test SSO Token
    Axios({
      method: 'POST',
      url: Store.getters.getBaseAppUrl + 'Sso/Login',
      headers: Store.getters.getRequestHeaders
    })
      .then(response => {
        let url = response.data
        console.log(url)
        // Testing with a 200 response to make sure the Partial Registration is working.
        if (response.status === 200) {
          let parsedQuery = UrlHelper.parseUrlQuery(response.data)
          console.log(parsedQuery)
          let token = parsedQuery['jwt']
          // let claims = jwtService.transform(token)
          let claims = JwtService.myDecode(token)

          // Change this back to claims['roleType'] when roleType is not public.

          console.log(claims)
          if (UrlHelper.getUrlPath(url) === 'partial-registration') {
            Store.dispatch('updateRole', claims['roleType'])
            Store.dispatch('updateUsername', claims['username'])
            Store.commit('signIn', token)
            Router.push({
              name: 'PartialRegistration',
              params: {
                jwt: token
              }
            })
          }
          if (urlHelper.getUrlPath(url) === 'home') {
            Store.dispatch('updateRole', claims['role'])
            Store.dispatch('updateUsername', claims['unique_name'])
            Store.commit('signIn', token)
            Router.push({
              name: 'Home'
            })
          }
        }
        // Should be a 301 response when you figure that out.
        if (response.status === 301) {
          let headers = response.headers
          let headersString = JSON.stringify(headers)
          console.log(headersString)
        }
      })
      .catch(error => {
        // Error
        console.log(error)
        console.log(error)
        console.log(error)
        console.log(error)
        console.log(error)
        if (error.response) {
          // The request was made and the server responded with a status code
          // that falls out of the range of 2xx
          console.log('An error occured')
          console.log(error.response.data)
          console.log(error.response.status)
          console.log(error.response.headers)
        } else if (error.request) {
          // The request was made but no response was received
          // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
          // http.ClientRequest in node.js
          console.log(error.request)
        } else {
          // Something happened in setting up the request that triggered an Error
          console.log('Error', error.message)
        }
        console.log(error.config)
      })
  },
  submitResetPassword: function () {
    // Test SSO Token
    Axios({
      method: 'POST',
      url: Store.getters.getBaseAppUrl + 'Sso/ResetPassword',
      headers: Store.getters.getRequestHeaders
    })
      .then(function (response) {
        return response.data
      })
      .catch(function (error) {
        console.log(error)
        return error
      })
  }
}
