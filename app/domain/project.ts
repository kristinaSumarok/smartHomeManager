import { z } from 'zod'
import { auditableEntitySchema } from './auditable-entity'

export const projectSchema = auditableEntitySchema.merge(
  z.object({
    name: z.string(),
  }),
)

export type Project = z.infer<typeof projectSchema>

export const createProjectSchema = projectSchema.omit({
  id: true,
  createdAt: true,
  lastModifiedAt: true,
})

export type CreateProject = z.infer<typeof createProjectSchema>

export const updateProjectSchema = projectSchema.omit({
  createdAt: true,
  lastModifiedAt: true,
})

export type UpdateProject = z.infer<typeof updateProjectSchema>
