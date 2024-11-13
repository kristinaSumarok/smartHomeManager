<script setup lang="ts">
const projectsStore = useProjectsStore()
const { currentProject } = storeToRefs(projectsStore)

const isSubmitting = ref(false)

async function handleRemove() {
  isSubmitting.value = true
  // TODO: show a confirmation modal before

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
      <Button
        as="button"
        type="button"
        label="Delete project"
        variant="destructive"
        :disabled="isSubmitting"
        @click="handleRemove"
      />
    </SettingsActionCard>
  </div>
</template>
