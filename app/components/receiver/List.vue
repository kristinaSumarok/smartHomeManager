<script setup lang="ts">
import type { TreeItemToggleEvent } from 'radix-vue'
import type { Device } from '~/domain/device'
import type { Receiver } from '~/domain/receiver'

const receiversStore = useReceiversStore()
const devicesStore = useDevicesStore()
const { receivers } = storeToRefs(receiversStore)
const { devices } = storeToRefs(devicesStore)

const { status } = await useLazyAsyncData(() => receiversStore.getReceivers())

interface TreeNode {
  id: Receiver['id'] | Device['id']
  name: Receiver['name'] | Device['name']
  type: 'receiver' | Device['$type']
  children?: TreeNode[]
}

const expanded = ref<string[]>([])
const loadingState: Record<string, boolean> = reactive({})
const items = computed<TreeNode[]>(() => {
  return receivers.value.map((receiver) => {
    const receiverDevices = devices.value[receiver.id]?.map(device => ({
      id: device.id,
      name: device.name,
      type: device.$type,
    }))

    return {
      id: receiver.id,
      name: receiver.name,
      type: 'receiver',
      children: receiverDevices,
    }
  })
})

async function handleToggle(event: TreeItemToggleEvent<TreeNode>) {
  const treeItem = event.detail
  if (!treeItem.value || treeItem.value.type !== 'receiver')
    return

  const item = treeItem.value
  if (!treeItem.isExpanded && !item.children && !devices.value[item.id]) {
    loadingState[item.id] = true

    try {
      await devicesStore.getDevicesByReceiver(item.id)
      loadingState[item.id] = false

      expanded.value.push(`${item.type}-${item.id}`)
    }
    catch (error) {
      // TODO: show some error feedback in UI
      if (error instanceof Error) {
        console.error(error)
      }
    }
  }
}
</script>

<template>
  <TreeRoot
    v-if="status === 'success'"
    v-slot="{ flattenItems }"
    v-model:expanded="expanded"
    class="select-none list-none text-sm font-medium space-y-1"
    :items="items"
    :get-key="(item) => `${item.type}-${item.id}`"
  >
    <TreeItem
      v-for="item in flattenItems"
      v-slot="{ isExpanded }"
      :key="item._id"
      :style="{ 'padding-left': `${item.level - 0.5}rem` }"
      v-bind="item.bind"
      class="group/treeitem h-8 flex items-center gap-2 rounded px-2 sm:h-7 data-[selected]:(bg-blue-500 text-white hover:bg-blue-400) hover:bg-zinc-950/5 focus-visible:(ring-2 ring-white ring-inset)"
      @toggle="handleToggle"
    >
      <span class="text-zinc-600 group-data-[selected]/treeitem:text-blue-50">
        <div
          v-if="loadingState[item.value.id]"
          class="animate-spin"
        >
          <Icon name="i-material-symbols-progress-activity" />
        </div>

        <template v-else-if="item.value.type === 'receiver'">
          <Icon
            v-if="!isExpanded"
            name="i-material-symbols-audio-video-receiver-outline-rounded"
          />
          <Icon
            v-else
            name="i-material-symbols-scanner-outline-rounded"
          />
        </template>

        <template v-else>
          <template v-if="item.hasChildren">
            <Icon
              v-if="!isExpanded"
              name="i-material-symbols-folder-outline-rounded"
            />
            <Icon
              v-else
              name="i-material-symbols-folder-open-outline-rounded"
            />
          </template>
          <DeviceIcon
            v-else
            :device-type="item.value.type"
          />
        </template>
      </span>
      <span class="truncate">
        {{ item.value.name }}
      </span>
    </TreeItem>
  </TreeRoot>

  <span v-else>
    loading or error
  </span>
</template>
