// https://github.com/nuxt/nuxt/issues/28804
import { useRoute } from 'vue-router'

export const useProjectsStore = defineStore('projects', () => {
  const route = useRoute()

  const projects = ref([
    { id: 1, name: 'Project one' },
    { id: 2, name: 'Project two' },
  ])

  const currentProject = computed(() => {
    const id = route.params.id

    if (typeof id === 'string' && /^\d+$/.test(id)) {
      return projects.value.find(project => project.id === +id)
    }
  })

  return { projects, currentProject }
})
