import { z } from 'zod'

export const auditableEntitySchema = z.object({
  createdAt: z.coerce.date(),
  lastModifiedAt: z.coerce.date(),
})

export type AuditableEntity = z.infer<typeof auditableEntitySchema>
