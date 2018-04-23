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
      <iframe src="https://ecschooling.org/" id = "FrameResult" name="FrameResult" @load="mounted" @error="alert('Frame not loaded')" sandbox=""></iframe>
      <LinkedInPostModal/>
    </main>
    <RedirectModal/>
    <ErrorModal/>
  </div>
</template>

<script>
import Store from '@/store/index'
import ErrorModal from '@/components/error-modal/Template'
import LinkedInPostModal from '@/components/linkedin-modal/Template'
import RedirectModal from '@/components/redirect-modal/Template'
import SideBar from '@/components/sidebar-menu/Template'
import Axios from 'axios'
export default {
  name: 'home',
  data () {
    return {
      username: this.$store.getters.getUsername,
      headers: this.$store.getters.getRequestHeaders,
      Points: 2,
      timer: ''
    }
  },
  components: {
    ErrorModal,
    LinkedInPostModal,
    RedirectModal,
    SideBar
  },
  methods: {
    // REQUEST TO POST POINTS TO THE SCHOLAR POINTS AFTER ARTICLE HAS BEEN READ
    earnPoints: function (username, Points) {
      alert('Hello. You earned 2 points.')
      Axios({
        method: 'POST',
        url: Store.getters.getBaseAppUrl + 'SweepstakeAdmin/UpdatePoints/' + this.username,
        headers: Store.getters.getRequestHeaders,
        data: {
          'Points': this.$data.Points,
          'ScholarUserName': this.$data.username
        }
      })
        .then(response => {
          console.log(response)
          this.$router.push({
            // name: 'Home'
          })
        })
        .catch(error => {
          console.log(error.response)
          this.$data.error = JSON.parse(error.response.data)
          if (error.response.status === 500) {
            alert('We apologize.  We are unable to process your request at this time.')
          }
        })
      clearInterval(this.timer)
    },
    // Iframe gets recreated each time a new page is clicked.
    mounted () {
      // this.timer = setTimeout(this.earnPoints, 200000)
      // after 3 minutes 30 aseconds you can earn 2 points
      // try to resolve the problem of when the user goes to another page the timer keep son running. use clearTimeout
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
