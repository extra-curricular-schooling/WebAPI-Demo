import Axios from 'axios'
import Store from '@/store/index'
import Router from '@/router/index'
import UrlHelper from '@/assets/js/urlHelper'
import JwtService from '@/assets/js/jwtService'
import urlHelper from '../../assets/js/urlHelper'

export default {
  submitRegistration: function (username, password, application) {
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
  submitLogin (username, password) {
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
      .catch(response => {
        console.log(response)
        return response.data
      })
  },
  submitResetPassword: function (username, password) {
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
