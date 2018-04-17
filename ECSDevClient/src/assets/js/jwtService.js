import jsonwebtoken from 'jsonwebtoken'
import store from '@/store/index.js'
// import moment from 'moment'

export default {
  setClaims: function (claims) {
    store.dispatch('updateRole', claims['role'])
    store.dispatch('updateUsername', claims['unique_name'])
  },
  myDecode: function (token) {
    return jsonwebtoken.decode(token)
  },
  myVerify: function (claims) {
    try {
      this.verifyAudience(claims['aud'])
      this.verifyExpiration(claims['exp'])
    } catch (exception) {
      console.log(exception)
    }
    return jsonwebtoken.verify(claims)
  },
  verifyAudience: function (audClaimValue) {
    return true
  },
  verifyExpiration: function (expClaimValue) {
    return true
  },
  // BUG: Currently not working. Says that "myDecode" is not a function.
  transform: function (token) {
    let claims = this.myDecode(token)
    this.myVerify(claims)
    return claims
  }
}
