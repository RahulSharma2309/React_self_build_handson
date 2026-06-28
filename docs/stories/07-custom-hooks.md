# 07 — Custom Hooks

## Goal

Move reusable behavior out of page components and into custom hooks.

This story teaches:

> Components render UI. Hooks package reusable behavior.

You already know how fetching and filtering work. Now you learn how to organize that behavior so pages do not become crowded.

## What You Are Building

- `useProducts` for product loading state.
- `useProductFilters` for search/category/sort behavior.
- `useDebounce` for delaying fast-changing values.
- A cleaner `HomePage` that composes hooks and renders UI.

## Concepts You Must Understand First

### Custom Hooks

A custom hook is a function that can call React hooks and return reusable stateful behavior.

It must start with `use`:

```js
useProducts()
useProductFilters()
useDebounce()
```

The name is not just style. React tooling uses the `use` prefix to enforce hook rules.

### Rules Of Hooks

Hooks must be called:

- at the top level,
- inside React components or other hooks,
- in the same order on every render.

Do not call hooks inside:

- `if`,
- loops,
- nested functions,
- event handlers.

### UI vs Behavior

UI:

- headings,
- sections,
- cards,
- buttons,
- form controls.

Behavior:

- fetching products,
- filtering products,
- debouncing input,
- syncing with browser APIs.

Custom hooks are for behavior, not markup.

## Files You Will Touch

- `src/hooks/useProducts.js`
  Product fetching behavior.

- `src/hooks/useProductFilters.js`
  Search, category, sort, and visible products.

- `src/hooks/useDebounce.js`
  Delay fast-changing values.

- `src/pages/HomePage.jsx`
  Uses hooks and renders UI.

## Build Steps With Explanation

### Step 1 — Create `useProducts`

Move product fetching into:

```js
export function useProducts() {
  ...
  return { products, isLoading, error }
}
```

Why?

Any page can now load products without copying effect logic.

### Step 2 — Use `useProducts` In The Page

In `HomePage`:

```jsx
const { products, isLoading, error } = useProducts()
```

The page should read like intent, not request plumbing.

### Step 3 — Create `useProductFilters`

Move:

- `searchTerm`,
- `selectedCategory`,
- `sortBy`,
- `categories`,
- `visibleProducts`

into a hook.

Return both state values and setter functions so the UI can stay controlled.

### Step 4 — Create `useDebounce`

Debouncing means waiting for the user to pause before using a fast-changing value.

Search input changes every keystroke. Debouncing can reduce expensive filtering or future API calls.

### Step 5 — Confirm Behavior Stayed The Same

Refactoring should not change the user experience.

After extraction:

- search still works,
- category still works,
- sort still works,
- loading/error still work.

## Debug While Building

If a hook breaks:

- Confirm it starts with `use`.
- Confirm it is called at the top level.
- Log the hook return value.
- Check effect dependencies.
- Confirm the page uses returned values, not old local variables.

## Done When

- `HomePage` is shorter and clearer.
- Fetching behavior lives in `useProducts`.
- Filtering behavior lives in `useProductFilters`.
- Debounce behavior lives in `useDebounce`.
- You can explain why hooks return data/functions, not JSX.

## Interview Explanation

> I extracted repeated or complex behavior into custom hooks. A custom hook is a function that starts with `use`, can call other hooks, and returns reusable stateful behavior. Components still render UI, while hooks handle fetching, filtering, and debouncing. This keeps pages readable and makes behavior reusable.

## Reference

Read `React Learning/docs/15-custom-hooks.md`, then compare with `React Learning/frontend/src/hooks`.
