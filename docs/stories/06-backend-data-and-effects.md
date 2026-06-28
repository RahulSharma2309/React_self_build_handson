# 06 — Backend Data And Effects

## Goal

Load products from the backend gateway instead of relying only on local data.

This story teaches the first major boundary between React and the outside world:

> Rendering is React's world. Network requests are side effects.

## What You Are Building

- Start the backend services.
- Install Axios.
- Create a shared HTTP client.
- Create catalog API functions.
- Fetch products from the gateway.
- Show loading and error states.
- Keep fallback data so React learning is not blocked by backend setup.

## Concepts You Must Understand First

### Side Effects

A side effect is work that reaches outside rendering.

Examples:

- network request,
- timer,
- browser storage,
- DOM subscription,
- logging analytics.

Fetching products is a side effect because it talks to a server.

### `useEffect`

`useEffect` lets you run side effects after React renders.

You do not fetch directly in the component body because render should stay predictable. If a request starts during render, every re-render can accidentally start another request.

### Loading State

Async work takes time.

The UI needs to represent:

- request has not started,
- request is running,
- request succeeded,
- request failed.

### API Layer

Components should not know every URL.

Instead of calling Axios everywhere, create named functions:

- `getProducts()`
- `getProductBySlug(slug)`

This makes components easier to read and backend changes easier to manage.

## Files You Will Touch

- `src/api/http.js`
  Shared Axios client.

- `src/api/catalogApi.js`
  Product API functions.

- `src/pages/HomePage.jsx`
  Fetches products and renders loading/error/success states.

- `src/pages/ProductDetailPage.jsx`
  Loads one product by slug or uses fallback lookup.

## Build Steps With Explanation

### Step 1 — Start Backend Services

Run in separate terminals:

```powershell
.\start-catalog.ps1
.\start-orders.ps1
.\start-gateway.ps1
```

The frontend should call the gateway at `http://localhost:5100/api`.

### Step 2 — Install Axios

```powershell
npm install axios
```

Axios is an HTTP client. It makes request setup, JSON handling, errors, and timeouts convenient.

### Step 3 — Create `src/api/http.js`

Create one configured client:

```js
import axios from 'axios'

export const http = axios.create({
  baseURL: 'http://localhost:5100/api',
  timeout: 6000,
})
```

Why one client?

So base URL and timeout live in one place.

### Step 4 — Create `src/api/catalogApi.js`

Add:

```js
import { http } from './http.js'

export async function getProducts() {
  const response = await http.get('/products')
  return response.data
}
```

Components can now call `getProducts()` without knowing the URL.

### Step 5 — Fetch In An Effect

In the page:

```jsx
useEffect(() => {
  async function loadProducts() {
    ...
  }

  loadProducts()
}, [])
```

The empty dependency array means this effect runs after the first render.

### Step 6 — Render Loading, Error, And Products

Before showing the grid, handle states:

- loading: show message/spinner,
- error: show friendly message,
- success: show products,
- fallback: show local products if backend fails.

## Debug While Building

1. Open browser Network tab.
2. Confirm request goes to `/api/products`.
3. Stop the gateway and reload.
4. Confirm fallback data still appears.
5. Break the URL and confirm error UI appears.

## Done When

- Products load from the gateway when backend is running.
- Frontend still works with fallback data when backend is off.
- Loading and error UI are visible.
- Components call API functions, not raw Axios URLs.
- You can explain why fetching belongs in `useEffect`.

## Interview Explanation

> I keep network code outside components in an API layer. Components call named functions like `getProducts`. The request starts in `useEffect` because fetching is a side effect that should run after render, not during render. The UI tracks loading, error, and success states so users are never left with a blank screen.

## Reference

Read `React Learning/docs/09-useeffect-and-side-effects.md` and `React Learning/docs/18-axios-and-the-data-layer.md`.
