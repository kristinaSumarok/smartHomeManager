<script setup lang="ts">
const projectName = ref('')
const errorMessage = ref<string | null>(null)
const isSubmitting = ref(false)

const projectsStore = useProjectsStore()

async function handleSubmit(event: Event) {
  isSubmitting.value = true
  errorMessage.value = null

  const formData = new FormData((event.target as HTMLFormElement))
  const data = Object.fromEntries(formData)

  let newProject
  try {
    newProject = await projectsStore.createProject(data)
  }
  catch (error) {
    if (error instanceof Error) {
      console.error(error.message)
    }

    errorMessage.value = 'An error occurred while creating a new project! Try again later.'
  }

  isSubmitting.value = false

  if (newProject)
    await navigateTo(`/projects/${newProject.id}`)
}
</script>

<template>
  <div class="mx-auto mt-10 max-w-md">
    <h1 class="text-2xl font-semibold">
      Create a new project
    </h1>
    <form @submit.prevent="handleSubmit">
      <div class="mb-4">
        <label
          for="name"
          class="block text-sm font-medium"
        >
          Project Name
        </label>
        <input
          id="name"
          v-model="projectName"
          name="name"
          type="text"
          class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:border-blue-500 focus:ring focus:ring-blue-500"
          :class="{ 'border-red-500': errorMessage }"
          placeholder="Enter project name"
          required
          :disabled="isSubmitting"
        >
        <p
          v-if="errorMessage"
          class="mt-1 text-sm text-red-600"
        >
          {{ errorMessage }}
        </p>
      </div>
      <button
        type="submit"
        class="w-full rounded-md bg-blue-600 py-2 text-white hover:bg-blue-500 focus:outline-none focus:ring focus:ring-blue-500"
        :disabled="isSubmitting"
      >
        Create Project
      </button>
    </form>
  </div>
</template>
