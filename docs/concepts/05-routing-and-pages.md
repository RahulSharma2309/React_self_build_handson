# 05 — Routing And Pages Concepts

## Mental Model

In a React single-page app, the URL is state.

The browser does not ask the server for a new HTML page when you move from `/` to `/products/some-product`. React Router watches the URL and chooses which component to show.

## Important Files

### `src/main.jsx`

This is where `BrowserRouter` wraps the app.

Router features like `Link`, `Routes`, and `useParams` only work inside this wrapper.

### `src/App.jsx`

`App.jsx` becomes the route table.

It answers the question: for this URL, which page component should render?

### `src/pages/HomePage.jsx`

This page owns the catalog route `/`.

Moving the catalog from `App.jsx` into a page teaches that pages are route-level components.

### `src/pages/ProductDetailPage.jsx`

This page owns `/products/:slug`.

The `:slug` part is a dynamic URL parameter. React Router reads it with `useParams`.

## Pages vs Components

Use `pages` for route-level screens.

Use `components` for reusable pieces inside those screens.

`HomePage` can use `ProductCard`, but `ProductCard` should not know it lives on the home page.

## What Each Move Teaches

Installing `react-router-dom` teaches that routing is not built into React itself.

Using `BrowserRouter` teaches app-level providers.

Using `Routes` and `Route` teaches declarative route mapping.

Using `Link` teaches navigation without full reloads.

Using `useParams` teaches how components read URL state.

## Mistakes To Watch For

- Do not use normal `<a href>` for internal app navigation unless you want a full page reload.
- Do not put `BrowserRouter` around only one page. Put it near the root.
- Do not hard-code product details separately. Find the product by slug from your data.
- Do not forget a not-found state for unknown slugs.

## Check Yourself

- What is the route table?
- Why is `/products/:slug` dynamic?
- Why does `Link` feel faster than a normal page load?
- What makes a file a page instead of a reusable component?
