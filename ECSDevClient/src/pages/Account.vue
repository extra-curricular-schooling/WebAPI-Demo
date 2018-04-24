<template>
  <div>
    <interests/>
  </div>
</template>

<script>
import Interests from '@/components/interest-tag/Template'

export default {
  name: 'account',
  data () {
    return {
      username: this.$store.getters.getUsername,
      headers: this.$store.getters.getRequestHeaders
    }
  },
  components: {
    Interests
  }
}
</script>

<style>

</style>
