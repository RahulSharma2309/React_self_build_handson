# 05 — Routing And Pages Interview Questions

Use these to prepare for generic React Router and page-architecture interviews.

## Routing Concepts

1. What is client-side routing?
2. How is a single-page app different from a traditional multi-page website?
3. Why can the URL be considered application state?
4. Why is routing usually provided by a library instead of React core?
5. What is the purpose of a router provider such as `BrowserRouter`?
6. Why should a router provider wrap the app near the root?
7. What does a route configuration define?
8. What does a route path represent?
9. What is the difference between an index/home route and a nested/detail route?
10. How does routing change the responsibility of a top-level app component?

## Pages And URL Params

11. What makes a component a page component?
12. Why separate page components from reusable UI components?
13. What does a path like `/items/:id` or `/users/:username` mean?
14. How does a component read a dynamic URL parameter?
15. When would you use a slug instead of a numeric ID in a URL?
16. Why should route-level data lookup usually happen in a page component?
17. What is the difference between “no route matched” and “route matched but data was not found”?
18. How should a UI handle an unknown detail-page parameter?
19. What behavior should still work with browser back and forward buttons?
20. Why is browser refresh behavior important for routed pages?

## Navigation

21. What is the difference between a router `Link` and a normal `<a>` tag?
22. What happens if a normal anchor is used for internal SPA navigation?
23. When is a normal anchor still the correct choice?
24. What happens if a router link is rendered outside the router provider?
25. Scenario: clicking a link changes the URL but the wrong page renders. What would you inspect?
26. Scenario: a detail page always shows not-found. What would you debug?
27. Scenario: refreshing a deep link fails in production. What server-side configuration might be missing?
28. Why should URL structures be treated as public contracts?
29. What is the risk of changing route paths after users have bookmarks or shared links?
30. How would you design routes for a dashboard with list, detail, create, and edit screens?

## Interview Practice

31. How would you explain routing without a full page reload?
32. How would you explain router provider, route matching, links, and params together?
33. How would you decide whether a component belongs in `pages` or `components`?
34. How would you handle protected routes at a high level?
35. How would routing prepare an app for separate workflows like checkout, settings, or admin pages?
