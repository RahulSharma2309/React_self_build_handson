# 11 — Orders API Questions

Use these after completing Story 11.

## Questions

1. What is the difference between a GET request and a POST request?
2. Why does checkout use POST?
3. Why should order API code live in `src/api/ordersApi.js`?
4. What should `createOrder(order)` return?
5. What should `getOrders()` return?
6. Why should components not write raw Axios calls everywhere?
7. What is submit loading state?
8. Why should the submit button be disabled while submitting?
9. What should happen if order creation fails?
10. Why should the cart be cleared only after backend success?
11. What could go wrong if the cart is cleared before the response returns?
12. What should the success UI show after an order is placed?
13. Why does `OrdersPage` need loading, error, empty, and success states?
14. How does the gateway route an order request?
15. Why does the frontend not call `Orders.Api` directly?
16. What is the shape of the order object sent to the backend?
17. What is the shape of an order returned from the backend?
18. How would you debug a 400 error from order creation?
19. How would you debug a gateway connection failure?
20. How would you confirm the order was stored?
21. In an interview, how would you explain the full order submission flow?
22. What is the difference between optimistic UI and confirmed UI?
23. Which approach is safer for checkout: optimistic or confirmed? Why?
24. Why should API errors be converted into user-readable messages?
25. How does this story complete the frontend-to-backend loop?
