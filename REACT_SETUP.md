# React App Setup — Vite vs CRA

## TL;DR

- This project was created with **Vite** + React (JavaScript), the current community standard for a plain React single-page app.
- **Create React App (CRA) is deprecated** (2025) and no longer recommended by the React team.

## Steps used to create this app

```powershell
cd "C:\Users\Lenovo\source\repos\React Building self"
npm create vite@latest . -- --template react
npm install
npm run dev
```

1. `cd "..."` — move into the target folder (quotes required because the path has spaces).
2. `npm create vite@latest . -- --template react` — scaffolds a React project **in the current folder** (`.` = "here"). Use `--template react-ts` for TypeScript.
3. `npm install` — downloads dependencies into `node_modules`.
4. `npm run dev` — starts the dev server (default `http://localhost:5173`).

After scaffolding, the demo landing page was stripped down to a blank slate:
- `src/App.jsx` reduced to a minimal "Hello React" component.
- `src/App.css` and `src/index.css` cleared to minimal base styles.
- Demo assets removed (`src/assets/react.svg`, `src/assets/vite.svg`, `public/icons.svg`).

## Common commands

| Command | What it does |
|---|---|
| `npm run dev` | Start the dev server with hot reload |
| `npm run build` | Produce an optimized production build in `dist/` |
| `npm run preview` | Locally serve the production build to test it |

## Vite vs Create React App

| Topic | Vite | Create React App (CRA) |
|---|---|---|
| Status | Actively maintained, recommended | Deprecated (2025) |
| Dev server startup | Near-instant | Slow (bundles everything first) |
| Hot updates (HMR) | Very fast, near-instant | Slows down as app grows |
| Build tool | esbuild (dev) + Rollup (prod) | Webpack |
| Config | Minimal, easy to extend (`vite.config.js`) | Hidden behind `react-scripts` (needs "eject") |
| Bundle size / output | Optimized, modern | Heavier, older defaults |
| Dependencies installed | Lightweight | Large (lots of transitive deps) |

### Why Vite is better

1. **Speed.** Vite serves your source as **native ES modules** in dev, so it doesn't bundle the whole app before you can see it. CRA (Webpack) bundles everything up front, which gets slow as the project grows.
2. **Fast HMR.** Editing a file swaps just that one module. CRA often rebuilds large chunks.
3. **Modern + maintained.** CRA is no longer updated; its dependencies grow stale and can show security warnings.
4. **Simpler config.** Vite's config is small and readable; CRA hides its Webpack config unless you "eject" (a one-way, messy operation).

The main historical reason to use CRA — being the "official" tool — is gone now that it's deprecated.

## What happens behind the scenes?

### `npm create vite@latest`
- npm downloads and runs the `create-vite` scaffolding package.
- It copies a **template** (starter files) into your directory: `package.json`, `index.html`, `src/main.jsx`, `src/App.jsx`, `vite.config.js`, etc.
- No dependencies are installed yet — it just lays down files.

### `npm install`
- npm reads `package.json`, resolves the dependency tree, and downloads packages into `node_modules`.
- It writes/updates `package-lock.json` to lock exact versions.

### `npm run dev` (Vite)
- Starts a local **dev server** (default `http://localhost:5173`).
- `index.html` loads `src/main.jsx` as a native ES module (`<script type="module">`).
- The browser requests modules on demand; Vite transforms each file (JSX -> JS via **esbuild**) **only when requested**, instead of pre-bundling everything.
- A WebSocket connection enables **HMR**: saving a file pushes just that module to the browser.

### `npm run build` (Vite, production)
- Vite uses **Rollup** to bundle, tree-shake (remove unused code), minify, and hash filenames for caching.
- Output goes to a `dist/` folder of static files you can deploy anywhere.

### Contrast: how CRA does it
- `npm start` spins up a **Webpack dev server** that bundles the entire app into memory before serving — slower to boot.
- `npm run build` runs Webpack to produce a `build/` folder.
- All real config lives inside the `react-scripts` package; you only see it if you run `npm run eject` (irreversible).

## Project structure

```
React Building self/
├─ public/            # static assets served as-is (favicon.svg)
├─ src/
│  ├─ assets/         # imported assets (currently empty)
│  ├─ App.jsx         # root React component (blank slate)
│  ├─ App.css         # styles for App
│  ├─ index.css       # global base styles
│  └─ main.jsx        # entry point: mounts <App /> into #root
├─ index.html         # HTML shell, loads /src/main.jsx
├─ package.json       # scripts + dependencies
└─ vite.config.js     # Vite configuration
```
