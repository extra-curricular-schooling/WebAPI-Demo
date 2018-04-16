export default {
  // Takes a full URL and returns a tokenized dictionary of parameter names and their values.
  // Did not test if it can take query strings only as the function param 'str'.
  parseUrlQuery: function (str) {
    if (typeof str !== 'string' || str.length === 0) {
      return {}
    }
    let parsedUrl = str.split('?')
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
  }
}
