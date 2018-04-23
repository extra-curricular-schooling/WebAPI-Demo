<template>
  <div>
    <h1>Welcome to Sweepstake Entry. Buy A Ticket To Enter Into The Sweepstake.</h1>
    <h1>Time Left</h1>
    <Countdown deadline="May 25, 2018"></Countdown>
    <button v-on:click="fetchUserInfo(username,Points)">What are your Points? Find it out, First.</button>
    <button v-on:click="fetchValidSweepstakeInfo(Price, SweepStakesID, OpenDateTime, Prize, ClosedDateTime)">Is Sweepstake Open??</button>
    <button v-on:click="ticketBought(Points,Price,username,timeDateStamp)">Buy A Ticket and Surprise Yourself</button>
  </div>
</template>
<script>
import Vue from 'vue'
import moment from 'moment'
import Countdown from 'vuejs-countdown'
import Store from '@/store/index'
import Axios from 'axios'
Vue.use(require('vue-moment'))
export default {
  name: 'prizes',
  data () {
    return {
      Points: '', // Points from the scholar account
      Price: '', // it is the Price of ticket for sweepstake that is set by admin
      username: this.$store.getters.getUsername,
      timeDateStamp: moment().utc('dddd, MMMM Do YYYY , hh:mm:ss').format(), // the time date stamp is right in utc format
      SweepStakesID: '', // the ID of the sweepstake that is open
      OpenDateTime: '', // the opening date of the sweepstake
      Prize: '',
      ClosedDateTime: '', // the closing date of the sweepstake
      UserNameWinner: ''
    }
  },
  components: {
    Countdown
  },
  methods: {
    fetchUserInfo: function (username, Points) {
      Axios({
        // REQUEST TO GET THE SCHOLAR POINTS
        method: 'GET',
        url: Store.getters.getBaseAppUrl + 'Sweepstake/ScholarPoints/' + username,
        headers: Store.getters.getRequestHeaders
      })
        .then(response => {
          console.log(response.data)
          this.Points = response.data
          alert('Points are ' + this.Points)
        })
        .catch(error => {
          console.log(error.response)
          this.$data.error = JSON.parse(error.response.data)
          if (error.response.status === 500) {
            alert('We apologize.  We are unable to process your request at this time.')
          }
        })
    },
    fetchValidSweepstakeInfo: function (Price, SweepStakesID, OpenDateTime, Prize) {
      Axios({
        // REQUEST TO GET THAT WHETHER THE SWEEPSTAKE IS OPEN
        method: 'GET',
        url: Store.getters.getBaseAppUrl + 'SweepstakeAdmin/ValidSweepstakeInfo',
        headers: Store.getters.getRequestHeaders
      })
        .then(response => {
          console.log(response.data)
          this.Price = response.data.price
          this.SweepStakesID = response.data.sweepStakesID
          this.OpenDateTime = response.data.openDateTime
          this.Prize = response.data.prize
          this.ClosedDateTime = response.data.closedDateTime
          alert('SweepStake Information: Price To Enter: ' + this.Price +
          ' SweepStakesID: ' + this.SweepStakesID +
          ' SweepStake Open Date: ' + this.OpenDateTime +
          ' Prize: ' + this.Prize +
          ' Closing Date: ' + this.ClosedDateTime)
        })
        .catch(error => {
          console.log(error.response)
          this.$data.error = JSON.parse(error.response.data)
          if (error.response.status === 500) {
            alert('We apologize.  We are unable to process your request at this time.')
          }
        })
    },
    // REQUEST TO POST A SWEEPSTAKE TICKET TO A SWEEPSTAKE
    ticketBought: function (Points, Price, username, timeDateStamp, OpenDateTime) {
      if (Points >= Price) {
        // remember the points should no tbe negative
        // change the points to equal or something
        alert('Congragulations! One ticket bought for ' + Price + ' points! Your Points are ' + Points)
        Points = Points - Price
        alert('Points left = ' + Points)
        // Axios({
        //   method: 'POST',
        //   url: Store.getters.getBaseAppUrl + 'Sweepstake/ScholarTicket/' + username,
        //   headers: Store.getters.getRequestHeaders,
        //   data: {
        //     'SweepstakesID': this.$data.SweepStakesID,
        //     'OpenDateTime': this.$data.OpenDateTime,
        //     'PurchaseDateTime': this.$data.timeDateStamp,
        //     'Price': this.$data.Price,
        //     'username': this.$data.username
        //   }
        // })
        //   .then(response => {
        //     console.log(response)
        //     this.$router.push({
        //       name: 'Sweepstake'
        //     })
        //   })
        //   .catch(error => {
        //     console.log(error.response)
        //     this.$data.error = JSON.parse(error.response.data)
        //     if (error.response.status === 500) {
        //       alert('We apologize.  We are unable to process your request at this time.')
        //     }
        //   })
      } else {
        alert('Sorry! You have Insufficient Points!')
      }
    }
  }
}
</script>
<style scoped>
button {
  background-color: #E8E9E4;
  color: black;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 270px;
  opacity: 0.9;
}

button:hover {
    opacity:1;
}
</style>
