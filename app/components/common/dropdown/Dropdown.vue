<script lang="ts" setup>
</script>

<template>
  <DropdownMenuRoot>
    <slot name="trigger" />
    <DropdownMenuPortal>
      <DropdownMenuContent
        :side-offset="4"
        align="start"
        avoid-collisions
        class="grid min-w-64 w-min rounded-lg bg-white/75 p-1 shadow-lg ring-1 ring-zinc-200 backdrop-blur-xl"
        :class="$style.columns"
      >
        <slot />
      </DropdownMenuContent>
    </DropdownMenuPortal>
  </DropdownMenuRoot>
</template>

<style module>
  .columns  {
    grid-template-columns: auto 1fr;
  }
</style>
