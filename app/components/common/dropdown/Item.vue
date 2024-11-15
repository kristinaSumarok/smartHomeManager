<script lang="ts" setup>
defineOptions({
  inheritAttrs: false,
})

interface Props {
  as?: unknown
  label: string
  icon?: string
  variant?: 'default' | 'destructive'
}

defineProps<Props>()
</script>

<template>
  <DropdownMenuItem
    as-child
  >
    <component
      :is="as"
      v-bind="$attrs"
      class="group grid col-span-full grid-cols-subgrid h-10 items-center justify-start gap-2 rounded-md px-3 text-sm sm:h-9 data-[highlighted]:bg-zinc-950/5"
      :class="variant === 'destructive' && 'text-red-600'"
    >
      <slot name="icon">
        <span
          v-if="icon"
          :class="variant === 'destructive' ? 'text-red-500' : 'text-zinc-500 group-hover:text-zinc-600'"
        >
          <Icon :name="icon" />
        </span>
      </slot>
      <slot name="label">
        <span
          v-if="label"
          class="col-start-2 truncate text-start"
        >
          {{ label }}
        </span>
      </slot>
    </component>
  </DropdownMenuItem>
</template>
