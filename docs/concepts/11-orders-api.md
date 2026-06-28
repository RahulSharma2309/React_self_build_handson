# 11 — Orders API Concepts

## Mental Model

Submitting an order is a full round trip.

The user fills a form, React builds an order object, the API layer sends it to the gateway, the orders service stores it, and React updates the UI based on the response.

## Important Files

### `src/api/ordersApi.js`

This file owns order network calls.

Components should call `createOrder` and `getOrders`, not write Axios calls inline.

### `src/pages/CheckoutPage.jsx`

This page changes from local form handling to real backend submission.

It needs submit states so the user understands what is happening.

### `src/pages/OrdersPage.jsx`

This page reads submitted orders from the backend.

It repeats the same async UI pattern you learned with products: loading, error, success, empty.

### `backend/Gateway.Api`

The gateway receives frontend requests and forwards them to the right service.

The frontend should know one API base URL, not every microservice URL.

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

## Check Yourself

- What does `createOrder` send?
- What should happen while submit is in progress?
- Why does the frontend call the gateway?
- When should the cart be cleared?
