# Grove

🌳 **Grow your knowledge.** · 让知识长成一片林。

A personal blog for full-stack engineers, with a private knowledge base built in. The blog is the primary feature; the knowledge base is a supporting feature, built afterward.

## Status

Currently building **Phase 1 — Blog**. See [`docs/progress.md`](docs/progress.md) for milestone-by-milestone status.

## Stack

- **Frontend**: React + TypeScript, Next.js (SSR/ISR for the public blog, client-rendered admin editor)
- **Backend**: ASP.NET Core Web API
- **Database**: PostgreSQL + EF Core
- **Markdown**: Markdig
- **Deployment**: Docker Compose + Nginx

Full detail in [`docs/architecture.md`](docs/architecture.md).

## Project structure

```
grove/
├── frontend/          # Next.js — public blog + admin editor
├── backend/           # ASP.NET Core Web API
├── docs/              # product & technical docs (see below)
└── docker-compose.yml
```

## Documentation

| Doc                                            | Covers                                     |
| ---------------------------------------------- | ------------------------------------------ |
| [`docs/prd.md`](docs/prd.md)                   | Scope, priorities, requirements            |
| [`docs/brand.md`](docs/brand.md)               | Visual and voice guidelines                |
| [`docs/architecture.md`](docs/architecture.md) | Stack, repo structure, deployment topology |
| [`docs/data-model.md`](docs/data-model.md)     | Schema (ER overview)                       |
| [`docs/api-design.md`](docs/api-design.md)     | API endpoints                              |
| [`docs/decisions.md`](docs/decisions.md)       | Decision log — why things changed          |
| [`docs/progress.md`](docs/progress.md)         | Milestone status                           |

## Getting started

> Local dev setup isn't finalized yet (M1 in progress) — fill this in once the Docker Compose environment is working.

```bash
git clone <repo-url>
cd grove
docker compose up
```

- Frontend: http://localhost:3000 _(placeholder — confirm once configured)_
- API: http://localhost:5000 _(placeholder — confirm once configured)_

## Roadmap

- **Phase 1 — Blog**: writing, publishing, tags, search, RSS/SEO _(in progress)_
- **Phase 2 — Knowledge base**: bidirectional links, knowledge graph, learning paths
- **Phase 3 — Review system**: flashcards, spaced repetition

See [`docs/prd.md`](docs/prd.md) §8 for the full milestone breakdown.

## License

TBD — personal project; not yet decided if or how it'll be open-sourced.
