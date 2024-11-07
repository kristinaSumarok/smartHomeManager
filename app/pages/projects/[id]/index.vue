<script setup lang="ts">
</script>

<template>
  <div>
    <h1 class="text-3xl font-semibold tracking-tight">
      Overview
    </h1>
    <p class="mt-2 leading-7">
      Manage your devices with just a few clicks
    </p>
    <div class="grid mt-6 sm:block">
      <Dropdown>
        <template #trigger>
          <DropdownTrigger>
            <Button
              as="button"
              type="button"
              label="Add new"
              leading-icon="i-material-symbols-add-2-rounded"
              trailing-icon="i-material-symbols-arrow-drop-down-rounded"
              variant="primary"
            />
          </DropdownTrigger>
        </template>
        <DropdownItem
          as="button"
          label="New receiver"
          icon="i-material-symbols-audio-video-receiver-outline-rounded"
        />
        <DropdownItem
          as="button"
          label="New device"
          icon="i-material-symbols-devices-outline-rounded"
        />
      </Dropdown>
    </div>
    <div class="mt-6 flex flex-col gap-8 xl:(flex-row items-start)">
      <div class="flex-1 overflow-hidden border rounded-lg bg-white p-2 shadow-sm">
        <ReceiverList />
      </div>

      <div class="xl:(sticky top-8 w-96)">
        <h2 class="text-xl font-semibold tracking-tight">
          Details
        </h2>
        <div class="mt-2 border border-2 rounded-lg border-dashed px-4 py-8 hover:border-zinc-300">
          <div class="mx-auto w-fit text-3xl text-zinc-600 sm:text-4xl">
            <Icon name="i-material-symbols-lasso-select-rounded" />
          </div>
          <h3 class="mt-2 text-center text-sm font-semibold">
            Device not selected
          </h3>
          <p class="text-center text-sm text-zinc-600 leading-6">
            Select a device to start managing it
          </p>
        </div>
      </div>
    </div>
  </div>
</template>
