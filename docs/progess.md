# Grove — Progress

**Related**: [Grove_prd.md](Grove_prd.md) §8 (milestone definitions), [decisions.md](decisions.md)
**Last updated**: 2026-09-22

**How to use this file**: update the status and notes as you go — no fixed format required, just enough that a fresh chat can tell where things stand without you re-explaining. When you re-upload it, I'll read it at the start of a session instead of asking.

---

## Current focus

**Milestone**: M1 — Data model + single-user login + backend CRUD
**Status**: Not started
**Notes**: —

---

## Milestone tracker

### Phase 1 — Blog

| Milestone | Content                                                              | Status      | Notes |
| --------- | -------------------------------------------------------------------- | ----------- | ----- |
| M1        | Data model + single-user login + backend CRUD                        | Not started |       |
| M2        | Markdown rendering + editor (frontend)                               | Not started |       |
| M3        | Frontend list / detail / edit for posts                              | Not started |       |
| M4        | Tags + search (English, Postgres FTS) + blog feed + public-view isolation | Not started |       |
| M5        | Deploy + backup + basic SEO + RSS (**MVP live**)                     | Not started |       |

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
