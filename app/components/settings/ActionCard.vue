<script setup lang="ts">
interface Props {
  title: string
  description: string
}

defineProps<Props>()
</script>

<template>
  <div class="flex flex-wrap items-center justify-between gap-4 border rounded-lg p-4 shadow-sm">
    <div class="max-w-md">
      <h3 class="text-sm font-semibold leading-6">
        {{ title }}
      </h3>
      <p class="text-sm text-zinc-600 leading-6">
        {{ description }}
      </p>
    </div>
    <slot>
      <Button
        as="button"
        type="button"
        label="Commit action"
      />
    </slot>
  </div>
</template>
