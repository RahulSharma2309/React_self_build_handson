# 06 — Effects, API Calls, And Async UI Interview Questions

Use these to prepare for generic interviews about side effects and data fetching.

## Effects

1. What is a side effect in React?
2. Why is fetching data considered a side effect?
3. What does it mean for render to be pure?
4. Why should a network request not run directly inside a component body?
5. What does `useEffect` do?
6. When does an effect with an empty dependency array run?
7. What does it mean when an effect depends on a route parameter or prop?
8. What can go wrong if an effect dependency array is incorrect?
9. Scenario: an API request fires infinitely. What would you inspect?
10. Scenario: a screen shows stale data after a parameter changes. What would you check?

## Async UI State

11. Why do async screens need loading state?
12. Why do async screens need error state?
13. Why are loading, error, and data separate state concerns?
14. Why is an empty array not the same thing as loading?
15. What should the UI show before a request finishes?
16. What should the UI show if a request fails?
17. What should the UI show when a request succeeds with no rows?
18. Why should async errors be converted into user-readable messages?
19. Scenario: the browser console shows an error but the UI is blank. What is missing?
20. How would you test a screen with the backend turned off?

## API Layer

21. Why create a dedicated API or services folder in a frontend app?
22. What responsibilities belong in a shared HTTP client module?
23. What responsibilities belong in feature-specific API modules?
24. Why centralize a base URL and timeout configuration?
25. What does an HTTP client library like Axios provide over raw request code?
26. Why should components call named API functions instead of inline URLs?
27. How does an API layer improve readability and testability?
28. What is the purpose of a backend-for-frontend or gateway API?
29. Why should a frontend avoid knowing every internal backend service URL?
30. How would you explain frontend/backend boundaries in an interview?

## Debugging And Scenarios

31. How would you debug whether data came from a network response or fallback data?
32. How would you debug a CORS error?
33. How would you inspect request and response payloads in the browser?
34. Scenario: a request succeeds in Postman but fails in the browser. What might be different?
35. Scenario: a request is slow. What UI states should protect the user experience?
36. Scenario: a response shape changes. Which layer should ideally absorb the change?
37. How would you explain the lifecycle of fetching data in a React screen?
38. How would you prevent duplicate fetch logic across multiple pages?
39. When might a custom hook be a better home for fetching behavior?
40. What are the risks of hiding all request failures behind silent fallback data?
