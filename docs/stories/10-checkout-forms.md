# 10 — Checkout Forms

## Goal

Build a checkout page that collects customer details and prepares an order.

## Concepts

- controlled inputs
- form submit
- validation
- refs
- derived totals
- route navigation

## Build Steps

1. Create `src/pages/CheckoutPage.jsx`.

2. Add a route for `/checkout` in `src/App.jsx`.

3. Create `src/components/CustomerForm.jsx`.
   Include fields for:
   - name
   - email
   - address

4. Keep each field controlled with React state.

5. Read cart items and subtotal from Redux in `CheckoutPage`.

6. On submit, validate that the cart has items and required fields are filled.

7. Use a ref to focus the first invalid field.

8. For now, log the order object to the console.
   The next story sends it to the backend.

## Done When

- `/checkout` renders a form.
- Form inputs update React state.
- Empty required fields produce a visible message.
- Submitting with cart items creates a clear order object.

## Reference

Read `React Learning/docs/11-refs-and-the-dom.md` and `React Learning/docs/19-forms-the-checkout-deep-dive.md`.
