<script setup lang="ts">
import { useReceiversStore } from '@/stores/receivers'

const receiversStore = useReceiversStore()
const { receivers } = storeToRefs(receiversStore)

const { status } = await useLazyAsyncData(() => receiversStore.getReceivers())
</script>

<template>
  <div>
    <ul
      v-if="status === 'success'"
    >
      <li
        v-for="receiver in receivers"
        :key="receiver.id"
      >
        <h3>
          {{ receiver.name }}
        </h3>
      </li>
    </ul>
    <span v-else>
      loading or error
    </span>
  </div>
</template>
