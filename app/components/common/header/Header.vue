<script setup lang="ts">

</script>

<template>
  <div class="mx-auto max-w-screen-xl px-6 lg:px-10">
    <nav
      class="h-16 flex items-center justify-between gap-8"
      aria-label="Global navigation"
    >
      <div class="shrink-0 -ml-2 lg:hidden">
        <slot name="menu" />
      </div>
      <ul
        v-if="$slots.default"
        class="hidden items-center gap-8 lg:flex"
      >
        <slot />
      </ul>
      <div class="shrink-0 -mr-1">
        <UserMenu />
      </div>
    </nav>
  </div>
</template>
