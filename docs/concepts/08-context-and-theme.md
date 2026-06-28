# 08 — Context And Theme Concepts

## Mental Model

Context is for values many components need, where passing props through every layer would be noisy.

Theme is a good Context example because many components care about colors, but theme is not business data like cart items or orders.

## Important Files

### `src/contexts/themeContext.js`

This exports the raw context object.

Keeping it separate from the provider component can make hot reload and exports cleaner.

### `src/contexts/ThemeContext.jsx`

This exports `ThemeProvider`.

The provider owns theme state and gives child components access to `theme` and `toggleTheme`.

### `src/hooks/useTheme.js`

This custom hook is the safe way to read theme context.

It hides `useContext` details and can throw a helpful error if used outside `ThemeProvider`.

### `src/main.jsx`

The provider wraps the app here because theme should be available everywhere.

### `src/index.css`

CSS variables let the whole visual system change by switching a small set of values.

## Context vs Props vs Redux

Use props for direct parent-to-child data.

Use Context for broad app-level values like theme, locale, or current user.

Use Redux later for more complex business state with many actions, like cart behavior.

## What Each Move Teaches

Creating a provider teaches how React shares values down the tree.

Creating `useTheme` teaches wrapping low-level APIs in safer local helpers.

Using `localStorage` teaches persistence outside React state.

Using CSS variables teaches that not every theme change needs conditional JSX.

## Mistakes To Watch For

- Do not put rapidly changing large business state into Context by default.
- Do not use `useTheme` outside `ThemeProvider`.
- Do not duplicate theme state in many components.
- Do not hard-code colors everywhere once CSS variables exist.

## Check Yourself

- Why is theme a good Context use case?
- What does `ThemeProvider` provide?
- Why create `useTheme` instead of calling `useContext` everywhere?
- How do CSS variables help with dark mode?
