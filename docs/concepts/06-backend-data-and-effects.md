# 06 — Backend Data And Effects Concepts

## Mental Model

Rendering should be pure. Fetching data is not pure.

A component render should describe UI for the current data. A network request reaches outside React into the world, so it belongs in an effect.

This distinction is one of the biggest jumps in React:

- render calculates UI,
- effects synchronize with external systems.

External systems include APIs, browser storage, timers, subscriptions, and manually controlled DOM APIs.

## Important Files

### `backend/`

The backend exists so the frontend can practice realistic data flows.

The React app should call the gateway at `http://localhost:5100/api`, not the catalog and orders services directly.

The gateway gives the frontend one stable backend doorway. The frontend should not need to know how many services exist behind it.

### `src/api/http.js`

This is the configured HTTP client.

It centralizes base URL, timeout, and error handling so components do not repeat request setup.

This is a maintainability decision. If the backend URL changes, you update one file.

### `src/api/catalogApi.js`

This file gives the app product-specific functions like `getProducts`.

Components should call these named functions instead of building URLs themselves.

Good component code reads like intent:

```js
await getProducts()
```

Not transport detail:

```js
await axios.get('http://localhost:5100/api/products')
```

### `src/pages/HomePage.jsx`

This page uses an effect to load data after the first render.

It renders loading, error, fallback, and success states.

Async UI is never just data. It is data plus lifecycle state.

## Why `useEffect`

React calls your component to calculate UI.

If you start fetching directly inside the component body, every render can start another request. `useEffect` tells React: after this render is committed, run this side effect.

## What Each Move Teaches

Starting the backend teaches that frontend and backend are separate programs.

Installing Axios teaches using a library for HTTP requests.

Creating an API folder teaches separation of concerns.

Adding loading state teaches that async work has time between start and finish.

Adding error state teaches that the UI must handle failure.

Keeping fallback data teaches graceful learning: React work should not stop just because the backend is off.

## `useEffect` In Depth

`useEffect` runs after React commits a render to the screen.

Basic shape:

```jsx
useEffect(() => {
  // side effect
}, [])
```

The dependency array controls when the effect re-runs.

- `[]`: run after first render.
- `[slug]`: run after first render and whenever `slug` changes.
- no array: run after every render.

Fetching in render is wrong because render can happen many times. Effects are the right place to synchronize with the network.

## Async State Shape

Most fetching UI needs:

- `data`
- `isLoading`
- `error`

These are separate because each answers a different UI question.

Do not use only `products.length` to detect loading. An empty successful result and a not-yet-loaded result are different states.

## API Boundary

The `api` folder is a contract layer.

Pages and components should not care:

- which HTTP client is used,
- exact base URL,
- timeout settings,
- response wrapping,
- low-level error object shape.

They should care about app language:

- get products,
- get product by slug,
- create order.

## Common Bugs

- Infinite requests because an effect dependency changes every render.
- Blank screens because loading state is not handled.
- Silent failures because errors are only logged.
- Components coupled to backend URLs.
- Fetching the same data in multiple unrelated components without a shared pattern.

## Mistakes To Watch For

- Do not call `getProducts()` directly in the render body.
- Do not let every component create its own Axios client.
- Do not ignore loading and error states.
- Do not make the frontend call `http://localhost:5201` directly once the gateway exists.
- Do not treat empty array as the same thing as loading.
- Do not ignore cleanup for effects that subscribe or use timers.

## Senior-Level Thinking

Experienced developers design data layers early:

- network code is centralized,
- components read like product behavior,
- loading/error states are explicit,
- backend topology is hidden from UI,
- failure is treated as normal, not surprising.

## Interview Explanation

> Fetching is a side effect because it talks to an external system. I put the request in `useEffect` so it runs after render. I keep HTTP details in an API layer so components call meaningful functions. The UI handles loading, error, success, and fallback states separately, which makes the experience predictable and easier to debug.

## Check Yourself

- What is a side effect?
- Why does fetching belong in `useEffect`?
- What problem does the `api` folder solve?
- What should the screen show while products are loading?
