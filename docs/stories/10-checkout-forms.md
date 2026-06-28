# 10 — Checkout Forms

## Goal

Build a checkout page that collects customer details and prepares an order.

This story teaches:

> Forms turn user input into structured state.

Checkout combines local form state with global cart state.

## What You Are Building

- Checkout route.
- Customer form.
- Controlled inputs.
- Validation messages.
- Ref-based focus for invalid fields.
- Order object assembled from form + cart.

## Concepts You Must Understand First

### Controlled Inputs

React state owns the input value:

```jsx
value={name}
onChange={(event) => setName(event.target.value)}
```

### Form Submit

Forms trigger `onSubmit`. In React SPAs, you usually call:

```js
event.preventDefault()
```

so the browser does not reload the page.

### Validation

Validation checks whether data is good enough to submit.

In checkout:

- cart must contain items,
- name is required,
- email is required and plausible,
- address is required.

### Refs

Refs let React code access a DOM element directly.

Focusing the first invalid field is a good ref use case.

Do not use refs as a replacement for normal form state.

## Files You Will Touch

- `src/pages/CheckoutPage.jsx`
  Coordinates cart, form submit, validation, and order creation.

- `src/components/CustomerForm.jsx`
  Renders customer input fields.

- `src/App.jsx`
  Adds checkout route.

- `src/components/Header.jsx`
  Links to checkout.

## Build Steps With Explanation

1. Create checkout route.
2. Build controlled fields for name, email, and address.
3. Store field values in state.
4. Read cart items from Redux.
5. Derive subtotal from cart items.
6. Validate on submit.
7. Focus first invalid input with a ref.
8. Build an order object.
9. Log the order for now; Story 11 sends it to the backend.

## Debug While Building

- Type in each input and inspect state.
- Submit empty form and confirm errors.
- Add cart items and confirm checkout can read them.
- Submit valid form and inspect order object.
- Confirm the page does not reload.

## Done When

- Checkout route renders.
- Form fields are controlled.
- Validation errors are visible.
- Invalid field focus works.
- Order object combines customer data and cart data.

## Interview Explanation

> I built checkout with controlled inputs, so React state is the source of truth for form values. On submit, I prevent the browser reload, validate customer fields and cart contents, focus the first invalid field with a ref, and assemble an order object from local form state plus global cart state.

## Reference

Read `React Learning/docs/11-refs-and-the-dom.md` and `React Learning/docs/19-forms-the-checkout-deep-dive.md`.
