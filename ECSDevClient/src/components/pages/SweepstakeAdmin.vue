<template>
<div>
    <h1>Admin Page to Set Sweepstake Entry Settings</h1>
    <h1>Admin Can Set Sweepstake Open/Close Date, Sweepstake ID, & Prize.</h1>
    <div class="dates">
      <v2-datepicker v-model="OpenDateTime" lang="en" format="MM/DD/YYYY" placeholder="Opening Date"></v2-datepicker>
      <p>Admin Selected Opening Date: {{OpenDateTime}}</p>
      <v2-datepicker v-model="ClosedDateTime" lang="en" format="MM/DD/YYYY" placeholder="Closing Date"></v2-datepicker>
      <p>Admin Selected Closing Date: {{ClosedDateTime}}</p>
      <!-- check that the closing date should not be less than the opening date
      make a button to POST everything to the database -->
    </div>
    <div class="prize">
      <input v-model="Prize" placeholder="Prize">
      <p>Admin Selected Prize: {{Prize}}</p>
      <input v-model="SweepStakesID" placeholder="SweepstakeID">
      <p>Admin Selected Sweepstakes ID: {{SweepStakesID}}</p>
      <!-- problem here the plaeceholer does not work -->
      <!-- <input v-model="message" placeholder="edit me">
      <p>Message is: {{ message }}</p> -->
    </div>
    <!-- put in username winner -->
    <!-- v2-datepicker license MIT -->
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
      OpenDateTime: ' ',
      ClosedDateTime: ' ',
      Prize: ' ',
      UsernameWinner: ' ',
      SweepStakesID: ' ',
      totalNumberTickets: ' '
    }
    // methods: {
    //   findWinner: function () {
    //   in this need to create randomizer by calling all the tickets in the sweepstake
    //   use the total number of tickets and find one number than match the number with the userID
    //   }
    // }
  }
}
</script>
<style scoped>
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
/* styling is CRAP And CONFUSING for me */
</style>
