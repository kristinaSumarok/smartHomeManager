<script setup lang="ts">
interface Props {
  title: string
  description?: string
  icon?: string
}

defineProps<Props>()
</script>

<template>
  <AlertDialogRoot>
    <slot name="trigger" />
    <AlertDialogPortal>
      <AlertDialogOverlay class="fixed inset-0 bg-zinc-950/20" />
      <div class="pointer-events-none fixed inset-0 flex items-center justify-center p-4 sm:p-8">
        <AlertDialogContent
          class="max-w-md border border-zinc-950/10 rounded-lg bg-white px-4 py-6 shadow-lg space-y-4 sm:px-6 focus:outline-none"
        >
          <div
            v-if="icon"
            class="mx-auto size-16 flex items-center justify-center border rounded-lg text-3xl text-blue-600 shadow-sm sm:text-4xl"
          >
            <Icon :name="icon" />
          </div>
          <AlertDialogTitle class="text-center font-semibold">
            {{ title }}
          </AlertDialogTitle>
          <slot>
            <AlertDescription>
              <p class="text-center text-sm text-zinc-600 leading-6">
                {{ description }}
              </p>
            </AlertDescription>
          </slot>
          <div class="flex flex-col-reverse gap-2 pt-4 sm:flex-row sm:*:flex-1">
            <slot name="actions" />
          </div>
        </AlertDialogContent>
      </div>
    </AlertDialogPortal>
  </AlertDialogRoot>
</template>
