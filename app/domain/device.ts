import { z } from 'zod'
import { auditableEntitySchema } from './auditable-entity'

export const deviceSchema = auditableEntitySchema.merge(
  z.object({
    name: z.string(),
    $type: z.enum(['lightbulb', 'thermostat', 'socket', 'ac']),
  }),
)

export type Device = z.infer<typeof deviceSchema>

export const createDeviceSchema = deviceSchema.omit({
  id: true,
  createdAt: true,
  lastModifiedAt: true,
})

export type CreateDevice = z.infer<typeof createDeviceSchema>

export const updateDeviceSchema = deviceSchema.omit({
  createdAt: true,
  lastModifiedAt: true,
})

export type UpdateDevice = z.infer<typeof updateDeviceSchema>
