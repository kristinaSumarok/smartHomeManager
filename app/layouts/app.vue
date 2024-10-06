<template>
  <div class="min-h-full flex flex-col bg-white lg:(flex-row bg-zinc-100)">
    <UIHeader />

    <aside class="hidden lg:block">
      <slot name="sidebar" />
    </aside>

    <main class="flex flex-1 lg:(py-2 pl-64 pr-2)">
      <div class="grow lg:(rounded-lg bg-white shadow-sm ring-1 ring-zinc-200)">
        <div class="mx-auto h-full max-w-screen-xl overflow-hidden p-6 lg:p-10">
          <slot />
        </div>
      </div>
    </main>
  </div>
</template>
