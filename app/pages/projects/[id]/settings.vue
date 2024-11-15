<script setup lang="ts">
</script>

<template>
  <div>
    <div class="max-w-3xl">
      <h1 class="text-3xl font-semibold tracking-tight">
        Settings
      </h1>
      <p class="mt-2 leading-7">
        Manage your project settings
      </p>
    </div>
    <hr class="my-8">
    <div class="max-w-3xl space-y-16">
      <ProjectUpdateForm />
      <div class="space-y-6">
        <div>
          <h2 class="font-semibold">
            Actions
          </h2>
          <p class="mt-1 text-sm text-zinc-600">
            Things you can do with your project
          </p>
        </div>
        <SettingsActionCard
          title="Export project"
          description="Export all receivers and connected devices for the current project"
        >
          <Tooltip label="Feature is not available">
            <Button
              as="button"
              type="button"
              label="Start export"
              disabled
            />
          </Tooltip>
        </SettingsActionCard>
      </div>
      <ProjectDeleteForm />
    </div>
  </div>
</template>
