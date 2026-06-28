# 06 — Backend Data And Effects Questions

Use these after completing Story 06.

## Questions

1. What is a side effect in React?
2. Why is fetching data considered a side effect?
3. Why should a network request not run directly inside the component body?
4. What does `useEffect` do?
5. When does an effect with an empty dependency array run?
6. What can go wrong if an effect dependency array is incorrect?
7. Why do we need loading state?
8. Why do we need error state?
9. What should the UI show before the product request finishes?
10. What should the UI show if the request fails?
11. Why create an `api` folder?
12. What is the purpose of `http.js`?
13. Why centralize the API base URL?
14. What is Axios doing for us?
15. Why should components call `getProducts()` instead of `axios.get(...)` directly?
16. What is the gateway API's job?
17. Why should the React app call the gateway instead of every microservice directly?
18. What is fallback data, and why is it helpful for learning?
19. How would you debug whether products came from the backend or fallback data?
20. How would you debug a CORS error?
21. In an interview, how would you explain the lifecycle of fetching products?
22. Why should async errors become user-friendly messages?
23. What is the difference between backend state and React state?
24. How does this story change the meaning of `fallbackProducts`?
25. How would you test the app with the backend turned off?
