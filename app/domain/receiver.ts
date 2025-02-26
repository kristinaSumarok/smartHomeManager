import { z } from 'zod'
import { auditableEntitySchema } from './auditable-entity'

export const receiverSchema = auditableEntitySchema.merge(
  z.object({
    name: z.string(),
  }),
)

export type Receiver = z.infer<typeof receiverSchema>

export const createReceiverSchema = receiverSchema
  .omit({
    id: true,
    createdAt: true,
    lastModifiedAt: true,
  })
  .partial({
    name: true,
  })

export type CreateReceiver = z.infer<typeof createReceiverSchema>

export type CreateReceiverErrors = z.inferFlattenedErrors<typeof createReceiverSchema>

export const updateReceiverSchema = receiverSchema.omit({
  createdAt: true,
  lastModifiedAt: true,
})

export type UpdateReceiver = z.infer<typeof updateReceiverSchema>

export type UpdateReceiverErrors = z.inferFlattenedErrors<typeof updateReceiverSchema>
