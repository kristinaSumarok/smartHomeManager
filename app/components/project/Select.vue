<script setup lang="ts">
import { NuxtLink } from '#components'

const projectsStore = useProjectsStore()
const { projects, currentProject } = storeToRefs(projectsStore)
</script>

<template>
  <Dropdown>
    <template #trigger>
      <DropdownTrigger :label="currentProject?.name ?? 'Untitled*'" />
    </template>

    <DropdownGroup>
      <DropdownItem
        v-for="project in projects"
        :key="project.id"
        :as="NuxtLink"
        :to="`/projects/${project.id}`"
        :label="project.name"
      />
    </DropdownGroup>
    <DropdownSeparator />
    <DropdownGroup>
      <DropdownItem
        :as="NuxtLink"
        to="/projects/new"
        label="Add project..."
        icon="i-material-symbols-add-rounded"
      />
    </DropdownGroup>
  </Dropdown>
</template>
