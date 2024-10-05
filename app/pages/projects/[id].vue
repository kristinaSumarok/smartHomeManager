<script setup lang="ts">
definePageMeta({
  layout: 'app',
})

const projectsStore = useProjectsStore()
const { currentProject } = storeToRefs(projectsStore)

// block page render until we get data
await useAsyncData(() => projectsStore.getCurrentProject())

if (!currentProject.value) {
  throw createError({
    statusCode: 404,
    statusMessage: 'Project not found',
  })
}
</script>

<template>
  <!-- eslint-disable vue/no-multiple-template-root -->
  <Sidebar>
    <template #header>
      <ProjectMenu />
    </template>
    <UITab
      icon="i-material-symbols-grid-view-outline-rounded"
      label="Overview"
      :to="{ name: 'projects-id', params: { id: currentProject!.id } }"
    />
    <UITab
      icon="i-material-symbols-event-list-outline-rounded"
      label="Event logs"
      :to="{ name: 'projects-id-logs', params: { id: currentProject!.id } }"
    />
    <UITab
      icon="i-material-symbols-settings-outline-rounded"
      label="Settings"
      :to="{ name: 'projects-id-settings', params: { id: currentProject!.id } }"
    />
    <template #footer>
      <UserMenu />
    </template>
  </Sidebar>

  <main class="flex flex-1 lg:(py-2 pl-64 pr-2)">
    <div class="grow lg:(rounded-lg bg-white shadow-sm ring-1 ring-zinc-200)">
      <div class="mx-auto h-full max-w-screen-xl overflow-hidden p-6 lg:p-10">
        <p>hello {{ JSON.stringify(currentProject) }}</p>
        <NuxtPage />
      </div>
    </div>
  </main>
</template>
