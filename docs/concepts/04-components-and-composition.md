# 04 — Components And Composition Concepts

## Mental Model

Components are boundaries.

A good component has one clear job. When a file starts doing too many jobs, you split it so each part becomes easier to read, test, and reuse.

## Important Files

### `src/components/ProductFilters.jsx`

This component owns the filter UI, not the filter state.

It receives values and callbacks from its parent. This teaches a common React pattern: props down, events up.

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

## What Each Move Teaches

Extracting `ProductFilters` teaches component boundaries.

Passing callbacks teaches that child components can request changes without owning parent state.

Creating `Header` and `Footer` teaches layout composition.

Keeping `ProductCard` focused teaches that small components are easier to reason about.

## Mistakes To Watch For

- Do not move state into `ProductFilters` if `App.jsx` needs the filtered result.
- Do not make every tiny `<div>` a component. Extract when there is a clear responsibility.
- Do not pass more props than a component needs.
- Do not let shared layout components depend on catalog-specific details.

## Check Yourself

- Which component owns search state?
- Which component renders the search input?
- Why is that split useful?
- What does composition mean in React?
