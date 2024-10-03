<script setup lang="ts">
import { NuxtLink } from '#components'
</script>

<template>
  <Dropdown>
    <template #trigger>
      <DropdownTrigger>
        <button class="group w-full flex items-center justify-between gap-2 rounded-lg p-2 active:(bg-zinc-950/10 shadow-inset) hover:bg-zinc-950/5">
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
            <Icon name="i-material-symbols-arrow-drop-up-rounded" />
          </span>
        </button>
      </DropdownTrigger>
    </template>

    <DropdownGroup>
      <DropdownItem
        :as="NuxtLink"
        to="/"
        label="My account"
        icon="i-material-symbols-account-circle"
      />
      <DropdownItem
        :as="NuxtLink"
        to="/"
        label="Change preferences"
        icon="i-material-symbols-tune-rounded"
      />
    </DropdownGroup>
    <DropdownSeparator />
    <DropdownGroup>
      <DropdownItem
        :as="NuxtLink"
        to="/"
        label="Privacy policy"
        icon="i-material-symbols-verified-user-outline-rounded"
      />
      <DropdownItem
        :as="NuxtLink"
        to="/"
        label="Share feedback"
        icon="i-material-symbols-lightbulb-2-outline-rounded"
      />
    </DropdownGroup>
    <DropdownSeparator />
    <DropdownGroup>
      <DropdownItem
        :as="NuxtLink"
        to="/"
        label="Sign out"
        icon="i-material-symbols-logout-rounded"
      />
    </DropdownGroup>
  </Dropdown>
</template>
