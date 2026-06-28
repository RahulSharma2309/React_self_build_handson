# 11 — Orders API

## Goal

Submit orders to the backend and show past orders.

## Concepts

- POST requests
- async submit state
- optimistic vs confirmed UI
- clearing global state after success
- reusing API modules

## Build Steps

1. Create `src/api/ordersApi.js`.
   Add functions:
   - `createOrder(order)`
   - `getOrders()`

2. Update `CheckoutPage`.
   On submit, call `createOrder(order)` instead of only logging.

3. Add submit states:
   - idle
   - submitting
   - success
   - error

4. After a successful order:
   - show the order number,
   - clear the cart,
   - keep the page stable so the learner can inspect the result.

5. Create `src/pages/OrdersPage.jsx`.
   Fetch orders from the backend with `getOrders()`.

6. Add a route for `/orders`.

7. Add links to checkout and orders in `Header`.

## Done When

- Submitting checkout creates an order in `Orders.Api`.
- The orders page shows submitted orders.
- Failed requests show a useful error message.
- You can explain the path from form submit to gateway to orders service.

## Reference

Read `React Learning/docs/18-axios-and-the-data-layer.md` and `React Learning/docs/20-backend-gateway-and-microservices.md`.
