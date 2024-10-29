<script setup lang="ts">
const projectsStore = useProjectsStore()
const { projects } = storeToRefs(projectsStore)

const { status } = await useLazyAsyncData(() => projectsStore.getProjects())
</script>

<template>
  <div class="grid grow-1 content-center justify-items-center">
    <div class="max-w-2xl">
      <div class="mx-auto w-fit text-3xl text-zinc-600 sm:text-4xl">
        <Icon name="i-material-symbols-draft-outline-rounded" />
      </div>
      <h1 class="mt-4 text-center text-2xl font-semibold tracking-tight sm:text-3xl">
        Open existing project
      </h1>
      <p class="mt-2 text-center text-zinc-700 leading-7">
        Or create a new one and start connecting your devices
      </p>
    </div>
    <div class="mt-8 max-w-3xl w-full">
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
          class="w-64 border border-zinc-950/10 rounded-lg bg-white px-4 py-2 shadow-sm space-y-2"
        >
          <div class="h-4 w-2/3 animate-pulse rounded bg-zinc-200" />
          <div class="h-4 w-1/3 animate-pulse rounded bg-zinc-200" />
        </div>
      </div>
    </div>
    <div class="mt-10 max-w-2xl w-full flex flex-col gap-2 sm:(flex-row items-center justify-center)">
      <Button
        as="button"
        type="button"
        leading-icon="i-material-symbols-add-2-rounded"
        label="Add project"
        variant="primary"
      />
      <Button
        as="button"
        type="button"
        trailing-icon="i-material-symbols-folder-open-outline-rounded"
        label="Open project"
      />
    </div>
  </div>
</template>
