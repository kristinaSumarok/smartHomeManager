import { z } from 'zod'
import { projectSchema, type Project } from '~/domain/project'

export const useProjectService = () => {
  const config = useRuntimeConfig()
  const repository = createRepository(
    $fetch.create({
      baseURL: `${config.public.apiBaseUrl}/projects`,
    }),
  )

  return {
    async getProjects() {
      const response = await repository.findAll()
      return z.array(projectSchema).parse(response)
    },

    async getProjectById(id: Project['id']) {
      const response = await repository.findOne(id)
      return projectSchema.parse(response)
    },
    async removeProjectById(id: Project['id']) {
      await repository.remove(id)
    },
  }
}
