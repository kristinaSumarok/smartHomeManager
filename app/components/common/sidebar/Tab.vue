<script setup lang="ts">
defineOptions({
  inheritAttrs: false,
})

interface Props {
  as?: unknown
  label: string
  icon?: string
}

const { as = 'div', label, icon } = defineProps<Props>()
</script>

<template>
  <div class="relative">
    <component
      :is="as"
      v-bind="$attrs"
      class="peer group h-9 flex items-center gap-3 rounded-md p-2 text-sm font-medium active:(bg-zinc-950/10 shadow-inner) aria-[current=page]:bg-zinc-200 hover:bg-zinc-950/5"
    >
      <span
        v-if="icon"
        class="text-base text-zinc-500 group-[[aria-current=page]]:text-zinc-700 group-hover:text-zinc-800"
      >
        <Icon :name="icon" />
      </span>
      <span class="truncate">{{ label }}</span>
    </component>
    <span
      class="absolute top-1/2 hidden h-6 w-1 rounded-full bg-blue-600 transition-height -left-2 peer-[[aria-current=page]]:block peer-hover:h-7 -translate-y-1/2"
      aria-hidden="true"
    />
  </div>
</template>
