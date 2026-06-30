# 04 — Components And Composition Interview Questions

Use these to prepare for generic component design and composition interviews.

## Component Boundaries

1. What problem does extracting components solve?
2. What makes a good component boundary?
3. What is the difference between extracting by file size and extracting by responsibility?
4. Scenario: a page has search controls, a table, and a footer. How would you decide what to extract?
5. When is it too early to extract a component?
6. What signs suggest a component is doing too much?
7. What signs suggest you extracted too many components?
8. What is a component contract?
9. Why should reusable components avoid knowing too much about a specific page?
10. Why is composition preferred over one very large component?

## Props And State Ownership

11. What does “props down, events up” mean?
12. Why does a parent often pass both values and callbacks to a child component?
13. What is the difference between a presentational component and a stateful component?
14. Why does moving JSX into a child component not automatically mean moving state?
15. What is the closest common owner rule for state?
16. What happens if a child component tries to mutate parent state directly?
17. Why do callback prop names often start with `on`?
18. Scenario: a child component receives `undefined` props. How would you debug it?
19. Scenario: a callback prop is not firing. What would you inspect?
20. How can React DevTools help inspect component props?

## Layout And Composition

21. What should a generic header component know about page-specific data?
22. Why might a footer or shell component be useful even if it is small?
23. How does composition make a page component easier to read?
24. What should remain in a page component after extracting reusable UI?
25. How do imports reveal dependency direction between components?
26. Why should layout components avoid domain-specific logic?
27. How does adding more pages affect component boundaries?
28. What is prop drilling?
29. Is prop drilling always bad? Explain with an example.
30. When would Context or a custom hook become more appropriate than passing props?

## Interview Practice

31. How would you explain the difference between a React component and an HTML element?
32. Explain props down/events up with a generic form-controls example.
33. Explain how one-way data flow improves debugging.
34. Scenario: a child component needs to notify a parent about user input. How would you design the props?
35. Scenario: several pages share the same layout. How would you structure components?
36. Scenario: a reusable component now has too many props. What options do you have?
37. Scenario: a component is hard to test. What design problems might be causing it?
38. How does component composition prepare an app for routing?
39. How does component extraction prepare logic for custom hooks later?
40. How would you describe good component design in an interview?
