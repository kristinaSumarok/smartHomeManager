<script setup lang="ts">
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
  <p>hello {{ JSON.stringify(currentProject) }}</p>
</template>
