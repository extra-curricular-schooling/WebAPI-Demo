<template>
  <div class="embed_content">
    <h1>Welcome to Article Page</h1>
    <iframe src="https://ecschooling.org/" name="frame_result" height="700" width=100% style="border:8px solid black;"></iframe>
    <vue-good-table :columns="columns" :rows="rows" styleClass="table condensed table-bordered table-striped" paginate=true>
    <template slot="table-row" slot-scope="props">
    <td>{{ props.row.articleType }}</td>
    <td>{{ props.row.articleTitle }}</td>
    <td>{{ props.row.articleLink }}</td>
    <td>{{ props.row.articleDescription }}</td>
    <td>{{ props.row.articleTag }}</td>
    <a v-bind:href="props.row.articleLink" target="frame_result">DISPLAY</a>
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
        {articleType: 'School', articleTitle: 'main page', articleLink: 'http://www.ivc.edu/Pages/default.aspx', articleDescription: 'Famous School', articleTag: 'education'},
        {articleType: 'Lounge', articleTitle: 'Good Ones', articleLink: 'https://www.caspianrestaurant.com/hookah-lounge', articleDescription: 'Where I go To', articleTag: 'entertainment'},
        {articleType: 'King', articleTitle: 'Competition', articleLink: 'https://www.texashookah.com/afzal.html', articleDescription: 'Famous Brands', articleTag: 'entertainment'},
        {articleType: 'School', articleTitle: 'main page', articleLink: 'http://www.ivc.edu/Pages/default.aspx', articleDescription: 'Famous School', articleTag: 'education'},
        {articleType: 'Hookah', articleTitle: 'power', articleLink: 'https://www.hookah-shisha.com/', articleDescription: 'Famous', articleTag: 'entertainment'},
        {articleType: 'OC', articleTitle: 'Home', articleLink: 'https://www.yelp.com/', articleDescription: 'Famous OC', articleTag: 'Like'},
        {articleType: 'Lounge', articleTitle: 'Good Ones', articleLink: 'http://myblufig.com/', articleDescription: 'Where I go To', articleTag: 'entertainment'}
      ]
    }
  }
}
</script>
