# 12 — Polish And Final App

## Goal

Turn the working rebuild into a finished learning app similar to `React Learning`.

## Concepts

- memoization
- `useMemo`
- `useCallback`
- `memo`
- error boundaries
- accessibility
- responsive CSS
- final refactoring

## Build Steps

1. Add `src/components/ErrorBoundary.jsx`.
   Wrap routes so render errors show a friendly fallback.

2. Add `memo` to `ProductCard` after confirming it receives stable props.

3. Use `useMemo` for expensive derived values:
   - filtered products
   - cart subtotal
   - category list

4. Use `useCallback` only where it helps keep memoized children stable.
   Do not wrap every function automatically.

5. Add an in-app learning page at `/learn`.
   Summarize the concepts you have built so far.

6. Improve CSS:
   - responsive product grid,
   - accessible focus states,
   - cart drawer animation,
   - readable light and dark themes.

7. Compare your folder structure with `React Learning/frontend/src`.
   Rename or move files until the responsibilities are clear.

8. Do a final browser walkthrough:
   - search catalog,
   - filter and sort,
   - open detail page,
   - add to cart,
   - checkout,
   - view orders,
   - toggle theme.

## Done When

- The app behaves like the finished `React Learning` app.
- You can explain every folder in `src`.
- You can trace data from backend to UI and from user action back to backend.
- You can add a new small feature without feeling lost.

## Reference

Read `React Learning/docs/13-performance-memo-usememo-usecallback.md`, `React Learning/docs/14-advanced-and-concurrent-hooks.md`, and `React Learning/docs/22-glossary-roadmap-and-next-steps.md`.
