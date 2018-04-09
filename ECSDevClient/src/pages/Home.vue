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

export default {
  name: 'home',
  components: {
    ErrorModal,
    LinkedInPostModal,
    RedirectModal,
    SideBar
  },
  methods: {
    checkFrame: function () {
      // if (document.getElementById('FrameResult') == null) {
      //   alert('Frame not created. Please reload')
      // } else {
      //   document.getElementById('FrameResult').onload = alert('Done. You might be able to earn points after 1 minute.')
      // }
    },
    // timerPage: function () {
    //   setTimeout(function () {
    //     document.getElementById('myframe').innerHTML = 'Failed To Load'
    //   }, 5000)
    // },
    // need timeout if the page is not rendered in 5 seconds.Have to do this is for earning points.
    // or what really happening is the iframe gets recreated each time a new page is clicked.
    // add a method to the else above if loads start timer and give points
    // onload="alert('Done Loading')"
    // onerror="alert('failed to load')"
    mounted () {
      this.$nextTick(function (checkFrame) {
        this.checkFrame()
      }
      )
    },
    data () {
      return {
        username: this.$store.getters.getUsername,
        headers: this.$store.getters.getRequestHeaders
      }
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
