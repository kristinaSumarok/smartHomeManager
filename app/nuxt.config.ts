const fonts = [
  'https://cdn.jsdelivr.net/gh/orioncactus/pretendard@v1.3.9/dist/web/variable/pretendardvariable-std-dynamic-subset.min.css',
  'https://cdn.jsdelivr.net/gh/orioncactus/pretendard@v1.3.9/dist/web/static/pretendard-std-dynamic-subset.min.css',
]

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2024-04-03',
  devtools: { enabled: true },

  modules: ['@nuxt/eslint', '@unocss/nuxt'],

  // https://eslint.nuxt.com/
  eslint: {
    config: {
      stylistic: true,
      typescript: {
        strict: true,
      },
    },
  },

  // https://unocss.dev/integrations/nuxt
  unocss: {
    preflight: true,
  },

  app: {
    head: {
      link: [
        ...['preload', 'stylesheet'].flatMap(rel =>
          fonts.map(href => ({
            as: 'style' as const,
            rel,
            crossorigin: 'anonymous' as const,
            href,
          })),
        ),
      ],
    },
  },
})
