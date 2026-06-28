# 05 — Routing And Pages Concepts

## Mental Model

In a React single-page app, the URL is state.

The browser does not ask the server for a new HTML page when you move from `/` to `/products/some-product`. React Router watches the URL and chooses which component to show.

Routing turns this:

```text
current URL -> matched route -> page component -> UI
```

That matters because URLs are shareable. A user should be able to copy a product URL, refresh it, press back, and return to the same screen.

## Important Files

### `src/main.jsx`

This is where `BrowserRouter` wraps the app.

Router features like `Link`, `Routes`, and `useParams` only work inside this wrapper.

Put `BrowserRouter` near the root because routing is an app-wide capability. If a component using `Link` or `useParams` renders outside the router, it will fail.

### `src/App.jsx`

`App.jsx` becomes the route table.

It answers the question: for this URL, which page component should render?

As the app grows, `App.jsx` should not contain every screen's full UI. It should mostly map paths to pages and app-level layout.

### `src/pages/HomePage.jsx`

This page owns the catalog route `/`.

Moving the catalog from `App.jsx` into a page teaches that pages are route-level components.

### `src/pages/ProductDetailPage.jsx`

This page owns `/products/:slug`.

The `:slug` part is a dynamic URL parameter. React Router reads it with `useParams`.

One route can now support many product pages:

```text
/products/arduino-sensor-starter-lab
/products/esp32-robotics-controller-kit
```

## Pages vs Components

Use `pages` for route-level screens.

Use `components` for reusable pieces inside those screens.

`HomePage` can use `ProductCard`, but `ProductCard` should not know it lives on the home page.

Rule of thumb:

- If it maps directly to a URL, it is probably a page.
- If it is reused inside pages, it is probably a component.

## What Each Move Teaches

Installing `react-router-dom` teaches that routing is not built into React itself.

Using `BrowserRouter` teaches app-level providers.

Using `Routes` and `Route` teaches declarative route mapping.

Using `Link` teaches navigation without full reloads.

Using `useParams` teaches how components read URL state.

## `Link` vs `<a>`

Use `Link` for internal app navigation:

```jsx
<Link to={`/products/${product.slug}`}>View details</Link>
```

React Router updates the URL and renders the matching route without reloading the whole document.

Use normal `<a>` for external websites:

```jsx
<a href="https://react.dev">React docs</a>
```

If you use `<a href="/products/demo">` inside the app, the browser performs a full page navigation.

## Dynamic Params

Route:

```jsx
<Route path="/products/:slug" element={<ProductDetailPage />} />
```

Page:

```jsx
const { slug } = useParams()
```

`slug` comes from the URL. It is not local state, not a prop, and not hard-coded. It is route state.

## Not-Found Handling

There are two not-found cases:

- No route matches the URL.
- The route matches, but the product slug does not exist.

In this story, handle the second case in `ProductDetailPage`:

```jsx
if (!product) {
  return <p>Product not found.</p>
}
```

Good apps do not crash or show blank screens for bad URLs.

## Browser History

React Router works with browser history:

- back button,
- forward button,
- address bar,
- refresh.

This is why URL state is powerful. The user is not trapped inside invisible component state.

## Mistakes To Watch For

- Do not use normal `<a href>` for internal app navigation unless you want a full page reload.
- Do not put `BrowserRouter` around only one page. Put it near the root.
- Do not hard-code product details separately. Find the product by slug from your data.
- Do not forget a not-found state for unknown slugs.
- Do not put every page's full UI inside `App.jsx`.
- Do not use `useParams` outside a router.

## Senior-Level Thinking

Routes become part of the app's public contract.

Changing `/products/:slug` later can break shared links, browser history, and bookmarks. Experienced engineers choose route shapes intentionally and keep page ownership clear.

Routing also improves architecture:

- `App.jsx` maps URLs.
- `pages` own screens.
- `components` remain reusable.
- data lookup happens inside the page that needs it.

## Interview Explanation

> In a React SPA, the server serves one HTML file, and React Router handles screen changes on the client. `BrowserRouter` provides routing context. `Routes` and `Route` map paths to page components. `Link` changes the URL without a full reload. Dynamic params like `:slug` let one page component render different data based on the URL.

## Check Yourself

- What is the route table?
- Why is `/products/:slug` dynamic?
- Why does `Link` feel faster than a normal page load?
- What makes a file a page instead of a reusable component?
