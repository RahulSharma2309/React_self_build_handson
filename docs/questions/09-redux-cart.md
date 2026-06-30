# 09 — Redux And Global State Interview Questions

Use these to prepare for generic interviews about Redux Toolkit and shared business state.

## Global State Decisions

1. What problem does Redux solve?
2. What is global state?
3. When should state stay local instead of moving to a global store?
4. What makes state “business state” rather than simple UI state?
5. Scenario: multiple distant components must read and update the same data. What options do you have?
6. Why is a complex shared workflow often a better Redux candidate than a simple theme toggle?
7. What tradeoff does Redux add to a small app?
8. Why should not every local state value move into Redux?
9. How does Redux help avoid prop drilling?
10. How would you compare local state, Context, `useReducer`, and Redux?

## Redux Core

11. What is a Redux store?
12. What is a Redux action?
13. What is a reducer?
14. What is a selector?
15. What does `dispatch(...)` mean?
16. What is a slice in Redux Toolkit?
17. What does `createSlice` generate?
18. Why does Redux Toolkit allow reducer code that looks like mutation?
19. What does Immer do behind the scenes?
20. Why should reducers be pure?

## State Shape And Derived Values

21. What kinds of values should be stored in global state?
22. What kinds of values should be derived from global state?
23. Why should totals, counts, or summaries often be derived instead of stored?
24. What bug can happen when derived totals are duplicated in state?
25. What makes an action name clear?
26. Why should reducers not perform network requests?
27. Scenario: a count shown in a header does not update after an action. What would you inspect?
28. Scenario: a reducer updates the wrong item. How would you debug it?
29. Scenario: two components show different versions of shared data. What could be wrong?
30. How would you trace a button click through Redux to a UI update?

## Interview Practice

31. Explain Redux Toolkit's value over classic Redux.
32. Explain why reducers centralize business rules.
33. Explain why UI components should dispatch actions instead of directly mutating shared state.
34. Explain how selectors improve component readability.
35. Explain the full Redux data flow in an interview.
