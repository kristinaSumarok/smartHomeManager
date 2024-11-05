import type { Device } from '~/domain/device'
import { useDeviceService } from '~/services/device'

export const useDevicesStore = defineStore('devices', () => {
  const deviceService = useDeviceService()

  const devicesByReceiver = ref<Record<number, Device[]>>({})

  async function getDevices(receiverId: number) {
    if (!receiverId)
      return { success: false }

    const devices = await deviceService.getDevices(receiverId)
    devicesByReceiver.value[receiverId] = devices
    return devices
  }

  return {
    getDevices,
    devicesByReceiver,
  }
})
