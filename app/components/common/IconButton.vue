<script setup lang="ts">
interface Props {
  as?: unknown
  icon: string
  label: string
}

const { as = 'button', icon, label } = defineProps<Props>()
</script>

<template>
  <component
    :is="as"
    class="size-10 inline-flex items-center justify-center rounded-md text-lg text-zinc-500 sm:(size-9 text-base) active:(bg-zinc-950/10 text-zinc-900 shadow-inner) hover:(bg-zinc-950/5 text-zinc-900)"
  >
    <Icon :name="icon" />
    <span class="sr-only">{{ label }}</span>
  </component>
</template>
