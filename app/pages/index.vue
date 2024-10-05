<script setup lang="ts">
const projectsStore = useProjectsStore()
const { projects } = storeToRefs(projectsStore)

const { status } = await useLazyAsyncData(() => projectsStore.getProjects())
</script>

<template>
  <div class="mx-auto h-full max-w-screen-xl overflow-hidden p-6 lg:p-10">
    <h1 class="text-4xl font-semibold tracking-tight sm:text-3xl">
      Nuxt
    </h1>
    <p class="mt-4 text-zinc-700 leading-7">
      Select a project or create a new one to get started
    </p>
    <div>
      <ul
        v-if="status === 'success'"
        class="divide-y"
      >
        <li
          v-for="project in projects"
          :key="project.id"
          class="group relative p-4"
        >
          <h3>
            {{ project.name }}
          </h3>
          <NuxtLink
            :to="{ name: 'projects-id', params: { id: project.id } }"
            class="block text-blue-600 font-medium group-hover:(text-blue-500 underline underline-offset-2)"
          >
            Open
            <span
              class="absolute inset-0"
              aria-hidden="true"
            />
          </NuxtLink>
        </li>
      </ul>
      <span v-else>
        loading or error
      </span>
    </div>

    <div class="p-4">
      <button
        type="button"
        class="h-9 inline-flex items-center justify-center border rounded-md bg-blue-600 px-3 text-sm text-white font-semibold hover:bg-blue-500 focus-visible:(outline-blue-600 ring ring-white ring-inset)"
      >
        Add project
      </button>
    </div>
  </div>
</template>
