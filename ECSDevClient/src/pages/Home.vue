<template>
<div id="Home">
  <SideBar/>
  <main id="EmbedContent">
    <header>
      <div>
        <button class="toggle-button">☰</button>
      </div>
    </header>
    <h1>Welcome to Article Page</h1>
    <iframe src="https://ecschooling.org/" id = "FrameResult" name="FrameResult" @load="mounted" @error="alert('Frame not loaded')"></iframe>
    <LinkedInPostModal/>
  </main>
  <RedirectModal/>
  <ErrorModal/>
</div>
</template>

<script>
import ErrorModal from '../components/Error-Modal/index'
import LinkedInPostModal from '../components/LinkedIn-Modal/Index'
import RedirectModal from '../components/Redirect-Modal/index'
import SideBar from '../components/SideBar-Menu/index'
import axios from 'axios'
export default {
  name: 'home',
  data () {
    return {
      username: this.$store.getters.getUsername,
      headers: this.$store.getters.getRequestHeaders,
      Points: 2
    }
  },
  components: {
    ErrorModal,
    LinkedInPostModal,
    RedirectModal,
    SideBar
  },
  methods: {
    earnPoints: function (username, Points) {
      alert('Hello. You earned 2 points.')
      axios({
        method: 'POST',
        url: this.$store.getters.getBaseAppUrl + 'v1/SweepstakeAdmin/UpdatePoints/' + username,
        headers: this.$store.getters.getRequestHeaders,
        data: {
          'Points': this.$data.Points,
          'ScholarUserName': this.$data.username
        }
      })
        .then(response => {
          console.log(response)
          this.$router.push({
            name: 'Home'
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
    // Iframe gets recreated each time a new page is clicked.
    mounted () {
      setTimeout(
        this.earnPoints
        , 200000)
      // after 3 minutes 30 aseconds you can earn 2 points
    }
  }
}
</script>
<style scoped>
  body {
    width: 100%;
    height: 100%;
    margin: 0;
  }
  .toggle-button {
    position: absolute;
    left: 1%;
    top: 35%;
    font-size:180%;
  }
  #FrameResult{
    height: 700px;
    width: 98%;
    border: 4px solid black;
  }
</style>
