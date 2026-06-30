# 02 — Data, JSX, Props, And Lists Interview Questions

Use these to prepare for generic questions about rendering UI from data.

## Data And Modules

1. Why is it useful to keep sample data separate from JSX?
2. When should plain JavaScript data live outside a React component?
3. What does a named export such as `export const items = [...]` do?
4. What happens if data is declared in a module but never exported?
5. What is the difference between a named export and a default export?
6. Why do named imports use braces?
7. Why should numeric values usually be stored as numbers instead of formatted strings?
8. Why does list data usually need a stable unique identifier?
9. What is a URL-friendly identifier, and when might it be useful?
10. Scenario: a card needs status, rating, and date fields. Where would you add that data and why?

## Components And Props

11. What is the responsibility of a reusable item-card component?
12. What are props in React?
13. What does destructuring props in a function parameter mean?
14. Why should a reusable card receive one item through props instead of importing an entire list?
15. Why should props be treated as read-only?
16. What does placing a JavaScript expression inside `{}` in JSX mean?
17. What is the difference between static JSX text and data-driven JSX?
18. When is a semantic element like `<article>` useful?
19. How should you decide whether an image is decorative or needs meaningful alt text?
20. How would you format a numeric value for display without changing the source data?

## Lists And Keys

21. How does a parent component turn an array of data into rendered UI?
22. What does `.map(...)` return when used to render React elements?
23. How does an array of plain objects become an array of React elements?
24. Why does React ask for a `key` when rendering lists?
25. Why is a stable ID usually better than an array index as a key?
26. What bugs can index keys cause when items are inserted, removed, or reordered?
27. Scenario: the title of an item changes in the data source. What should happen in the UI?
28. Scenario: a new field must appear on every card. Which files or concepts would be involved?
29. Why should an item-card component not need to know how many total items exist?
30. How does the rendering pattern change when the data later comes from an API?

## Debugging And Interview Practice

31. How would you debug whether a parent component imported data correctly?
32. How would you debug whether a child component received the expected prop?
33. How can React DevTools help inspect props and component trees?
34. What is the main React concept behind rendering repeated UI from an array?
35. How would you explain dependency direction between a data module, parent component, and child component?
36. Why is separation of data and UI useful?
37. Why is component reuse valuable even when the first list is small?
38. Scenario: a list renders but every card shows `undefined`. What would you check?
39. How would you explain data-driven rendering in an interview?
40. What later features become easier when the data-to-card structure is clean?
