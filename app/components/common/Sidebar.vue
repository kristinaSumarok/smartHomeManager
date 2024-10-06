<script setup lang="ts">
</script>

<template>
  <div class="fixed inset-y-0 left-0 w-64">
    <nav
      class="h-full flex flex-col"
      aria-label="Sidebar navigation"
    >
      <div class="border-b border-zinc-200 p-4 space-y-2">
        <slot name="header" />
      </div>
      <div class="flex-1 p-4">
        <div class="grid gap-1">
          <slot />
        </div>
      </div>
      <div class="border-t border-zinc-200 p-4">
        <slot name="footer" />
      </div>
    </nav>
  </div>
</template>
