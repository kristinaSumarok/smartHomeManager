import { z } from 'zod'
import { entitySchema } from './entity'

export const receiverSchema = entitySchema.merge(
  z.object({
    name: z.string(),
  }),
)

export type Receiver = z.infer<typeof receiverSchema>

export const partialReceiverSchema = receiverSchema.omit({
  id: true,
})

export type PartialReceiver = z.infer<typeof partialReceiverSchema>
