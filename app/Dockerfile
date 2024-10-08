FROM node:lts-slim AS base

# pnpm
ENV PNPM_HOME="/pnpm"
ENV PATH="$PNPM_HOME:$PATH"
RUN corepack enable

WORKDIR /app

COPY package.json pnpm-lock.yaml ./

RUN --mount=type=cache,id=pnpm,target=/pnpm/store pnpm install --frozen-lockfile

COPY . .

FROM base AS dev

CMD [ "pnpm", "run", "dev" ]

EXPOSE 3000
EXPOSE 24678

# TODO: build and production stages
