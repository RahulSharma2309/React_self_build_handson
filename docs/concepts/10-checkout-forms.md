# 10 — Checkout Forms Concepts

## Mental Model

Forms are user input turned into state.

In React, controlled inputs make form values explicit: the input shows the value from state, and every change updates state.

Checkout is also where multiple state sources meet:

- local form state,
- Redux cart state,
- derived totals,
- validation state,
- later backend submit state.

## Important Files

### `src/pages/CheckoutPage.jsx`

This page coordinates checkout.

It reads cart data, owns submit status, and decides what happens when the user submits.

Pages are good workflow owners. Checkout is a workflow, not just a form component.

### `src/components/CustomerForm.jsx`

This component renders form fields.

It should receive current values, change handlers, and submit behavior from the page or manage a clearly defined form state.

Keep it focused on form UI. Do not make it know Redux cart rules.

### `src/features/cart/cartSlice.js`

Checkout reads cart items and totals from Redux.

After a successful order in the next story, checkout will clear the cart.

## Controlled Inputs

A controlled input has two important pieces:

- `value` comes from React state.
- `onChange` updates React state.

This makes the form predictable. React always knows what the user has typed.

## Validation Thinking

Validation should answer:

- Is required data present?
- Is the format acceptable?
- Is the action allowed with current app state?

For checkout, an empty cart should block submit even if customer fields are valid.

Validation messages should be visible to the user, not hidden in the console.

## Refs In Forms

Refs are for reaching a DOM node when React state is not the right tool.

Focusing the first invalid input is a good ref use case. You are not storing business data; you are asking the browser to focus an element.

Refs are escape hatches for imperative DOM actions. Use them sparingly.

Good ref use:

- focus an input,
- measure an element,
- control media playback.

Bad ref use:

- store form values that should be in React state.

## What Each Move Teaches

Creating a checkout page teaches route-level workflow.

Building controlled fields teaches stateful user input.

Validating on submit teaches guarding business actions.

Using refs teaches direct DOM access for focused, practical cases.

Creating an order object teaches shaping frontend data for the backend.

## Order Object Design

The order object should be shaped intentionally:

- customer from form state,
- items from Redux cart,
- total derived from cart items.

Do not trust display-only text as source data. Use numeric prices and quantities.

## Mistakes To Watch For

- Do not read form values with random DOM queries.
- Do not submit if the cart is empty.
- Do not hide validation errors only in the console.
- Do not use refs for normal form data that belongs in state.
- Do not clear the cart in Story 10; the backend has not confirmed anything yet.
- Do not submit if validation fails.

## Senior-Level Thinking

Forms are where many bugs hide:

- stale input values,
- unclear validation,
- inaccessible errors,
- accidental page reloads,
- data shape mismatch with backend.

Experienced developers make form state explicit and submit flows traceable.

## Interview Explanation

> Checkout uses local state for form values and Redux for cart data. Inputs are controlled, so React always knows the current customer fields. On submit, I prevent the default reload, validate both form and cart, use refs only for focusing invalid inputs, and create an order object from reliable source data.

## Check Yourself

- What makes an input controlled?
- Which values belong to form state?
- Why does checkout need cart state?
- When is a ref useful here?
