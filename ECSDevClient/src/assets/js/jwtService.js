import jsonwebtoken from 'jsonwebtoken'
import store from '@/store/index.js'
// import moment from 'moment'

export default {
  setClaims: (claims) => {
    store.dispatch('updateRole', claims['role'])
    store.dispatch('updateUsername', claims['unique_name'])
  },
  myDecode: (token) => {
    return jsonwebtoken.decode(token)
  },
  myVerify: (claims) => {
    try {
      this.verifyAudience(claims['aud'])
      this.verifyExpiration(claims['exp'])
    } catch (exception) {
      console.log(exception)
    }
    return jsonwebtoken.verify(claims)
  },
  verifyAudience: (audClaimValue) => {
    return true
  },
  verifyExpiration: (expClaimValue) => {
    return true
  },
  // BUG: Currently not working. Says that "myDecode" is not a function.
  transform: (token) => {
    let claims = this.myDecode(token)
    let verifiedClaims = this.myVerify(claims)
    return verifiedClaims
  }
}
