import { z } from 'zod'

export const entitySchema = z.object({
  id: z.number().gt(0),
})

export type Entity = z.infer<typeof entitySchema>
