import { z } from 'zod'
import { entitySchema } from './entity'

// Define a Receiver type
export const receiverSchema = entitySchema.merge(
  z.object({
    name: z.string(),
  }),
)

// Infer the Receiver type
export type Receiver = z.infer<typeof receiverSchema>

export const partialReceiverSchema = receiverSchema.omit({
  id: true,
})

export type PartialReceiver = z.infer<typeof partialReceiverSchema>
