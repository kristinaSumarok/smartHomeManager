import type { $Fetch } from 'nitropack'
import { createRepository } from './base'
import type { Project } from '~/domain/project'
import type { CreateReceiver } from '~/domain/receiver'

export const createReceiverRepository = (fetch: $Fetch) => {
  const { findOne, remove } = createRepository(fetch)

  return {
    async findAll(projectId: Project['id']) {
      return await fetch<unknown[]>(
        // to learn why this works
        //  https://github.com/unjs/ufo
        `../projects/${projectId}/receivers`,
      )
    },

    async add(projectId: Project['id'], newReceiver: CreateReceiver) {
      return await fetch<unknown>(
        `../projects/${projectId}/receivers`,
        {
          method: 'POST',
          body: newReceiver,
        },
      )
    },

    findOne,
    remove,
  }
}
