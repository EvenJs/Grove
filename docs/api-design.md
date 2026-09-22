# Grove — API Design

**Related**: [Grove_prd.md](Grove_prd.md) (scope & requirements), [architecture.md](architecture.md) (stack), [data-model.md](data-model.md) (schema)
**Last updated**: 2026-09-22

---

## Core API List

```
GET    /api/notes                  List (paginated, filterable)
GET    /api/notes/{slug}           Detail (incl. backlinks)
POST   /api/notes                  Create
PUT    /api/notes/{id}             Update
DELETE /api/notes/{id}             Delete
GET    /api/notes/{slug}/backlinks Backlinks
GET    /api/search?q=              Search
GET    /api/tags                   Tag list
GET    /api/graph                  Graph data
GET    /api/paths                  Path list
GET    /api/review/today           Today's review queue (Phase 3)
POST   /api/review/{id}            Submit a review rating (Phase 3)
GET    /rss.xml                    RSS
POST   /api/auth/login             Login (all write endpoints require it)
# Read endpoints return public content only for anonymous requests — see prd.md §4.6, B-07
```

> This is currently just the endpoint list carried over from the PRD. Add request/response shapes, status codes, and error formats here as each endpoint gets built in M1 — this file is meant to grow into the real API reference rather than staying a one-liner list.
