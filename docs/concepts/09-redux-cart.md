# 09 — Redux Cart Concepts

## Mental Model

Redux is a shared state machine for the app.

The cart is used by far-apart components: product cards add items, the header shows count, the drawer edits quantities, and checkout reads totals. Passing all of that through props would become painful.

## Important Files

### `src/features/cart/cartSlice.js`

This file owns cart rules.

It defines the initial cart state and reducer functions that describe how the cart changes when actions happen.

### `src/app/store.js`

This creates the Redux store.

The store is the single place where global Redux state lives.

### `src/main.jsx`

Redux `Provider` wraps the app here so any component can use the store.

### `src/components/ProductCard.jsx`

This dispatches `addToCart`.

It should not manually edit cart arrays. It sends an action and lets the reducer decide how state changes.

### `src/components/CartDrawer.jsx`

This reads cart state with selectors and dispatches cart actions.

## Redux Vocabulary

- Store: the global state container.
- State: the current data.
- Action: a description of what happened.
- Reducer: a function that calculates the next state.
- Dispatch: sending an action.
- Selector: reading a specific value from state.
- Slice: Redux Toolkit's way to group state, reducers, and generated actions for one feature.

## What Each Move Teaches

Creating a slice teaches centralizing business rules.

Creating a store teaches global state setup.

Wrapping `Provider` teaches app-level state access.

Dispatching from `ProductCard` teaches that UI triggers actions, not direct mutations.

Reading from `Header` and `CartDrawer` teaches that distant components can share the same source of truth.

## Mistakes To Watch For

- Do not keep separate cart state in multiple components.
- Do not mutate Redux state outside reducers.
- Do not put every piece of state in Redux. Local UI state can stay local.
- Do not calculate cart totals in many places differently; centralize or derive consistently.

## Check Yourself

- Why does cart need global state?
- What action fires when Add to Cart is clicked?
- Which reducer changes quantity?
- How does the header know the cart count changed?
