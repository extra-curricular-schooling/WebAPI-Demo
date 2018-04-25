<template>
  <div>
    <vue-good-table
      title="Simple Table"
      :columns="columns"
      :rows="rows">
    </vue-good-table>
  </div>
</template>

<script>
import VueGoodTable from 'vue-good-table'
export default {
  components: {
    VueGoodTable
  },
  data () {
    return {
      columns: [
        {
          label: 'Name',
          field: 'name'
        },
        {
          label: 'Age',
          field: 'age',
          type: 'number'
        },
        {
          label: 'Joined On',
          field: 'joined',
          type: 'date',
          inputFormat: 'YYYYMMDD',
          outputFormat: 'MMM Do YYYY'
        }
      ],
      rows: [
        { name: 'Scott', age: 20, joined: '20120201' },
        { name: 'Kris', age: 24, joined: '20120305' },
        { name: 'Trisha', age: 16, joined: '20140823' },
        { name: 'Luis', age: 55, joined: '20161109' },
        { name: 'Furkan', age: 40, joined: '20170612' },
        { name: 'Hugo', age: 30, joined: '20170612' }
      ]
    }
  }
}
</script>

<style>

</style>
