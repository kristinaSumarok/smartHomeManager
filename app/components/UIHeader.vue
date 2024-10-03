<script setup lang="ts">
</script>

<template>
  <header class="flex items-center justify-between gap-4 px-4 py-2 lg:hidden">
    <IconButton
      as="button"
      icon="i-material-symbols-menu-rounded"
      label="Open navigation"
      type="button"
      @click="console.log('here')"
    />
    <button
      type="button"
      class="rounded-full p-1 active:(bg-zinc-200/60 shadow-inset) hover:bg-zinc-950/5"
    >
      <div class="sm:hidden">
        <UIAvatar size="md" />
      </div>
      <div class="hidden sm:block">
        <UIAvatar size="sm" />
      </div>
    </button>
  </header>
</template>
