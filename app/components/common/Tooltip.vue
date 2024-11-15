<script setup lang="ts">
interface Props {
  label: string
}

defineProps<Props>()
</script>

<template>
  <TooltipProvider :delay-duration="500">
    <TooltipRoot>
      <TooltipTrigger as-child>
        <slot />
      </TooltipTrigger>
      <TooltipPortal>
        <TooltipContent
          class="select-none rounded bg-zinc-950/90 px-2 py-1 text-xs text-white shadow-sm will-change-opacity data-[state=delayed-open]:animate-fade-in !animate-duration-100 !animate-ease-out"
          :side-offset="2"
        >
          {{ label }}
          <TooltipArrow
            class="fill-zinc-950/90"
            :width="8"
          />
        </TooltipContent>
      </TooltipPortal>
    </TooltipRoot>
  </TooltipProvider>
</template>
