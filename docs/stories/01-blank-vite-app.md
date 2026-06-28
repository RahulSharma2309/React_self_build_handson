# 01 — Blank Vite App

## Goal

Understand the smallest possible React app before adding features.

This story is about the startup chain. If you do not understand how the app boots, every later file feels random. By the end, you should be able to explain how the browser gets from `index.html` to the text rendered by `App.jsx`.

## What You Are Learning

- What `package.json` controls.
- Why `package-lock.json` exists.
- What Vite does during development.
- Why `index.html` exists in a React app.
- How `src/main.jsx` mounts React.
- What `src/App.jsx` is responsible for.
- What JSX is and why it is not exactly HTML.
- How CSS enters the app.

## Files In This Story

- `package.json`
  Your project control panel: scripts, dependencies, dev dependencies, and module settings.

- `package-lock.json`
  npm's exact dependency receipt. You usually read it only when debugging installs.

- `index.html`
  The single HTML shell Vite serves.

- `src/main.jsx`
  The JavaScript entry point that connects React to the DOM.

- `src/App.jsx`
  Your first React component.

- `src/index.css`
  Global app styles.

- `src/App.css`
  Styles for the current app layout.

## Build Steps With Explanation

### Step 1 — Install Dependencies

Run:

```powershell
npm install
```

This reads `package.json`, downloads packages, creates or updates `node_modules`, and uses `package-lock.json` to keep versions exact.

You do not edit `node_modules`. It is generated.

### Step 2 — Start Vite

Run:

```powershell
npm run dev
```

This works because `package.json` has:

```json
"scripts": {
  "dev": "vite"
}
```

`npm run dev` means: look inside `scripts`, find `dev`, and run its command.

Vite starts a local development server. It serves `index.html`, transforms JSX, and updates the browser when files change.

### Step 3 — Trace `index.html`

Open `index.html` and find:

```html
<div id="root"></div>
```

This is the empty DOM container where React will place your app.

Also find:

```html
<script type="module" src="/src/main.jsx"></script>
```

This tells the browser to load your JavaScript entry point.

### Step 4 — Trace `src/main.jsx`

Open `src/main.jsx`.

The key idea is:

```jsx
createRoot(document.getElementById('root')).render(
  <StrictMode>
    <App />
  </StrictMode>,
)
```

Read it as:

1. Find the DOM element with id `root`.
2. Tell React to control that element.
3. Render the `App` component inside it.
4. Wrap it in `StrictMode` for development checks.

### Step 5 — Trace `src/App.jsx`

Open `src/App.jsx`.

`App` is a component:

```jsx
function App() {
  return (
    <div className="app">
      ...
    </div>
  )
}
```

A component is a JavaScript function that returns JSX.

JSX looks like HTML, but it is JavaScript syntax. That is why you write `className` instead of `class`.

### Step 6 — Change Something And Watch Hot Reload

Change a heading in `App.jsx`.

The browser should update without restarting the dev server. That is Vite hot reload. It makes learning fast because you see feedback immediately.

### Step 7 — Understand CSS Entry Points

`src/main.jsx` imports:

```jsx
import './index.css'
```

That makes global styles available.

`src/App.jsx` imports:

```jsx
import './App.css'
```

That styles the current app layout.

## Debugging Practice

If the browser is blank, check in this order:

1. Is `npm run dev` still running?
2. Does the browser console show an error?
3. Does `index.html` still have `<div id="root"></div>`?
4. Does `main.jsx` still import `App` correctly?
5. Does `App.jsx` export `App`?
6. Did you accidentally break JSX syntax?

## Done When

- You can start the app without help.
- You can explain `npm install` vs `npm run dev`.
- You can trace `index.html` -> `main.jsx` -> `App.jsx`.
- You can explain what `createRoot` does.
- You can change text and see hot reload.
- You can explain why `package-lock.json` is npm's receipt, not your main learning file.

## Interview Explanation

If asked how a Vite React app boots, say:

> Vite serves `index.html`. That file contains a root DOM node and loads `src/main.jsx` as a module. `main.jsx` imports React, finds the root element, creates a React root with `createRoot`, and renders the `App` component. `App.jsx` returns JSX, and React turns that JSX into DOM updates.

## Reference

Read `React Learning/docs/01-how-a-react-app-boots.md` and `React Learning/docs/04-vite-and-the-build-pipeline.md` when you want the deeper explanation.
