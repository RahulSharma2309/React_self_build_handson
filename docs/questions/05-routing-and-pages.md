# 05 — Routing And Pages Questions

Use these after completing Story 05.

## Questions

1. What is client-side routing?
2. How is a single-page app different from a traditional multi-page website?
3. Why is the URL considered state in a React app?
4. Why do we install `react-router-dom` instead of expecting routing from React itself?
5. What is the purpose of `BrowserRouter`?
6. Why should `BrowserRouter` wrap the app near the root?
7. What does `Routes` do?
8. What does a `Route` define?
9. What does the `/` route represent?
10. Why move catalog UI into `HomePage.jsx`?
11. What makes a component a page component?
12. Why create a `pages` folder instead of putting every component in `components`?
13. What does `/products/:slug` mean?
14. How does `useParams` read URL values?
15. Why use `slug` in the URL instead of product `id`?
16. What is the difference between `Link` and a normal `<a>` tag?
17. What would happen if you used `<a href="/products/...">` for internal navigation?
18. How would you handle an unknown product slug?
19. Why should `ProductCard` link to a detail page but not own route definitions?
20. How would you debug a route that renders nothing?
21. In an interview, how would you describe routing without a full page reload?
22. How does routing change the responsibility of `App.jsx`?
23. What should be tested after adding a route?
24. Why is browser refresh behavior important for routed pages?
25. How does this story prepare the app for checkout and orders pages?
