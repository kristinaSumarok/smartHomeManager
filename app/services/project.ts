import { z } from 'zod'
import { partialProjectSchema, projectSchema, type Project } from '~/domain/project'

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

    async updateProject(projectId: Project['id'], updatedProject: unknown) {
      const partialProject = partialProjectSchema.parse(updatedProject)

      // TODO: avoid passing unnecessary props to update
      //  should be fixed in API
      const response = await repository.update(projectId, { id: projectId, ...partialProject })
      return projectSchema.parse(response)
    },
  }
}
