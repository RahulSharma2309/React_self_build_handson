# 09 — Redux Cart Concepts

## Mental Model

Redux is a shared state machine for the app.

The cart is used by far-apart components: product cards add items, the header shows count, the drawer edits quantities, and checkout reads totals. Passing all of that through props would become painful.

Redux is not needed because state exists. Redux is useful because this state is shared, business-oriented, and changed by many actions.

## Important Files

### `src/features/cart/cartSlice.js`

This file owns cart rules.

It defines the initial cart state and reducer functions that describe how the cart changes when actions happen.

Cart rules belong here so they do not get duplicated in `ProductCard`, `Header`, `CartDrawer`, and `CheckoutPage`.

### `src/app/store.js`

This creates the Redux store.

The store is the single place where global Redux state lives.

The state shape begins here. If the reducer key is `cart`, components read `state.cart`.

### `src/main.jsx`

Redux `Provider` wraps the app here so any component can use the store.

### `src/components/ProductCard.jsx`

This dispatches `addToCart`.

It should not manually edit cart arrays. It sends an action and lets the reducer decide how state changes.

This is the core Redux discipline: UI describes what happened; reducers decide how state changes.

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

## Context vs Redux For Cart

Could Context hold cart? Technically yes.

But Redux teaches a better pattern for complex shared business state:

- named actions,
- centralized reducers,
- devtools,
- selectors,
- predictable updates.

Theme has one or two simple actions. Cart has many rules.

## Derived Cart Values

Do not store everything.

Good stored state:

- cart items,
- quantities,
- drawer open/closed.

Good derived values:

- total count,
- subtotal,
- tax,
- grand total.

Derived totals should be calculated from items so they cannot drift out of sync.

## Reducer Thinking

A reducer should answer:

> Given current state and this action, what should next state be?

Examples:

- `addToCart`: if item exists, increase quantity; otherwise add it.
- `removeFromCart`: remove matching item.
- `clearCart`: reset items.
- `openCart`: set drawer state true.

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
- Do not dispatch vague actions like `updateStuff`.
- Do not put network calls inside reducers.

## Senior-Level Thinking

Redux is valuable when it creates a clear event log:

```text
cart/addToCart
cart/increaseQuantity
cart/clearCart
```

Those action names tell the story of user behavior.

The store should contain source-of-truth state, not every calculated value.

## Interview Explanation

> I chose Redux for cart because cart is shared business state touched by many unrelated components. Product cards dispatch actions, reducers centralize cart rules, selectors read state, and the provider makes the store available. I derive totals from cart items instead of storing duplicate totals.

## Check Yourself

- Why does cart need global state?
- What action fires when Add to Cart is clicked?
- Which reducer changes quantity?
- How does the header know the cart count changed?
