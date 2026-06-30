# 11 — API Submit Flow Interview Questions

Use these to prepare for generic interviews about POST requests and async submit workflows.

## HTTP And API Boundaries

1. What is the difference between a GET request and a POST request?
2. When should a form submit use POST?
3. Why should API request code live in a dedicated API module?
4. What should a create function return after a successful POST?
5. What should a list/read function return after a successful GET?
6. Why should components avoid writing raw HTTP calls everywhere?
7. What does a gateway or backend-for-frontend hide from the client?
8. Why should the frontend avoid knowing every internal backend service?
9. How would you inspect a POST request body in the browser?
10. Scenario: an API works in a REST client but fails in the browser. What would you compare?

## Submit Lifecycle

11. What are the common states in a submit lifecycle?
12. What is submit loading state?
13. Why should a submit button be disabled while submitting?
14. What should happen if the create request fails?
15. What should a success UI show after a create request?
16. Why should API errors be converted into user-readable messages?
17. Scenario: a user double-clicks submit and creates duplicates. How would you prevent it?
18. Scenario: the backend returns a 400 validation error. How would you surface it?
19. Scenario: the network fails mid-submit. What state should the UI preserve?
20. How would you confirm that submitted data was actually stored?

## Optimistic vs Confirmed UI

21. What is optimistic UI?
22. What is confirmed UI?
23. When is optimistic UI appropriate?
24. When is confirmed UI safer?
25. What could go wrong if important local state is cleared before the server confirms success?
26. Why might payment, checkout, or account-change workflows prefer confirmed UI?
27. Why is an empty results list not the same as a failed request?
28. Why should a read page handle loading, error, empty, and success states separately?
29. How does a submit flow complete the frontend-to-backend loop?
30. How would you explain confirmed UI in an interview?

## Interview Practice

31. Explain the full flow from form submit to backend success UI.
32. Explain how you would centralize API request code.
33. Explain how you would prevent duplicate submissions.
34. Explain how you would debug a failed POST request.
35. Explain how you would design user feedback for a slow submit request.
