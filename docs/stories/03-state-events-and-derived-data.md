# 03 — State, Events, And Derived Data

## Goal

Make the product catalog interactive with search, category filtering, and sorting.

This story is not about making three form controls. It is about learning the most important daily React skill:

> Keep the smallest amount of changing information in state, then calculate the UI from that state.

After this story, you should understand why React is often described as:

> UI = data + state

## What You Are Building

You already have product data in `src/data/fallbackProducts.js`, and cards render from that data.

Now you will add:

- A search box that filters products by name or summary.
- A category dropdown that narrows products by category.
- A sort dropdown that changes product order.
- A no-results message when no product matches.

The product cards themselves will not change. That is important. A card should render one product; the catalog decides which products are visible.

## Concepts You Must Understand First

### `useState`

`useState` gives a component memory.

A normal variable is recreated every render:

```jsx
let searchTerm = ''
```

If the user types into an input and you change a normal variable, React does not know that the UI should update.

State is different:

```jsx
const [searchTerm, setSearchTerm] = useState('')
```

This tells React:

- Remember `searchTerm` between renders.
- When `setSearchTerm` is called, schedule a re-render.
- On the next render, give the component the new value.

Use state when:

- The value changes because the user does something.
- The value should affect what appears on screen.
- The value must survive a re-render.

Do not use state when:

- The value can be calculated from existing state or props.
- The value never changes.
- You are only trying to store a temporary helper inside one calculation.

### Event Handlers

An event handler is a function that runs because the user or browser did something.

Examples:

- User types in an input: `onChange`
- User clicks a button: `onClick`
- User submits a form: `onSubmit`

In this story:

```jsx
onChange={(event) => setSearchTerm(event.target.value)}
```

Meaning:

1. The browser notices the input changed.
2. React calls your `onChange` function.
3. React gives your function an `event` object.
4. `event.target.value` is the latest input text.
5. You call `setSearchTerm(...)`.
6. React re-renders the component.

### Controlled Inputs

A controlled input is an input where React state is the source of truth.

```jsx
<input
  value={searchTerm}
  onChange={(event) => setSearchTerm(event.target.value)}
/>
```

There are two halves:

- `value={searchTerm}` means React controls what the input shows.
- `onChange={...}` means user typing updates React state.

If you only add `value` and forget `onChange`, the input becomes read-only from the user's point of view.

If you only add `onChange` and forget `value`, the input can still work, but React is no longer fully controlling the displayed value.

### Derived Values

A derived value is calculated from data and state.

For this story:

- `searchTerm` is state.
- `selectedCategory` is state.
- `sortBy` is state.
- `categories` is derived.
- `normalizedSearchTerm` is derived.
- `visibleProducts` is derived.

Do not store `visibleProducts` in state. It can be calculated from `fallbackProducts`, `searchTerm`, `selectedCategory`, and `sortBy`.

This is a senior habit: avoid duplicate state. Duplicate state becomes stale and creates bugs.

### `filter`, `sort`, And `includes`

These are JavaScript tools React developers use constantly.

`filter` keeps only items that pass a condition:

```js
products.filter((product) => product.category === 'IoT')
```

`includes` checks whether one string contains another:

```js
product.name.toLowerCase().includes('robot')
```

`sort` changes order:

```js
products.sort((a, b) => a.price - b.price)
```

Important: `sort` mutates the array it is called on. In our implementation, `sort` runs after `filter`, and `filter` already returns a new array. If you sort the original array directly, copy it first.

## Files You Will Touch

- `src/App.jsx`
  Add state, event handlers, derived categories, derived visible products, controls, and empty state.

- `src/App.css`
  Add styles for the control panel, inputs, focus states, and empty message.

You will not change:

- `src/components/ProductCard.jsx`
  The card should not know about searching, filtering, or sorting.

- `src/data/fallbackProducts.js`
  The data does not change just because the user changes how it is viewed.

## Build Steps With Explanation

### Step 1 — Import `useState`

In `src/App.jsx`, add:

```jsx
import { useState } from 'react'
```

Why?

Because Story 03 introduces component memory. Before this, `App` only rendered static data. Now `App` must remember what the user typed and selected.

### Step 2 — Add State Values

Inside `App`, before `return`, add:

```jsx
const [searchTerm, setSearchTerm] = useState('')
const [selectedCategory, setSelectedCategory] = useState('All')
const [sortBy, setSortBy] = useState('featured')
```

Why these three?

- `searchTerm`: changes when the user types.
- `selectedCategory`: changes when the user picks a category.
- `sortBy`: changes when the user chooses a sort order.

Why not store `visibleProducts`?

Because `visibleProducts` is calculated from these three state values plus the product data.

### Step 3 — Calculate Categories

Add:

```jsx
const categories = ['All', ...new Set(fallbackProducts.map((product) => product.category))]
```

Read it slowly:

1. `fallbackProducts.map(...)` creates an array of categories.
2. `new Set(...)` removes duplicate categories.
3. `...` spreads the unique values back into an array.
4. `'All'` is added as the first option.

This is derived data. If products change later, categories update automatically.

### Step 4 — Normalize Search Text

Add:

```jsx
const normalizedSearchTerm = searchTerm.trim().toLowerCase()
```

Why?

Users do not type perfectly. They may type spaces or uppercase letters.

This makes searches like these behave similarly:

- `robot`
- ` Robot `
- `ROBOT`

### Step 5 — Calculate Visible Products

Add:

```jsx
const visibleProducts = fallbackProducts
  .filter((product) => {
    const matchesSearch =
      product.name.toLowerCase().includes(normalizedSearchTerm) ||
      product.summary.toLowerCase().includes(normalizedSearchTerm)
    const matchesCategory = selectedCategory === 'All' || product.category === selectedCategory

    return matchesSearch && matchesCategory
  })
  .sort((firstProduct, secondProduct) => {
    if (sortBy === 'price-low') {
      return firstProduct.price - secondProduct.price
    }

    if (sortBy === 'price-high') {
      return secondProduct.price - firstProduct.price
    }

    return firstProduct.id - secondProduct.id
  })
```

This is the main logic of the story.

`matchesSearch` is true when the product name or summary contains the search text.

`matchesCategory` is true when:

- the user selected `All`, or
- the product category equals the selected category.

The final `return` says:

```js
return matchesSearch && matchesCategory
```

Both must be true.

Sorting rules:

- `price-low`: cheapest first.
- `price-high`: most expensive first.
- `featured`: original order by `id`.

### Step 6 — Add The Search Input

Render:

```jsx
<input
  type="search"
  value={searchTerm}
  onChange={(event) => setSearchTerm(event.target.value)}
  placeholder="Try robot or pi"
/>
```

This is a controlled input. React state controls the input, and the input updates React state.

### Step 7 — Add The Category Select

Render:

```jsx
<select
  value={selectedCategory}
  onChange={(event) => setSelectedCategory(event.target.value)}
>
  {categories.map((category) => (
    <option key={category} value={category}>
      {category}
    </option>
  ))}
</select>
```

Important idea: even the dropdown options come from data.

### Step 8 — Add The Sort Select

Render:

```jsx
<select value={sortBy} onChange={(event) => setSortBy(event.target.value)}>
  <option value="featured">Featured</option>
  <option value="price-low">Price: low to high</option>
  <option value="price-high">Price: high to low</option>
</select>
```

The option `value` is the internal value your code reads. The text between `<option>` tags is what the user sees.

### Step 9 — Render `visibleProducts`

Replace the old product loop:

```jsx
fallbackProducts.map(...)
```

with:

```jsx
visibleProducts.map(...)
```

Why?

The UI should now reflect the user's current state, not the raw product array.

### Step 10 — Add Empty State

Render the grid only when products exist:

```jsx
{visibleProducts.length > 0 ? (
  <section className="product-grid" aria-label="Product catalog">
    {visibleProducts.map((product) => (
      <ProductCard key={product.id} product={product} />
    ))}
  </section>
) : (
  <p className="empty-state">No products match your filters. Try a different search.</p>
)}
```

This teaches conditional rendering.

Good UI does not silently show nothing. It tells the user what happened.

## Debug While Building

Add this temporarily before `return`:

```jsx
console.log({ searchTerm, selectedCategory, sortBy, visibleProducts })
```

Then:

1. Type in the search box.
2. Watch `searchTerm` change.
3. Select a category.
4. Watch `selectedCategory` change.
5. Change sort order.
6. Watch `sortBy` change.
7. Watch `visibleProducts` recalculate.

Remove the log after you understand the flow.

## Done When

- Typing in search changes the visible products.
- Changing category narrows the list.
- Sorting changes the order without changing `fallbackProducts.js`.
- A no-results message appears when nothing matches.
- You can explain why `searchTerm` is state but `visibleProducts` is derived.
- You can explain what happens from typing a character to React re-rendering the grid.

## Interview-Level Explanation

If asked about this story in an interview, say:

> I kept only user choices in state: search text, selected category, and sort order. The filtered and sorted product list is derived during render from the original data plus those state values. Inputs are controlled, so user events update React state through `onChange`. When state changes, React re-renders the component and recalculates the visible list. This avoids duplicate state and keeps the UI predictable.

## Reference

Read `React Learning/docs/08-state-and-events.md`, then compare with `React Learning/frontend/src/hooks/useProductFilters.js`.
