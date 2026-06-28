# 06 — Backend Data And Effects

## Goal

Load products from the backend gateway instead of only local data.

## Concepts

- side effects
- `useEffect`
- async functions
- loading state
- error state
- API module boundaries

## Build Steps

1. Start the backend in three terminals:

   ```powershell
   .\start-catalog.ps1
   .\start-orders.ps1
   .\start-gateway.ps1
   ```

2. Install Axios:

   ```powershell
   npm install axios
   ```

3. Create `src/api/http.js`.
   Configure an Axios client with base URL `http://localhost:5100/api`.

4. Create `src/api/catalogApi.js`.
   Add functions:
   - `getProducts()`
   - `getProductBySlug(slug)`

5. In `HomePage`, replace direct local data usage with:
   - `products`
   - `isLoading`
   - `error`

6. Use `useEffect` to call `getProducts()` after the page first renders.

7. Keep `fallbackProducts` as a fallback if the gateway is off.

8. Show loading and error UI before the product grid.

## Done When

- With backend running, products come from `http://localhost:5100/api/products`.
- With backend off, the page can still show fallback products.
- You can explain why the request belongs in an effect, not directly in render.

## Reference

Read `React Learning/docs/09-useeffect-and-side-effects.md` and `React Learning/docs/18-axios-and-the-data-layer.md`.
