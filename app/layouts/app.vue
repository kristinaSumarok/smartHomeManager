<template>
  <div class="min-h-full flex flex-col bg-white lg:(flex-row bg-zinc-100)">
    <header class="lg:hidden">
      <slot name="header" />
    </header>

    <aside class="hidden lg:block">
      <slot name="sidebar" />
    </aside>

    <div class="flex flex-1 lg:(py-2 pl-64 pr-2)">
      <div class="flex grow flex-col items-center lg:(rounded-lg bg-white shadow-sm ring-1 ring-zinc-200)">
        <main class="w-full max-w-screen-xl flex-1 overflow-hidden p-6 lg:p-10">
          <slot />
        </main>
        <footer class="w-full">
          <Footer />
        </footer>
      </div>
    </div>
  </div>
</template>
