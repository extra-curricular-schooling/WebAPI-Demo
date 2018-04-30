export default {
  /**
   * Takes a URL and returns a tokenized dictionary of parameter names and their values.
   * @param {string} url Complete url
   */
  parseUrlQuery: function (url) {
    if (typeof url !== 'string' || url.length === 0) {
      return {}
    }
    let parsedUrl = url.split('?')
    let parsedParams = parsedUrl[1].split('&')
    let parsedParamsLength = parsedParams.length
    let bit = null
    let query = {}
    let first = null
    let second = null
    for (let i = 0; i < parsedParamsLength; i++) {
      bit = parsedParams[i].split('=')
      first = decodeURIComponent(bit[0])
      if (first.length === 0) { continue }
      second = decodeURIComponent(bit[1])
      if (typeof query[first] === 'undefined') {
        query[first] = second
      } else if (query[first] instanceof Array) {
        query[first].push(second)
      } else {
        query[first] = [query[first], second]
      }
    }
    return query
  },
  /**
   * Seperates a url into discrete parts.
   * @param {string} url Complete URL
   * @returns tokenized list
   */
  parseUrl: function (url) {
    if (typeof url !== 'string' || url.length === 0) {
      return {}
    }
    let parsedUrl = url.split('?')
    let moreParsedUrl = parsedUrl[0].split('/')
    return moreParsedUrl
  },
  /**
   * @param {string} url Complete URL
   * @returns URL scheme
   */
  getUrlScheme: function (url) {
    let parsedUrl = this.parseUrl(url)
    return parsedUrl[0]
  },
  /**
   * @param {string} url Complete URL
   * @returns URL Host
   */
  getUrlHost: function (url) {
    let parsedUrl = this.parseUrl(url)
    return parsedUrl[2]
  },
  /**
   * @param {string} url Complete URL
   * @returns URL Path
   */
  getUrlPath: function (url) {
    let parsedUrl = this.parseUrl(url)
    return parsedUrl[3]
  }
}
