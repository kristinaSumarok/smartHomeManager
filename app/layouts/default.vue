<script setup lang="ts">
import { NuxtLink } from '#components'
</script>

<template>
  <div class="min-h-full flex flex-col items-center bg-zinc-100">
    <header class="w-full">
      <Header>
        <HeaderItem
          :as="NuxtLink"
          to="/"
          label="Documentation"
        />
        <HeaderItem
          :as="NuxtLink"
          to="/"
          label="Support"
        />
        <HeaderItem
          :as="NuxtLink"
          to="/"
          label="Changelog"
        />
      </Header>
    </header>

    <main class="w-full max-w-screen-xl flex flex-1 p-6 lg:p-10">
      <slot />
    </main>

    <footer class="w-full">
      <Footer />
    </footer>
  </div>
</template>
