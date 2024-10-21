import type { $Fetch } from 'nitropack'

// TODO: remove it later
const sleep = () => new Promise((resolve) => {
  setTimeout(() => resolve(true), 3000)
})

type Id = string | number

export const createRepository = (fetch: $Fetch) => ({
  async findAll(url?: string) {
    return await fetch<unknown[]>(url ?? '/')
  },

  async findOne(id: Id) {
    await sleep()
    return await fetch<unknown>(`/${id}`)
  },

  async add<T>(entity: T) {
    return await fetch<unknown>('/', {
      method: 'POST',
      body: { entity },
    })
  },

  async update<T>(id: Id, entity: T) {
    return await fetch<unknown>(`/${id}`, {
      method: 'PUT',
      body: { entity },
    })
  },

  async remove(id: Id) {
    return await fetch<unknown>(`/${id}`, {
      method: 'DELETE',
    })
  },
})
