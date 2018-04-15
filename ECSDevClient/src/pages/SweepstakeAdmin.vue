<template>
<div class="SweepstakeAdminPage">
    <h1>Admin Page to Set Sweepstake Settings</h1>
    <h2>Admin Can Set Sweepstake Open/Close Date, Sweepstake ID, Ticket Price, & Prize.</h2>
    <div class="dates">
      <!-- date in utc -->
      <!-- v2-datepicker license MIT -->
      <v2-datepicker v-model="OpenDateTime" lang="en" format="MM/DD/YYYY" placeholder="Opening Date"></v2-datepicker>
      <p>Admin Selected Opening Date: {{OpenDateTime}}</p>
      <v2-datepicker v-model="ClosedDateTime" lang="en" format="MM/DD/YYYY" placeholder="Closing Date"></v2-datepicker>
      <p>Admin Selected Closing Date: {{ClosedDateTime}}</p>
      <!-- <template v-if="OpenDateTime>ClosedDateTime">
        <p>Wrong Close Date Entered: {{ClosedDateTime}}</p>
      </template> -->
      <!-- make Something more pretty here -->
      <p v-if="OpenDateTime>ClosedDateTime">Wrong Close Date Entered</p>
    </div>
    <div class="settings">
      <input type="number" v-model.lazy="Price" placeholder="Ticket Price">
      <p>Admin Selected Ticket Price: {{ Price }}</p>
      <input type="text" v-model.lazy="Prize" placeholder="Prize Sweepstake">
      <p>Admin Selected Prize: {{ Prize }}</p>
      <input type="number" v-model.lazy="SweepStakesID" placeholder="Enter Sweepstake ID">
      <p>Admin Selected Sweepstakes ID: {{ SweepStakesID }}</p>
    </div>
    <!-- button to POST everything to the database -->
    <button v-on:click.prevent="submitSweepstake(OpenDateTime,ClosedDateTime,Prize,UsernameWinner,SweepStakesID,Price)">Submit Sweepstake</button>
    <!-- put in username winner -->
    <button v-on:click="randomNumberGenerator(totalNumberTickets, winningTicket)">Select the Winner</button>
    <!-- fire the random number generator event at time expiration or when it goes to zero -->
    <!-- <p>The winning ticket is: {{winningTicket}}</p> -->
</div>
</template>
<script>
import Vue from 'vue'
import V2Datepicker from 'v2-datepicker'
import 'v2-datepicker/lib/index.css'
import axios from 'axios'
import store from '@/store/index'
Vue.use(V2Datepicker)
export default {
  name: 'sweepstake',
  data () {
    return {
      OpenDateTime: '',
      ClosedDateTime: '',
      Prize: '',
      UsernameWinner: 'No Winner',
      SweepStakesID: '',
      winningTicket: '',
      Price: '',
      totalNumberTickets: 100
      // remove the total ticket number (100) when connect to database
    }
  },
  methods: {
    submitSweepstake: function (OpenDateTime, ClosedDateTime, Prize, UsernameWinner, SweepStakesID, Price) {
      // alert('Sweepstake Set ' + OpenDateTime + ' ' + ClosedDateTime)
      // alert('Other Information Set ' + Price + ' ' + Prize + ' ' + SweepStakesID + ' ')
      axios({
        method: 'POST',
        url: store.getters.getBaseAppUrl + 'v1/SweepstakeAdmin/submitSweepstake',
        // url: 'https://localhost:44311/SweepstakeAdmin/submitSweepstake',
        headers: store.getters.getRequestHeaders,
        data: {
          'SweepStakesID': this.$data.SweepStakesID, // why MY ID DOESN't GO with what i want
          'OpenDateTime': this.$data.OpenDateTime,
          'ClosedDateTime': this.$data.ClosedDateTime,
          'Prize': this.$data.Prize,
          'Price': this.$data.Price,
          'UsernameWinner': this.$data.UsernameWinner // can be cut out
        }
      })
        .then(response => {
          console.log(response)
          this.$router.push({
            name: 'SweepstakeAdmin'
            // params: { isSuccess: true }
          })
        })
        .catch(error => {
          console.log(error.response)
          this.$data.error = JSON.parse(error.response.data)
          if (error.response.status === 500) {
            alert('We apologize.  We are unable to process your request at this time.')
          }
        })
    },
    randomNumberGenerator: function (totalNumberTickets, winningTicket) {
      winningTicket = Math.floor(Math.random() * Math.floor(totalNumberTickets))
      alert(winningTicket)
      return winningTicket
      // generate the random number which is total number of tickets = sweepstakes id.
      // look at the corresponding username and notify that user
      //   in this need to create randomizer by calling all the tickets in the sweepstake
      //   use the total number of tickets and find one number than match the number with the userID
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
input {
    width: 200px;
    height: 40px;
}
v2-datepicker {
  size: 30cm;
  padding: 30px
}
.dates:after {
  content: "\A";
  white-space: pre;
  size: 30cm;
}

.dates:before {
  content: "\A";
  white-space: pre;
}
.prize:after {
  content: "\A";
  white-space: pre;
  size: 30cm;
}

.prize:before {
  content: "\A";
  white-space: pre;
}
</style>
