# 01 — Blank Vite App Concepts

## Why This Story Matters

A React app is not many HTML pages. It starts from one HTML file, loads JavaScript, and React takes control of one empty DOM node.

In this story, your job is to understand the boot chain:

`package.json` -> Vite -> `index.html` -> `src/main.jsx` -> `src/App.jsx` -> browser screen.

If you understand this chain, later concepts like routing, providers, Redux, and Context become easier because they all get wired into this startup path.

## Files Added Or Used In This Story

- `package.json`
  Defines npm scripts and dependency intent.

- `package-lock.json`
  Records exact installed dependency versions.

- `index.html`
  The browser's first HTML document.

- `src/main.jsx`
  The React entry point.

- `src/App.jsx`
  The root component rendered by React.

- `src/index.css`
  Global styles loaded once.

- `src/App.css`
  App-specific styles.

## Important Files

### `package.json`

`package.json` is the project control panel.

- `scripts` are commands you run with npm, like `npm run dev`.
- `dependencies` are packages needed by the app in the browser, like `react` and `react-dom`.
- `devDependencies` are tools needed while building, like `vite`, `oxlint`, and `@vitejs/plugin-react`.

Use it to understand how the project runs before looking at React code.

When you see:

```json
"dev": "vite"
```

it means:

```powershell
npm run dev
```

runs Vite.

When you see:

```json
"type": "module"
```

it means Node and tooling treat `.js` files as modern ES modules, so `import` and `export` syntax is expected.

### `package-lock.json`

`package-lock.json` is npm's exact dependency record.

`package.json` says what versions are acceptable. For example, `^8.1.0` means a compatible version is allowed.

`package-lock.json` says what exact versions were installed, including hidden sub-dependencies.

Use it when:

- installs behave differently on two machines,
- you want repeatable installs,
- you need to inspect exactly which package version is present.

Do not use it as your main learning file for React. Treat it as npm's receipt.

### `index.html`

This is the only HTML page Vite serves.

The important line is the root element:

```html
<div id="root"></div>
```

React will put your app inside this empty element. The script tag loads `src/main.jsx`, so this file is the bridge between the browser and your JavaScript app.

If the `root` id changes here, `main.jsx` must change too. Otherwise React cannot find where to mount.

### `src/main.jsx`

This is the React entry point.

It imports React, finds the root DOM node, creates a React root, and renders `<App />`.

`StrictMode` is a development helper. It makes React run some checks more aggressively so you notice unsafe patterns early.

Important pieces:

- `document.getElementById('root')` is normal browser DOM API.
- `createRoot(...)` tells React to manage that DOM container.
- `.render(<App />)` asks React to render the component tree.
- `<StrictMode>` does not appear visually. It helps catch issues during development.

### `src/App.jsx`

This is your first component.

A component is a JavaScript function that returns JSX. JSX looks like HTML, but it is JavaScript syntax that React turns into UI instructions.

The file ends with:

```jsx
export default App
```

That lets `main.jsx` import it:

```jsx
import App from './App.jsx'
```

Because it is a default export, the importing file can choose the local name, though `App` is the sensible name.

### `src/index.css` and `src/App.css`

`index.css` is for global styles: body, fonts, resets, CSS variables.

`App.css` is for styles that belong to the current app layout. Later, as the app grows, you will learn when styles should stay global and when they should be component-focused.

## JSX Deep Meaning

JSX is syntax that lets you write UI-like markup inside JavaScript.

This:

```jsx
<App />
```

is not an HTML tag. It is a React component usage.

This:

```jsx
<div className="app">
```

becomes a real DOM `div`.

Capitalized tags are components. Lowercase tags are DOM elements.

That is why `App` starts with a capital letter.

## What Each Move Teaches

Running `npm install` teaches that code often depends on packages that are not stored in Git.

Running `npm run dev` teaches that development uses a local server, not direct file opening.

Changing text in `App.jsx` teaches hot reload: Vite updates the browser without restarting the whole app.

Changing CSS teaches that React controls structure and behavior, while CSS controls presentation.

## Render Flow

1. Browser opens the Vite URL.
2. Vite serves `index.html`.
3. Browser sees the module script for `/src/main.jsx`.
4. Vite transforms JSX as needed.
5. `main.jsx` imports `App.jsx` and CSS.
6. React creates a root using the DOM node from `index.html`.
7. React calls `App`.
8. `App` returns JSX.
9. React creates DOM updates.
10. Browser paints the result.

## When To Debug This Layer

Debug this layer when:

- the whole screen is blank,
- Vite cannot start,
- imports fail,
- React says the root element does not exist,
- JSX syntax errors appear,
- styles do not load at all.

## Mistakes To Watch For

- Do not put React code in `index.html`.
- Do not rename `id="root"` unless you also update `main.jsx`.
- Do not edit `node_modules`; it is generated by npm.
- Do not confuse `npm run dev` with `npm run build`. Dev is for local learning. Build is for production output.
- Do not remove `export default App` unless you also change the import in `main.jsx`.
- Do not treat JSX as a string. It is JavaScript syntax transformed by tooling.

## Senior-Level Thinking

An experienced developer sees the boot files as the app's foundation:

- `index.html` should stay small.
- `main.jsx` should wire app-wide providers and render the root.
- `App.jsx` should become the app's top-level UI or routing table.
- Package scripts should be predictable and boring.
- Generated folders and lock files should be understood, but not manually edited casually.

## Check Yourself

Can you answer these without looking?

- What command starts the app?
- Which file loads first in the browser?
- Which file renders `<App />`?
- Why does `App.jsx` need to export the component?
- What is the difference between `dependencies` and `devDependencies`?
