<script setup lang="ts">
import type { Project } from '~/domain/project'
import { partialProjectSchema } from '~/domain/project'

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

async function handleFormSubmit() {
  let isSuccess = false
  errorMessage.value = null
  const validation = partialProjectSchema.safeParse(form)

  if (!validation.success) {
    errorMessage.value = 'An error occurred while updating project! Try again later'
    return
  }
  try {
    const result = await projectsStore.updateCurrentProject(form)
    isSuccess = result.success
  }
  catch (error) {
    if (error instanceof Error) {
      console.error(error.message)
    }
  }

  if (!isSuccess) {
    errorMessage.value = 'An error occurred while updating project! Try again later'
    return
  }
  await useAsyncData(() => projectsStore.getCurrentProject())
  await navigateTo(`/projects/${currentProject.value?.id}`)
}

const form = reactive<Project>({
  id: Number(currentProject.value?.id),
  name: currentProject.value?.name || '',
})
</script>

<template>
  <div>
    <form
      class="border rounded-md"
      @submit.prevent="handleFormSubmit"
    >
      <h2>Update Project settings</h2>
      <div>
        <label for="name">Project Name: </label>
        <input
          id="name"
          v-model="form.name"
          type="text"
          class="border rounded-md"
        >
      </div>
      <button
        class="h-9 inline-flex items-center justify-center border rounded-md bg-blue-600 px-3 text-sm text-white font-semibold hover:bg-blue-500 focus-visible:(outline-blue-600 ring ring-white ring-inset)"
        type="submit"
      >
        Save
      </button>
    </form>
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
