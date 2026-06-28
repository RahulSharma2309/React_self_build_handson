# 07 — Custom Hooks Concepts

## Mental Model

Custom hooks are reusable behavior.

Components should focus on what the UI looks like. Hooks can hold the logic for fetching, filtering, debouncing, local storage, and other behavior that multiple components may need.

Think of a custom hook as a named behavior module for React state and effects.

It is not a component because it does not return JSX.

## Important Files

### `src/hooks/useProducts.js`

This hook owns product loading behavior.

It can return `products`, `isLoading`, and `error`, so pages do not need to know the details of the request.

Good hook return values are the things the UI needs to make decisions.

### `src/hooks/useProductFilters.js`

This hook owns filtering and sorting behavior.

It keeps search, category, sort, and visible products together.

### `src/hooks/useDebounce.js`

This hook delays a fast-changing value.

It is useful when the user types quickly and you do not want expensive work to run on every keystroke.

Debounce is also useful before API search requests so you do not call the backend on every keypress.

### `src/pages/HomePage.jsx`

After hooks are extracted, this page becomes easier to read:

- get products,
- get filters,
- render UI.

## Why Hooks Start With `use`

React uses naming rules to protect hook behavior.

A function named `useSomething` tells React tooling that this function may call other hooks. It must follow the Rules of Hooks: call hooks at the top level, not inside loops, conditions, or nested functions.

## Why Hooks Must Not Be Conditional

React tracks hook state by call order.

If hooks run in a different order between renders, React cannot match stored state to the right hook.

Bad:

```js
if (shouldLoad) {
  useProducts()
}
```

Good:

```js
const productsState = useProducts()
```

Then use conditions in rendering or inside the hook logic.

## When To Create A Custom Hook

Create one when:

- behavior is reused,
- behavior is complex enough to name,
- a component is becoming hard to read,
- logic combines state/effects/calculations,
- you want to test or reason about behavior separately.

Avoid one when:

- the logic is only one simple line,
- the name is vague,
- it hides important flow from a beginner too early,
- it returns JSX instead of behavior.

## Hook Return Design

Hooks should return the minimum useful API.

Example:

```js
return {
  products,
  isLoading,
  error,
}
```

For filters:

```js
return {
  searchTerm,
  setSearchTerm,
  selectedCategory,
  setSelectedCategory,
  sortBy,
  setSortBy,
  categories,
  visibleProducts,
}
```

The page should not need to know internal helper variables unless the UI needs them.

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
- Do not create hooks just to avoid writing imports.
- Do not make hook names generic like `useData` if the behavior is specifically products.

## Senior-Level Thinking

Custom hooks are an architecture tool, not a magic performance tool.

They make code better when they clarify ownership:

- Page owns screen composition.
- Hook owns behavior.
- Component owns reusable UI.

But too many hooks can hide the flow. Extract when the behavior has a meaningful name.

## Interview Explanation

> A custom hook is a reusable function for React behavior. It starts with `use`, can call built-in hooks, and returns state or functions needed by components. I use hooks to keep components focused on rendering while sharing behavior like fetching, filtering, and debouncing. Hooks must be called unconditionally at the top level so React can preserve hook call order.

## Check Yourself

- What is the difference between a component and a hook?
- Why does `useProducts` not render anything?
- What problem does debouncing solve?
- How did `HomePage` become easier after extraction?
