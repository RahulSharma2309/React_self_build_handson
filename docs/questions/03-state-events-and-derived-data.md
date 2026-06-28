# 03 — State, Events, And Derived Data Questions

Use these after completing Story 03.

## Core Understanding

1. What does “UI is a function of state” mean in this catalog?
2. What is state in React, in your own words?
3. Why does `searchTerm` belong in state?
4. Why does `selectedCategory` belong in state?
5. Why does `sortBy` belong in state?
6. Why does `visibleProducts` not belong in state?
7. What is the difference between source data, state, and derived data?
8. What bug can happen when you store duplicate derived data in state?
9. Why is `ProductCard.jsx` unchanged in this story?
10. Which component owns the filter behavior right now, and why?

## `useState`

11. What does `useState('')` return?
12. What is the purpose of a setter function like `setSearchTerm`?
13. Why should you not write `searchTerm = 'robot'` directly?
14. What happens after a setter function is called?
15. Why does React not guarantee that state looks changed on the very next line after a setter call?
16. When is `useState` a good fit?
17. When is `useState` the wrong tool?

## Events And Controlled Inputs

18. What is an event handler?
19. What does `onChange` mean for an input?
20. What does `event.target.value` contain?
21. What makes an input controlled?
22. Why does the search input need both `value` and `onChange`?
23. What happens if you provide `value` but forget `onChange`?
24. How is a controlled `<select>` similar to a controlled `<input>`?
25. How would you debug an input that does not update while typing?

## Derived Values And JavaScript Methods

26. Why do we calculate `categories` from `fallbackProducts`?
27. Why does `categories` use `new Set(...)`?
28. What does the spread operator `...` do in the categories line?
29. Why do we normalize search text with `trim().toLowerCase()`?
30. What does `includes` check?
31. What is the difference between `map` and `filter`?
32. Why does the filter condition use `matchesSearch && matchesCategory`?
33. What does `selectedCategory === 'All' || product.category === selectedCategory` mean?
34. How does `sortBy === 'price-low'` change the sort result?
35. Why can `sort` be dangerous if you call it directly on original data?
36. Why is sorting safe in this implementation after `filter`?

## Render And Debugging

37. Walk through what happens after the user types `r` in the search input.
38. Why does React re-render `App` after state changes?
39. What values are recalculated on every render?
40. How would you prove `visibleProducts` is recalculated from current state?
41. How would you debug a product that should appear but does not?
42. How would React DevTools help you inspect this story?
43. What should the UI show when no products match?
44. Why is an empty state better than a blank product grid?

## Interview Practice

45. Explain controlled inputs to an interviewer using this story.
46. Explain derived state to an interviewer using this story.
47. Explain why storing only user choices is better than storing filtered products.
48. Explain how you would add a new sort option.
49. Explain how you would move this logic into a custom hook later.
50. Explain this entire Story 03 implementation in two minutes.
