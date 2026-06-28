# 02 — Local Products And JSX Concepts

## Mental Model

React is strongest when UI is created from data.

Instead of manually writing six product cards, you keep product information in an array and let React render one card per item. This is your first real taste of declarative UI: describe what should appear for the current data.

## Important Files

### `src/data/fallbackProducts.js`

This file holds plain JavaScript data. It has no React. That is deliberate.

Keeping data separate from UI makes the app easier to test, replace, and understand. Later this same shape will help when products come from the backend.

### `src/components/ProductCard.jsx`

This file teaches the component idea.

`ProductCard` should receive a product through props and render only that product. It should not know where the product came from or how many products exist.

### `src/App.jsx`

For this story, `App.jsx` coordinates the page:

- imports the data,
- loops over it,
- renders many `ProductCard` components.

That makes `App.jsx` the temporary page owner.

## What Each Move Teaches

Creating `fallbackProducts` teaches that frontend apps often begin with local seed data before backend integration.

Using `map` teaches how arrays become UI.

Passing `product={product}` teaches props: parent components pass data down to child components.

Adding `key={product.id}` teaches React identity. React uses keys to understand which list item is which between renders.

## JSX Is Not HTML

JSX looks like HTML, but it can use JavaScript expressions inside `{}`.

Examples:

- `{product.name}` inserts a value.
- `{products.map(...)}` inserts many elements.
- `className` is used instead of `class` because JSX is JavaScript.

## Mistakes To Watch For

- Do not call `map` without returning JSX.
- Do not use array index as the key when each product has a stable `id`.
- Do not make `ProductCard` import the whole product list. A card should receive one product.
- Do not put prices or names directly in JSX if they already exist in data.

## Check Yourself

- What is a prop?
- Why is `ProductCard` reusable?
- Why does React need a `key` in a list?
- What is the difference between data and UI?
