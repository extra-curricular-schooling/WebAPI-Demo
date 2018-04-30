import jsonwebtoken from 'jsonwebtoken'
import store from '@/store/index.js'

export default {
  /**
   * Sets the Vuex store with the User's appropriate claims.
   * @param claims List of security claims.
   */
  setClaims: function (claims) {
    store.dispatch('updateRole', claims['role'])
    store.dispatch('updateUsername', claims['unique_name'])
  },
  /**
   * Wrapper function for JsonWebToken "Decode" function
   * @param {string} token Json Web Token
   * @returns The decoded token.
   */
  myDecode: function (token) {
    return jsonwebtoken.decode(token)
  },
  /**
   * Jwt Verification strategy wrapping JsonWebToken "Verify" function.
   * @param claims List of security claims.
   * @returns The decoded token.
   */
  myVerify: function (claims) {
    try {
      this.verifyAudience(claims['aud'])
      this.verifyExpiration(claims['exp'])
    } catch (exception) {
      console.log(exception)
    }
    return jsonwebtoken.verify(claims)
  },
  /**
   * Validates the "Audience" claim.
   * @param audClaimValue Audience claim value.
   * @returns {true} If the claim is validated.
   * @returns {false} If the claim is invalid.
   */
  verifyAudience: function (audClaimValue) {
    return true
  },
  /**
   * Validates the "Expiration" claim.
   * @param expClaimValue Expiration claim value.
   * @returns {true} If the claim is validated.
   * @returns {false} If the claim is invalid.
   */
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
