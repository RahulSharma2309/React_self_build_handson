# 03 — State, Events, And Derived Data Concepts

## Mental Model

State is memory for the UI.

When the user types, clicks, or selects something, the app remembers that value in state. React then re-renders the screen from the new state.

The key sentence is:

UI = data + state.

## Files Modified In This Story

- `src/App.jsx`
  Adds `useState`, stores the current search/category/sort choices, calculates categories and visible products, renders filter controls, and shows an empty state.

- `src/App.css`
  Adds styles for the filter controls, input focus states, and empty result message.

- `docs/concepts/03-state-events-and-derived-data.md`
  Explains the exact state, event, derived data, and debug flow for Story 03.

No new React component file is added in this story. That is intentional: before extracting filter UI in Story 04, you first learn the state and event logic in one place.

## Important Files

### `src/App.jsx`

At this stage, `App.jsx` owns the catalog behavior. It stores the user's search text, selected category, and sort option.

This is okay for now because the app is still small. Later stories will move this behavior into custom hooks.

The import changed because Story 03 uses React state:

```jsx
import { useState } from 'react'
```

`useState` is a React hook. It gives a component memory between renders.

The three state values are:

```jsx
const [searchTerm, setSearchTerm] = useState('')
const [selectedCategory, setSelectedCategory] = useState('All')
const [sortBy, setSortBy] = useState('featured')
```

Read each pair as:

- `searchTerm` is the current value.
- `setSearchTerm` is the function that changes that value.

Same pattern:

- `selectedCategory` / `setSelectedCategory`
- `sortBy` / `setSortBy`

The initial values matter:

- `''` means no search text yet.
- `'All'` means show every category.
- `'featured'` means keep the original product order.

The category list is derived:

```jsx
const categories = ['All', ...new Set(fallbackProducts.map((product) => product.category))]
```

This line takes every product category, removes duplicates with `Set`, then adds `All` at the beginning.

The search text is normalized:

```jsx
const normalizedSearchTerm = searchTerm.trim().toLowerCase()
```

This makes search forgiving:

- `trim()` ignores spaces at the start and end.
- `toLowerCase()` makes `Robot`, `robot`, and `ROBOT` behave the same.

The visible products are derived:

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

Important idea: `visibleProducts` is not state. It is calculated from:

- original data: `fallbackProducts`
- current state: `searchTerm`, `selectedCategory`, `sortBy`

That is why it updates automatically when state changes.

The controls are controlled inputs:

```jsx
<input
  type="search"
  value={searchTerm}
  onChange={(event) => setSearchTerm(event.target.value)}
/>
```

`value={searchTerm}` means React controls what the input displays.

`onChange={...}` means when the user types, React updates `searchTerm`.

The category and sort dropdowns follow the same pattern with `selectedCategory` and `sortBy`.

The grid now renders `visibleProducts`, not `fallbackProducts`:

```jsx
{visibleProducts.map((product) => (
  <ProductCard key={product.id} product={product} />
))}
```

This is the payoff: the same `ProductCard` component works because it only cares about receiving one product.

### `src/components/ProductCard.jsx`

The card still stays simple. It renders a product. It should not own search state or sorting state.

No code changed in `ProductCard.jsx`.

That is important. Search, category, and sort are catalog-level concerns. A card should not know whether it is visible because of a search, a category, or a sort option.

### `src/App.css`

The new styles are not just decoration. They support the learning behavior:

- `.catalog-controls` groups the input and dropdowns as one filter panel.
- `.control` keeps each label connected visually to its input.
- `.control input` and `.control select` make form controls consistent.
- `.control input:focus` and `.control select:focus` make keyboard focus visible.
- `.empty-state` makes the no-results case obvious.

## State vs Derived Data

State is the minimum information React must remember.

Examples:

- `searchTerm`
- `selectedCategory`
- `sortBy`

Derived data is calculated from existing state and data.

Examples:

- `visibleProducts`
- `categories`
- `hasNoResults`

Do not store derived data in state unless you have a strong reason. If React can calculate it during render, calculate it.

In this story:

- Store `searchTerm`; derive `normalizedSearchTerm`.
- Store `selectedCategory`; derive which products match it.
- Store `sortBy`; derive the sorted visible product list.
- Store none of the final filtered list.

## What Each Move Teaches

Adding `useState` teaches component memory.

Adding `onChange` teaches events. The browser reports what happened, and your handler updates React state.

Using controlled inputs teaches that React state is the source of truth for form values.

Filtering and sorting before render teaches that render is a calculation, not a manual DOM update.

## Render Flow To Debug

Use this flow when debugging Story 03:

1. The browser loads the app.
2. `main.jsx` renders `<App />`.
3. `App` starts with initial state: empty search, `All` category, `featured` sort.
4. `categories` is calculated from `fallbackProducts`.
5. `visibleProducts` is calculated from the current state.
6. React renders the controls and product grid.
7. You type in the search input.
8. `onChange` calls `setSearchTerm(...)`.
9. React re-renders `App`.
10. `normalizedSearchTerm` and `visibleProducts` are recalculated.
11. The product grid renders the new visible list.

The DOM is not manually edited. React re-renders from the new state.

## Debugging Exercises

Try these while running the app:

1. Search for `robot`.
   Only the robotics product should remain visible.

2. Search for `pi`.
   The Raspberry Pi product should match.

3. Choose the `IoT` category.
   Only products in that category should remain.

4. Choose `Price: low to high`.
   Products should reorder from cheapest to most expensive.

5. Search for text that does not exist.
   You should see the empty state.

6. Temporarily add this before `return` in `App.jsx`:

   ```jsx
   console.log({ searchTerm, selectedCategory, sortBy, visibleProducts })
   ```

   Change each control and watch which value updates. Remove the log after observing it.

7. In React DevTools, inspect `App`.
   Notice that the state belongs to `App`, not `ProductCard`.

## Mistakes To Watch For

- Do not mutate the original products array with `sort` directly. In this story, `sort` runs after `filter`, and `filter` already returns a new array. If you sort the original array directly, copy it first with `[...products]`.
- Do not keep `visibleProducts` in state if it can be calculated.
- Do not read old state immediately after calling a setter and expect it to be updated in the same line.
- Do not put too much logic inside JSX. Calculate first, render second.

## Check Yourself

- Which values are true state?
- Which values are derived?
- What makes an input controlled?
- Why does typing in a search box cause the product grid to update?
