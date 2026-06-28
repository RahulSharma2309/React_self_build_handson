# 05 — Routing And Pages

## Goal

Turn the single catalog screen into a multi-page React app.

## Concepts

- client-side routing
- `BrowserRouter`
- `Routes` and `Route`
- `Link`
- URL params
- page components

## Build Steps

1. Install React Router:

   ```powershell
   npm install react-router-dom
   ```

2. Wrap `<App />` in `<BrowserRouter>` inside `src/main.jsx`.

3. Create `src/pages/HomePage.jsx`.
   Move the catalog UI from `App.jsx` into this page.

4. Create `src/pages/ProductDetailPage.jsx`.
   Read the product `slug` from the URL with `useParams`.

5. Update `src/App.jsx`.
   Add routes for:
   - `/`
   - `/products/:slug`

6. In `ProductCard`, wrap the product name or button in a `Link` to `/products/${product.slug}`.

7. Add a simple not-found state on the detail page when the slug does not match a product.

## Done When

- The home page renders at `/`.
- Clicking a product changes the URL without a full page reload.
- The detail page shows the correct product from the slug.

## Reference

Read `React Learning/docs/16-routing-with-react-router.md`, then compare with `React Learning/frontend/src/App.jsx`.
