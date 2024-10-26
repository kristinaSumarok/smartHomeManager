<script setup lang="ts">
</script>

<template>
  <div class="fixed inset-y-0 left-0 w-64">
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
        </div>
      </div>
      <div class="border-t border-zinc-200 p-4">
        <slot name="footer">
          <UserMenu>
            <button class="group w-full flex items-center justify-between gap-2 rounded-lg p-2 active:(bg-zinc-950/10 shadow-inner) hover:bg-zinc-950/5">
              <div class="flex flex-1 items-center gap-3 overflow-x-hidden">
                <UIAvatar size="lg" />
                <div class="min-w-0 flex-1 text-left">
                  <h4 class="truncate text-sm font-medium">
                    Pavel Mayorov
                  </h4>
                  <p class="truncate text-sm text-zinc-600 group-active:text-zinc-800 group-hover:text-zinc-800">
                    pamayo@taltech.ee
                  </p>
                </div>
              </div>
              <span class="text-zinc-500 group-hover:text-zinc-700">
                <Icon name="i-material-symbols-arrow-drop-up-rounded" />
              </span>
            </button>
          </UserMenu>
        </slot>
      </div>
    </nav>
  </div>
</template>
