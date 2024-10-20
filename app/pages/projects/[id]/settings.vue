<script setup lang="ts">
const projectsStore = useProjectsStore()
const { currentProject } = storeToRefs(projectsStore)

// block page render until we get data
await useAsyncData(() => projectsStore.removeProject())

if (!currentProject.value) {
  throw createError({
    statusCode: 404,
    statusMessage: 'Project not found',
  })
}
async function onClick() {
  projectsStore.removeProject()
  await navigateTo('/projects')
}
</script>

<template>
  <div>
    <b
      class="cursor-pointer border-b-2 border-red-500 rounded-md p-2"
      @click="onClick()"
    >
      Delete project {{ currentProject?.name }}
    </b>
    settings
  </div>
</template>
