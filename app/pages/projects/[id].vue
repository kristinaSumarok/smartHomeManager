<script setup lang="ts">
definePageMeta({
  layout: 'app',
})

const projectsStore = useProjectsStore()
const { currentProject } = storeToRefs(projectsStore)

if (!currentProject.value) {
  throw createError({
    statusCode: 404,
    statusMessage: 'Project not found',
  })
}
</script>

<template>
  <div class="mx-auto h-full max-w-screen-xl overflow-hidden p-6 lg:p-10">
    <p>hello {{ JSON.stringify(currentProject) }}</p>
    <NuxtPage />
  </div>
</template>
