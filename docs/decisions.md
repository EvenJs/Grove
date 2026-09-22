# Grove — Decision Log

Reverse-chronological. One entry per decision: what was decided, why, and what it changed (if anything) in `Grove_prd.md` or `Grove_brand.md`. `Grove_prd.md` and `Grove_brand.md` are the source of truth for current state; this file is the paper trail for how they got there.

---

## 2026-09-22 — Repo structure: monorepo

**Decision**: single git repo, `frontend/` (Next.js) + `backend/` (ASP.NET Core) folders, one `docker-compose.yml` at root. Backend is a single project, folder-separated (`Controllers/`, `Models/`, `Data/`, `Services/`) — no Clean Architecture layering yet.

**Why**: solo developer, one deploy target, Phase 1 scope is small (Note, Tag, User). Splitting into multiple repos or layered projects is overhead with no current payoff; can revisit once Phase 2 adds enough entities to make folders feel crowded.

**Affects**: implementation detail, not a PRD requirement — recorded here for reference only.

## 2026-09-22 — UI chrome is bilingual (English/Chinese)

**Decision**: chrome text only (nav, buttons, labels, system messages) is bilingual and switchable. Each note/post stays in whichever single language it was written in — no per-post translation. Full dual-language content per post is a possible future expansion, not in v1.

**Why**: author writes in both languages day to day; full per-post translation is out of scope for a one-person blog.

**Affects**: PRD §5 (Localization row added), §6.1 (i18n stack line added, e.g. next-intl), §4.2 (flagged an open item: no `language` field on Note yet). Brand doc §6 (voice section resolved from "to confirm," copy examples rewritten as real EN/ZH pairs instead of translation glosses).

## 2026-09-22 — Tags and search ship with Phase 1

**Decision**: kept in Phase 1 (blog), not deferred to Phase 2 with the rest of the knowledge base.

**Why**: a blog needs its own post categorization and lookup, independent of note-linking features.

**Affects**: PRD §4.0 (open question resolved).

---

## Earlier decisions (recorded before this log started)

These were made in discussion prior to this file existing; dates are approximate.

- **Blog precedes knowledge base**: Grove ships in three phases — Phase 1 Blog, Phase 2 Knowledge Base, Phase 3 Review System (flashcards/SM-2). Previously blog and knowledge-base features were bundled into one MVP; bidirectional links, backlinks, and the knowledge graph now ship in Phase 2. _Affects: PRD §1.1, §4 restructured by phase, §8 milestones regrouped._
- **Primary audience**: mainly the author himself, for writing and note-taking; public visibility is secondary. _Affects: PRD §1.3, §2._
- **No comments in Phase 1**: explicitly out of scope for the blog phase, not urgent. _Affects: PRD §1.4 (added as an explicit non-goal, previously unmentioned)._
- **Publishing workflow — web editor, not Git sync**: content is published via a web-based editor with login, not a Git-based import/sync workflow. Chosen to keep the architecture open for a possible future multi-user product — a Git-sync model doesn't generalize past a single technical user. _Affects: PRD §4.11 (auth), §6.1 (stack)._
- **Git import — later, supplementary**: a one-time batch import (parse a repo's Markdown files into drafts) can be added later without changing the current architecture. A live-sync (webhook) approach or a Git-as-database approach were considered and rejected — the former adds real complexity (source-of-truth conflicts, idempotency, webhook auth) and the latter conflicts with the web-editor decision above. _Affects: PRD §4.10 (I-02)._
- **All Grove documentation in English**: PRD, specs, and decisions are written in English regardless of what language the discussion happens in.
