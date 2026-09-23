# Grove — Progress

**Related**: [Grove_prd.md](Grove_prd.md) §8 (milestone definitions), [decisions.md](decisions.md)
**Last updated**: 2026-09-22

**How to use this file**: update the status and notes as you go — no fixed format required, just enough that a fresh chat can tell where things stand without you re-explaining. When you re-upload it, I'll read it at the start of a session instead of asking.

---

## Current focus

**Milestone**: M1 — Data model + single-user login + backend CRUD
**Status**: In progress
**Notes**: Solution scaffolded (2026-09-23): four backend projects with correct project references, MediatR added, Next.js frontend created, docker-compose.yml with the `db` service. Still bare — Class1.cs placeholders, no entities, no DbContext, default Program.cs.

### M1 — Step 0: project scaffolding

- [x] Monorepo layout: `frontend/` (Next.js) + `backend/` (ASP.NET Core) folders, `docker-compose.yml` at root
- [x] `backend/` solution (`Grove.slnx`), four projects with references verified pointing inward: `Grove.Domain` (none) ← `Grove.Application` (→ Domain) ← `Grove.Infrastructure` (→ Application, Domain) ← `Grove.Api` (→ Application, Infrastructure). Target framework `net10.0` throughout.
- [ ] `Grove.Domain`: Note, Tag, NoteTag, User entities/enums — still just the template's `Class1.cs`
- [x] MediatR package added to `Grove.Application` (v14.2.0)
- [ ] `Grove.Application`: actual Commands/Queries per feature (`Notes/Commands/CreateNote`, `Notes/Queries/GetNoteBySlug`, etc.), plus interfaces like `IApplicationDbContext`
- [ ] `Grove.Infrastructure`: EF Core + Npgsql packages, `DbContext` implementing Application's interfaces — not added yet
- [ ] `Grove.Api`: DI wiring (`AddApplication()`, `AddInfrastructure()`), thin controllers sending via `IMediator` — currently just the default `dotnet new webapi` template (`AddControllers()`, `AddOpenApi()`, no MediatR/Infrastructure wiring)
- [x] Docker Compose: `db` service (Postgres 17)
- [ ] Docker Compose: `backend` service — not added yet
- [ ] A trivial health-check endpoint (`GET /api/health`) to confirm the API boots, DI resolves across all four projects, and it reaches Postgres, before writing anything real

### M1 — Tasks

- [ ] EF Core migrations: Note, Tag, NoteTag, User (schema in data-model.md). Migrations live in `Grove.Infrastructure`, run with `Grove.Api` as the startup project (`dotnet ef migrations add ... --project Grove.Infrastructure --startup-project Grove.Api`)
- [ ] Note CRUD via MediatR: `CreateNoteCommand`, `UpdateNoteCommand`, `DeleteNoteCommand`, `GetNoteBySlugQuery`, `GetNotesListQuery` (per api-design.md endpoints, `Grove.Application/Notes/`)
- [ ] Title uniqueness check, case-insensitive, on create/update (N-07)
- [ ] Status/visibility fields enforced server-side: a note is only public when `status=published` AND `visibility=public` (§4.2 rule)
- [ ] Deletion impact-scope check (N-08) — for M1 this just reports 0 links / 0 paths, since Link/Path tables don't exist yet; revisit once Phase 2 ships
- [ ] Single-user login endpoint, cookie session (A-01)
- [ ] Credentials via env var or first-run setup; no signup endpoint exists (A-02, A-04)
- [ ] Auth guard: write endpoints return 401 when unauthenticated (A-03)
- [ ] Rate-limit failed logins via `failed_attempts` / `locked_until` (A-05)
- [ ] Change-password endpoint (A-06); session lifetime via cookie config, not DB — see decisions.md

### M1 — Definition of done

Pulled from prd.md's acceptance criteria (§4.2, §4.11), filtered to what's backend-testable at this stage. Frontend-facing criteria (markdown rendering, list UI, backlinks) wait for M2/M3/Phase 2.

- [ ] A note created via the API is immediately retrievable via list and detail
- [ ] Creating or updating a note with a title that collides (case-insensitive) with an existing one fails with a clear error
- [ ] A note is visible to anonymous requests only when `status=published` AND `visibility=public`; every other combination stays hidden
- [ ] Any write endpoint (create/update/delete) called unauthenticated returns 401
- [ ] Once logged in, all notes (draft or published, private or public) can be read and written
- [ ] No registration/signup endpoint exists anywhere in the API
- [ ] Exceeding the failed-login threshold locks the account until `locked_until` passes, then unlocks automatically on its own

### M1 — Still to decide while building (not blocking start)

- **Slug generation**: auto-derive from title (slugify + collision suffix) vs. author sets it manually. Not specified anywhere yet, needed before the create endpoint can be written. Not worth a decisions.md entry unless you want one on record.
- **Failed-login threshold and lockout duration**: PRD says "rate-limit," no numbers given (e.g. 5 attempts / 15 minutes is a reasonable default). Same, your call, log it only if you want it tracked.

---

## Milestone tracker

### Phase 1 — Blog

| Milestone | Content                                                                   | Status      | Notes |
| --------- | ------------------------------------------------------------------------- | ----------- | ----- |
| M1        | Data model + single-user login + backend CRUD                             | Not started |       |
| M2        | Markdown rendering + editor (frontend)                                    | Not started |       |
| M3        | Frontend list / detail / edit for posts                                   | Not started |       |
| M4        | Tags + search (English, Postgres FTS) + blog feed + public-view isolation | Not started |       |
| M5        | Deploy + backup + basic SEO + RSS (**MVP live**)                          | Not started |       |

### Phase 2 — Knowledge Base

| Milestone | Content                                       | Status      | Notes |
| --------- | --------------------------------------------- | ----------- | ----- |
| M6        | Bidirectional links + backlinks + rename-sync | Not started |       |
| M7        | Knowledge graph + learning paths              | Not started |       |
| M8        | Import/export (incl. Git import) + iteration  | Not started |       |

### Phase 3 — Review System

| Milestone | Content           | Status      | Notes                     |
| --------- | ----------------- | ----------- | ------------------------- |
| M9        | Flashcards + SM-2 | Not started | Timing TBD, after Phase 2 |

**Status values**: Not started / In progress / Blocked / Done

---

## Open items carried from prd.md / decisions.md

Things already decided to revisit at a specific point — not blocking right now, but don't let them slide past their milestone unnoticed:

- [ ] **Note `language` field** (`en` / `zh`) + **Chinese search approach** (zhparser vs. pg_trgm vs. Meilisearch) — decide together, whenever you're about to publish your first Chinese-language note; not tied to a milestone. Until then, M1/M4 build plain English Postgres full-text search.
- [ ] **Language-switch mechanism** for bilingual UI chrome (toggle vs. Accept-Language detection vs. URL prefix) — decide during M3
