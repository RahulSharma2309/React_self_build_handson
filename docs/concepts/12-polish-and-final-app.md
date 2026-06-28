# 12 — Polish And Final App Concepts

## Mental Model

Polish is not decoration only.

At the end, you make the app easier to use, easier to maintain, and easier to explain. This is where you review performance, accessibility, folder structure, and the complete user flow.

## Important Files

### `src/components/ErrorBoundary.jsx`

An error boundary catches render errors and shows a fallback UI.

It does not replace normal error handling for network requests. It protects the React tree from crashing completely.

### `src/pages/LearnPage.jsx`

This page can become your in-app concept map.

It is useful because the app itself becomes a reminder of what you learned.

### `src/App.css` and `src/index.css`

These files become more important during polish.

Use `index.css` for global foundations and CSS variables. Use `App.css` for app layout and component-level styles if you are keeping this simple.

### `src/components/ProductCard.jsx`

This is a good place to learn `memo`, but only after you understand props and rendering.

## Performance Concepts

`memo` skips re-rendering a component when props did not change.

`useMemo` remembers a calculated value until dependencies change.

`useCallback` remembers a function reference until dependencies change.

These are tools, not default habits. Use them when they make rendering behavior clearer or prevent real repeated work.

## Accessibility Concepts

Good React is not only about components.

Buttons need clear labels. Forms need labels and visible errors. Focus states should be visible. Keyboard users should be able to navigate the app.

## What Each Move Teaches

Adding an error boundary teaches resilience.

Adding memoization teaches render performance and reference stability.

Adding `/learn` teaches documentation inside the product.

Improving CSS teaches responsive and accessible UI.

Doing a final walkthrough teaches thinking like a user, not only like a coder.

## Mistakes To Watch For

- Do not use `memo`, `useMemo`, and `useCallback` everywhere without reason.
- Do not confuse network errors with render errors.
- Do not polish one page and forget the full checkout flow.
- Do not leave folder names unclear after the project grows.

## Check Yourself

- Can you explain every folder in `src`?
- Can you trace Add to Cart from click to Redux to UI?
- Can you trace checkout from form submit to backend response?
- Can you explain why each major library was added?
