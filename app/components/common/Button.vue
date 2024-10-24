<script setup lang="ts">
const variants = {
  primary: 'border-blue-950/10 bg-blue-600 text-white active:bg-blue-700 hover:bg-blue-500 focus-visible:outline-blue-600',
  secondary: 'border-zinc-950/10 bg-zinc-950/5 text-gray-900 shadow-sm active:bg-zinc-950/15 hover:bg-zinc-950/10',
  outline: 'border-zinc-950/10 text-gray-900 shadow-sm active:bg-zinc-950/10 hover:bg-zinc-950/5',
  destructive: 'border-zinc-950/10 bg-zinc-950/5 text-red-600 underline underline-offset-1 shadow-sm active:(bg-red-700 text-white no-underline) hover:(bg-red-600 text-white no-underline) focus-visible:outline-red-600',
}

type Variant = keyof typeof variants

interface Props {
  as?: unknown
  label: string
  variant?: Variant
  leadingIcon?: string
  trailingIcon?: string
}

const { as = 'button', variant = 'secondary' } = defineProps<Props>()

const iconVariants = {
  primary: 'text-blue-50',
  secondary: 'text-zinc-800',
  outline: 'text-zinc-800',
  destructive: 'text-red-500 group-hover/button:text-red-50 group-active/button:text-red-50',
} satisfies Record<Variant, string>
</script>

<template>
  <component
    :is="as"
    class="group/button relative h-10 min-w-fit inline-flex items-center justify-center gap-2 border rounded-md px-4 text-sm font-semibold sm:(h-9 px-3) active:shadow-inner focus-visible:(ring ring-white ring-inset)"
    :class="variants[variant]"
  >
    <span
      v-if="leadingIcon"
      :class="iconVariants[variant]"
    >
      <Icon :name="leadingIcon" />
    </span>

    {{ label }}

    <span
      v-if="trailingIcon"
      :class="iconVariants[variant]"
    >
      <Icon :name="trailingIcon" />
    </span>
  </component>
</template>
