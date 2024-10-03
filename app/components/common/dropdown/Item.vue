<script lang="ts" setup>
interface Props {
  as?: unknown
  label: string
  icon?: string
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
      class="group grid col-span-full grid-cols-subgrid h-9 items-center gap-2 rounded-md px-3 text-sm data-[highlighted]:bg-zinc-950/5"
    >
      <slot name="icon">
        <span
          v-if="icon"
          class="text-zinc-500 group-hover:text-zinc-600"
        >
          <Icon :name="icon" />
        </span>
      </slot>
      <slot name="label">
        <span
          v-if="label"
          class="col-start-2 truncate"
        >
          {{ label }}
        </span>
      </slot>
    </component>
  </DropdownMenuItem>
</template>
