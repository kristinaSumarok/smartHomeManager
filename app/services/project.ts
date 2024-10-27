import { z } from 'zod'
import { partialProjectSchema, projectSchema, type PartialProject, type Project } from '~/domain/project'

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

    async updateProject(project: PartialProject, Id: Project['id']) {
      const updatedProject = { ...project, id: Id }
      const validation = partialProjectSchema.safeParse(updatedProject)
      if (!validation.success) {
        return { success: false }
      }
      await repository.update(Id, updatedProject)
      return { success: true }
    },
  }
}
