<template>
  <div>
    <h1 class="title">
      About Us
    </h1>
    <div></div>
    <section class="hero is-light">
        <div class="hero-body">
            <div class="container is-fluid">
                <div class="box">
                    <div class="container is-fluid">
                        <h1 class="sub-title">
                            What do we do?
                        </h1>
                        <p/>
                    </div>
                    <div class="container is-fluid">
                        <h3 class="subtitle">
                            Well it all began on a nice day, very typical for Southern California. The sun is out and there is frolic and laugher all
                            around. And then a sudden realization was made. The senior project had begun and neigh an idea
                            was to be had. So out of the blue, Sir Scott came up with this idea for which we have implemented
                            here today. Sooner or later, someone, somewhere, with actual ideas that can be expressed in tangible
                            words, will edit out this masterpiece, and in turn, put something less awesome but probably more
                            appropriate for our cause. Until that day arrives,
                            <strong>I love this class. I don't lose sleep to this project at all.</strong> Honestly though, all BS
                            aside, I learned alot and will forever be grateful. Keep your head up guys.
                            <strong>Almost done!</strong>
                        </h3>
                    </div>
                </div>
            </div>
            <div class="container is-fluid">
                <div class="box">
                    <div class="container is-fluid">
                        <h1 class="sub-title">
                            Who can you contact?
                        </h1>
                        <p/>
                    </div>
                    <div class="container is-fluid" align="left">
                        <h3 class="subtitle">
                            <vue-good-table
                              :columns="columns"
                              :rows="rows"
                              @on-row-click='onRowClick'>
                            </vue-good-table>
                        </h3>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <img src="../assets/images/thumbs-up.jpg" alt="Thumbs Up!" height="300" width="300">
  </div>
</template>

<script>
export default {
  data () {
    return {
      columns: [
        {
          label: 'Name',
          field: 'name'
        },
        {
          label: 'Email',
          field: 'email'
        }
      ],
      rows: [
        { name: 'Luis Pedroza-Soto', email: 'example' },
        { name: 'Scott Roberts', email: 's.e.roberts0@gmail.com' },
        { name: 'Hugo Garcia', email: 'example' },
        { name: 'Kris Cubie', email: 'example' },
        { name: 'Trisha Eschual', email: 'example' },
        { name: 'Furkan Arif', email: 'example' }
      ]
    }
  },
  methods: {
    onRowClick (params) {
      console.log(params.row)
    }
  }
}
</script>
