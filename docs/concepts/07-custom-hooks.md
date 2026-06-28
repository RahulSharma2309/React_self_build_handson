# 07 — Custom Hooks Concepts

## Mental Model

Custom hooks are reusable behavior.

Components should focus on what the UI looks like. Hooks can hold the logic for fetching, filtering, debouncing, local storage, and other behavior that multiple components may need.

## Important Files

### `src/hooks/useProducts.js`

This hook owns product loading behavior.

It can return `products`, `isLoading`, and `error`, so pages do not need to know the details of the request.

### `src/hooks/useProductFilters.js`

This hook owns filtering and sorting behavior.

It keeps search, category, sort, and visible products together.

### `src/hooks/useDebounce.js`

This hook delays a fast-changing value.

It is useful when the user types quickly and you do not want expensive work to run on every keystroke.

### `src/pages/HomePage.jsx`

After hooks are extracted, this page becomes easier to read:

- get products,
- get filters,
- render UI.

## Why Hooks Start With `use`

React uses naming rules to protect hook behavior.

A function named `useSomething` tells React tooling that this function may call other hooks. It must follow the Rules of Hooks: call hooks at the top level, not inside loops, conditions, or nested functions.

## What Each Move Teaches

Moving fetch logic teaches reuse.

Moving filter logic teaches separation between behavior and UI.

Adding debounce teaches how effects can manage time.

Cleaning `HomePage` teaches that refactoring is not just making files smaller; it is making responsibilities clearer.

## Mistakes To Watch For

- Do not call hooks conditionally.
- Do not make hooks return JSX. Hooks return data and functions.
- Do not hide unclear behavior in a hook too early. Extract only when the responsibility is real.
- Do not forget dependencies in effects inside hooks.

## Check Yourself

- What is the difference between a component and a hook?
- Why does `useProducts` not render anything?
- What problem does debouncing solve?
- How did `HomePage` become easier after extraction?
