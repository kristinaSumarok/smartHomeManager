<script setup lang="ts">
interface Props {
  label?: string
}

defineProps<Props>()
</script>

<template>
  <DropdownMenuTrigger as-child>
    <slot>
      <button class="group h-9 w-full flex items-center gap-2 border border-zinc-400/20 rounded-md px-2 text-sm font-medium shadow-sm active:(bg-zinc-950/10 shadow-inset) hover:bg-zinc-950/5">
        <span class="min-w-0 flex-1 truncate text-left">{{ label }}</span>
        <span class="text-zinc-500 group-hover:text-zinc-600">
          <Icon name="i-material-symbols-unfold-more-rounded" />
        </span>
      </button>
    </slot>
  </DropdownMenuTrigger>
</template>
