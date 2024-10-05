<script setup lang="ts">
interface Props {
  label?: string
  icon?: string
}

defineProps<Props>()
</script>

<template>
  <DropdownMenuTrigger as-child>
    <slot>
      <button class="group h-9 w-full flex items-center gap-2 border border-zinc-400/20 rounded-md px-2 text-sm font-medium shadow-sm active:(bg-zinc-950/10 shadow-inset) hover:bg-zinc-950/5">
        <slot name="label">
          <span
            v-if="label"
            class="min-w-0 flex-1 truncate text-left"
          >
            {{ label }}
          </span>
        </slot>
        <slot name="icon">
          <span
            v-if="icon"
            class="text-zinc-500 group-hover:text-zinc-600"
          >
            <Icon :name="icon" />
          </span>
        </slot>
      </button>
    </slot>
  </DropdownMenuTrigger>
</template>
