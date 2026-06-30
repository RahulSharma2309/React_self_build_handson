# 08 — Context, Providers, And Theme Interview Questions

Use these to prepare for generic interviews about React Context and app-wide UI state.

## Context Fundamentals

1. What problem does React Context solve?
2. What is prop drilling?
3. Is prop drilling always bad? Why or why not?
4. When is Context a good fit?
5. When is Context the wrong tool?
6. What is a provider component?
7. Why should a provider usually wrap the part of the tree that needs the value?
8. What does the raw context object do?
9. Why might a raw context object be separated from the provider component?
10. Why is provider value design important?

## Context API Design

11. What values should be included in a small UI-preference context?
12. What kind of values should not be placed into an unrelated context?
13. Why can a custom hook around `useContext` produce better errors?
14. What should happen if a context hook is used outside its provider?
15. How can unnecessary context updates cause extra renders?
16. Why can fast-changing values be risky in Context?
17. How would you debug a context value that is always `undefined`?
18. Scenario: a deeply nested button needs to update app-wide UI state. How might Context help?
19. Scenario: only one child needs a value one level down. Would you use Context? Why?
20. How would you explain Context in one minute?

## Persistence And Styling Scenarios

21. What is the difference between React state and browser storage?
22. Why does browser storage not replace React state?
23. What does it mean that browser storage stores strings?
24. When would you persist a UI preference?
25. How do CSS variables help with theming?
26. Why can CSS variables be better than conditional class logic everywhere?
27. What is a `data-*` attribute, and how can it support styling?
28. Scenario: a toggle changes state but colors do not change. What would you debug?
29. Scenario: a preference resets after refresh. What would you inspect?
30. Scenario: a theme flashes before applying. What might be happening?

## Context vs State Libraries

31. What is the difference between Context and Redux or another state library?
32. Why should complex business state not automatically go into Context?
33. What kind of state is better suited to a reducer or global store?
34. What kind of state is simple enough for Context?
35. How would you explain Context vs Redux in an interview?
