import type { $Fetch } from 'nitropack'
import { createRepository } from './base'
import type { Receiver } from '~/domain/receiver'
import type { CreateDevice } from '~/domain/device'

export const createDeviceRepository = (fetch: $Fetch) => {
  const { findOne, update, remove } = createRepository(fetch)

  return {
    async findAll(receiverId: Receiver['id']) {
      return await fetch<unknown[]>(
        // to learn why this works
        //  https://github.com/unjs/ufo
        `../receivers/${receiverId}/devices`,
      )
    },

    async add(receiverId: Receiver['id'], newDevice: CreateDevice) {
      return await fetch<unknown>(
        `../receivers/${receiverId}/devices`,
        {
          method: 'POST',
          body: newDevice,
        },
      )
    },

    findOne,
    update,
    remove,
  }
}
