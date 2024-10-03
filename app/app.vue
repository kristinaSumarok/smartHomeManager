<script setup lang="ts">
</script>

<template>
  <NuxtRouteAnnouncer />
  <NuxtLayout name="app">
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
