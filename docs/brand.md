# Grove Brand Guidelines

**Version**: v1.1 (English)
**Status**: Draft
**Last updated**: 2026-09-19
**Related document**: [Grove_prd.md](Grove_prd.md)

---

## 1. Brand Core

**Positioning**:

> **Grove — capture what you learn, link your knowledge, and let your notes grow into a forest.**

**Keywords**: quiet, growth, connection, natural, personal

**Brand personality**:

- Like a quiet study, not a busy public square
- Like a gardener, patiently tending knowledge
- Like an old friend — reliable, unobtrusive

**Brand no-gos**:

- No cold tech-blue or neon colors
- No heavy decoration or flashy motion
- No marketing-heavy taglines
- Avoid words like "disrupt" or "revolutionize"

## 2. Logo Direction

**Core imagery**: a tree, three trees, a forest, roots, tree rings

**Direction A: Minimalist tree (recommended)**

```
      ●
     ╱ ╲
    ●   ●
   ╱ ╲ ╱ ╲
  ●   ●   ●
```

- The canopy is made of nodes and connecting lines
- Node = a note, line = a link
- Works well as an app icon or favicon

**Direction B: Three trees**

```
  ▲   ▲   ▲
  │   │   │
  ┴   ┴   ┴
```

- Uneven heights, symbolizing accumulation over time
- Minimal, stays legible even very small

**Direction C: Stylized letter "G"**

```
   ╭───╮
   │   ●
   │  ╱
   ╰─●
```

- The curve of the "G" doubles as a canopy or tree ring
- Letterform and imagery merge into one

**Direction D: Tree rings**

```
   ╭─────╮
   │ ╭─╮ │
   │ │●│ │
   │ ╰─╯ │
   ╰─────╯
```

- Tree rings = time accumulating
- The center point = a single note

**Logo usage guide**:

| Context                  | Which direction                           |
| ------------------------ | ----------------------------------------- |
| App icon                 | Direction A (node tree)                   |
| Website logo             | Direction B or C + the wordmark "Grove"   |
| Favicon                  | Simplified Direction A                    |
| Loading animation        | Direction A, nodes lighting up one by one |
| Empty-state illustration | Direction B, three trees                  |

**Logo don'ts**:

- Don't stretch or distort it
- Don't add shadows, gradients, or outlines
- Don't recolor it (except using the monochrome version)
- Don't rotate it
- Don't place it directly on a busy background

## 3. Color System

**Primary colors**:

| Name        | Hex       | Use                                                  |
| ----------- | --------- | ---------------------------------------------------- |
| Grove Green | `#2D5A3D` | Primary brand color, buttons, links                  |
| Deep Forest | `#1A3A28` | Dark-mode background, headings                       |
| Moss        | `#4A7C59` | Secondary buttons, hover state; use white text on it |

**Neutrals**:

| Name      | Hex       | Use                                                                                 |
| --------- | --------- | ----------------------------------------------------------------------------------- |
| Parchment | `#F5F2EA` | Light-mode background                                                               |
| Birch     | `#E8E4D9` | Dividers, secondary background (light mode); body text (dark mode)                  |
| Bark      | `#6B6355` | Secondary text (light mode)                                                         |
| Stone     | `#9C9485` | Secondary text (dark mode), disabled state; don't use as text on a light background |
| Charcoal  | `#2A2A28` | Body text (light mode)                                                              |

**Accent colors**:

| Name         | Hex       | Use                                                                                               |
| ------------ | --------- | ------------------------------------------------------------------------------------------------- |
| Morning Mist | `#A8C4B0` | Tags, light emphasis, dark-mode links                                                             |
| Autumn       | `#C77D4A` | Fill color for important markers; use the warning semantic color for text (see Semantic colors)   |
| Berry        | `#8B4A5C` | Error, delete                                                                                     |
| Sky          | `#7A9BB5` | Fill color for informational elements; use the info semantic color for text (see Semantic colors) |
| Sunlight     | `#D4B86A` | Highlight background — use Charcoal for text on it; review reminders (Phase 3)                    |

**Semantic colors**:

| Meaning | Light mode | Dark mode |
| ------- | ---------- | --------- |
| Success | `#3D6B4B`  | `#6BAF7A` |
| Warning | `#995628`  | `#D99A6C` |
| Error   | `#8B4A5C`  | `#C4818F` |
| Info    | `#4A6C8A`  | `#9BBAD0` |

Light-mode semantic colors are deepened so that, used as text, they all meet ≥ 4.5:1 contrast. Accent colors like Autumn and Sky are fills only — never use them directly as text.

**Color usage ratio**:

```
Primary (Grove Green)       ████████░░░░░░░░░░░░  40%
Neutrals (Parchment, etc.)  ████████████████░░░░  40%
Accents                     ██████░░░░░░░░░░░░░░  15%
Semantic colors             ██░░░░░░░░░░░░░░░░░░   5%
```

**Light mode (default)**:

| Element        | Hex       |
| -------------- | --------- |
| Background     | `#F5F2EA` |
| Card           | `#FFFFFF` |
| Body text      | `#2A2A28` |
| Secondary text | `#6B6355` |
| Link           | `#2D5A3D` |
| Divider        | `#E8E4D9` |

**Dark mode**:

| Element        | Hex       |
| -------------- | --------- |
| Background     | `#1A1F1B` |
| Card           | `#242A25` |
| Body text      | `#E8E4D9` |
| Secondary text | `#9C9485` |
| Link           | `#A8C4B0` |
| Divider        | `#2D3A2F` |

**Contrast requirements**:

- Body text vs. background ≥ 7:1 (AAA)
- Secondary text vs. background ≥ 4.5:1 (AA)
- Borders, icons, focus rings, and other non-text elements ≥ 3:1
- When status colors (success, warning, error, info) are used as text or icons, use the values from the semantic color table above
- Autumn, Sky, and Moss are fills only — never use them directly as text on a light background; use white text on Moss buttons
- Sunlight is a highlight background only — use Charcoal for text on it
- In dark mode, Grove Green cannot be used directly as text or icon color on the dark background (contrast is only 1.84:1) — use Morning Mist instead

**Verified combinations** (computed via the WCAG formula):

| Foreground                                                               | Background                | Contrast                        | Use                       |
| ------------------------------------------------------------------------ | ------------------------- | ------------------------------- | ------------------------- |
| Charcoal `#2A2A28`                                                       | Parchment `#F5F2EA`       | 12.85:1                         | Light-mode body text      |
| Bark `#6B6355`                                                           | Parchment                 | 5.30:1 (5.93:1 on a white card) | Light-mode secondary text |
| Grove Green `#2D5A3D`                                                    | Parchment                 | 7.11:1                          | Light-mode links          |
| White                                                                    | Grove Green               | 7.95:1                          | Primary button text       |
| White                                                                    | Moss `#4A7C59`            | 4.86:1                          | Secondary button text     |
| Charcoal                                                                 | Sunlight `#D4B86A`        | 7.44:1                          | Highlight text            |
| Success `#3D6B4B` / Warning `#995628` / Error `#8B4A5C` / Info `#4A6C8A` | Parchment                 | 5.52 / 5.05 / 5.81 / 4.94       | Light-mode status text    |
| Birch `#E8E4D9`                                                          | Dark background `#1A1F1B` | 13.16:1                         | Dark-mode body text       |
| Stone `#9C9485`                                                          | Dark background           | 5.57:1 (4.88:1 on a dark card)  | Dark-mode secondary text  |
| Morning Mist `#A8C4B0`                                                   | Dark background           | 8.91:1                          | Dark-mode links           |
| `#6BAF7A` / `#D99A6C` / `#C4818F` / `#9BBAD0`                            | Dark card `#242A25`       | 5.61 / 6.13 / 4.80 / 7.21       | Dark-mode status text     |

## 4. Typography

**Typefaces**:

| Use      | Font                                           | Fallback                     |
| -------- | ---------------------------------------------- | ---------------------------- |
| Headings | Lora (serif)                                   | Source Serif Pro, Noto Serif |
| Body     | Inter (sans-serif)                             | Source Sans Pro, Noto Sans   |
| Code     | JetBrains Mono                                 | Fira Code, Cascadia Code     |
| Chinese  | Noto Serif SC (headings) / Noto Sans SC (body) | System default               |

**Why serif for headings**:

- A serif face has a literary, bookish quality that fits the "study" personality
- Creates contrast with the body text, giving clear visual hierarchy
- Distinct from the common all-sans-serif look

**Type scale**:

| Level   | Size | Line height | Weight | Use                |
| ------- | ---- | ----------- | ------ | ------------------ |
| H1      | 32px | 1.3         | 600    | Page title         |
| H2      | 24px | 1.4         | 600    | Section heading    |
| H3      | 20px | 1.4         | 600    | Subsection heading |
| H4      | 16px | 1.5         | 600    | Paragraph heading  |
| Body    | 16px | 1.7         | 400    | Body text          |
| Small   | 14px | 1.6         | 400    | Secondary text     |
| Caption | 12px | 1.5         | 400    | Tags, timestamps   |
| Code    | 14px | 1.6         | 400    | Code blocks        |

**Font weights**:

| Weight | Use                   |
| ------ | --------------------- |
| 400    | Body text             |
| 500    | Emphasis, buttons     |
| 600    | Headings              |
| 700    | Rare, strong emphasis |

**Typesetting rules**:

- Max body-text width: 72ch (~720px), for comfortable reading
- Paragraph spacing: `1em`
- Spacing between a heading and the following body text: `1.5em`
- Code block padding: `16px`
- List indent: `24px`

**Font loading**:

```css
/* System fonts first, web fonts as fallback */
font-family:
  "Inter",
  -apple-system,
  BlinkMacSystemFont,
  "Segoe UI",
  "Noto Sans SC",
  sans-serif;

/* Headings */
font-family: "Lora", "Noto Serif SC", Georgia, serif;

/* Code */
font-family: "JetBrains Mono", "Fira Code", monospace;
```

## 5. Visual Language

**Border radius**:

| Element | Radius      |
| ------- | ----------- |
| Button  | 6px         |
| Card    | 8px         |
| Input   | 6px         |
| Tag     | 12px (pill) |
| Avatar  | 50%         |

**Shadows**:

| Level  | Shadow                        | Use             |
| ------ | ----------------------------- | --------------- |
| Low    | `0 1px 2px rgba(0,0,0,0.05)`  | Default card    |
| Medium | `0 4px 12px rgba(0,0,0,0.08)` | Hover, dropdown |
| High   | `0 8px 24px rgba(0,0,0,0.12)` | Popover, modal  |

**Spacing scale** (based on a 4px grid):

| Name | Value |
| ---- | ----- |
| xs   | 4px   |
| sm   | 8px   |
| md   | 16px  |
| lg   | 24px  |
| xl   | 32px  |
| 2xl  | 48px  |
| 3xl  | 64px  |

**Icons**:

| Property              | Spec                        |
| --------------------- | --------------------------- |
| Style                 | Linear, thin stroke (1.5px) |
| Size                  | 16 / 20 / 24px              |
| Corners               | Rounded line caps           |
| Color                 | Inherits text color         |
| Recommended libraries | Lucide, Phosphor            |

**Motion**:

| Scenario        | Duration | Easing      |
| --------------- | -------- | ----------- |
| Hover           | 150ms    | ease-out    |
| Expand/collapse | 200ms    | ease-in-out |
| Page transition | 250ms    | ease-in-out |
| Loading         | Looping  | linear      |

## 6. Brand Voice

> **Confirmed**: Grove's UI chrome (nav, buttons, labels, system messages) is bilingual — English and Chinese, switchable. Each note/post is authored once, in whichever language it was written in; there's no obligation to translate a post's own content. A future version may add full per-post dual-language content, but that's not in scope now. The copy below is written as real pairs in both languages, not a translation gloss.

**Tone**:

| Context        | Tone                                     |
| -------------- | ---------------------------------------- |
| UI copy        | Concise, calm, unobtrusive               |
| Empty states   | Gently encouraging, never preachy        |
| Error messages | Clear about what happened, never blaming |
| Blog           | Personal, sincere                        |

**Copy examples**:

| Context                   | Preferred (EN)                                      | Preferred (ZH)               | Avoid (EN)                                         | Avoid (ZH)                 |
| ------------------------- | --------------------------------------------------- | ---------------------------- | -------------------------------------------------- | -------------------------- |
| Empty note list           | "No notes yet — write your first one"               | 「还没有笔记，写下第一条吧」 | "No data available"                                | 「暂无数据」               |
| Save succeeded            | "Saved"                                             | 「已保存」                   | "Operation successful!"                            | 「操作成功！」             |
| Delete confirmation       | "This can't be undone once deleted — are you sure?" | 「删除后无法恢复，确定吗？」 | "Are you sure you want to perform this operation?" | 「您确定要执行此操作吗？」 |
| Review reminder (Phase 3) | "5 notes due for review today"                      | 「今天有 5 条笔记待复习」    | "You have 5 pending to-dos!"                       | 「您有 5 条待办事项！」    |
| Loading                   | "Loading…"                                          | 「加载中…」                  | "Please wait, working hard to load…"               | 「请稍候，正在努力加载…」  |

**Vocabulary preferences**:

| Concept | Chinese: use | Chinese: avoid | English: use | English: avoid         |
| ------- | ------------ | -------------- | ------------ | ---------------------- |
| Note    | 笔记         | 文档、文件     | Note         | Document, file         |
| Link    | 链接         | 关联、引用     | Link         | Association, reference |
| Tag     | 标签         | 分类、目录     | Tag          | Category, directory    |
| Path    | 路径         | 课程、教程     | Path         | Course, tutorial       |
| Review  | 复习         | 测试、考核     | Review       | Quiz, test             |
| Blog    | 博客         | 文章、动态     | Blog         | Article, post/feed     |

**Slogan**:

| Context           | Slogan                           |
| ----------------- | -------------------------------- |
| Primary (English) | **Grow your knowledge.**         |
| Primary (Chinese) | **让知识长成一片林。**           |
| Functional        | **Write. Link. Grow.**           |
| Poetic            | **Where notes become a forest.** |
| Personal          | **Your quiet place to think.**   |

## 7. Application Examples

**Homepage**:

```
┌─────────────────────────────────────────┐
│  🌳 Grove                    [Log in]    │
├─────────────────────────────────────────┤
│                                         │
│         Grow your knowledge.            │
│         让知识长成一片林。                │
│                                         │
│         [ Start writing ]               │
│                                         │
├─────────────────────────────────────────┤
│  Latest notes                          │
│  ┌─────────┐ ┌─────────┐ ┌─────────┐  │
│  │ Note    │ │ Note    │ │ Note    │  │
│  │ card    │ │ card    │ │ card    │  │
│  └─────────┘ └─────────┘ └─────────┘  │
└─────────────────────────────────────────┘
```

**Note detail page**:

```
┌─────────────────────────────────────────┐
│  ← Back                                 │
│                                         │
│  How to choose PostgreSQL indexes       │
│  2026-09-19 · #database #postgres       │
│                                         │
│  Body content…                          │
│                                         │
│  ─────────────────────────────────────  │
│  🌿 Backlinks (3)                       │
│  · Reading an EXPLAIN query plan        │
│  · Full-text search & Chinese tokenizing│
│  · A few ways to paginate an API        │
└─────────────────────────────────────────┘
```

**App icon**:

```
┌─────────┐
│         │
│    ●    │
│   ╱ ╲   │
│  ●   ●  │
│ ╱ ╲ ╱ ╲ │
│●   ●   ●│
│         │
└─────────┘
Background: Grove Green #2D5A3D
Nodes: Parchment #F5F2EA
```

## 8. Asset Checklist

**Assets still to produce**:

| Asset                     | Format     | Use                       |
| ------------------------- | ---------- | ------------------------- |
| Primary logo              | SVG        | Website, docs             |
| Logo icon                 | SVG / PNG  | App icon, favicon         |
| Monochrome logo           | SVG        | Dark backgrounds, print   |
| Color variables           | CSS / JSON | Development               |
| Font files                | WOFF2      | Web loading               |
| Icon set                  | SVG        | UI                        |
| Empty-state illustrations | SVG        | Empty states across pages |

**Design tools**:

| Purpose          | Tool                     |
| ---------------- | ------------------------ |
| Design files     | Figma                    |
| Icons            | Lucide / Phosphor        |
| Illustration     | Hand-drawn or Excalidraw |
| Contrast testing | Contrast Checker         |

## 9. Brand Checklist

Before shipping any interface or content, check:

- [ ] Colors come from the brand palette; text colors come from the "Verified combinations" table in §3
- [ ] Fonts are Lora (headings), Inter (body), JetBrains Mono (code), with a Chinese fallback in place
- [ ] Body text contrast ≥ 7:1, secondary text ≥ 4.5:1, non-text elements ≥ 3:1
- [ ] Checked in both light and dark mode
- [ ] Border radius, shadows, and spacing follow the visual language (4px grid)
- [ ] Icons are linear/thin-stroke, colored via inherited text color
- [ ] The logo hasn't been stretched, shadowed, gradient-filled, recolored, or rotated
- [ ] Copy tone is calm and non-preachy, and follows the vocabulary preferences
- [ ] Motion durations are within spec, with no flashy animation
