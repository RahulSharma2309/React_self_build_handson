# 07 — Custom Hooks

## Goal

Move reusable behavior out of pages and into custom hooks.

## Concepts

- custom hooks
- hook naming rules
- reducer-style state for async flows
- debouncing
- separation of UI and behavior

## Build Steps

1. Create `src/hooks/useProducts.js`.
   Move product fetching, loading, error, and fallback behavior out of `HomePage`.

2. Update `HomePage` to call `useProducts()`.
   The page should focus on rendering, not request details.

3. Create `src/hooks/useProductFilters.js`.
   Move search, category, sort, and `visibleProducts` logic into it.

4. Create `src/hooks/useDebounce.js`.
   Use it to delay search input before filtering.

5. Confirm the filters still behave the same from the user's point of view.

## Done When

- `HomePage` is shorter and easier to read.
- Product fetching can be reused by another page.
- Filtering logic is not mixed into the JSX.
- You can explain why custom hooks start with `use`.

## Reference

Read `React Learning/docs/15-custom-hooks.md`, then compare with `React Learning/frontend/src/hooks`.
