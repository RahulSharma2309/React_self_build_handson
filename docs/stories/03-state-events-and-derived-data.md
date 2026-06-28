# 03 — State, Events, And Derived Data

## Goal

Make the product catalog interactive with search, category filter, and sorting.

## Concepts

- `useState`
- event handlers
- controlled inputs
- derived values
- `filter`, `sort`, `includes`

## Build Steps

1. In `src/App.jsx`, import `useState`.

2. Add state for:
   - `searchTerm`
   - `selectedCategory`
   - `sortBy`

3. Add an input for search.
   Its `value` should come from `searchTerm`, and `onChange` should update `searchTerm`.

4. Add a category `<select>`.
   Start with `All`, then add categories from your product data.

5. Add a sort `<select>`.
   Support at least `featured`, `price-low`, and `price-high`.

6. Before rendering the grid, calculate `visibleProducts`.
   Filter by search and category, then sort the result.

7. Show a friendly empty message when no products match.

## Done When

- Typing in search changes the visible products.
- Changing category narrows the list.
- Sorting changes the order without changing the original data file.
- You can explain the difference between state and derived data.

## Reference

Read `React Learning/docs/08-state-and-events.md`, then compare with `React Learning/frontend/src/hooks/useProductFilters.js`.
