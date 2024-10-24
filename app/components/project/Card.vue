<script setup lang="ts">
import type { Project } from '~/domain/project'

interface Props {
  project: Project
}

const { project } = defineProps<Props>()

const initials = project.name
  .split(' ')
  .map(name => name.at(0)!)
  .filter(name => /^[A-Za-z]$/.test(name))
  .slice(0, 3)
  .join('')
  .toUpperCase()
</script>

<template>
  <div class="group/card relative flex rounded-lg bg-white shadow-sm active:(bg-zinc-950/10 shadow-inner) hover:bg-zinc-950/5">
    <div class="w-16 flex shrink-0 items-center justify-center border border-zinc-950/10 border-rounded-l-lg border-r-none bg-zinc-200 text-sm text-zinc-600 font-medium tracking-wide uppercase group-hover/card:(border-blue-950/10 bg-blue-500 text-blue-50) group-active/card:(text-white shadow-inner bg-blue-600!)">
      {{ initials }}
    </div>
    <div class="flex-1 overflow-hidden border border-zinc-950/10 border-rounded-r-lg border-l-none px-4 py-2">
      <h3 class="truncate text-sm font-medium">
        <NuxtLink
          :to="{ name: 'projects-id', params: { id: project.id } }"
        >
          {{ project.name }}
          <span
            class="absolute inset-0"
            aria-hidden="true"
          />
        </NuxtLink>
      </h3>
      <p class="text-sm text-zinc-500 group-active/card:text-zinc-700 group-hover/card:text-zinc-700">
        some metadata
      </p>
    </div>
  </div>
</template>
