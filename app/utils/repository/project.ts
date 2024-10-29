import type { $Fetch } from 'nitropack'
import { createRepository } from './base'

export const createProjectRepository = (fetch: $Fetch) => createRepository(fetch)
