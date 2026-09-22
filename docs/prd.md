# Grove Product Requirements Document (PRD)

**Product**: Grove
**Version**: v1.3 (English; re-scoped into phased delivery)
**Status**: Draft
**Author**: —
**Last updated**: 2026-09-22 (schema consolidation)

**Changelog (v1.2 → v1.3)**:

- Translated from Chinese to English.
- Made the blog-first sequencing explicit: **Phase 1 = Blog, Phase 2 = Knowledge Base, Phase 3 = Review System**. Previously the MVP (M1–M5) bundled blog and knowledge-base features (bidirectional links, tags, search) together; bidirectional links and the knowledge graph now move to Phase 2.
- Added "Comments" as an explicit non-goal for the blog phase.
- Redefined MVP as Phase 1 only (write posts, view posts, tags, search, blog — no backlinks).
- Milestones renumbered and regrouped by phase (M1–M9 instead of M1–M7 + "later").

---

## 1. Product Overview

### 1.1 One-line positioning

**Grove** is a **personal blog** for full-stack engineers, with a **private knowledge base** built in: the blog is for publishing technical write-ups and best practices; the knowledge base is for learning notes, kept for later lookup. **The blog is the primary feature. The knowledge base is a supporting feature, built afterward.**

Grove ships in three phases:

- **Phase 1 — Blog**: write, publish, and share technical posts.
- **Phase 2 — Knowledge Base**: connect notes with bidirectional links, tags-as-a-graph, search, and learning paths.
- **Phase 3 — Review System** (later): flashcards and spaced repetition.

### 1.2 Background & Problems

| Current problem                          | Description                                                                                       |
| ---------------------------------------- | ------------------------------------------------------------------------------------------------- |
| Nowhere to capture learning              | Notes are scattered across tools, with no single place to record them                             |
| Hard to find knowledge later             | Folder-based organization forces a note into one place; can't be found from multiple entry points |
| Review relies on re-reading              | No review mechanism; learned material fades over time                                             |
| Blog and knowledge base are disconnected | Different tools for each, duplicate upkeep                                                        |

### 1.3 Goals

**Primary feature (Blog) — Phase 1**

- **Publish**: turn technical write-ups into blog posts, public to readers, discoverable via search engines and RSS.
- **Capture**: write learning notes and best practices with low friction, using the same editor for blog posts and private notes.

**Supporting feature (Knowledge Base) — Phase 2**

- **Organize**: connect notes into a network via bidirectional links + tags.
- **Look up**: search + backlinks, find knowledge from multiple entry points.
- **Review**: learning paths first, for systematic reinforcement; spaced repetition comes in Phase 3.

### 1.4 Non-goals

- Multi-user signup and collaboration
- Native mobile app (PWA for now)
- Real-time collaborative editing
- AI-assisted writing
- **Comments** — not part of the blog phase; deferred, not urgent
- **Knowledge-base features** (bidirectional links, backlinks, tag-graph, knowledge graph, learning paths) — deferred to Phase 2; out of scope for the Phase 1 blog
- **Review system** (Flashcards + SM-2) — deferred to Phase 3; requirements draft kept in §4.9
- Note cloning — tags + backlinks already cover "one note, multiple entry points"; not needed

### 1.5 Scale assumptions (to confirm)

Assumptions the design is based on. If actual usage doesn't match, the search and graph approach need re-evaluating:

- Single user, personal use
- Total notes ≤ 5,000, each ≤ 100 KB
- Public notes ≤ 500
- Graph renders ≤ 1,000 nodes per view; beyond that, show a local subgraph only

---

## 2. Target Users

| User                  | Profile                                                                                          | Core need                                                                                     |
| --------------------- | ------------------------------------------------------------------------------------------------ | --------------------------------------------------------------------------------------------- |
| Author (primary user) | Full-stack engineer spanning frontend, backend, database, AI, and DevOps; keeps notes as a habit | Publish technical blog posts; keep learning notes organized for later lookup                  |
| Reader (visitor)      | Other developers visiting the blog (frontend, backend, AI, DevOps, etc.)                         | A comfortable reading experience, discoverable via search engines or RSS, clean readable code |
| Usage scenarios       | Learning new tech, recording pitfalls, interview prep, organizing best practices                 | Quick capture, easy lookup, periodic review                                                   |

**Example persona**:

> A full-stack engineer whose work and learning span frontend, backend, database, AI, and DevOps. Writes up pitfalls and best practices as blog posts. Saves notes from learning new technologies into the knowledge base, to look up quickly when needed or before interviews, and reviews them systematically via learning paths.

---

## 3. Core Concepts

| Concept       | Description                                               | Ships in |
| ------------- | --------------------------------------------------------- | -------- |
| **Seed**      | The smallest unit of knowledge — a note, in Markdown      | Phase 1  |
| **Roots**     | Bidirectional links between notes                         | Phase 2  |
| **Backlink**  | All notes linking to the current note                     | Phase 2  |
| **Species**   | Tags — coarse categories; a note can have several         | Phase 1  |
| **Clearing**  | A published, public note — a blog post                    | Phase 1  |
| **Trail**     | A hand-curated sequence of notes, for structured learning | Phase 2  |
| **Flashcard** | A review unit tied to a note, driven by SM-2              | Phase 3  |
| **Canopy**    | The visual graph of notes and links                       | Phase 2  |

**Underlying philosophy**: the data model is a network; the views on top of it can be linear.

**Naming metaphor**: Grove is a forest. Each note is a tree. Links are roots. Over time, it grows into a forest.

---

## 4. Functional Requirements

### 4.0 Phasing Overview

| Phase                        | Scope                                                                           | Notes                        |
| ---------------------------- | ------------------------------------------------------------------------------- | ---------------------------- |
| **Phase 1 — Blog**           | Post authoring, tags, search (public content), blog publishing, access control  | Ships first; this is the MVP |
| **Phase 2 — Knowledge Base** | Bidirectional links & backlinks, knowledge graph, learning paths, import/export | Ships after Phase 1          |
| **Phase 3 — Review System**  | Flashcards + SM-2 spaced repetition                                             | Later; timing TBD            |

> Product focus: the blog is the primary feature; the knowledge base is a supporting feature that follows it. When trade-offs are needed, protect the blog's reader experience and discoverability first.

**Confirmed**: tags and search ship with Phase 1 (blog), since a blog needs its own post categorization and lookup.

### 4.1 Functional Summary

| Module              | Priority | Phase | Description                                                                   |
| ------------------- | -------- | ----- | ----------------------------------------------------------------------------- |
| Content management  | P0       | 1     | Create/edit/delete/view; Markdown editing & rendering; draft/published status |
| Bidirectional links | P0       | 2     | Link parsing, backlink display, navigation, auto-sync on rename               |
| Tags                | P0       | 1     | Tag CRUD, filter by tag                                                       |
| Search              | P0       | 1     | Full-text search (incl. Chinese/CJK), highlighted results                     |
| Blog publishing     | P0       | 1     | Public/private, blog feed, public-view isolation, RSS, SEO                    |
| Access control      | P0       | 1     | Single-user login; unauthenticated visitors can only read public content      |
| Knowledge graph     | P2       | 2     | Node/edge visualization (optional)                                            |
| Learning paths      | P1       | 2     | Note sequences, progress tracking                                             |
| Import/export       | P2       | 2     | Obsidian/Markdown bulk import; Git-based import as a later option             |
| Version history     | P2       | 2     | Edit history & diff                                                           |
| Review system       | P2       | 3     | Cards, SM-2, review queue                                                     |

---

### 4.2 Content Management (Phase 1, P0)

**Description**: create, edit, delete, and view notes (Seeds). In Phase 1 this is effectively post authoring for the blog.

**Detailed requirements**:

| ID   | Requirement                                                                                                                              | Priority |
| ---- | ---------------------------------------------------------------------------------------------------------------------------------------- | -------- |
| N-01 | Markdown editing with live preview                                                                                                       | P0       |
| N-02 | Syntax highlighting for code blocks                                                                                                      | P0       |
| N-03 | Image and attachment upload                                                                                                              | P0       |
| N-04 | A note has a title, slug, body, tags, created/updated timestamps                                                                         | P0       |
| N-05 | Draft and published states (draft is a prerequisite for public release)                                                                  | P0       |
| N-06 | Note archiving                                                                                                                           | P2       |
| N-07 | Note titles are unique (case-insensitive); saving fails with a message on collision                                                      | P0       |
| N-08 | Deleting a note warns about impact scope (how many notes link to it, how many paths it belongs to); deletion is permanent once confirmed | P0       |
| N-09 | A note can be created via two entry points ("New Note" / "New Blog Post") that only change which fields the form shows by default (blog fields: `excerpt`, `cover_image_url`); same underlying Note record either way | P0       |

**Status and visibility**: two fields, each governing one thing, with no overlap.

| Field      | Values                       | Meaning                             |
| ---------- | ---------------------------- | ----------------------------------- |
| status     | draft / published / archived | Writing progress; defaults to draft |
| visibility | private / public             | Who can see it; defaults to private |

Rule: a note is a Clearing (i.e., appears on the blog) only when `status = published` AND `visibility = public`. In draft or archived status, visibility has no effect — the note is never publicly visible.

**Deletion rules**:

- Links from this note to others: deleted along with it.
- `[[Title]]` references to it from other notes: body text is left unchanged and becomes an "unresolved link" (see §4.3); recreating a note with the same title restores it.
- Tag associations and path items: deleted along with it (tags and paths themselves are kept).
- Flashcards: deleted along with the note (to be confirmed once the review system ships in Phase 3).

**Note table**: field-level schema (columns, indexes) in [data-model.md](data-model.md), including blog-specific `excerpt` / `cover_image_url` columns (nullable, added for N-09). Open item: no `language` field yet — see data-model.md, decide before M4.

**Acceptance criteria**:

- A new note appears in the list within 1 second of creation.
- Markdown renders correctly; code blocks are highlighted.
- Backlinks update automatically after an edit is saved.
- Saving fails with a message when the title collides with an existing note.
- After a note is deleted, links to it from other notes render as unresolved links, without errors.

---

### 4.3 Bidirectional Links & Backlinks (Phase 2, P0 within Phase 2)

**Description**: a note references another via `[[Title]]`, and the system automatically builds a bidirectional relationship (Roots). Link relationships are derived data parsed from the body, with `content_md` as the source of truth: re-parsed on every save, fully rebuilding that note's outbound links.

**Detailed requirements**:

| ID   | Requirement                                                                                                                     | Priority |
| ---- | ------------------------------------------------------------------------------------------------------------------------------- | -------- |
| L-01 | Parse `[[Title]]`, match the target note by title (case-insensitive), and record the target note's id                           | P0       |
| L-02 | Show a backlink list on the note detail page                                                                                    | P0       |
| L-03 | Clicking a link navigates to the target note                                                                                    | P0       |
| L-04 | If the target note doesn't exist, saving still succeeds; record it as an "unresolved link" and style it differently in the body | P0       |
| L-05 | Support `[[uuid\|Display Name]]` alias syntax                                                                                   | P1       |
| L-06 | Show a context snippet on each backlink                                                                                         | P1       |
| L-07 | Renaming a note automatically rewrites `[[Old Title]]` to the new title in every other note's body, without breaking the link   | P0       |
| L-08 | Clicking an unresolved link offers to create a matching note; once created, related links are auto-completed                    | P1       |
| L-09 | Support `[[Title#Heading]]` to jump to a specific heading inside a note (not block-level embedding/transclusion)                  | P1       |

In the public view, backlinks only show links coming from public notes — see the rule in §4.6, B-07.

**Link table (link relationships)**

| Field          | Type      | Description                                                                                                                                          |
| -------------- | --------- | ---------------------------------------------------------------------------------------------------------------------------------------------------- |
| id             | bigint    | Primary key                                                                                                                                          |
| source_note_id | bigint    | Source note ID                                                                                                                                       |
| target_note_id | bigint    | Target note ID; null for an unresolved link                                                                                                          |
| target_title   | varchar   | The title as written in the link; used for matching, auto-completion, and the "create note" prompt                                                   |
| context        | text      | The paragraph containing the link (for backlink summaries); for repeated links to the same target from the same source, the first occurrence is kept |
| target_heading_slug | varchar | Optional; set when the link is `[[Title#Heading]]` — slug of the target heading within the target note. Null for a whole-note link.            |
| created_at     | timestamp | Created time                                                                                                                                         |

**Suggested indexes**:

- Index on `source_note_id` (what a note links out to)
- Index on `target_note_id` (what links to a note — i.e., backlinks)
- Unique constraint on `(source_note_id, lower(target_title))`: one row per source–title pair

**Acceptance criteria**:

- Writing `[[B]]` in note A makes A appear immediately in B's backlinks.
- Deleting the link removes it from the backlinks accordingly.
- Backlinks are clickable and navigate correctly.
- Renaming B to C automatically turns `[[B]]` in A into `[[C]]`; A still appears in C's backlinks.
- Writing `[[A note that doesn't exist yet]]` in A saves successfully; creating a note with that title later makes A appear in its backlinks.

---

### 4.4 Tags (Phase 1, P0)

**Description**: coarse categorization of notes/posts using tags (Species).

**Detailed requirements**:

| ID   | Requirement                   | Priority |
| ---- | ----------------------------- | -------- |
| T-01 | Create, rename, delete tags   | P0       |
| T-02 | A note can have multiple tags | P0       |
| T-03 | Filter the note list by tag   | P0       |
| T-04 | Tag cloud / tag listing page  | P1       |

**Tag / NoteTag tables**: field-level schema (columns, indexes) moved to [data-model.md](data-model.md).

---

### 4.5 Search (Phase 1, P0)

**Description**: full-text search over title and body, with highlighted results.

**Detailed requirements**:

| ID   | Requirement                                                                                                                                                                                    | Priority |
| ---- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------- |
| S-01 | Full-text search over title and body                                                                                                                                                           | P0       |
| S-02 | Highlight matched keywords in results                                                                                                                                                          | P0       |
| S-03 | Filter by tag and type                                                                                                                                                                         | P1       |
| S-04 | Search inside code blocks                                                                                                                                                                      | P1       |
| S-05 | Search suggestions / autocomplete                                                                                                                                                              | P2       |
| S-06 | Chinese and mixed Chinese/English content is searchable (e.g., searching "依赖注入" matches notes containing that phrase; searching "EF Core 迁移" matches both the English and Chinese parts) | P0       |

**Technical approach**: content is English-only for now, so M1/M4 build plain PostgreSQL full-text search (`tsvector` + `english` config + `ts_rank`) — proper stemming and relevance ranking for what's actually being written today. PostgreSQL's native full-text search can't segment Chinese by word with the default configuration, so it alone won't satisfy S-06 once Chinese notes appear. That decision (and the `language` column it depends on) is deferred until then, not tied to a milestone — see decisions.md. Options at that point: (a) PostgreSQL + a Chinese segmentation extension (e.g. zhparser); (b) PostgreSQL + `pg_trgm` substring matching; (c) Meilisearch (built-in Chinese segmentation, but adds another service and memory footprint — lowest priority under the free-first constraint). Prefer (a) or (b) to keep search inside PostgreSQL. Evaluate against the §1.5 scale assumption (≤ 5,000 notes).

**Acceptance criteria**:

- Results return within 1 second of a query.
- Results are sorted by relevance.
- Keywords are highlighted in the excerpt.
- Searching "依赖注入" matches Chinese notes containing that term (once Chinese search is implemented — see Technical approach above; not required before then).
- Anonymous searches only return public notes.

---

### 4.6 Blog Publishing (Phase 1, P0, primary feature)

**Description**: display public notes (Clearings — `status = published` AND `visibility = public`) as a blog feed, sorted by publish time, descending.

**Detailed requirements**:

| ID   | Requirement                                                                                                                         | Priority |
| ---- | ----------------------------------------------------------------------------------------------------------------------------------- | -------- |
| B-01 | A note can be toggled public/private                                                                                                | P0       |
| B-02 | Public notes display as a blog feed, sorted by `published_at`, descending                                                           | P0       |
| B-03 | Blog post pages have a shareable link                                                                                               | P0       |
| B-04 | RSS feed                                                                                                                            | P0       |
| B-05 | SEO support (sitemap, meta tags)                                                                                                    | P0       |
| B-06 | Custom domain support                                                                                                               | P2       |
| B-07 | Public-view isolation: everything an unauthenticated visitor sees must come only from public notes (rules below)                    | P0       |
| B-08 | Un-publishing (back to draft or archived) makes the original public URL return 404 immediately; RSS and sitemap are updated in sync | P0       |
| B-09 | When making a note public, if its body links to a private note, warn "N link(s) won't be clickable for visitors"                    | P1       |

**Public-view isolation rules (B-07)**:

| Location                                              | What an unauthenticated visitor sees                                                     |
| ----------------------------------------------------- | ---------------------------------------------------------------------------------------- |
| Blog feed, RSS, sitemap                               | Public notes only                                                                        |
| Backlink list and count                               | Only backlinks from public notes; private sources are hidden and excluded from the count |
| A `[[private note]]` link inside a public note's body | Rendered as plain text, not a link — keeping only the wording the author wrote           |
| Search                                                | Public notes only                                                                        |
| Tag listing                                           | Counts only public notes; a tag with no public notes doesn't show                        |
| Graph                                                 | Public notes only, and the links between them                                            |
| Learning paths                                        | Visible only when logged in, in v1                                                       |
| Private note / draft URLs                             | Return 404, not 403                                                                      |

**Acceptance criteria**:

- Private notes never appear in the blog feed.
- Public notes are reachable directly by URL.
- The RSS feed subscribes correctly in a reader.
- Search engines can crawl post bodies: the HTML response includes the body directly, without depending on client-side rendering.
- No unauthenticated response includes the title, slug, or body of a private note.
- When a public note is linked from a private note, the visitor doesn't see that backlink, and it isn't counted.
- Un-publishing makes the original URL return 404.

---

### 4.7 Knowledge Graph (Phase 2, P1)

**Description**: a Canopy view showing the network of notes and links.

**Detailed requirements**:

| ID   | Requirement                              | Priority |
| ---- | ---------------------------------------- | -------- |
| G-01 | Visualize the network of notes and links | P1       |
| G-02 | Clicking a node navigates to that note   | P1       |
| G-03 | Filter the graph by tag                  | P2       |
| G-04 | Local graph view (a note's neighbors)    | P2       |

**Technology choice**: D3.js or Cytoscape.js.

---

### 4.8 Learning Paths (Phase 2, P1)

**Description**: organize a group of notes into a Trail, for structured, sequential learning.

**Detailed requirements**:

| ID   | Requirement                                         | Priority |
| ---- | --------------------------------------------------- | -------- |
| P-01 | Create a path; add and order notes                  | P1       |
| P-02 | Path page displays notes in order                   | P1       |
| P-03 | Track progress (done / in progress)                 | P1       |
| P-04 | A path can auto-suggest notes via an associated tag | P2       |

**Path table**

| Field       | Type      | Description      |
| ----------- | --------- | ---------------- |
| id          | bigint    | Primary key      |
| title       | varchar   | Path title       |
| description | text      | Path description |
| created_at  | timestamp | Created time     |

**PathItem table (path entries)**

| Field   | Type   | Description                      |
| ------- | ------ | -------------------------------- |
| id      | bigint | Primary key                      |
| path_id | bigint | Parent path ID                   |
| note_id | bigint | Note ID                          |
| order   | int    | Sort order                       |
| note    | text   | Optional remark for this entry   |
| status  | enum   | not_started / in_progress / done |

**Suggested indexes**:

- Composite index on `PathItem(path_id, order)`, for efficient ordered queries
- Index on `PathItem.note_id` (which paths a note belongs to)

---

### 4.9 Review System (Phase 3, P2, later)

> Not built in Phase 1 or Phase 2. This section is kept as a requirements draft for Phase 3; the tables and endpoints below are not implemented yet. All R-series items are P2.

**Description**: turn notes into flashcards and schedule review using the SM-2 algorithm.

**Detailed requirements**:

| ID   | Requirement                                         | Priority |
| ---- | --------------------------------------------------- | -------- |
| R-01 | Turn a note (or a block within it) into a flashcard | P2       |
| R-02 | Implement the SM-2 spaced-repetition algorithm      | P2       |
| R-03 | Daily review queue                                  | P2       |
| R-04 | Rating: Again / Hard / Good / Easy                  | P2       |
| R-05 | Review stats (streaks, cards due)                   | P2       |

**Flashcard table**

| Field            | Type      | Description                               |
| ---------------- | --------- | ----------------------------------------- |
| id               | bigint    | Primary key                               |
| note_id          | bigint    | Associated note ID                        |
| front            | text      | Card front (question)                     |
| back             | text      | Card back (answer)                        |
| next_review_at   | timestamp | Next review time                          |
| interval         | int       | Current interval, in days                 |
| ease_factor      | float     | Difficulty factor (SM-2's core parameter) |
| review_count     | int       | Number of reviews so far                  |
| last_reviewed_at | timestamp | Last review time                          |

**Suggested indexes**:

- Index on `next_review_at` (query cards due today)
- Index on `note_id` (query a note's cards)

**SM-2 algorithm notes**:

- Rating < 3: reset interval to 1 day.
- Rating ≥ 3: compute the next review time from `ease_factor` and `interval`.
- `ease_factor` adjusts dynamically based on ratings.
- To confirm when this phase is built: how the four-point UI rating (Again / Hard / Good / Easy) maps onto SM-2's 0–5 scale.

---

### 4.10 Import / Export (Phase 2, P2)

**Detailed requirements**:

| ID   | Requirement                                                                                                                                                | Priority |
| ---- | ---------------------------------------------------------------------------------------------------------------------------------------------------------- | -------- |
| I-01 | Import an Obsidian / Markdown folder                                                                                                                       | P2       |
| I-02 | Import from a Git repository (batch, one-time; see the architecture discussion for the recommended approach — parse and insert as drafts, not a live sync) | P2       |
| I-03 | Export all notes as Markdown                                                                                                                               | P2       |
| I-04 | Export as a JSON backup                                                                                                                                    | P2       |

---

### 4.11 Access Control & Authentication (Phase 1, P0)

**Description**: v1 has exactly one user (the site owner). Once logged in, they can read and write everything; unauthenticated visitors can only read public content.

**Detailed requirements**:

| ID   | Requirement                                                                                                             | Priority |
| ---- | ----------------------------------------------------------------------------------------------------------------------- | -------- |
| A-01 | Single-user login (username + password)                                                                                 | P0       |
| A-02 | Account credentials are set via environment variables or a first-run setup page at initial deployment; no public signup | P0       |
| A-03 | All write operations (create/edit/delete, uploads, public/private toggling) require login                               | P0       |
| A-04 | Unauthenticated visitors are read-only, limited to public content (rules in §4.6, B-07)                                 | P0       |
| A-05 | Rate-limit failed logins, to resist brute-forcing                                                                       | P1       |
| A-06 | Change password; configurable session lifetime                                                                          | P1       |

**Acceptance criteria**:

- Any write endpoint called while unauthenticated returns 401.
- Once logged in, all notes can be read and written.
- No signup entry point exists in the UI.

---

## 5. Non-Functional Requirements

| Category      | Requirement                                                                                                                                                                                                                                     |
| ------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Performance   | Note list first paint < 1s; search response < 1s                                                                                                                                                                                                |
| Usability     | Markdown keyboard shortcuts supported; smooth editor experience                                                                                                                                                                                 |
| Security      | Private notes are never accessible without authorization; anonymous requests only ever get public content; HTTPS                                                                                                                                |
| Data          | Scheduled database backups; export supported                                                                                                                                                                                                    |
| Compatibility | Modern browsers (Chrome / Edge / Firefox / Safari)                                                                                                                                                                                              |
| Localization  | UI chrome (nav, buttons, labels, system messages) ships in English and Chinese, switchable; each note/post is authored in a single language, with no auto-translation. Per-post dual-language content is a possible future expansion, not in v1 |
| Rendering     | Public blog pages use server-side rendering or static generation, with the body included directly in the HTML; the editing back-office can be a client-rendered single-page app                                                                 |
| Extensibility | Frontend/backend separated, API-first, to ease a future mobile client                                                                                                                                                                           |
| Deployment    | One-command startup via Docker Compose; runtime environment prefers free or low-cost options                                                                                                                                                    |

---

## 6. Technical Architecture

See [architecture.md](architecture.md) for the stack, repo structure, and architecture diagram, and [api-design.md](api-design.md) for the API surface.

---

## 7. Data Model

See [data-model.md](data-model.md) for the full schema: ER overview plus field-level tables for Note, Tag, NoteTag, and User. Link, Path, PathItem, and Flashcard table definitions remain in §4 next to their Phase 2/3 requirements, to be moved over when those phases start.

---

## 8. Milestones

### Phase 1 — Blog

| Milestone | Content                                                              | Duration | Output                         |
| --------- | -------------------------------------------------------------------- | -------- | ------------------------------ |
| M1        | Data model + single-user login + backend CRUD                        | 1 week   | Working API                    |
| M2        | Markdown rendering + editor (frontend)                               | 1 week   | Can write & preview            |
| M3        | Frontend list / detail / edit for posts                              | 2 weeks  | Read & write                   |
| M4        | Tags + search (English, Postgres FTS) + blog feed + public-view isolation | 1 week   | Phase 1 (P0) features complete |
| M5        | Deploy + backup + basic SEO + RSS                                    | 1 week   | **MVP live**                   |

**MVP definition**: M1–M5 — "write posts + view posts + tags + search + blog," deployed and usable day to day. Bidirectional links are **not** part of MVP; they ship in Phase 2.

### Phase 2 — Knowledge Base

| Milestone | Content                                                  | Duration | Output                     |
| --------- | -------------------------------------------------------- | -------- | -------------------------- |
| M6        | Bidirectional links + backlinks + rename-sync            | 1 week   | Links work                 |
| M7        | Knowledge graph + learning paths (graph is P2, can slip) | 2 weeks  | Knowledge base P1 complete |
| M8        | Import/export (incl. Git import) + iteration             | Ongoing  | P2                         |

### Phase 3 — Review System

| Milestone | Content           | Duration | Output                             |
| --------- | ----------------- | -------- | ---------------------------------- |
| M9        | Flashcards + SM-2 | TBD      | Scheduled after Phase 2, as needed |

---

## 9. Risks & Mitigations

| Risk                                  | Impact                                               | Mitigation                                                                                                                                                                                       |
| ------------------------------------- | ---------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Bidirectional link parsing is complex | Data-model rework                                    | Lock down the syntax and schema early (Phase 2 planning)                                                                                                                                         |
| Scope creep                           | Launch keeps slipping                                | Cut ruthlessly to the Phase 1 MVP                                                                                                                                                                |
| Search performance                    | Poor experience                                      | Start with PostgreSQL; switch only if volume demands it                                                                                                                                          |
| Chinese search underperforms          | Can't find your own content                          | Validate with real notes in M1; fall back to Meilisearch if needed                                                                                                                               |
| Public view leaks private content     | Privacy incident, irreversible                       | B-07 is P0, with endpoint-level tests: anonymous requests must never return a private note's title, slug, or body                                                                                |
| Data loss                             | Irreversible                                         | Scheduled backups + export                                                                                                                                                                       |
| Phase 1/2 boundary blurs during build | Rework, or Phase 1 slips waiting on Phase 2 features | Build the Note schema to already support Phase 2 (links, tags) where cheap to do so, but gate the linking UI and graph behind Phase 2 — don't let link-parsing work creep into the Phase 1 build |

---

## 10. Success Metrics

| Metric                 | Target                                           |
| ---------------------- | ------------------------------------------------ |
| Capture frequency      | ≥ 3 notes per week                               |
| Lookup efficiency      | Find a target note in ≤ 30 seconds               |
| Review completion rate | To be set once the review system ships (Phase 3) |
| Blog output            | ≥ 2 public posts per month                       |
| Uptime                 | Accessible 99% of the time                       |

---

## 11. Appendix

### 11.1 Bidirectional link syntax (Phase 2)

| Syntax                   | Meaning                                                                    |
| ------------------------ | -------------------------------------------------------------------------- |
| `[[Note Title]]`         | Link to the note matching this title (case-insensitive; titles are unique) |
| `[[uuid\|Display Name]]` | Link precisely by uuid, with a custom display name                         |
| `#tag`                   | Inline tag (optional)                                                      |

### 11.2 Glossary

| Term     | Description                                     |
| -------- | ----------------------------------------------- |
| Seed     | A note; the smallest unit of knowledge          |
| Roots    | Bidirectional links between notes               |
| Backlink | The list of notes linking to the current one    |
| Species  | Tags                                            |
| Clearing | A published, public note — blog content         |
| Trail    | A learning path                                 |
| Canopy   | The knowledge graph view                        |
| SM-2     | A classic spaced-repetition algorithm (Phase 3) |

### 11.3 Reference Products

- Obsidian + Quartz — local Markdown + publishing
- Logseq — block references + built-in review
- Trilium Notes — tree structure + note cloning
- Anki — spaced-repetition algorithm
- Blossom — self-hosted notes + blog, combined

---

## 12. Brand Guidelines

The full brand guidelines (logo, color palette, typography, visual language, brand voice, usage examples) live in a separate document: [Grove_brand.md](Grove_brand.md).

This PRD keeps only the product-relevant highlights:

- Positioning: "Grove — capture what you learn, link your knowledge, and let your notes grow into a forest."
- Keywords: quiet, growth, connection, natural, personal
- UI: light mode is the default, with a dark mode also available
