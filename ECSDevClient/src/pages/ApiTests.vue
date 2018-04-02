<template>
  <div>
    <scholar-layout/>
    <sso-test/>
  </div>
</template>

<script>
import ScholarLayout from '@/layouts/Scholar'
import SsoTest from '@/components/sso-test/index'

export default {
  components: {
    ScholarLayout,
    SsoTest
  }
}
</script>
