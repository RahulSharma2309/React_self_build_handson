# 01 — Blank Vite App

## Goal

Understand the smallest possible React app in this repo before adding features.

## Concepts

- `package.json` scripts
- Vite dev server
- `index.html`
- `src/main.jsx`
- `src/App.jsx`
- JSX as a JavaScript expression

## Build Steps

1. Run the app:

   ```powershell
   npm install
   npm run dev
   ```

2. Open `index.html`.
   Find `<div id="root"></div>` and the script that loads `/src/main.jsx`.

3. Open `src/main.jsx`.
   Trace how React finds `root` and renders `<App />`.

4. Open `src/App.jsx`.
   Change the heading text and confirm the browser updates.

5. Open `src/App.css` and `src/index.css`.
   Add one small style, then remove it again. This story is about knowing where global styles and component styles live.

## Done When

- You can explain how the browser reaches `App.jsx`.
- You can start the app without help.
- You can change text in `App.jsx` and see hot reload work.

## Reference

Read `React Learning/docs/01-how-a-react-app-boots.md` and `React Learning/docs/04-vite-and-the-build-pipeline.md` when you want the deeper explanation.
