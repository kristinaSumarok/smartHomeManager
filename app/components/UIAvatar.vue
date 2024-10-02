<script setup lang="ts">
const userInitials = 'PM'

const sizes = {
  sm: 'size-7 text-sm rounded-full',
  md: 'size-8 text-base rounded-full',
  lg: 'size-10 text-lg rounded-md',
}

interface Props {
  size?: keyof typeof sizes
}

const { size = 'md' } = defineProps<Props>()
</script>

<template>
  <div
    class="inline-flex items-center justify-center border border-zinc-200 bg-zinc-50 text-zinc-700 font-medium uppercase"
    :class="sizes[size]"
  >
    <span>{{ userInitials }}</span>
  </div>
</template>
