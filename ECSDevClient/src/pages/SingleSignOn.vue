<template>
  <div>
    <loading-modal/>>
  </div>
</template>

<script>
import EventBus from '@/assets/js/EventBus'
import LoadingModal from '@/components/loading-modal/Template'

export default {
  components: {
    EventBus,
    LoadingModal
  },
  mounted () {
    EventBus.$emit('loading')
  },
  methods: {
    toggleLoadingModal: function () {
    }
  }
}
</script>

<style>

</style>
