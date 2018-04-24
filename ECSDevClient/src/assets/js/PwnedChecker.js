/**
 * helpers associated with the have i been pwned? API integrated upon password creation
 * at registration, forget password, etc.
 */

/* eslint-disable */
var crypto = require('crypto-js')

/**
 * @member {number} parseAtChar - The index at which a string will be split to create its prefix and suffix
 */
var parseAtChar = 5

export default {
  /**
   * gets a prefix substring of a provided password after it is hased using SHA1
   * @param {string} plainPassword - A password in plaintext
   * @return {string} The prefix substring of a hashed password with its letters uppercased
   */
  getHashedPrefix: function (plainPassword) {
    let hashedPassword = crypto.SHA1(plainPassword)
    return hashedPassword.toString().substring(0, parseAtChar).toUpperCase()
  },

  /**
   * gets a suffix substring of a provided password after it is hased using SHA1
   * @param {string} plainPassword - A password in plaintext
   * @return {string} The suffix substring of a hashed password with its letters uppercased
   */
  getHashedSuffix: function (plainPassword) {
    let hashedPassword = crypto.SHA1(plainPassword)
    return hashedPassword.toString().substring(parseAtChar, hashedPassword.length).toUpperCase()
  },

  /**
   * gets the number of known breaches that have been found to be 
   * associated with a given password
   * @param {string} plainPassword - A password in plaintext
   * @param {string} textArea - The response data in plaintext from the have i been pwned? API
   * @return The number of breaches associated with the password
   */
  getHits: function (plainPassword, textArea) {
    // store each hash of the string in an array
    let myArray = textArea.split("\n")

    let element
    let pwnedHash
    let passwordSuffix = this.getHashedSuffix(plainPassword)
    let suffixLength = passwordSuffix.length

    for (let i = 0; i < myArray.length; i++) {
      element = myArray[i]

      // extract hash
      pwnedHash = element.substring(0, suffixLength)

      // find match
      if (passwordSuffix == pwnedHash) {
        return Number(element.substring(suffixLength+1, element.length))
      }
    }
    return 0
  }
}
