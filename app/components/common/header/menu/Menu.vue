<script setup lang="ts">
</script>

<template>
  <DialogRoot>
    <DialogTrigger as-child>
      <IconButton
        as="button"
        type="button"
        icon="i-material-symbols-menu-rounded"
        label="Open navigation drawer"
      />
    </DialogTrigger>
    <DialogPortal>
      <DialogOverlay class="fixed inset-0 bg-zinc-950/25" />
      <DialogContent
        :aria-describedby="undefined"
        class="fixed inset-y-0 left-0 max-w-sm w-full p-2"
      >
        <div class="h-full rounded-lg bg-white shadow-lg ring-1 ring-zinc-200">
          <div class="min-h-full flex flex-col">
            <div class="border-b border-zinc-200 p-4">
              <div class="-m-1">
                <DialogClose as-child>
                  <IconButton
                    as="button"
                    type="button"
                    icon="i-material-symbols-close-rounded"
                    label="Close navigation drawer"
                  />
                </DialogClose>
              </div>
              <VisuallyHidden as-child>
                <DialogTitle>
                  Mobile navigation drawer
                </DialogTitle>
              </VisuallyHidden>
            </div>
            <div class="grid flex-1 p-4">
              <slot name="content">
                <nav class="px-2 py-4">
                  <ul class="space-y-6">
                    <slot />
                  </ul>
                </nav>
              </slot>
            </div>
            <div class="border-t border-zinc-200 p-4">
              <div class="p-2">
                <p class="text-xs text-zinc-600">
                  &copy; 2024 Homemap, Ltd.
                </p>
              </div>
            </div>
          </div>
        </div>
      </DialogContent>
    </DialogPortal>
  </DialogRoot>
</template>
