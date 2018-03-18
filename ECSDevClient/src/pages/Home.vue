<template>
  <div class="EmbedContent">
    <h1>Welcome to Article Page</h1>
    <div id="myframe">
    <iframe
    src="https://ecschooling.org/"
    name="FrameResult"
    @load="mounted"
    @error="alert('Frame not loaded')"
    >
    </iframe>
    </div>
    <vue-good-table name="CreateTable" :columns="columns" :rows="rows" styleClass="table condensed table-bordered table-striped" paginate=true>
    <template slot="table-row" slot-scope="props">
    <td>{{ props.row.articleType }}</td>
    <td>{{ props.row.articleTitle }}</td>
    <td>{{ props.row.articleLink }}</td>
    <td>{{ props.row.articleDescription }}</td>
    <td>{{ props.row.articleTag }}</td>
    <a v-bind:href="props.row.articleLink" target="FrameResult">DISPLAY</a>
    </template>
    </vue-good-table>
  </div>
</template>
<script>
import Vue from 'vue'
import VueGoodTable from 'vue-good-table'
Vue.use(VueGoodTable)
export default {
  name: 'test',
  data () {
    return {
      columns: [
        {
          label: 'Article Type',
          field: 'articleType'
        },
        {
          label: 'Article Title',
          field: 'articleTitle'
        },
        {
          label: 'Article Link',
          field: 'articleLink',
          html: true
        },
        {
          label: 'Article Description',
          field: 'articleDescription'
        },
        {
          label: 'Article Tag',
          field: 'articleTag'
        }
      ],
      rows: [
        {articleType: 'School', articleTitle: 'main page', articleLink: 'http://www.ivc.edu/Pages/default.aspx', articleDescription: 'Famous School', articleTag: 'education'},
        {articleType: 'Hookah', articleTitle: 'power', articleLink: 'https://www.hookah-shisha.com/', articleDescription: 'Famous', articleTag: 'entertainment'},
        {articleType: 'King', articleTitle: 'Competition', articleLink: 'https://powerhookahus.com/', articleDescription: 'Famous Brands', articleTag: 'entertainment'},
        {articleType: 'School', articleTitle: 'BeachBoard', articleLink: 'https://bbcsulb.desire2learn.com/d2l/login?logout=1', articleDescription: 'School', articleTag: 'education'},
        {articleType: 'School', articleTitle: 'main page', articleLink: 'https://uci.edu/', articleDescription: 'Famous School', articleTag: 'education'},
        {articleType: 'Lounge', articleTitle: 'Good Ones', articleLink: 'https://www.caspianrestaurant.com/hookah-lounge', articleDescription: 'Where I go To', articleTag: 'entertainment'},
        {articleType: 'King', articleTitle: 'Competition', articleLink: 'https://www.texashookah.com/afzal.html', articleDescription: 'Famous Brands', articleTag: 'entertainment'},
        {articleType: 'School', articleTitle: 'main page', articleLink: 'http://www.ivc.edu/Pages/default.aspx', articleDescription: 'Famous School', articleTag: 'education'},
        {articleType: 'Hookah', articleTitle: 'power', articleLink: 'https://www.hookah-shisha.com/', articleDescription: 'Famous', articleTag: 'entertainment'},
        {articleType: 'OC', articleTitle: 'Home', articleLink: 'https://www.yelp.com/', articleDescription: 'Famous OC', articleTag: 'Like'},
        {articleType: 'Lounge', articleTitle: 'Good Ones', articleLink: 'http://myblufig.com/', articleDescription: 'Where I go To', articleTag: 'entertainment'}
      ]
    }
  },
  methods: {
    checkFrame: function () {
      if (document.getElementById('myframe') == null) {
        alert('Frame not created. Please reload')
      } else {
        document.getElementById('myframe').onload = alert('Done. You might be able to earn points after 1 minute.')
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
    }
  }
}
</script>
<style scoped>
iframe {
  position: relative;
  height: 700px;
  width: 100%;
  border: 8px solid black
}
</style>
