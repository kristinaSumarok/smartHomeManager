<script setup lang="ts">
import type { NuxtLinkProps } from '#app'

interface Props {
  label: string
  to: NuxtLinkProps['to']
  icon?: string
}

const { to, label, icon } = defineProps<Props>()
</script>

<template>
  <NuxtLink
    :to="to"
    class="group relative h-9 flex items-center gap-3 rounded-md p-2 text-sm font-medium active:(bg-zinc-950/10 shadow-inset) hover:bg-zinc-950/5"
    exact-active-class="bg-zinc-200"
  >
    <span
      class="absolute top-1/2 hidden h-6 w-1 rounded-full bg-blue-600 transition-height -left-2 group-[[aria-current=page]]:block group-hover:h-7 -translate-y-1/2"
      aria-hidden="true"
    />

    <span
      v-if="icon"
      class="text-base text-zinc-500 group-[[aria-current=page]]:text-zinc-700 group-hover:text-zinc-800"
    >
      <Icon :name="icon" />
    </span>

    <span class="truncate">{{ label }}</span>
  </NuxtLink>
</template>
