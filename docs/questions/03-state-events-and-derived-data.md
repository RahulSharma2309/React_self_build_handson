# 03 — State, Events, And Derived Data Questions

Use these after completing Story 03.

## Questions

1. What is state in React?
2. Why does search text belong in state?
3. What is the difference between state and a normal variable inside a component?
4. What does `useState` return?
5. Why do we call a setter function instead of assigning to state directly?
6. What is an event handler?
7. What information does `event.target.value` give you in an input change?
8. What is a controlled input?
9. Why should the input `value` come from state?
10. What would happen if you added `onChange` but forgot `value`?
11. What is derived data?
12. Why should `visibleProducts` usually be calculated instead of stored in state?
13. Why should you copy an array before sorting it?
14. What is the difference between `filter` and `map`?
15. Why is `includes` useful for search?
16. How would you make search case-insensitive?
17. What should the UI show when no products match?
18. Which part of the app owns the search, category, and sort state in this story?
19. What bug might happen if you mutate `fallbackProducts` directly?
20. How would you debug a filter that is not changing the visible list?
21. In an interview, how would you explain “UI is a function of state” using this story?
22. Why is it useful to calculate values before the JSX return?
23. How would you add a new sort option without changing `ProductCard`?
24. What is the difference between user input state and product data?
25. When should state stay local to a component?
26. Which files changed in Story 03?
27. Why did `ProductCard.jsx` not need to change for filtering and sorting?
28. What does `searchTerm.trim().toLowerCase()` protect against?
29. Why does `categories` use `new Set(...)`?
30. What does `selectedCategory === 'All' || product.category === selectedCategory` mean?
31. Why does `visibleProducts` render instead of `fallbackProducts`?
32. What happens after `setSearchTerm(event.target.value)` runs?
33. Why is the no-results message part of good UI state handling?
34. How would you prove that sorting did not change the original data file?
35. In this exact implementation, which values are stored and which values are recalculated?
