# 05 — Routing And Pages

## Goal

Turn the single-screen catalog into a routed React app with a home page and product detail page.

This story teaches:

> In a single-page React app, the URL is application state.

The browser still loads one HTML file, but React Router chooses which page component to render based on the current URL.

## What You Are Building

- Install React Router.
- Wrap the app with `BrowserRouter`.
- Move catalog UI into `HomePage.jsx`.
- Create `ProductDetailPage.jsx`.
- Add route definitions in `App.jsx`.
- Use `Link` for client-side navigation.
- Read `slug` from the URL with `useParams`.

## Concepts You Must Understand First

### Client-Side Routing

Traditional website:

```text
Click link -> browser asks server for a new page -> full reload
```

React single-page app:

```text
Click Link -> URL changes -> React renders a different component
```

No full page reload is needed.

### `BrowserRouter`

`BrowserRouter` listens to the browser URL and gives routing information to the React tree.

Without it, hooks like `useParams` and components like `Link` do not know what router they belong to.

### `Routes` And `Route`

`Routes` looks at the current URL.

`Route` says what component should render for a path.

Example:

```jsx
<Route path="products/:slug" element={<ProductDetailPage />} />
```

### URL Params

`products/:slug` means part of the URL is dynamic.

For:

```text
/products/esp32-robotics-controller-kit
```

`slug` is:

```text
esp32-robotics-controller-kit
```

### Pages vs Components

Pages map to routes.

Components are reusable pieces inside pages.

`HomePage` is a page. `ProductCard` is a component.

## Files You Will Touch

- `src/main.jsx`
  Add `BrowserRouter`.

- `src/App.jsx`
  Become the route table.

- `src/pages/HomePage.jsx`
  New page for `/`.

- `src/pages/ProductDetailPage.jsx`
  New page for `/products/:slug`.

- `src/components/ProductCard.jsx`
  Add a `Link` to product detail.

## Build Steps With Explanation

### Step 1 — Install React Router

```powershell
npm install react-router-dom
```

React itself does not include routing. Routing is a separate concern handled by React Router.

### Step 2 — Wrap App With `BrowserRouter`

In `src/main.jsx`:

```jsx
<BrowserRouter>
  <App />
</BrowserRouter>
```

This gives routing context to the whole app.

### Step 3 — Create `HomePage.jsx`

Move the catalog UI from `App.jsx` into `src/pages/HomePage.jsx`.

Why?

Because `/` is now a route, and route-level screens should live in `pages`.

### Step 4 — Create `ProductDetailPage.jsx`

Use:

```jsx
const { slug } = useParams()
```

Then find the product:

```jsx
const product = fallbackProducts.find((item) => item.slug === slug)
```

If no product matches, render a friendly not-found message.

### Step 5 — Define Routes

In `App.jsx`:

```jsx
<Routes>
  <Route path="/" element={<HomePage />} />
  <Route path="/products/:slug" element={<ProductDetailPage />} />
</Routes>
```

`App` now answers: which page should this URL render?

### Step 6 — Link From Product Cards

Use React Router's `Link`:

```jsx
<Link to={`/products/${product.slug}`}>View details</Link>
```

Do not use normal `<a href>` for internal app navigation unless you want a full document reload.

## Debug While Building

Check:

1. `/` renders the catalog.
2. Clicking a product changes the URL.
3. The browser does not fully reload.
4. Product detail page shows the correct product.
5. Unknown slug shows not-found UI.

If routes fail, inspect:

- Is `BrowserRouter` wrapped around `App`?
- Did you import `Routes`, `Route`, `Link`, and `useParams` correctly?
- Does the route path match the generated link?
- Does the product data contain the slug?

## Done When

- Home page renders at `/`.
- Product cards link to detail URLs.
- Detail page reads `slug`.
- Unknown slugs are handled.
- You can explain why URL is state.

## Interview Explanation

> I used React Router to map URLs to page components. `BrowserRouter` provides routing context. `App` defines route paths with `Routes` and `Route`. Product cards use `Link` so navigation updates the URL without a full reload. The detail page uses `useParams` to read the dynamic `slug` from the URL and find the matching product.

## Reference

Read `React Learning/docs/16-routing-with-react-router.md`, then compare with `React Learning/frontend/src/App.jsx`.
