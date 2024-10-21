<script setup lang="ts">
const projectsStore = useProjectsStore()
const { currentProject } = storeToRefs(projectsStore)
const errorMessage = ref<string | null>(null)

async function handleRemove() {
  try {
    errorMessage.value = null
    await projectsStore.removeProject()
    await navigateTo('/')
  }
  catch (error) {
    if (error instanceof Error) {
      errorMessage.value = error.message
    }
    else {
      errorMessage.value = 'An unknown error occurred'
    }
  }
}
</script>

<template>
  <div>
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
