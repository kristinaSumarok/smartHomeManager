import type { Theme } from 'unocss/preset-uno'

import {
  defineConfig,
  transformerDirectives,
  transformerVariantGroup,
} from 'unocss'
import icons from 'unocss/preset-icons'
import typography from 'unocss/preset-typography'
import uno from 'unocss/preset-uno'

export default defineConfig<Theme>({
  presets: [
    // https://unocss.dev/presets/uno
    uno(),

    // https://unocss.dev/presets/icons
    icons({
      scale: 1.2,
    }),

    // https://unocss.dev/presets/typography
    typography(),
  ],

  transformers: [
    // https://unocss.dev/transformers/directives
    transformerDirectives(),

    // https://unocss.dev/transformers/variant-group
    transformerVariantGroup(),
  ],

  theme: {
    fontFamily: {
      sans: '-apple-system,BlinkMacSystemFont,"Pretendard Std Variable","Pretendard Std",Pretendard,Inter,ui-sans-serif,system-ui,"Segoe UI",Roboto,"Helvetica Neue",Arial,"Noto Sans",sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol","Noto Color Emoji"',
    },
  },

  preflights: [
    {
      getCSS: ({ theme: { colors } }) => `
        :root {
          color-scheme: light;
        }

        *:focus-visible {
          outline-width: medium;
          outline-style: auto;
          outline-offset: 1px;
          outline-color: ${(colors?.blue as { [key: string]: string })['500'] ?? '#3b82f6'}66;
        }
      `,
    },
    {
      getCSS: ({ theme: { fontFamily } }) => `
        html, :host {
          font-family: ${fontFamily?.sans};
        }

        h1, h2, h3, h4, h5, h6 {
          text-wrap: balance;
        }

        p, li {
          text-wrap: pretty;
        }
      `,
    },
  ],
})
