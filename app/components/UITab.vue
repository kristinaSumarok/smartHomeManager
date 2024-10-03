<script setup lang="ts">
interface Props {
  label: string
  href: string
  icon?: string
  isActive?: boolean
}

const { href, label, icon, isActive = false } = defineProps<Props>()
</script>

<template>
  <a
    :href="href"
    class="group relative h-9 flex items-center gap-3 rounded-md p-2 text-sm font-medium active:(bg-zinc-950/10 shadow-inset) aria-[current=page]:bg-zinc-200 hover:bg-zinc-950/5"
    :aria-current="isActive ? 'page' : 'false'"
  >
    <span
      v-if="isActive"
      class="absolute inset-y-1 w-1 rounded-full bg-blue-600 -left-2"
      aria-hidden="true"
    />

    <span
      v-if="icon"
      class="text-base text-zinc-500 group-hover:text-zinc-900"
    >
      <Icon :name="icon" />
    </span>

    <span class="truncate">{{ label }}</span>
  </a>
</template>
