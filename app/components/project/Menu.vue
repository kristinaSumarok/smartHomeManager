<script setup lang="ts">
import { NuxtLink } from '#components'

const projectsStore = useProjectsStore()
const { currentProject } = storeToRefs(projectsStore)
</script>

<template>
  <Dropdown>
    <template #trigger>
      <DropdownTrigger
        :label="currentProject?.name"
        icon="i-material-symbols-arrow-drop-down-rounded"
      />
    </template>

    <DropdownItem
      :as="NuxtLink"
      to="/"
      label="Switch projects"
      icon="i-material-symbols-sync-alt-rounded"
    />
    <DropdownItem
      :as="NuxtLink"
      to="/projects/new"
      label="Add project..."
      icon="i-material-symbols-add-rounded"
    />
  </Dropdown>
</template>
