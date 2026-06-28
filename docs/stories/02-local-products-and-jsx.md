# 02 — Local Products And JSX

## Goal

Render a small product catalog from local JavaScript data.

## Concepts

- JavaScript arrays and objects
- `map`
- JSX
- props
- component files

## Build Steps

1. Create `src/data/fallbackProducts.js`.
   Add two or three product objects with `id`, `name`, `slug`, `category`, `price`, `image`, and `summary`.

2. Create `src/components/ProductCard.jsx`.
   Accept a `product` prop and render its name, category, price, and summary.

3. Update `src/App.jsx`.
   Import `fallbackProducts`, loop over it with `map`, and render a `ProductCard` for each product.

4. Add a `key` prop to each rendered `ProductCard`.
   Use `product.id`.

5. Style the list lightly in `src/App.css`.
   Keep styles simple: page wrapper, grid, card, title, price.

## Done When

- The page shows multiple products from data, not hard-coded JSX.
- You can explain why `map` returns an array of components.
- You can explain why React wants a `key`.

## Reference

Compare with `React Learning/frontend/src/data/fallbackProducts.js` and `React Learning/frontend/src/components/ProductCard.jsx` only after trying yourself.
