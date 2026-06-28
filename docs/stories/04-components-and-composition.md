# 04 — Components And Composition

## Goal

Split the growing catalog screen into focused components without losing the behavior from Story 03.

This story teaches a key React design skill:

> A component should have one clear reason to change.

Story 03 intentionally kept state and controls in `App.jsx` so you could understand the behavior. Story 04 teaches how to separate UI pieces while keeping state ownership clear.

## What You Are Building

You will extract:

- `ProductFilters.jsx` for the search/category/sort controls.
- `Header.jsx` for the top page identity.
- `Footer.jsx` for bottom page structure.

`App.jsx` should start reading like a page outline instead of one large block of JSX.

## Concepts You Must Understand First

### Component Responsibility

Responsibility means: what is this file in charge of?

Good responsibilities:

- `ProductCard`: render one product.
- `ProductFilters`: render filter controls.
- `Header`: render top app identity/navigation area.
- `Footer`: render bottom app area.
- `App`: hold state for now and compose the page.

Bad responsibility:

- One component fetches data, filters data, renders controls, renders cards, owns layout, handles checkout, and styles everything mentally.

That becomes hard to understand and hard to change.

### Props Down

Data moves from parent to child through props.

`App` owns:

- `searchTerm`
- `selectedCategory`
- `sortBy`
- `categories`

`App` passes those values into `ProductFilters`.

### Events Up

Children cannot directly change parent state.

Instead, parent passes callback functions:

- `onSearchChange`
- `onCategoryChange`
- `onSortChange`

The child calls them when the user interacts.

This pattern is called “props down, events up.”

### Composition

Composition means building bigger UI by putting smaller components together:

```jsx
<Header />
<ProductFilters />
<ProductCard />
<Footer />
```

React prefers composition over giant components.

## Files You Will Touch

- `src/components/ProductFilters.jsx`
  New component for filter controls.

- `src/components/Header.jsx`
  New component for the page header.

- `src/components/Footer.jsx`
  New component for page footer.

- `src/App.jsx`
  Imports and composes the new components.

- `src/App.css`
  Moves or adjusts styles for the new component classes.

## Build Steps With Explanation

### Step 1 — Create `ProductFilters.jsx`

Move the search input and two selects from `App.jsx` into `ProductFilters`.

The component should receive values and callbacks:

```jsx
export function ProductFilters({
  searchTerm,
  selectedCategory,
  sortBy,
  categories,
  onSearchChange,
  onCategoryChange,
  onSortChange,
}) {
  ...
}
```

Why not keep state inside `ProductFilters`?

Because `App` still needs the state to calculate `visibleProducts`.

### Step 2 — Wire Controlled Inputs Through Props

Inside `ProductFilters`, keep the same controlled input pattern:

```jsx
value={searchTerm}
onChange={(event) => onSearchChange(event.target.value)}
```

The child does not know how state is stored. It only reports the new value.

### Step 3 — Update `App.jsx`

Import:

```jsx
import { ProductFilters } from './components/ProductFilters.jsx'
```

Render:

```jsx
<ProductFilters
  searchTerm={searchTerm}
  selectedCategory={selectedCategory}
  sortBy={sortBy}
  categories={categories}
  onSearchChange={setSearchTerm}
  onCategoryChange={setSelectedCategory}
  onSortChange={setSortBy}
/>
```

This keeps state in `App`, but moves form markup into a focused child.

### Step 4 — Create `Header.jsx`

Move the hero heading into a `Header` component.

For now, it can be static. Later it will grow into navigation, theme toggle, and cart button.

### Step 5 — Create `Footer.jsx`

Add a simple footer.

Even small layout components are useful because they show how the page shell forms.

### Step 6 — Keep `ProductCard` Focused

Do not add filtering logic to `ProductCard`.

If you feel tempted to pass search state into the card, stop. The card should receive one already-selected product and render it.

## Debug While Building

After extracting `ProductFilters`, test:

1. Type in search.
2. Change category.
3. Change sort.
4. Confirm the product grid still updates.

If it breaks, inspect:

- Did `App` pass the right value prop?
- Did `ProductFilters` call the right callback?
- Did the callback receive `event.target.value`?
- Did you accidentally move state into the child?

## Done When

- `App.jsx` reads like a page outline.
- Search, filter, and sort still work.
- `ProductFilters` renders controls but does not own catalog state.
- `Header` and `Footer` are separate components.
- You can explain props down and events up.

## Interview Explanation

> I extracted UI sections into focused components while keeping state ownership in the parent. `App` owns the filter state because it calculates visible products. `ProductFilters` receives current values and callback props. When the user changes an input, the child calls the callback, the parent updates state, and the filtered list recalculates. This keeps components focused without breaking data flow.

## Reference

Read `React Learning/docs/07-components-and-props.md`, then compare with the finished `components` folder.
