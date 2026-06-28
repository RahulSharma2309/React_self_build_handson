# 08 — Context And Theme Concepts

## Mental Model

Context is for values many components need, where passing props through every layer would be noisy.

Theme is a good Context example because many components care about colors, but theme is not business data like cart items or orders.

Context is not a replacement for all props. It is a tool for sharing broad values through a subtree.

Think:

```text
ThemeProvider
  -> gives theme value to everything below
  -> Header can toggle it
  -> CSS can display it
  -> pages do not need theme props
```

## Important Files

### `src/contexts/themeContext.js`

This exports the raw context object.

Keeping it separate from the provider component can make hot reload and exports cleaner.

The context object is like a named channel. It does not hold useful app behavior by itself. The provider puts a value into the channel, and consumers read from it.

### `src/contexts/ThemeContext.jsx`

This exports `ThemeProvider`.

The provider owns theme state and gives child components access to `theme` and `toggleTheme`.

Provider value design matters. Keep it small:

```js
{ theme, toggleTheme }
```

Do not dump unrelated state into the theme provider.

### `src/hooks/useTheme.js`

This custom hook is the safe way to read theme context.

It hides `useContext` details and can throw a helpful error if used outside `ThemeProvider`.

That helpful error matters. Without it, a component may fail later with a confusing `Cannot read properties of null` message.

### `src/main.jsx`

The provider wraps the app here because theme should be available everywhere.

### `src/index.css`

CSS variables let the whole visual system change by switching a small set of values.

Instead of conditionally styling every component, components read variables:

```css
background: var(--surface);
color: var(--text);
```

The theme changes the variable values.

## Context vs Props vs Redux

Use props for direct parent-to-child data.

Use Context for broad app-level values like theme, locale, or current user.

Use Redux later for more complex business state with many actions, like cart behavior.

Context provides access to a value.

Redux provides a structured state system: actions, reducers, selectors, devtools, and predictable update rules.

Theme is simple. Context is enough.

Cart is more complex. Redux is a better fit later.

## `localStorage`

React state resets when the page refreshes.

`localStorage` persists strings in the browser.

Theme persistence usually works like this:

1. Read saved theme when provider starts.
2. Store theme when it changes.
3. Apply theme to the DOM or CSS variables.

Remember: `localStorage` stores strings, not rich JavaScript objects unless you serialize them.

## Context Re-render Warning

When a context value changes, consumers of that context can re-render.

For theme, that is okay because theme changes are rare.

For rapidly changing values like mouse position or input text, Context may be a poor fit because it can trigger broad re-renders.

## What Each Move Teaches

Creating a provider teaches how React shares values down the tree.

Creating `useTheme` teaches wrapping low-level APIs in safer local helpers.

Using `localStorage` teaches persistence outside React state.

Using CSS variables teaches that not every theme change needs conditional JSX.

## Debugging Theme Context

If theme does not work:

1. Confirm `ThemeProvider` wraps the app.
2. Confirm `useTheme` is called below the provider.
3. Log `theme` in `Header`.
4. Confirm `toggleTheme` changes state.
5. Inspect `localStorage`.
6. Inspect the DOM attribute or class used for theme.
7. Confirm CSS variables are referenced by components.

## Mistakes To Watch For

- Do not put rapidly changing large business state into Context by default.
- Do not use `useTheme` outside `ThemeProvider`.
- Do not duplicate theme state in many components.
- Do not hard-code colors everywhere once CSS variables exist.
- Do not put unrelated values into theme context.
- Do not use Context for fast-changing state without thinking about re-renders.
- Do not forget persistence and React state solve different problems.

## Senior-Level Thinking

Context design is API design.

Every component using `useTheme` depends on the shape of that returned value. Keep it stable, small, and meaningful.

An experienced developer separates:

- provider: owns state and persistence,
- custom hook: gives safe access,
- CSS variables: express visual theme,
- header button: triggers user change.

## Interview Explanation

> Context lets me avoid prop drilling for broad app-level values. For theme, I use a provider to store the current theme and toggle function, a custom hook to read the context safely, localStorage to persist the user's choice, and CSS variables to apply the visual changes globally. I would not put complex cart logic in this same context because cart has more business actions and belongs in a structured state solution.

## Check Yourself

- Why is theme a good Context use case?
- What does `ThemeProvider` provide?
- Why create `useTheme` instead of calling `useContext` everywhere?
- How do CSS variables help with dark mode?
