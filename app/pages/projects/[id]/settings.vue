<script setup lang="ts">
const projectsStore = useProjectsStore()
const { currentProject } = storeToRefs(projectsStore)

const errorMessage = ref<string | null>(null)

const projectName = ref(currentProject.value!.name)

async function handleRemove() {
  errorMessage.value = null

  try {
    // NOTE: currentProject should be already loaded here
    await projectsStore.removeProject(currentProject.value!.id)
  }
  catch (error) {
    if (error instanceof Error) {
      console.error(error.message)
    }

    errorMessage.value = 'An error occurred while deleting project! Try again later.'
    return
  }

  await navigateTo('/')
}

async function handleUpdate(event: Event) {
  errorMessage.value = null

  // TODO: CSRF, and it is not the best place to write this comment tbh
  const formData = new FormData((event.target as HTMLFormElement))
  const data = Object.fromEntries(formData)

  try {
    await projectsStore.updateCurrentProject(data)
    errorMessage.value = 'Updated successfully!'
  }
  catch (error) {
    if (error instanceof Error) {
      console.error(error.message)
    }

    errorMessage.value = 'An error occurred while updating project! Try again later.'
  }
}
</script>

<template>
  <div>
    <form
      class="border rounded-md"
      @submit.prevent="handleUpdate"
    >
      <h2>Update Project settings</h2>
      <div>
        <label for="name">Project Name: </label>
        <input
          id="name"
          v-model="projectName"
          name="name"
          type="text"
          class="border rounded-md"
        >
      </div>
      <p
        v-if="errorMessage"
        class="text-red-500"
      >
        {{ errorMessage }}
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
      v-if="errorMessage "
      class="text-red-500"
    >
      {{ errorMessage }}
    </p>
  </div>
</template>
