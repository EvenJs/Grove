# Grove — Architecture

**Related**: [Grove_prd.md](Grove_prd.md) (scope & requirements), [api-design.md](api-design.md) (endpoints), [data-model.md](data-model.md) (schema)
**Last updated**: 2026-09-22

---

## Stack

**Selection principle**: a personal project, free-first. All software is open-source and free; the runtime environment prefers free or low-cost options, and should run as few independent services as possible — ideally everything on one machine via Docker Compose.

| Layer              | Choice                                        | Notes                                                                                                                                                    |
| ------------------ | --------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Frontend           | React + TypeScript, on Next.js                | Public blog pages need SSR/ISR for SEO; the editing back-office lives in the same project, client-rendered only                                          |
| Backend            | ASP.NET Core Web API (current LTS)            | The frontend fetches data via the API; SSR also calls it                                                                                                 |
| Database           | PostgreSQL                                    |                                                                                                                                                          |
| ORM                | EF Core                                       |                                                                                                                                                          |
| Markdown rendering | Markdig                                       |                                                                                                                                                          |
| Search             | A PostgreSQL-based approach (see prd.md §4.5) | No separate search service for now                                                                                                                       |
| Graph              | D3.js or Cytoscape.js                         | Phase 2; choose when building it                                                                                                                         |
| File storage       | Local disk on the server (Docker volume)      | Images, attachments; no object storage for now                                                                                                           |
| Deployment         | Docker Compose + Nginx                        | See below for the runtime environment                                                                                                                    |
| Auth               | Cookie session (HttpOnly), single user        |                                                                                                                                                          |
| Localization       | next-intl (or react-i18next)                  | Chrome text only, not post content; switch mechanism (explicit toggle vs. Accept-Language detection vs. URL prefix like `/en`, `/zh`) — decide during M3 |

**Runtime environment**: v1 deploys to a single free or low-cost machine (a machine you own, or a cloud provider's free tier). Free-tier terms change, so confirm the specific provider right before deployment (M5).

**Repo structure**: monorepo — `frontend/` (Next.js) + `backend/` (ASP.NET Core), one `docker-compose.yml` at root. Backend is a single project, folder-separated (`Controllers/`, `Models/`, `Data/`, `Services/`), no Clean Architecture layering yet. See decisions.md for the reasoning.

## Architecture Diagram

```
[Browser]
   │
   ▼
[Nginx reverse proxy]
   │
   ├──► /api/*      ──► [Grove API (ASP.NET Core)] ──► [PostgreSQL]
   │                            ▲
   └──► other paths ──► [Next.js (React)]
                        Public blog pages (SSR/ISR) + editing back-office
                        SSR calls the Grove API for data
```
