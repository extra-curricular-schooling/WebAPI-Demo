/* eslint-disable */
export default {
  /**
   * shuffles a given array and outputs the new randomized array
   * @function shuffleArray
   * @param {Object[]} oldArray - The inputted array that needs to be shuffled
   * @return {Object[]} newArray - The new shuffled array
   */
  shuffleArray: function (oldArray) {
    let newArray = [].concat(oldArray)
    let currentIndex = newArray.length
    let temp
    let randomIndex

    while (currentIndex !== 0) {
      randomIndex = Math.floor(Math.random() * currentIndex)
      currentIndex -= 1

      temp = newArray[currentIndex]
      newArray[currentIndex] = newArray[randomIndex]
      newArray[randomIndex] = temp
    }

    return newArray
  }
}
