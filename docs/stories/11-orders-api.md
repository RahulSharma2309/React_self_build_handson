# 11 — Orders API

## Goal

Submit checkout orders to the backend and show past orders.

This story teaches:

> A submit flow is a state machine around an async request.

## What You Are Building

- `ordersApi.js` for order requests.
- Real checkout submit using `POST`.
- Submit states: idle, submitting, success, error.
- Cart clearing after backend success.
- Orders page that fetches stored orders.

## Concepts You Must Understand First

### GET vs POST

GET reads data.

POST creates or submits data.

Checkout uses POST because it creates an order.

### Confirmed UI

For checkout, wait for backend success before clearing the cart.

Optimistic UI can be useful elsewhere, but checkout should be conservative.

### Submit State

Submit state tells the UI what is happening:

- idle: ready,
- submitting: request in progress,
- success: order accepted,
- error: request failed.

## Files You Will Touch

- `src/api/ordersApi.js`
  `createOrder` and `getOrders`.

- `src/pages/CheckoutPage.jsx`
  Real submit behavior.

- `src/pages/OrdersPage.jsx`
  Fetch and display orders.

- `src/App.jsx`
  Add orders route.

- `src/components/Header.jsx`
  Add orders navigation.

## Build Steps With Explanation

1. Create order API functions.
2. Replace checkout console logging with `createOrder(order)`.
3. Track submit state.
4. Disable submit while submitting.
5. Show success or error message.
6. Clear cart only after success.
7. Build `OrdersPage` with loading/error/empty/success states.
8. Add `/orders` route and navigation.

## Debug While Building

- Watch Network tab for POST `/api/orders`.
- Confirm request body shape.
- Stop backend and confirm error UI.
- Submit valid order and confirm order appears in `/orders`.
- Confirm cart clears only after success.

## Done When

- Checkout creates backend orders.
- Orders page shows created orders.
- Failed submit shows error.
- Submit button cannot double-submit.
- Cart clears only after confirmed success.

## Interview Explanation

> I created an order API module so components do not contain raw HTTP details. Checkout sends a POST request and tracks submit state. I clear the cart only after the backend confirms success because checkout should use confirmed UI. The orders page reuses the API layer to fetch submitted orders and handles loading, error, empty, and success states.

## Reference

Read `React Learning/docs/18-axios-and-the-data-layer.md` and `React Learning/docs/20-backend-gateway-and-microservices.md`.
