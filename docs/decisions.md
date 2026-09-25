# Grove — Decision Log

Reverse-chronological. One entry per decision: what was decided, why, and what it changed (if anything) in the other Grove docs (`prd.md`, `brand.md`, `architecture.md`, `data-model.md`, `api-design.md`). Those docs are the source of truth for current state; this file is the paper trail for how they got there.

---

## 2026-09-23 — User logs in with email, not username; added first/last name for display

**Decision**: `User`'s login identifier is `email` (unique), replacing the earlier `username` field. Added `first_name` / `last_name`, used to show an author byline on posts, unrelated to login.

**Why**: single-user system, email is what you'd actually type day to day, no real need for a separate username. Author display name wasn't specified anywhere before now; needed once posts show who wrote them.

**Affects**: prd.md §4.11 (A-01 now "email + password", A-02 mentions display name at setup); data-model.md (User table: `username` → `email`, added `first_name`/`last_name`, unique index moves to `email`).

## 2026-09-22 — Backend restructured to full Clean Architecture (supersedes the structural half of the monorepo decision below)

**Decision**: reversed the single-project call from earlier the same day. Backend is now four projects — `Grove.Domain`, `Grove.Application`, `Grove.Infrastructure`, `Grove.Api` — with project references enforcing the dependency rule (Domain depends on nothing; Application depends on Domain; Infrastructure implements Application's interfaces; Api wires it together). SOLID applies within each project.

**Why**: chose full Clean Architecture deliberately, for the practice/rigor of doing it properly — not because Phase 1's scope (Note, Tag, User) demands it. Worth being explicit that this trades away what the single-project decision optimized for: a compiler-enforced boundary matters most for stopping a teammate from cutting corners, and there's no teammate here. Traded that for the discipline of doing the real thing rather than a folder-based approximation. Application layer uses CQRS with MediatR (Commands/Queries + handlers, organized per feature) rather than plain service classes — more ceremony, consistent with doing Clean Architecture for the practice rather than the minimum needed for Phase 1's scope.

**Affects**: `architecture.md` (repo-structure section rewritten, Application layer folder shape added), progess.md (M1 Step 0 scaffolding checklist and Tasks rewritten for the four-project structure and MediatR).

## 2026-09-22 — Heading-level links for Phase 2, not full block-level

**Decision**: Phase 2 links support `[[Title#Heading]]` — jump to a heading inside a note — but not full block-level referencing/transclusion (Logseq-style). `content_md` stays a single field per note; Link table gets an optional `target_heading_slug`.

**Why**: came up while discussing a multi-section article (OOP: inheritance/encapsulation/polymorphism) — whole-note-only links (the original §4.3 scope) couldn't reference just one section. Full block-level modeling (per-block IDs, blocks as the link unit, embed/transclusion rendering) would mean redesigning Note/Link from scratch and blocks the current schema; heading-level links solve the actual pain (referencing a section) at a fraction of the cost, at the price of not being able to embed/display a section's content elsewhere.

**Affects**: PRD §4.3 (added L-09), Link table (added `target_heading_slug`).

## 2026-09-22 — Blog posts and notes stay one Note entity, not split into Post + Note

**Decision**: no separate Post table. Blog-specific fields (`excerpt`, `cover_image_url`) are added as optional columns directly on Note, nullable for private notes. The editor gets two creation entry points ("New Note" / "New Blog Post") that only change which fields the form shows by default — same underlying record, nothing stored about which entry point was used.

**Why**: splitting into two entities would reintroduce the exact problem §1.2 of the PRD names as a reason Grove exists ("blog and knowledge base use separate tools, duplicate upkeep") — publishing a note would become a cross-table migration or a reference-based split, and Phase 2's Link table would need a polymorphic target (Note or Post), which relational databases handle badly. A few nullable columns on Note get the same practical benefit (post-specific fields) without any of that. Considered adding an `intent` field (note vs. post) at creation time to record the author's original plan; deferred — it's a non-breaking addition, so it can be added later if filtering by original intent ever actually comes up.

**Affects**: PRD §4.2 (added N-09, `excerpt`, `cover_image_url` on the Note table).

---

## 2026-09-22 — Split technical docs out of the PRD

**Decision**: pulled §6 (stack, architecture diagram) and §7 (data model ER overview) out of `Grove_prd.md` into three new standalone files: `architecture.md`, `api-design.md`, `data-model.md`. The PRD now just points to each. Field-level table schemas (Note, Link, Tag, etc., with columns and indexes) stay in PRD §4 for now, next to each feature's requirements — not yet consolidated into `data-model.md`.

**Why**: schema and API surface change constantly during build (M1 especially); keeping them inside the requirements source-of-truth document made routine implementation churn look like it was touching product scope. Considered also splitting `ui-layout.md` and `deployment.md` now, and switching to one-file-per-decision ADRs instead of this single log — both rejected as premature: no UI decided yet, deployment target not needed until M5, and ~5 log entries don't justify the fragmentation of per-file ADRs yet.

**Affects**: PRD §6 and §7 replaced with pointers; `architecture.md`, `api-design.md`, `data-model.md` created.

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
