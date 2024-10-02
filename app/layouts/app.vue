<template>
  <div class="min-h-full flex flex-col bg-white lg:(flex-row bg-zinc-100)">
    <UISidebar />
    <UIHeader />
    <main class="flex flex-1 lg:(py-2 pl-64 pr-2)">
      <div class="grow lg:(rounded-lg bg-white shadow-sm ring-1 ring-zinc-200)">
        <slot />
      </div>
    </main>
  </div>
</template>
