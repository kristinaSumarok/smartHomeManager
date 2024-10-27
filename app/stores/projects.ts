// https://github.com/nuxt/nuxt/issues/28804
import { useRoute } from 'vue-router'
import type { Project, PartialProject } from '~/domain/project'
import { useProjectService } from '~/services/project'

export const useProjectsStore = defineStore('projects', () => {
  const route = useRoute()
  const projectService = useProjectService()

  const projects = ref<Project[]>([])

  async function getProjects() {
    projects.value = await projectService.getProjects()
    return projects.value
  }

  const currentProjectId = computed(() => {
    const id = route.params.id

    if (typeof id === 'string' && /^\d+$/.test(id))
      return +id
  })

  const currentProject = ref<Project>()

  async function getCurrentProject() {
    if (!currentProjectId.value)
      return { success: false }

    currentProject.value = await projectService.getProjectById(currentProjectId.value)
    return currentProject.value
  }

  async function removeProject() {
    if (!currentProjectId.value)
      return { success: false }

    await projectService.removeProjectById(currentProjectId.value)
    return { success: true }
  }
  async function updateCurrentProject(project: PartialProject) {
    if (!currentProjectId.value)
      return { success: false }
    const valid = await projectService.updateProject(project, currentProjectId.value)
    if (!valid)
      return { success: false }

    return { success: true }
  }

  return {
    projects,
    getProjects,
    updateCurrentProject,
    currentProject,
    currentProjectId,
    getCurrentProject,
    removeProject,
  }
})
