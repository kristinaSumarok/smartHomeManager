import { z } from 'zod'
import { updateProjectSchema, projectSchema, type Project } from '~/domain/project'

export const useProjectService = () => {
  const config = useRuntimeConfig()
  const repository = createProjectRepository(
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

    async updateProject(id: Project['id'], updatedProject: Record<string, unknown>) {
      const project = updateProjectSchema.parse({ id, ...updatedProject })

      const response = await repository.update(id, project)
      return projectSchema.parse(response)
    },
  }
}
