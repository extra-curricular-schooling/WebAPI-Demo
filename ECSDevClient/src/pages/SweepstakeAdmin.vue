<template>
<div class="SweepstakeAdmin">
    <h1>Admin Page to Set Sweepstake Settings</h1>
    <h2>Admin Can Set Sweepstake Open/Close Date, Sweepstake ID, & Prize.</h2>
    <div class="dates">
      <v2-datepicker v-model="OpenDateTime" lang="en" format="MM/DD/YYYY" placeholder="Opening Date"></v2-datepicker>
      <p>Admin Selected Opening Date: {{OpenDateTime}}</p>
      <v2-datepicker v-model="ClosedDateTime" lang="en" format="MM/DD/YYYY" placeholder="Closing Date"></v2-datepicker>
      <p>Admin Selected Closing Date: {{ClosedDateTime}}</p>
      <!-- date time in UTC -->
      <!-- <template v-if="OpenDateTime>ClosedDateTime">
        <p>Wrong Close Date Entered: {{ClosedDateTime}}</p>
      </template> -->
      <p v-if="OpenDateTime>ClosedDateTime">Wrong Close Date Entered</p>
    </div>
    <div class="settings">
      <input type="text" v-model.lazy="Prize" placeholder="Prize Sweepstake">
      <p>Admin Selected Prize: {{ Prize }}</p>
      <input type="text" v-model.lazy="SweepStakesID" placeholder="Enter Sweepstake ID">
      <p>Admin Selected Sweepstakes ID: {{ SweepStakesID }}</p>
    </div>
    <!-- make a button to POST everything to the database -->
    <button v-on:click="submitSweepstake(OpenDateTime,ClosedDateTime,Prize,UsernameWinner,SweepStakesID)">Submit Sweepstake</button>
    <!-- put in username winner -->
    <!-- v2-datepicker license MIT -->
    <button v-on:click="randomNumberGenerator(totalNumberTickets, winningTicket)">Select the Winner</button>
    <!-- fire the random number generator event at time expiration -->
    <!-- <p>The winning ticket is: {{winningTicket}}</p> -->
    <!-- fire the random number event when the timer goes to zero or ends -->
    <!-- fire the random number event when the timer goes to zero or ends -->
</div>
</template>
<script>
import Vue from 'vue'
import V2Datepicker from 'v2-datepicker'
import 'v2-datepicker/lib/index.css'
Vue.use(V2Datepicker)
export default {
  name: 'sweepstake',
  data () {
    return {
      OpenDateTime: '',
      ClosedDateTime: '',
      Prize: '',
      UsernameWinner: '',
      SweepStakesID: '',
      winningTicket: '',
      totalNumberTickets: 100
      // remove the total ticket number (100) when connect to database
    }
  },
  methods: {
    submitSweepstake: function (OpenDateTime, ClosedDateTime, Prize, UsernameWinner, SweepStakesID) {
      alert('Sweepstake Set ' + OpenDateTime + ' ' + ClosedDateTime)
      alert('Other Information Set' + Prize + ' ' + SweepStakesID + ' ' + UsernameWinner)
    },
    randomNumberGenerator: function (totalNumberTickets, winningTicket) {
      winningTicket = Math.floor(Math.random() * Math.floor(totalNumberTickets))
      alert(winningTicket)
      return winningTicket
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
    height: 30px;
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
