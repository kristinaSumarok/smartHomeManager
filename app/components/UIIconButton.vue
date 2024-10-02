<script setup lang="ts">
type HTMLTag = 'a' | 'button' | 'input' | 'div'

interface Props {
  as?: HTMLTag
  icon: string
  label: string
}

const { as = 'div', icon, label } = defineProps<Props>()
</script>

<template>
  <component
    :is="as"
    class="size-10 inline-flex items-center justify-center rounded-md text-xl text-zinc-500 sm:(size-9 text-lg) active:(bg-zinc-950/10 text-zinc-900 shadow-inner) hover:(bg-zinc-950/5 text-zinc-900)"
    v-bind="$attrs"
  >
    <UIIcon :name="icon" />
    <span class="sr-only">{{ label }}</span>
  </component>
</template>
