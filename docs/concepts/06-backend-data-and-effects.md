# 06 — Backend Data And Effects Concepts

## Mental Model

Rendering should be pure. Fetching data is not pure.

A component render should describe UI for the current data. A network request reaches outside React into the world, so it belongs in an effect.

## Important Files

### `backend/`

The backend exists so the frontend can practice realistic data flows.

The React app should call the gateway at `http://localhost:5100/api`, not the catalog and orders services directly.

### `src/api/http.js`

This is the configured HTTP client.

It centralizes base URL, timeout, and error handling so components do not repeat request setup.

### `src/api/catalogApi.js`

This file gives the app product-specific functions like `getProducts`.

Components should call these named functions instead of building URLs themselves.

### `src/pages/HomePage.jsx`

This page uses an effect to load data after the first render.

It renders loading, error, fallback, and success states.

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

## Mistakes To Watch For

- Do not call `getProducts()` directly in the render body.
- Do not let every component create its own Axios client.
- Do not ignore loading and error states.
- Do not make the frontend call `http://localhost:5201` directly once the gateway exists.

## Check Yourself

- What is a side effect?
- Why does fetching belong in `useEffect`?
- What problem does the `api` folder solve?
- What should the screen show while products are loading?
