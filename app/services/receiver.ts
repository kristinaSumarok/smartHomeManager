import { z } from 'zod'
import type { Project } from '~/domain/project'
import { receiverSchema } from '~/domain/receiver'

export const useReceiverService = () => {
  const config = useRuntimeConfig()
  const repository = createRepository(
    $fetch.create({
      baseURL: `${config.public.apiBaseUrl}`,
    }),
  )

  return {
    async getReceivers(projectId: Project['id']) {
      const response = await repository.findAll(
        `/projects/${projectId}/receivers`,
      )

      return z.array(receiverSchema).parse(response)
    },
  }
}
