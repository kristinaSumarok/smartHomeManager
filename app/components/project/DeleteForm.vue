<script setup lang="ts">
const projectsStore = useProjectsStore()
const { currentProject } = storeToRefs(projectsStore)

const isSubmitting = ref(false)

async function handleRemove() {
  isSubmitting.value = true

  try {
    await projectsStore.removeProject(currentProject.value!.id)
  }
  catch (error) {
    if (error instanceof Error) {
      console.error(error.message)
    }

    // TODO: show toast component
    //  'An error occurred while deleting project! Try again later.'
    return
  }

  isSubmitting.value = false
  await navigateTo('/')
}
</script>

<template>
  <div class="space-y-6">
    <div>
      <h2 class="font-semibold">
        Danger zone
      </h2>
      <p class="mt-1 text-sm text-zinc-600">
        Please be certain when committing the following actions
      </p>
    </div>
    <SettingsActionCard
      title="Delete project"
      description="Delete current project and all associated data with it. Keep in mind that this action is irreversible!"
    >
      <Alert
        title="Do you want to delete this project?"
        icon="i-material-symbols-scan-delete-outline-rounded"
      >
        <template #trigger>
          <AlertTrigger>
            <Button
              as="button"
              type="button"
              label="Delete project"
              variant="destructive"
            />
          </AlertTrigger>
        </template>

        <div class="relative">
          <div class="absolute inset-y-0 left-0 w-6 flex justify-center">
            <div class="w-px bg-zinc-200" />
          </div>
          <AlertDescription>
            <ul
              role="list"
              class="space-y-1"
            >
              <li class="relative flex gap-2">
                <div class="relative size-6 flex flex-none items-center justify-center">
                  <div class="size-2 rounded-full bg-zinc-100 ring-1 ring-zinc-300" />
                </div>
                <p class="flex-auto text-sm text-zinc-600 leading-6">
                  This action cannot be undone
                </p>
              </li>
              <li class="relative flex gap-2">
                <div class="relative size-6 flex flex-none items-center justify-center">
                  <div class="size-2 rounded-full bg-zinc-100 ring-1 ring-zinc-300" />
                </div>
                <p class="flex-auto text-sm text-zinc-600 leading-6">
                  The project <strong>{{ currentProject!.name }}</strong> will be permanently deleted with all its associated data
                </p>
              </li>
              <li class="relative flex gap-2">
                <div class="relative size-6 flex flex-none items-center justify-center">
                  <div class="size-2 rounded-full bg-zinc-100 ring-1 ring-zinc-300" />
                </div>
                <p class="flex-auto text-sm text-zinc-600 leading-6">
                  Are you sure you want to continue?
                </p>
              </li>
            </ul>
          </AlertDescription>
        </div>

        <template #actions>
          <AlertCancel>
            <Button
              as="button"
              type="button"
              label="Cancel"
            />
          </AlertCancel>
          <AlertAction>
            <Button
              as="button"
              type="button"
              label="Delete project"
              variant="destructive"
              :disabled="isSubmitting"
              @click="handleRemove"
            />
          </AlertAction>
        </template>
      </Alert>
    </SettingsActionCard>
  </div>
</template>
