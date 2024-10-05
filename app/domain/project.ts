import { z } from 'zod'
import { entitySchema } from './entity'

export const projectSchema = entitySchema.merge(
  z.object({
    name: z.string(),
  }),
)

export type Project = z.infer<typeof projectSchema>

export const partialProjectSchema = projectSchema.omit({
  id: true,
})

export type PartialProject = z.infer<typeof partialProjectSchema>
