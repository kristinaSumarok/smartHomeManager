<script setup lang="ts">
</script>

<template>
  <NuxtRouteAnnouncer />
  <NuxtLoadingIndicator color="#a1a1aa" />
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
</template>

<style>
  html {
    --at-apply: 'text-zinc-900';
  }

  html, body, div#__nuxt {
    height: 100%;
  }
</style>
