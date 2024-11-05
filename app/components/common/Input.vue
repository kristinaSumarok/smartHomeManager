<script setup lang="ts">
defineOptions({
  inheritAttrs: false,
})

interface Props {
  label: string
  name: string
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
        v-if="'required' in $attrs"
        class="text-sm text-red-600"
      >
        Required
      </span>
    </div>
    <div class="mt-2">
      <input
        :id="id"
        v-model="model"
        :name="name"
        v-bind="$attrs"
        class="block h-10 w-full appearance-none border rounded-md bg-white px-3 shadow-sm sm:(h-9 text-sm) disabled:(cursor-not-allowed border-zinc-950/10 bg-zinc-950/10 text-zinc-600) focus-visible:border-blue-500 placeholder:text-zinc-400"
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
  </div>
</template>
