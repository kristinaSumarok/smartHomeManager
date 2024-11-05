import { z } from 'zod'
import { entitySchema } from './entity'

export const auditableEntitySchema = entitySchema.merge(
  z.object({
    createdAt: z.coerce.date(),
    lastModifiedAt: z.coerce.date(),
  }),
)

export type AuditableEntity = z.infer<typeof auditableEntitySchema>
