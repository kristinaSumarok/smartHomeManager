<script setup lang="ts">
</script>

<template>
  <div class="fixed inset-y-0 left-0 hidden w-64 lg:block">
    <nav
      class="h-full flex flex-col"
      aria-label="Sidebar navigation"
    >
      <div class="border-b border-zinc-200 p-4 space-y-2">
        <button
          type="button"
          class="group w-full flex items-center gap-3 border border-zinc-400/20 rounded-md p-2 text-sm font-medium shadow-sm active:(bg-zinc-950/10 shadow-inset) hover:bg-zinc-950/5"
        >
          <div class="size-7 inline-flex items-center justify-center border border-amber-400 rounded-full bg-amber-200 text-sm text-amber-800">
            <UIIcon name="i-material-symbols-add-notes-outline-rounded" />
          </div>
          <div class="min-w-0 flex-1 truncate text-left">
            Dad's garage
          </div>
          <span class="text-zinc-500 group-hover:text-zinc-600">
            <UIIcon name="i-material-symbols-unfold-more-rounded" />
          </span>
        </button>
      </div>
      <div class="flex-1 p-4">
        <div class="grid gap-1">
          <UITab
            icon="i-material-symbols-grid-view-outline-rounded"
            label="Devices"
            href="/"
          />
          <UITab
            icon="i-material-symbols-event-list-outline-rounded"
            label="Event logs"
            href="/"
          />
          <UITab
            icon="i-material-symbols-settings-outline-rounded"
            label="Settings"
            href="/"
          />
        </div>
      </div>
      <div class="border-t border-zinc-200 p-4">
        <button
          type="button"
          class="group w-full flex items-center justify-between gap-3 rounded-lg p-2 active:(bg-zinc-950/10 shadow-inset) hover:bg-zinc-950/5"
        >
          <div class="flex flex-1 items-center gap-3 overflow-x-hidden">
            <UIAvatar size="lg" />
            <div class="min-w-0 flex-1 text-left">
              <h4 class="truncate text-sm font-medium">
                Pavel Mayorov
              </h4>
              <p class="truncate text-sm text-zinc-600 group-hover:text-zinc-800">
                pamayo@taltech.ee
              </p>
            </div>
          </div>
          <span class="text-zinc-500 group-hover:text-zinc-700">
            <UIIcon name="i-material-symbols-arrow-drop-up-rounded" />
          </span>
        </button>
      </div>
    </nav>
  </div>
</template>
