# 04 — Components And Composition

## Goal

Split the growing page into focused components.

## Concepts

- component responsibility
- props down, events up
- composition
- reusable UI

## Build Steps

1. Create `src/components/ProductFilters.jsx`.
   Move the search input and select controls into it.

2. Pass values and setter functions from `App.jsx` into `ProductFilters`.
   Keep the actual state in `App.jsx` for now.

3. Keep `ProductCard` focused on one product only.
   It should not know how searching or sorting works.

4. Create `src/components/Header.jsx`.
   Add a simple title and navigation placeholder.

5. Create `src/components/Footer.jsx`.
   Add a small footer with the app name.

6. Update `App.jsx` to compose:
   - `Header`
   - filter controls
   - product grid
   - `Footer`

## Done When

- `App.jsx` reads like a page outline.
- Filter logic still works after moving the controls.
- You can explain which component owns each piece of state.

## Reference

Read `React Learning/docs/07-components-and-props.md`, then compare with the finished `components` folder.
