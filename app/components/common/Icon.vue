<script setup lang="ts">
const { name } = defineProps<{ name: string }>()
</script>

<template>
  <span
    class="block"
    :class="name"
    aria-hidden="true"
  />
</template>

<style scoped>
  span {
    margin-left: -0.125em;
    margin-right: -0.125em;
  }

  @media (forced-colors: active) {
    span {
      background-color: CanvasText;
    }
  }
</style>
