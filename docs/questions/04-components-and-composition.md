# 04 — Components And Composition Questions

Use these after completing Story 04.

## Questions

1. What problem does extracting components solve?
2. What makes a good component boundary?
3. Why should `ProductFilters` render controls but not necessarily own all filter state?
4. What does “props down, events up” mean?
5. Why does the parent pass both values and callbacks to a child component?
6. What is the difference between a presentational component and a stateful component?
7. Why should `ProductCard` stay focused on one product?
8. What should `Header` know about the product catalog at this stage?
9. Why is `Footer` a separate component even if it is small?
10. How does composition make `App.jsx` easier to read?
11. What is prop drilling?
12. Is prop drilling always bad?
13. When is it too early to extract a component?
14. How would you decide whether a button deserves its own component?
15. What happens if a child component tries to change parent state directly?
16. Why do callback prop names often start with `on`, like `onSearchChange`?
17. How would you debug a child component that receives `undefined` props?
18. How can React DevTools help inspect component props?
19. In an interview, how would you explain the difference between components and HTML elements?
20. Why is composition preferred over one very large component?
21. What code smell tells you `App.jsx` is doing too much?
22. How do imports reveal the dependency direction between components?
23. How would adding a second page later affect your component boundaries?
24. What should remain in `App.jsx` after extraction?
25. How does this story prepare you for hooks and routing?
26. What is the difference between extracting by size and extracting by responsibility?
27. What props should `ProductFilters` receive in this story?
28. What callbacks should `ProductFilters` receive?
29. Why does moving JSX not automatically mean moving state?
30. What is the closest common owner rule for state?
31. How would you debug a callback prop that is not firing?
32. How would you debug a child component receiving the wrong value?
33. Why should layout components avoid catalog-specific logic?
34. What is a component contract?
35. What are signs you extracted too many components?
36. What are signs you did not extract enough?
37. How does React DevTools help after component extraction?
38. How would you explain props down/events up in an interview?
39. Why is one-way data flow easier to debug?
40. How does this story make custom hooks easier to understand later?
