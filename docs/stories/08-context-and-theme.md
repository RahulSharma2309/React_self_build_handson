# 08 — Context And Theme

## Goal

Add light/dark theme switching without passing theme props through every component.

This story teaches:

> Context shares app-wide values with a subtree.

Theme is a good Context example because many components care about the result, but the value is not complex business data.

## What You Are Building

- A theme context.
- A `ThemeProvider`.
- A safe `useTheme` hook.
- A header toggle button.
- Theme persistence with `localStorage`.
- CSS variables for light and dark themes.

## Concepts You Must Understand First

### Prop Drilling

Prop drilling happens when you pass props through components that do not actually need them just to reach a deeper child.

Context solves this for app-wide values.

### Context

Context lets a parent provider make a value available to all descendants.

It is useful for:

- theme,
- locale,
- current user,
- feature flags.

It is not automatically the best place for all state.

### Provider

A provider wraps part of the component tree and supplies a value.

```jsx
<ThemeProvider>
  <App />
</ThemeProvider>
```

### `localStorage`

`localStorage` stores strings in the browser and survives refresh.

React state remembers during the current session render lifecycle. `localStorage` remembers after reload.

### CSS Variables

CSS variables let you define reusable style values:

```css
:root {
  --color-bg: #ffffff;
}
```

Then use:

```css
background: var(--color-bg);
```

Switching theme becomes changing variables, not rewriting every component.

## Files You Will Touch

- `src/contexts/themeContext.js`
  Raw context object.

- `src/contexts/ThemeContext.jsx`
  Provider component.

- `src/hooks/useTheme.js`
  Safe hook for reading theme.

- `src/main.jsx`
  Wrap app with provider.

- `src/components/Header.jsx`
  Add theme toggle.

- `src/index.css`
  Add CSS variables for themes.

## Build Steps With Explanation

### Step 1 — Create The Context Object

```js
import { createContext } from 'react'

export const ThemeContext = createContext(null)
```

The context object is the channel.

### Step 2 — Create `ThemeProvider`

The provider owns:

- current theme,
- toggle function,
- persistence behavior.

It gives children a value like:

```js
{ theme, toggleTheme }
```

### Step 3 — Create `useTheme`

Wrap `useContext`:

```js
export function useTheme() {
  const context = useContext(ThemeContext)

  if (!context) {
    throw new Error('useTheme must be used inside ThemeProvider')
  }

  return context
}
```

This gives better errors than letting components fail mysteriously.

### Step 4 — Wrap The App

In `main.jsx`:

```jsx
<ThemeProvider>
  <App />
</ThemeProvider>
```

Now every component below can use `useTheme`.

### Step 5 — Add Toggle Button

In `Header`:

```jsx
const { theme, toggleTheme } = useTheme()
```

Then render a button.

### Step 6 — Persist Theme

When theme changes, save it to `localStorage`.

When the app starts, read the saved theme.

### Step 7 — Add CSS Variables

Use a `data-theme` attribute or class to switch variable values.

This keeps styling centralized.

## Debug While Building

- Toggle theme and inspect the DOM attribute.
- Refresh the page and confirm theme remains.
- Inspect `localStorage`.
- Temporarily use `useTheme` outside provider and confirm the error is clear.
- Verify product components do not receive theme props.

## Done When

- Theme toggles light/dark.
- Theme survives refresh.
- Components read theme through `useTheme`.
- No prop drilling is needed for theme.
- You can explain Context vs Redux.

## Interview Explanation

> I used Context for theme because theme is app-wide UI state needed by distant components. A `ThemeProvider` owns the theme value and toggle function, and `useTheme` gives components safe access. I persist the selected theme in `localStorage` and use CSS variables so the visual system changes centrally instead of adding conditional styling everywhere.

## Reference

Read `React Learning/docs/12-context-api-and-theming.md` and `React Learning/docs/21-styling-and-the-theme-system.md`.
