<script setup lang="ts">
defineOptions({
  inheritAttrs: false,
})

interface Props {
  as?: unknown
  label: string
}

const { as = 'a' } = defineProps<Props>()
</script>

<template>
  <li>
    <component
      :is="as"
      class="block text-sm text-zinc-700 font-medium hover:text-zinc-900"
      v-bind="$attrs"
    >
      {{ label }}
    </component>
  </li>
</template>
