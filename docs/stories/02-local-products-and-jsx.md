# 02 — Local Products And JSX

## Goal

Render a small product catalog from local JavaScript data.

This story teaches the first major React pattern:

> Data goes into components. Components return UI.

You are moving from hard-coded text to UI generated from an array.

## What You Are Building

You will create:

- A product data file.
- A reusable `ProductCard` component.
- A catalog grid that renders one card per product.
- Styling that makes the catalog readable.

## Concepts You Must Understand First

### JavaScript Objects

Each product is an object:

```js
{
  id: 1,
  name: 'Arduino Sensor Starter Lab',
  price: 2499,
}
```

An object groups related values under named properties.

React apps often receive data shaped like objects from APIs. Starting with local objects prepares you for backend data later.

### JavaScript Arrays

The product list is an array:

```js
export const fallbackProducts = [
  { id: 1, name: 'Arduino Sensor Starter Lab' },
  { id: 2, name: 'Raspberry Pi Home Automation Pack' },
]
```

An array lets you render many similar things without writing the same JSX repeatedly.

### Named Exports

This story uses:

```js
export const fallbackProducts = [...]
```

This creates a variable and exports it by name.

Another file imports it with matching braces:

```js
import { fallbackProducts } from './data/fallbackProducts.js'
```

Use named exports when a file may export multiple named things or when you want imports to be explicit.

### Props

Props are how a parent component gives data to a child component.

In this story:

```jsx
<ProductCard product={product} />
```

The parent gives one product object to the child.

Inside `ProductCard`:

```jsx
export function ProductCard({ product }) {
```

The child receives that object and renders it.

### `map`

`map` transforms each item in an array.

In React, it often transforms data into components:

```jsx
fallbackProducts.map((product) => (
  <ProductCard key={product.id} product={product} />
))
```

### Keys

React needs a `key` when rendering lists:

```jsx
key={product.id}
```

The key helps React track which item is which when the list changes.

Use stable IDs, not random numbers and not array indexes when real IDs exist.

## Files You Will Touch

- `src/data/fallbackProducts.js`
  New file for local product data.

- `src/components/ProductCard.jsx`
  New reusable component for one product card.

- `src/App.jsx`
  Imports data and component, then renders the grid.

- `src/App.css`
  Adds page, grid, and card styles.

- `src/index.css`
  Adds global foundation styles.

## Build Steps With Explanation

### Step 1 — Create Product Data

Create `src/data/fallbackProducts.js`.

Add:

```js
export const fallbackProducts = [
  {
    id: 1,
    name: 'Arduino Sensor Starter Lab',
    slug: 'arduino-sensor-starter-lab',
    category: 'Microcontrollers',
    price: 2499,
    image: '...',
    summary: '...',
  },
]
```

Why this file?

Because data should not be trapped inside JSX. Keeping data separate lets the UI render from a source.

Why these fields?

- `id`: stable identity for React keys.
- `name`: displayed title.
- `slug`: URL-friendly identifier for routing later.
- `category`: filtering later.
- `price`: numeric value for formatting and sorting.
- `image`: visual product image.
- `summary`: short card description.

### Step 2 — Create `ProductCard`

Create `src/components/ProductCard.jsx`.

The component receives one product:

```jsx
export function ProductCard({ product }) {
  return (
    <article className="product-card">
      ...
    </article>
  )
}
```

Why `ProductCard`?

Because rendering one product is a reusable UI responsibility. Later, many pages can use the same card.

Why `{ product }`?

React passes props as one object. Destructuring pulls out the `product` property.

### Step 3 — Render Product Fields

Inside the card, use expressions:

```jsx
{product.name}
{product.category}
{product.summary}
```

The `{}` means “switch from JSX markup into JavaScript expression mode.”

Format price:

```jsx
₹{product.price.toLocaleString('en-IN')}
```

The data stores `2499` as a number. The UI formats it as display text.

### Step 4 — Import Data And Component In `App.jsx`

Add:

```jsx
import { ProductCard } from './components/ProductCard.jsx'
import { fallbackProducts } from './data/fallbackProducts.js'
```

This tells you the dependency direction:

- `App` knows about the list.
- `ProductCard` knows only about one product.

### Step 5 — Render The List With `map`

Use:

```jsx
{fallbackProducts.map((product) => (
  <ProductCard key={product.id} product={product} />
))}
```

Read it like English:

> For every product in fallbackProducts, render one ProductCard.

### Step 6 — Add Styling

Style:

- the page width,
- the hero heading,
- the product grid,
- each card,
- image size,
- title, summary, and price.

CSS is not the React concept here, but good visual structure helps you understand what rendered.

## Debug While Building

Temporarily log the data in `App.jsx`:

```jsx
console.log(fallbackProducts)
```

Temporarily log props in `ProductCard.jsx`:

```jsx
console.log(product)
```

You should see one log per card render.

Use React DevTools:

- Inspect `App`.
- Find each `ProductCard`.
- Check the `product` prop.

## Done When

- The page shows multiple products from data.
- Product text comes from `fallbackProducts.js`.
- `ProductCard` receives a `product` prop.
- The list uses `key={product.id}`.
- You can explain how an array becomes cards on screen.

## Interview Explanation

If asked how you rendered the catalog, say:

> I kept product data in a separate JavaScript array and exported it as a named export. `App.jsx` imports the data and maps over it. For each product, it renders a reusable `ProductCard` component and passes the current product as a prop. Each list item gets a stable key from `product.id` so React can track identity across renders.

## Reference

Compare with `React Learning/frontend/src/data/fallbackProducts.js` and `React Learning/frontend/src/components/ProductCard.jsx` only after trying yourself.
