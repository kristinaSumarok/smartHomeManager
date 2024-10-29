<script lang="ts" setup>
</script>

<template>
  <DropdownMenuRoot>
    <slot name="trigger" />
    <DropdownMenuPortal>
      <DropdownMenuContent
        :side-offset="4"
        avoid-collisions
        class="grid min-w-80 w-min rounded-lg bg-white/75 p-1 shadow-lg ring-1 ring-zinc-200 backdrop-blur-xl lg:min-w-64"
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
