<script setup lang="ts">
import { ZodError } from 'zod'
import { NuxtLink } from '#components'
import type { CreateProject, CreateProjectErrors } from '~/domain/project'

const projectName = ref('')
const projectsStore = useProjectsStore()

const isSubmitting = ref(false)
const errorState: CreateProjectErrors = reactive({
  formErrors: [],
  fieldErrors: {},
})

async function handleSubmit(event: Event) {
  isSubmitting.value = true
  errorState.formErrors = []
  errorState.fieldErrors = {}

  const formData = new FormData((event.target as HTMLFormElement))
  const data = Object.fromEntries(formData)

  let newProject
  try {
    newProject = await projectsStore.createProject(data)
  }
  catch (error) {
    if (error instanceof Error) {
      // if validation error
      if (error instanceof ZodError) {
        const flattenedError = (error as ZodError<CreateProject>).flatten()

        // TODO: add toast if form error
        errorState.formErrors = flattenedError.formErrors
        errorState.fieldErrors = flattenedError.fieldErrors
      }

      console.error(error.message)
    }

    errorState.formErrors.push('An error occurred while creating a new project! Try again later.')
  }

  isSubmitting.value = false

  if (newProject)
    await navigateTo(`/projects/${newProject.id}`)
}
</script>

<template>
  <div class="grid grow-1 content-center justify-items-center">
    <div class="max-w-2xl">
      <div class="mx-auto w-fit text-3xl text-zinc-600 sm:text-4xl">
        <Icon name="i-material-symbols-library-add-outline-rounded" />
      </div>
      <h1 class="mt-4 text-center text-2xl font-semibold tracking-tight sm:text-3xl">
        Create new project
      </h1>
      <p class="mt-2 text-center text-zinc-700 leading-7">
        Give it a name and start connecting your devices
      </p>
    </div>
    <div class="mt-8 max-w-md w-full">
      <div>
        <form
          class="space-y-6"
          @submit.prevent="handleSubmit"
        >
          <Input
            v-model="projectName"
            type="text"
            label="Project name"
            name="name"
            :error="errorState.fieldErrors.name?.at(0)"
            placeholder="Enter project name"
            required
            :disabled="isSubmitting"
          />
          <div class="grid gap-2">
            <Button
              as="button"
              type="submit"
              leading-icon="i-material-symbols-add-2-rounded"
              label="Create project"
              variant="primary"
              :disabled="isSubmitting"
            />
            <Button
              :as="NuxtLink"
              to="/"
              leading-icon="i-material-symbols-arrow-back-rounded"
              label="Back to projects"
              variant="secondary"
            />
          </div>
        </form>
      </div>
    </div>
  </div>
</template>
