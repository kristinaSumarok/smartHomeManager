import type { $Fetch } from 'nitropack'
import { createRepository } from './base'
import type { Project } from '~/domain/project'
import type { PartialReceiver } from '~/domain/receiver'

export const createReceiversRepository = (fetch: $Fetch) => {
  const { findOne, remove } = createRepository(fetch)

  return {
    async findAll(projectId: Project['id']) {
      return await fetch<unknown[]>(
        // to learn why this works
        //  https://github.com/unjs/ufo
        `../projects/${projectId}/receivers`,
      )
    },

    async add(projectId: Project['id'], partialReceiver: PartialReceiver) {
      return await fetch<unknown>(
        `../projects/${projectId}/receivers`,
        {
          method: 'POST',
          body: partialReceiver,
        },
      )
    },

    findOne,
    remove,
  }
}
