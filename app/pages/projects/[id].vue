<script setup lang="ts">
import { NuxtLink } from '#components'

// https://nuxt.com/docs/guide/directory-structure/layouts#overriding-a-layout-on-a-per-page-basis
definePageMeta({
  layout: false,
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
  <div class="contents">
    <NuxtLayout name="app">
      <template #sidebar>
        <Sidebar>
          <template #header>
            <ProjectMenu />
          </template>
          <Tab
            icon="i-material-symbols-grid-view-outline-rounded"
            label="Overview"
            :as="NuxtLink"
            :to="{ name: 'projects-id', params: { id: currentProject!.id } }"
          />
          <Tab
            icon="i-material-symbols-event-list-outline-rounded"
            label="Event logs"
            :as="NuxtLink"
            :to="{ name: 'projects-id-logs', params: { id: currentProject!.id } }"
          />
          <Tab
            icon="i-material-symbols-settings-outline-rounded"
            label="Settings"
            :as="NuxtLink"
            :to="{ name: 'projects-id-settings', params: { id: currentProject!.id } }"
          />
        </Sidebar>
      </template>

      <p>hello {{ JSON.stringify(currentProject) }}</p>
      <NuxtPage />
    </NuxtLayout>
  </div>
</template>
