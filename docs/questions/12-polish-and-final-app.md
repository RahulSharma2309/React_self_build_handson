# 12 — React Polish, Performance, And Architecture Interview Questions

Use these to prepare for generic final-round React architecture and production-readiness interviews.

## Reliability And Error Handling

1. What does “polish” mean beyond visual styling?
2. What is an error boundary?
3. What kind of errors can an error boundary catch?
4. What kind of errors should still be handled with normal async error state?
5. Why do error boundaries not replace loading/error request state?
6. What is the difference between a render error and an API error?
7. Scenario: one widget crashes during render. What should the user experience be?
8. Scenario: a request fails but the component renders correctly. Where should the error be handled?
9. What bugs would you look for before calling a React screen complete?
10. What tests would be most valuable before release?

## Performance

11. What does `memo` do?
12. When is `memo` not useful?
13. What does `useMemo` remember?
14. What does `useCallback` remember?
15. What is referential stability?
16. Why should `useMemo` and `useCallback` not be added everywhere automatically?
17. What question should you ask before using `memo`?
18. When can `useCallback` make code harder without helping performance?
19. What kinds of derived values may be good candidates for memoization?
20. How would you measure whether a component re-renders too often?

## Accessibility And UX

21. Why is accessibility part of final polish?
22. Why do visible focus states matter?
23. How would you test keyboard accessibility?
24. What should happen when a form has validation errors?
25. How should modals, drawers, or overlays behave for keyboard users?
26. Why is responsive design important for list and dashboard screens?
27. Scenario: a button has only an icon. What accessibility concern appears?
28. Scenario: an error appears visually but is not announced or associated with a field. What would you improve?
29. What does good empty-state UX include?
30. What does good loading-state UX include?

## Architecture Review

31. What belongs in an API/services folder?
32. What belongs in a reusable components folder?
33. What belongs in a pages/routes folder?
34. What belongs in a hooks folder?
35. What belongs in a feature-state folder?
36. What belongs in a utilities folder?
37. How would you review whether a folder structure is clear?
38. What would you refactor only after seeing repeated patterns?
39. What feature would you add next to prove you understand an app's architecture?
40. How would you explain a complete React app architecture in an interview?
