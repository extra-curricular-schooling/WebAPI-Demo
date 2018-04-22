<template>
  <div>
    <!-- GET POINTS FIRST FROM USER ACCOUNT AND SOLVE THE ISSUE OF GETTING SCHOLAR POINTS -->
    <!-- thinking of changing the Price to the ticket number, which i can use to get the max number of tickets -->
    <h1>Welcome to Sweepstake Entry. Buy A Ticket To Enter Into The Sweepstake.</h1>
    <h1>Time Left</h1>
    <Countdown deadline="April 22, 2018"></Countdown>
    <!-- or
    <Countdown end="August 22, 2022"></Countdown> -->
    <button v-on:click="fetchUserInfo(username,Points)">What are your Points? Find it out, First.</button>
    <button v-on:click="fetchValidSweepstakeInfo(Price)">Is Sweepstake Open??</button>
    <!-- <button v-on:click="fetchUserInfo(username,Points),ticketBought(Points,Price)">Buy A Ticket</button> -->
    <button v-on:click="ticketBought(Points,Price)">Buy A Ticket and Surprise Yourself</button>
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
      Points: '', // Points i get from the scholar account
      Price: '', // it is the Price of ticket from sweepstake that is set by admin
      username: this.$store.getters.getUsername,
      timeDateStamp: moment().utc('dddd, MMMM Do YYYY , hh:mm:ss').format() // the time date stamp is right in utc format
      // SweepStakesID: '7',
      // OpenDateTime: moment().utc('dddd, MMMM Do YYYY , hh:mm:ss').format()
    }
  },
  components: {
    Countdown
  },
  methods: {
    fetchUserInfo: function (username, Points) {
      Axios({
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
    fetchValidSweepstakeInfo: function (Price) {
      Axios({
        method: 'GET',
        url: Store.getters.getBaseAppUrl + 'SweepstakeAdmin/ValidSweepstakeInfo',
        headers: Store.getters.getRequestHeaders
      })
        .then(response => {
          console.log(response.data)
          this.Price = response.data
          alert('The Price to enter Sweepstake is ' + this.Price)
        })
        .catch(error => {
          console.log(error.response)
          this.$data.error = JSON.parse(error.response.data)
          if (error.response.status === 500) {
            alert('We apologize.  We are unable to process your request at this time.')
          }
        })
    },
    ticketBought: function (Points, Price) {
      if (Points >= Price) {
        // remember the points should no tbe negative
        alert('Congragulations! One ticket bought for ' + Price + ' points! Your Points are ' + Points)
        Points = Points - Price
        alert('Points left = ' + Points)
        // Axios({
        //   // get request for sweepstake id and open date time from the sweepstake admin database table
        //   method: 'POST',
        //   // url: this.$store.getters.getBaseAppUrl + 'v1/SweepstakeAdmin/submitSweepstake',
        //   url: 'https://localhost:44311/v1/Sweepstake/submitSweepstake',
        //   headers: store.getters.getRequestHeaders,
        //   data: {
        //     // 'SweepstakesID': this.$data.SweepStakesID,
        //     // 'OpenDateTime': this.$data.timeDateStamp, // change it later to open date time
        //     'PurchaseDateTime': this.$data.timeDateStamp,
        //     'Price': this.$data.Price
        //     // 'Price': this.$data.Price,
        //     // 'username': this.$data.username
        //   }
        // })
        //   .then(response => {
        //     console.log(response)
        //     this.$router.push({
        //       name: 'Sweepstake'
        //       // params: { isSuccess: true }
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
