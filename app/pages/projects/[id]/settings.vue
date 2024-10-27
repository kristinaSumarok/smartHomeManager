<script setup lang="ts">
import type { PartialProject } from '~/domain/project'

const projectsStore = useProjectsStore()
const { currentProject } = storeToRefs(projectsStore)

const deleteMessage = ref<string | null>(null)
const updateMessage = ref<string | null>(null)

const noError = ref<boolean>(false)

async function handleRemove() {
  let isSuccess = false
  deleteMessage.value = null

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
    deleteMessage.value = 'An error occurred while deleting project! Try again later.'
    return
  }

  await navigateTo('/')
}

async function handleFormSubmit() {
  let isSuccess = false
  updateMessage.value = null
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
    updateMessage.value = 'An error occurred while updating project! Try again later '
    return
  }
  await useAsyncData(() => projectsStore.getCurrentProject())
  noError.value = true
  updateMessage.value = 'Updated!'
}

const form = reactive<PartialProject>({
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
      <p
        v-if="updateMessage"
        :class="noError ? 'text-green-500' : 'text-red-500'"
      >
        {{ updateMessage }}
      </p>
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
      v-if="deleteMessage"
      class="text-red-500"
    >
      {{ deleteMessage }}
    </p>
  </div>
</template>
