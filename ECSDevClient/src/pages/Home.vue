<template>
  <div id="Home" class="container is-fullhd">
    <SideBar/>
    <main id="EmbedContent" class="box" style="background-color: hsl(0, 0%, 96%); border-radius: 0px;">
      <button class="toggle-button">☰</button>
      <iframe class="box" src="http://hugogarcia.me/site/ecsHelp" id = "FrameResult" name="FrameResult" @load="mounted" @error="alert('Frame not loaded')" sandbox=""></iframe>
      <div class="box" style="width: 90%; display: inline-block;">
        <LinkedInPostModal/>
      </div>
    </main>
    <div style="height: 1px;"/>
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
import Swal from 'sweetalert2'
import EventBus from '@/assets/js/EventBus.js'
export default {
  name: 'home',
  data () {
    return {
      username: this.$store.getters.getUsername,
      headers: this.$store.getters.getRequestHeaders,
      Points: 2,
      FirstLoad: true,
      interval: null
    }
  },
  components: {
    ErrorModal,
    LinkedInPostModal,
    RedirectModal,
    SideBar
  },
  created () {
    var success = this.getParameterByName('linkedin')
    if (success !== null) {
      if (success === 'success') {
        Swal({
          title: 'Success!',
          text: 'You have now been linked to your LinkedIn profile!',
          type: 'success',
          toast: true,
          imageUrl: 'http://cliparting.com/wp-content/uploads/2016/08/Great-job-excellent-job-clipart-clipart-kid.png',
          imageHeight: '50px',
          imageWidth: '50px'
        })
      }
    }
  },
  methods: {
    // REQUEST TO POST POINTS TO THE SCHOLAR POINTS AFTER ARTICLE HAS BEEN READ
    earnPoints: function (username, Points) {
      Axios({
        method: 'POST',
        url: Store.getters.getBaseAppUrl + 'SweepstakeAdmin/UpdatePoints/' + this.username,
        headers: Store.getters.getRequestHeaders,
        data: {
          'Points': this.$data.Points,
          'ScholarUserName': this.$data.username
        }
      }) // Alert user they earned points if server responds with ok
        .then(response => {
          Swal({
            title: 'WooHoo!',
            text: 'You earned ' + this.Points + ' points!',
            type: 'success',
            toast: true,
            imageUrl: 'http://cliparting.com/wp-content/uploads/2016/08/Great-job-excellent-job-clipart-clipart-kid.png',
            imageHeight: '50px',
            imageWidth: '50px',
            timer: 2000,
            showConfirmButton: false
          }).then(result => {
            if (result.dismiss === Swal.DismissReason.timer) {

            }
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
    getParameterByName: function (name, url) {
      if (!url) {
        url = window.location.href
      }
      // eslint-disable-next-line
      name = name.replace(/[\[\]]/g, '\\$&')
      var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)')
      var results = regex.exec(url)
      if (!results) {
        return null
      }
      if (!results[2]) {
        return ''
      }
      return decodeURIComponent(results[2].replace(/\+/g, ' '))
    },
    // Iframe gets recreated each time a new page is clicked.
    mounted () {
      // If user barely logs in, does not start timer.
      if (this.FirstLoad) {
        this.FirstLoad = false
      } else {
        this.interval = setTimeout(this.earnPoints, 1000)
        // listen for eventbus to cancel the time interval is user leaves home.
        EventBus.$on('cancelInterval', cancelInterval => {
          clearInterval(this.interval)
        })
      }
      // after 3 minutes 30 aseconds you can earn 2 points
    }
  }
}
</script>
<style lang="scss" scoped>
  body {
    width: 100%;
    height: 100%;
    margin: 0;
  }
  .toggle-button {
    height: 90%;
    position: absolute;
    border: 0px;
    background-color:  #ffffff;
    display: inline-block;
    -webkit-border-radius: 15px 150px 150px 15px;
    -moz-border-radius: 15px 150px 150px 15px;
    -ms-border-radius: 15px 150px 150px 15px;
    border-radius: 15px 150px 150px 15px;
    left: 0%;
    font-size:1em;
  }

  .toggle-button:hover {
    @extend .toggle-button;
    background-color:  #f2f2f2;
  }

  #FrameResult{
    display: inline-block;
    padding: 1em;
    height: 700px;
    width: 90%;
  }
</style>
