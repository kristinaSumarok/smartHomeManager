<script setup lang="ts">
import { ZodError } from 'zod'
import type { UpdateProject, UpdateProjectErrors } from '~/domain/project'

const projectsStore = useProjectsStore()
const { currentProject } = storeToRefs(projectsStore)

const state = reactive({
  id: currentProject.value!.id.toString(),
  name: currentProject.value!.name,
})

const isSubmitting = ref(false)
const successMessage = ref<string | null>(null)
const errorState: UpdateProjectErrors = reactive({
  formErrors: [],
  fieldErrors: {},
})

async function handleUpdate(event: Event) {
  isSubmitting.value = true
  successMessage.value = null
  errorState.formErrors = []
  errorState.fieldErrors = {}

  // TODO: CSRF, and it is not the best place to write this comment tbh
  const formData = new FormData((event.target as HTMLFormElement))
  const data = Object.fromEntries(formData)

  try {
    await projectsStore.updateCurrentProject(data)

    // TODO: replace with toast later
    successMessage.value = 'Project was updated successfully!'
  }
  catch (error) {
    if (error instanceof Error) {
      // if validation error
      if (error instanceof ZodError) {
        const flattenedError = (error as ZodError<UpdateProject>).flatten()

        // TODO: add toast if form error
        errorState.formErrors = flattenedError.formErrors
        errorState.fieldErrors = flattenedError.fieldErrors
      }

      console.error(error.message)
    }

    errorState.formErrors.push('An error occurred while updating project! Try again later.')
  }

  isSubmitting.value = false
}
</script>

<template>
  <form
    class="space-y-6"
    @submit.prevent="handleUpdate"
  >
    <div>
      <h2 class="font-semibold">
        General
      </h2>
      <p class="mt-1 text-sm text-zinc-600">
        Basic settings and options for your project
      </p>
    </div>
    <div class="grid cols-1 gap-6 sm:cols-6">
      <div class="sm:col-span-3">
        <Input
          v-model="state.name"
          type="text"
          label="Project name"
          name="name"
          :error="errorState.fieldErrors.name?.at(0)"
          placeholder="Enter project name"
          required
          :disabled="isSubmitting"
        />
      </div>
      <div class="sm:col-span-2">
        <!-- TODO: make it static text -->
        <Input
          v-model="state.id"
          type="text"
          label="Project ID"
          name="id"
          disabled
          required
        />
      </div>
    </div>
    <div class="flex flex-col gap-4 sm:(flex-row items-center)">
      <Button
        as="button"
        type="submit"
        label="Save changes"
        variant="primary"
      />
      <p
        v-if="successMessage"
        class="text-sm text-zinc-600"
      >
        {{ successMessage }}
      </p>
    </div>
  </form>
</template>
