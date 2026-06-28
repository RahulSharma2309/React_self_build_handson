# 04 — Components And Composition Concepts

## Mental Model

Components are boundaries.

A good component has one clear job. When a file starts doing too many jobs, you split it so each part becomes easier to read, test, and reuse.

The mistake beginners make is extracting based only on size. Experienced developers extract based on responsibility.

Ask:

- What does this section know?
- What does it render?
- What state does it need?
- Who should own that state?
- Will this piece be reused?

## Important Files

### `src/components/ProductFilters.jsx`

This component owns the filter UI, not the filter state.

It receives values and callbacks from its parent. This teaches a common React pattern: props down, events up.

It should receive:

- current search value,
- current category,
- current sort,
- category options,
- callback for search changes,
- callback for category changes,
- callback for sort changes.

It should not calculate `visibleProducts`. That is not filter UI; that is catalog behavior.

### `src/components/Header.jsx`

The header is shared page structure. Later it will hold navigation, theme toggle, and cart button.

### `src/components/Footer.jsx`

The footer is another shared layout piece. It is simple, but it teaches that repeated UI should have a home.

### `src/App.jsx`

After extracting components, `App.jsx` should read like an outline of the page instead of one giant file.

## Props Down, Events Up

Data flows down:

`App.jsx` gives `searchTerm` to `ProductFilters`.

Events flow up:

`ProductFilters` calls `onSearchChange`, and `App.jsx` updates state.

This keeps ownership clear. The parent owns state because multiple parts of the page may need the result.

### Why Children Do Not Directly Change Parent State

React data flow is intentionally one-way.

A child cannot reach into a parent and mutate its variables. Instead, the parent gives the child a function.

This keeps updates traceable:

```text
User changes input
ProductFilters calls callback
App setter updates state
App recalculates visibleProducts
React re-renders
```

That traceability matters when apps grow.

## What Each Move Teaches

Extracting `ProductFilters` teaches component boundaries.

Passing callbacks teaches that child components can request changes without owning parent state.

Creating `Header` and `Footer` teaches layout composition.

Keeping `ProductCard` focused teaches that small components are easier to reason about.

## State Ownership

State should live in the closest common owner that needs it.

In Story 04:

- `ProductFilters` needs to display filter values.
- `App` needs filter values to calculate products.

Because `App` needs the values, `App` owns the state and passes values down.

Later, custom hooks can hold behavior, but ownership rules still matter.

## Component Extraction Checklist

Extract a component when:

- a section has a clear responsibility,
- the JSX distracts from the parent flow,
- the piece may be reused,
- it has a meaningful name,
- its props are understandable.

Do not extract when:

- the name would be vague like `Thing` or `Stuff`,
- the component needs twenty unrelated props,
- it hides simple code behind unnecessary indirection,
- it makes data flow harder to follow.

## Debugging Component Boundaries

If behavior breaks after extraction:

1. Check props in React DevTools.
2. Confirm the child receives the values you expect.
3. Confirm the child calls callbacks with the right arguments.
4. Confirm the parent setter updates state.
5. Confirm derived values recalculate.

Most extraction bugs are prop name mismatches or callbacks not being called.

## Mistakes To Watch For

- Do not move state into `ProductFilters` if `App.jsx` needs the filtered result.
- Do not make every tiny `<div>` a component. Extract when there is a clear responsibility.
- Do not pass more props than a component needs.
- Do not let shared layout components depend on catalog-specific details.
- Do not move state just because you moved JSX.
- Do not extract so aggressively that the data flow becomes invisible.

## Senior-Level Thinking

A senior engineer balances clarity and indirection.

Too little extraction creates huge files.

Too much extraction creates a maze.

The right extraction makes the parent read like a story:

```jsx
<Header />
<ProductFilters />
<ProductGrid />
<Footer />
```

Each child should have a clear contract.

## Interview Explanation

> I split the catalog UI by responsibility. `App` still owns the filter state because it needs that state to derive visible products. `ProductFilters` receives values and callbacks, so it can render controlled inputs without owning the data. This demonstrates props down, events up, and keeps state ownership clear.

## Check Yourself

- Which component owns search state?
- Which component renders the search input?
- Why is that split useful?
- What does composition mean in React?
