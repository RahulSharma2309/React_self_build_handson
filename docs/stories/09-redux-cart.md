# 09 — Redux Cart

## Goal

Build a cart drawer that can be read and updated from different parts of the app.

This story teaches:

> Use global state when many distant components need the same business state.

The cart is not just a local UI detail. Product cards add items, the header shows count, the drawer edits quantities, and checkout reads totals.

## What You Are Building

- Redux store.
- Cart slice.
- Cart actions and reducers.
- Redux provider.
- Add-to-cart behavior.
- Cart drawer.
- Header cart count.

## Concepts You Must Understand First

### Global State

Global state is state that many parts of the app need.

Cart state is global because it is used across unrelated components.

### Redux Toolkit

Redux Toolkit is the modern official Redux approach. It reduces boilerplate and gives good defaults.

### Slice

A slice groups:

- initial state,
- reducers,
- generated actions,
- one feature's state logic.

### Action

An action describes what happened:

```js
addToCart(product)
```

### Reducer

A reducer decides how state changes for an action.

### Selector

A selector reads a specific value from the store.

## Build Steps With Explanation

1. Install `@reduxjs/toolkit` and `react-redux`.
2. Create `features/cart/cartSlice.js`.
3. Define initial state: `items` and `isCartOpen`.
4. Add reducers for add/remove/increase/decrease/open/close/clear.
5. Create `app/store.js` with `configureStore`.
6. Wrap the app in Redux `Provider`.
7. Dispatch cart actions from product UI.
8. Read cart state with `useSelector`.

## Debug While Building

Trace one click:

```text
Add button -> dispatch action -> reducer updates store -> subscribed components re-render
```

Use Redux DevTools if available. If not, log reducer inputs during learning.

## Done When

- Product cards can add items.
- Header count updates.
- Cart drawer opens/closes.
- Quantities update.
- Totals derive from items.
- Checkout can read cart state later.

## Interview Explanation

> I used Redux for cart because the cart is shared business state used by distant components. Redux Toolkit creates a slice with reducer logic and action creators. Components dispatch actions to describe what happened, reducers update the store, and components use selectors to read updated state. This avoids prop drilling and keeps cart rules centralized.

## Reference

Read `React Learning/docs/17-redux-toolkit-state-management.md`, then compare with `React Learning/frontend/src/features/cart/cartSlice.js`.
