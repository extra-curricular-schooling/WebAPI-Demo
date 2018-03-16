/* eslint-disable */
var crypto = require('crypto')

export default {
  /**
   * generates random string of characters i.e salt
   * @function
   * @param {number} length - Length of the random string.
   */
  genRandomString: function (length) {
    return crypto.randomBytes(Math.ceil(length / 2))
      .toString('hex') /** convert to hexadecimal format */
      .slice(0, length) /** return required number of characters */
  },

  /**
   * hash password with sha256.
   * @function
   * @param {string} password - List of required fields.
   * @param {string} salt - Data to be validated.
   */
  sha256: function (password, salt) {
    var hash = crypto.createHmac('sha256', salt) /** Hashing algorithm sha512 */
    hash.update(password)
    var value = hash.digest('hex')
    return {
      salt: salt,
      passwordHash: value
    }
  }
}
