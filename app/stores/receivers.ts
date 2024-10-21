import type { Receiver } from '~/domain/receiver'
import { useReceiverService } from '~/services/receiver'

export const useReceiversStore = defineStore('receivers', () => {
  const projectsStore = useProjectsStore()
  const receiverService = useReceiverService()

  const receivers = ref<Receiver[]>([])

  async function getReceivers() {
    const projectId = projectsStore.currentProject?.id

    if (!projectId)
      return { success: false }

    receivers.value = await receiverService.getReceivers(projectId)
    return receivers.value
  }

  return {
    receivers,
    getReceivers,
  }
})
