<template>
<div id="Home">
  <Slideout menu="#sidebar" panel="#EmbedContent" :toggleSelectors="['.toggle-button']" @on-open="open">
  <nav id="sidebar">
    <div>Interests</div>
    <div class="container vue" id="Interests">
      <div class="column">
        <div id ="groups"  v-for="group in groups" :key="group.articles[0].interestTag">
          <a id="groupName" v-text="group.name"  @click="group.open = !group.open" ></a>
          <ul v-show="true">
            <ul class="button is-link" id="articles" v-for="article in group.articles" :key="article.title" v-text="article.title" v-on:click="target(group.name, article.title, article.url)">
            </ul>
          </ul>
        </div>
      </div>
    </div>
  </nav>
  <main id="EmbedContent">
    <header>
      <div>
        <button class="toggle-button">☰</button>
      </div>
    </header>
    <h1>Welcome to Article Page</h1>
    <iframe src="https://www.ecschooling.org" id = "FrameResult" name="FrameResult" @load="mounted" @error="alert('Frame not loaded')" height="700" width=100% style="border:8px solid black;" ></iframe>
  </main>
  </Slideout>
  <LinkedInPostModal/>
  <RedirectModal/>
  <ErrorModal/>
</div>
</template>

<script>
import ErrorModal from '../components/Error-Modal/index'
import LinkedInPostModal from '../components/LinkedIn-Modal/Index'
import RedirectModal from '../components/Redirect-Modal/index'
import EventBus from '../assets/js/EventBus.js'
import Slideout from 'vue-slideout'
import Axios from 'axios'
var groups = {}

export default {
  name: 'home',
  components: {
    ErrorModal,
    LinkedInPostModal,
    RedirectModal,
    Slideout
  },
  methods: {
    retieveArticles: function (username) {
      Axios({
        method: 'GET',
        url: 'https://localhost:44311/Home/' + username
      })
        .then((response) => {
          this.groups = {}
          response.data.$values.forEach(group => {
            this.groups[group.$values[0].interestTag] = {
              'name': group.$values[0].interestTag,
              'open': false,
              'articles': []
            }
            group.$values.forEach(article => {
              this.groups[article.interestTag].articles.push(
                {
                  'title': article.articleTitle,
                  'description': article.articleDescription,
                  'url': article.articleLink
                }
              )
            })
          })
        })
        .catch(e => {
          console.log(e)
          return e
        })
    },
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
    open: function () {
      console.log('slideoutOpen')
      this.retieveArticles(this.username)
    },
    target: function (tag, title, link) {
      console.log('target clicked')
      console.log(tag)
      document.getElementById('FrameResult').src = link
      this.$store.dispatch('updateInterestTag', tag)
      this.$store.dispatch('updateArticle', link)
      this.$store.dispatch('updateTitle', title)
      EventBus.$emit('articleChosen')
    }
  },
  created () {
    this.retieveArticles(this.username)
  },
  data () {
    return {
      groups: groups,
      username: this.$store.getters.getUsername,
      headers: this.$store.getters.getRequestHeaders
      // groups: []
    }
  }
}
</script>
<style>
  body {
    width: 100%;
    height: 100%;
    margin: 0;
  }
   .slideout-menu {
    position: fixed;
    top: 0;
    bottom: 0;
    width: 276px;
    height: 100vh;
    z-index: 0;
    display: none;
    background-color: #1D1F20;
    color: white;
  }
   .slideout-menu-left {
    left: 0;
  }
   .slideout-menu-right {
    right: 0;
  }
  .slideout-panel {
    position: relative;
    z-index: 1;
    will-change: transform;
    min-height: 100vh;
  }
  .slideout-open .slideout-menu {
    display: block;
    overflow: scroll;
  }
  .toggle-button {
    position: absolute;
    left: 0%;
    top: 35%;
    font-size:180%;
  }
  #Interests{
    position: fixed;
    width: 270px;
  }

  #articles{
    display: block;
    border: .3px solid;
    font-size:8pt
  }
  #articles:active{
    color:white;
  }

  #groups{
    display: block;
    border: .5px solid;
    cursor: pointer;
    padding: 5px;
    color: white;
  }
  #groups:active{
    color: blue;
    box-shadow: 0 0 5px -1px rgba(0,0,0,0.6);
  }
  #groupName{
    color:white;
  }
  #groupName:active{
    color:blue;
  }
</style>
