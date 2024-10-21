<script setup lang="ts">
const receiversStore = useReceiversStore()
const { receivers } = storeToRefs(receiversStore)

await useLazyAsyncData(() => receiversStore.getReceivers())
</script>

<template>
  <div>
    <h3>Receivers:</h3>
    <ul>
      <li
        v-for="receiver in receivers"
        :key="receiver.id"
      >
        <h3>
          {{ receiver.name }}
        </h3>
      </li>
    </ul>
  </div>
</template>
