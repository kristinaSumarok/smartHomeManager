<script setup lang="ts">
const projectsStore = useProjectsStore()
const { projects } = storeToRefs(projectsStore)

const { status } = await useLazyAsyncData(() => projectsStore.getProjects())
</script>

<template>
  <ul
    v-if="status === 'success'"
    role="list"
    class="grid cols-1 gap-2 lg:cols-3 sm:cols-2"
  >
    <li
      v-for="project in projects"
      :key="project.id"
    >
      <ProjectCard :project="project" />
    </li>
  </ul>
  <div
    v-else
    class="grid gap-2 lg:cols-3 sm:cols-2"
  >
    <div
      v-for="i in 6"
      :key="i"
      class="min-w-64 border border-zinc-950/10 rounded-lg bg-white px-4 py-2 shadow-sm space-y-2"
    >
      <div class="h-4 w-2/3 animate-pulse rounded bg-zinc-200" />
      <div class="h-4 w-1/3 animate-pulse rounded bg-zinc-200" />
    </div>
  </div>
</template>
