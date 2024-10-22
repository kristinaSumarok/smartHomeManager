<script setup lang="ts">
const projectsStore = useProjectsStore()
const { currentProject } = storeToRefs(projectsStore)
const errorMessage = ref<string | null>(null)

async function handleRemove() {
  let isSuccess = false
  errorMessage.value = null

  try {
    const result = await projectsStore.removeProject()
    isSuccess = result.success
  }
  catch (error) {
    if (error instanceof Error) {
      console.error(error.message)
    }
  }

  if (!isSuccess) {
    errorMessage.value = 'An error occurred while deleting project! Try again later.'
    return
  }

  await navigateTo('/')
}
</script>

<template>
  <div>
    Settings
    <button
      class="h-9 inline-flex items-center justify-center border rounded-md bg-blue-600 px-3 text-sm text-white font-semibold hover:bg-blue-500 focus-visible:(outline-blue-600 ring ring-white ring-inset)"
      @click="handleRemove()"
    >
      Delete project {{ currentProject?.name }}
    </button>
    <p
      v-if="errorMessage"
      class="text-red-500"
    >
      {{ errorMessage }}
    </p>
  </div>
</template>
