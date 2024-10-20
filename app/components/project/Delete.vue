<script setup lang="ts">
const projectsStore = useProjectsStore()
const { currentProject } = storeToRefs(projectsStore)

await useAsyncData(() => projectsStore.removeProject())

if (!currentProject.value) {
  throw createError({
    statusCode: 404,
    statusMessage: 'Project not found',
  })
}
async function onClick() {
  await navigateTo('/')
  projectsStore.removeProject()
}
</script>

<template>
  <b
    class="h-9 inline-flex items-center justify-center border rounded-md bg-blue-600 px-3 text-sm text-white font-semibold hover:bg-blue-500 focus-visible:(outline-blue-600 ring ring-white ring-inset)"
    @click="onClick()"
  >
    Delete project {{ currentProject?.name }}
  </b>
</template>
