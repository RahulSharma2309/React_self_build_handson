# 03 — State, Events, And Derived Data Interview Questions

Use these to prepare for generic questions about interactive UI state.

## Core Understanding

1. What does “UI is a function of state” mean in a React application?
2. What is state in React, in your own words?
3. Scenario: a user types in a search box. Why does that text usually belong in state?
4. Scenario: a user chooses a category from a dropdown. Why does that selected value usually belong in state?
5. Scenario: a user chooses a sort option. Why does that option usually belong in state?
6. Why should a filtered list usually be derived instead of stored separately in state?
7. What is the difference between source data, user state, and derived data?
8. What bug can happen when duplicate derived data is stored in state?
9. Why should an item-display component usually not know about filtering or sorting logic?
10. Where should filter behavior live when one parent needs it to decide what to render?

## `useState`

11. What does `useState(initialValue)` return?
12. What is the purpose of a state setter function?
13. Why should state not be reassigned directly like a normal variable?
14. What happens after a setter function is called?
15. Why is React state not guaranteed to look updated on the next line after calling a setter?
16. When is `useState` a good fit?
17. When is `useState` the wrong tool?

## Events And Controlled Inputs

18. What is an event handler?
19. What does `onChange` mean for a text input?
20. What does `event.target.value` usually contain?
21. What makes an input controlled?
22. Why does a controlled input need both `value` and `onChange`?
23. What happens if an input has a `value` prop but no working `onChange`?
24. How is a controlled `<select>` similar to a controlled text input?
25. Scenario: an input appears frozen while typing. What would you check?

## Derived Values And JavaScript Methods

26. Why might dropdown options be derived from a data array?
27. Why is `Set` useful when building unique dropdown options?
28. What does the spread operator do when converting a `Set` back to an array?
29. Why is it common to normalize user search text with `trim()` and `toLowerCase()`?
30. What does `includes` check?
31. What is the difference between `map` and `filter`?
32. Why might a filter condition combine multiple booleans with `&&`?
33. How would you represent “show all items OR match one selected value” in JavaScript logic?
34. How does a low-to-high numeric sort usually work?
35. Why can `sort` be dangerous if called directly on source data?
36. How can you sort safely without mutating original data?

## Render And Debugging

37. Walk through what happens after a user types one character into a controlled input.
38. Why does React re-render after state changes?
39. What kinds of values are recalculated on every render?
40. How would you prove a visible list is recalculated from current state?
41. Scenario: an expected item disappears after filtering. How would you debug it?
42. How can React DevTools help inspect interactive state?
43. What should the UI show when no items match a filter?
44. Why is an empty state better than rendering a blank area?

## Interview Practice

45. Explain controlled inputs to an interviewer with a generic form example.
46. Explain derived data to an interviewer with a filtered-list example.
47. Explain why storing only user choices is better than storing filtered results.
48. Explain how you would add a new sort option to a list screen.
49. Explain how you would later move filter behavior into a custom hook.
50. Explain an interactive search/filter/sort implementation in two minutes.
