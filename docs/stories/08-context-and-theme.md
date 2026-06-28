# 08 — Context And Theme

## Goal

Add light and dark theme switching without passing theme props everywhere.

## Concepts

- Context
- provider components
- custom context hooks
- `localStorage`
- CSS variables

## Build Steps

1. Create `src/contexts/themeContext.js`.
   Export a React context object.

2. Create `src/contexts/ThemeContext.jsx`.
   Add `ThemeProvider` with state for `theme` and a `toggleTheme` function.

3. Create `src/hooks/useTheme.js`.
   Read the context and throw a clear error if it is used outside the provider.

4. Wrap the app with `ThemeProvider` in `src/main.jsx`.

5. Add a theme toggle button to `Header`.

6. Store the selected theme in `localStorage`.

7. Move colors into CSS variables in `src/index.css`.
   Change variables based on a `data-theme` attribute.

## Done When

- The whole app switches between light and dark.
- The selected theme survives a browser refresh.
- No product or page component receives theme props.
- You can explain when Context is better than prop drilling.

## Reference

Read `React Learning/docs/12-context-api-and-theming.md` and `React Learning/docs/21-styling-and-the-theme-system.md`.
