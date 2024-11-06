<script setup lang="ts">
import type { Device } from '~/domain/device'

interface Props {
  deviceType: Device['$type']
}

defineProps<Props>()
</script>

<template>
  <Icon
    v-if="deviceType === 'lightbulb'"
    name="i-material-symbols-lightbulb-2-outline-rounded"
  />
  <Icon
    v-else-if="deviceType === 'socket'"
    name="i-material-symbols-smart-outlet-outline-rounded"
  />
  <Icon
    v-else-if="deviceType === 'thermostat'"
    name="i-material-symbols-thermostat-rounded"
  />
  <Icon
    v-else-if="deviceType === 'ac'"
    name="i-material-symbols-ac-unit-rounded"
  />
</template>
