<template>
<div id="Home">
  <Slideout menu="#sidebar" panel="#EmbedContent" :toggleSelectors="['.toggle-button']" @on-open="open">
  <nav id="sidebar">
    <div>Interests</div>
    <div class="container vue" id="Interests">
      <div class="column">
        <div id ="groups"  v-for="group in groups" :key="group.name">
          <a id="groupName" v-text="group.name"  @click="group.open=!group.open" ></a>
          <ul v-show="group.open">
            <ul class="button is-link" id="articles" v-for="article in group.articles" :key="article" v-text="article.title" v-on:click="target(article.url)">
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
    <iframe src="https://ecschooling.org/" id = "FrameResult" name="FrameResult" @load="mounted" @error="alert('Frame not loaded')" height="700" width=100% style="border:8px solid black;" ></iframe>
  </main>
  </Slideout>
</div>
</template>
<script>

// import Vue from 'vue'
import Slideout from 'vue-slideout'
var groups = {
  'Arts & Design': {
    'name': 'Arts & Design',
    'open': false,
    'articles': [
      {
        'title': 'article 1',
        'url': 'http://www.ivc.edu/Pages/default.aspx'
      },
      {
        'title': 'article 2',
        'url': 'https://www.hookah-shisha.com/'
      }
    ]
  },
  'Technology': {
    'name': 'Technology',
    'open': false,
    'articles': [
      {
        'title': 'article 1',
        'url': 'http://www.ivc.edu/Pages/default.aspx'
      },
      {
        'title': 'article 2',
        'url': 'https://www.hookah-shisha.com/'
      }
    ]
  },
  'Education': {
    'name': 'Education',
    'open': false,
    'articles': [
      {
        'title': 'article 1',
        'url': 'http://www.ivc.edu/Pages/default.aspx'
      },
      {
        'title': 'article 2',
        'url': 'https://www.hookah-shisha.com/'
      }
    ]
  },
  'Environmental': {
    'name': 'Environmental',
    'open': false,
    'articles': [
      {
        'title': 'article 1',
        'url': 'http://www.ivc.edu/Pages/default.aspx'
      },
      {
        'title': 'article 2',
        'url': 'https://www.hookah-shisha.com/'
      }
    ]
  },
  'History': {
    'name': 'History',
    'open': false,
    'articles': [
      {
        'title': 'article 1',
        'url': 'http://www.ivc.edu/Pages/default.aspx'
      },
      {
        'title': 'article 2',
        'url': 'https://www.hookah-shisha.com/'
      }
    ]
  },
  'Medicine': {
    'name': 'Medicine',
    'open': false,
    'articles': [
      {
        'title': 'article 1',
        'url': 'http://www.ivc.edu/Pages/default.aspx'
      },
      {
        'title': 'article 2',
        'url': 'https://www.hookah-shisha.com/'
      }
    ]
  },
  'Business': {
    'name': 'Business',
    'open': false,
    'articles': [
      {
        'title': 'article 1',
        'url': 'http://www.ivc.edu/Pages/default.aspx'
      },
      {
        'title': 'article 2',
        'url': 'https://www.hookah-shisha.com/'
      }
    ]
  }
}

export default {
  name: 'home',
  components: {
    Slideout
  },
  methods: {
    checkFrame: function () {
      if (document.getElementById('FrameResult') == null) {
        alert('Frame not created. Please reload')
      } else {
        document.getElementById('FrameResult').onload = alert('Done. You might be able to earn points after 1 minute.')
      }
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
    },
    target: function (link) {
      console.log('target clicked')
      document.getElementById('FrameResult').src = link
    }
  },
  data () {
    return {
      groups: groups
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
    width: 256px;
    height: 100vh;
    overflow-y: scroll;
    -webkit-overflow-scrolling: touch;
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
  .slideout-open,
  .slideout-open body,
  .slideout-open .slideout-panel {
    overflow: hidden;
  }
  .slideout-open .slideout-menu {
    display: block;
  }
  .toggle-button {
    position: absolute;
    left: 0%;
    top: 35%;
    font-size:180%;
  }
  #Interests{
    position: fixed;
    width: 250px;
  }

  #articles{
    display: block;
    border: .3px solid;
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
