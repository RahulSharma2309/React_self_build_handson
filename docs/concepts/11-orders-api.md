# 11 — Orders API Concepts

## Mental Model

Submitting an order is a full round trip.

The user fills a form, React builds an order object, the API layer sends it to the gateway, the orders service stores it, and React updates the UI based on the response.

This is no longer just rendering. It is a user workflow with backend confirmation.

## Important Files

### `src/api/ordersApi.js`

This file owns order network calls.

Components should call `createOrder` and `getOrders`, not write Axios calls inline.

This keeps transport details out of pages and makes the app language clearer.

### `src/pages/CheckoutPage.jsx`

This page changes from local form handling to real backend submission.

It needs submit states so the user understands what is happening.

Submit state also prevents double-submits.

### `src/pages/OrdersPage.jsx`

This page reads submitted orders from the backend.

It repeats the same async UI pattern you learned with products: loading, error, success, empty.

### `backend/Gateway.Api`

The gateway receives frontend requests and forwards them to the right service.

The frontend should know one API base URL, not every microservice URL.

## Submit Lifecycle

Typical checkout flow:

1. User submits form.
2. Validate locally.
3. Set status to `submitting`.
4. Send POST request.
5. If success, show confirmation and clear cart.
6. If failure, show error and keep cart.

Keeping cart on failure matters. The user should not lose their work because the network failed.

## Optimistic vs Confirmed UI

Optimistic UI updates before the backend confirms.

Confirmed UI waits for backend success.

For checkout, confirmed UI is safer. Orders involve money-like intent and should not pretend success before the server accepts the request.

## Orders Page State

Like products, orders need:

- loading,
- error,
- empty,
- success.

An empty order list is not an error. It is a valid successful state.

## Submit State

A submit flow usually has states:

- idle: nothing is happening.
- submitting: request in progress.
- success: backend accepted the order.
- error: request failed.

These states make the UI honest.

## What Each Move Teaches

Creating `ordersApi` teaches that each backend area gets named frontend functions.

Posting from checkout teaches async form submission.

Clearing the cart after success teaches sequencing: only clear after the backend confirms.

Building `OrdersPage` teaches data refresh and backend reads.

Using the gateway teaches frontend/backend boundaries.

## Mistakes To Watch For

- Do not clear the cart before the order succeeds.
- Do not leave the submit button enabled while submitting.
- Do not hide API errors.
- Do not duplicate order request code between checkout and orders pages.
- Do not allow multiple submits while a request is in progress.
- Do not clear cart on failed submit.
- Do not treat empty orders as a failed request.

## Senior-Level Thinking

Backend write flows need careful sequencing.

Ask:

- What happens if the request fails?
- Can the user double-click submit?
- Is the UI telling the truth?
- Which state should be cleared and when?
- Is request code centralized?

## Interview Explanation

> Submitting an order is a POST flow with explicit submit states. I validate first, set submitting state, call `createOrder`, then only after success show confirmation and clear the cart. If the request fails, I show an error and preserve cart state. The orders page uses `getOrders` and handles loading, error, empty, and success separately.

## Check Yourself

- What does `createOrder` send?
- What should happen while submit is in progress?
- Why does the frontend call the gateway?
- When should the cart be cleared?
