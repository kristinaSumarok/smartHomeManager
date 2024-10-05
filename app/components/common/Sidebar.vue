<script setup lang="ts">
</script>

<template>
  <div class="fixed inset-y-0 left-0 hidden w-64 lg:block">
    <nav
      class="h-full flex flex-col"
      aria-label="Sidebar navigation"
    >
      <div class="border-b border-zinc-200 p-4 space-y-2">
        <slot name="header" />
      </div>
      <div class="flex-1 p-4">
        <div class="grid gap-1">
          <slot />
          <!-- <UITab
            icon="i-material-symbols-grid-view-outline-rounded"
            label="Overview"
            :to="{ name: 'projects-id', params: { id: currentProject.id } }"
          />
          <UITab
            icon="i-material-symbols-event-list-outline-rounded"
            label="Event logs"
            :to="{ name: 'projects-id-logs', params: { id: currentProject.id } }"
          />
          <UITab
            icon="i-material-symbols-settings-outline-rounded"
            label="Settings"
            :to="{ name: 'projects-id-settings', params: { id: currentProject.id } }"
          /> -->
        </div>
      </div>
      <div class="border-t border-zinc-200 p-4">
        <slot name="footer" />
      </div>
    </nav>
  </div>
</template>
