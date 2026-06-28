# 03 — State, Events, And Derived Data Concepts

## Mental Model

State is memory for the UI.

When the user types, clicks, or selects something, the app remembers that value in state. React then re-renders the screen from the new state.

The key sentence is:

UI = data + state.

## Important Files

### `src/App.jsx`

At this stage, `App.jsx` owns the catalog behavior. It stores the user's search text, selected category, and sort option.

This is okay for now because the app is still small. Later stories will move this behavior into custom hooks.

### `src/components/ProductCard.jsx`

The card still stays simple. It renders a product. It should not own search state or sorting state.

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

## What Each Move Teaches

Adding `useState` teaches component memory.

Adding `onChange` teaches events. The browser reports what happened, and your handler updates React state.

Using controlled inputs teaches that React state is the source of truth for form values.

Filtering and sorting before render teaches that render is a calculation, not a manual DOM update.

## Mistakes To Watch For

- Do not mutate the original products array with `sort` directly. Copy it first with `[...products]`.
- Do not keep `visibleProducts` in state if it can be calculated.
- Do not read old state immediately after calling a setter and expect it to be updated in the same line.
- Do not put too much logic inside JSX. Calculate first, render second.

## Check Yourself

- Which values are true state?
- Which values are derived?
- What makes an input controlled?
- Why does typing in a search box cause the product grid to update?
