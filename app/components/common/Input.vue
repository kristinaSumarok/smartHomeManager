<script setup lang="ts">
defineOptions({
  inheritAttrs: false,
})

interface Props {
  label: string
  name: string
  description?: string | null
  error?: string | null
}

defineProps<Props>()

const id = useId()
const model = defineModel<string>()
</script>

<template>
  <div>
    <div class="flex flex-wrap items-center justify-between gap-1">
      <Label
        class="block text-sm font-medium"
        :for="id"
      >
        {{ label }}
      </Label>
      <span
        v-if="!('required' in $attrs)"
        class="text-sm text-zinc-600"
      >
        Optional
      </span>
    </div>
    <div class="mt-2">
      <input
        :id="id"
        v-model="model"
        :name="name"
        v-bind="$attrs"
        class="block h-10 w-full appearance-none border rounded-md bg-white px-3 shadow-sm sm:(h-9 text-sm) disabled:(cursor-not-allowed opacity-60) focus-visible:(border-blue-600 outline-blue-600) placeholder:text-zinc-400"
        :aria-invalid="!!error"
        :aria-describedby="error ? `error-${id}` : undefined"
      >
    </div>
    <p
      v-if="error"
      :id="`error-${id}`"
      class="mt-2 text-sm text-red-600"
    >
      {{ error }}
    </p>
    <p
      v-else-if="description"
      class="mt-2 text-xs text-zinc-500"
      role="region"
      aria-live="polite"
    >
      {{ description }}
    </p>
  </div>
</template>
