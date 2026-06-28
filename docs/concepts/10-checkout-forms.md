# 10 — Checkout Forms Concepts

## Mental Model

Forms are user input turned into state.

In React, controlled inputs make form values explicit: the input shows the value from state, and every change updates state.

## Important Files

### `src/pages/CheckoutPage.jsx`

This page coordinates checkout.

It reads cart data, owns submit status, and decides what happens when the user submits.

### `src/components/CustomerForm.jsx`

This component renders form fields.

It should receive current values, change handlers, and submit behavior from the page or manage a clearly defined form state.

### `src/features/cart/cartSlice.js`

Checkout reads cart items and totals from Redux.

After a successful order in the next story, checkout will clear the cart.

## Controlled Inputs

A controlled input has two important pieces:

- `value` comes from React state.
- `onChange` updates React state.

This makes the form predictable. React always knows what the user has typed.

## Refs In Forms

Refs are for reaching a DOM node when React state is not the right tool.

Focusing the first invalid input is a good ref use case. You are not storing business data; you are asking the browser to focus an element.

## What Each Move Teaches

Creating a checkout page teaches route-level workflow.

Building controlled fields teaches stateful user input.

Validating on submit teaches guarding business actions.

Using refs teaches direct DOM access for focused, practical cases.

Creating an order object teaches shaping frontend data for the backend.

## Mistakes To Watch For

- Do not read form values with random DOM queries.
- Do not submit if the cart is empty.
- Do not hide validation errors only in the console.
- Do not use refs for normal form data that belongs in state.

## Check Yourself

- What makes an input controlled?
- Which values belong to form state?
- Why does checkout need cart state?
- When is a ref useful here?
