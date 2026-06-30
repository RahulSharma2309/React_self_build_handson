# 07 — Custom Hooks Interview Questions

Use these to prepare for generic interviews about reusable React behavior.

## Hook Fundamentals

1. What is a custom hook?
2. Why must custom hook names start with `use`?
3. What is the difference between reusable UI and reusable behavior?
4. Why do custom hooks usually return data and functions instead of JSX?
5. What are the Rules of Hooks?
6. Why can hooks not be called conditionally?
7. How does React track hook state by call order?
8. What bug can happen if a hook is called in different orders between renders?
9. Why is naming important for custom hooks?
10. What makes a hook name too vague?

## Extraction Decisions

11. When is fetching behavior a good custom hook candidate?
12. When is filtering or sorting behavior a good custom hook candidate?
13. When should you avoid creating a custom hook?
14. How can too many custom hooks make code harder instead of easier?
15. How does moving logic into hooks make a page component easier to read?
16. What should a data-fetching hook expose to the UI?
17. What should a filtering hook expose to the UI?
18. How do custom hooks support separation of concerns?
19. Scenario: two pages repeat the same loading/error/data logic. How would you refactor?
20. Scenario: a hook returns ten unrelated values. What design concern does that suggest?

## Effects, Debounce, And Debugging

21. What is debouncing?
22. Why might a search input benefit from debouncing?
23. How would a debounce hook likely use `useEffect` internally?
24. What cleanup might a debounce effect need?
25. What dependencies should an effect inside a custom hook include?
26. Scenario: a custom hook keeps returning stale data. What would you inspect?
27. Scenario: a debounced value never updates. What would you debug?
28. How would you test a custom hook's calculation logic?
29. How would you test a custom hook that performs async work?
30. How can React DevTools help when debugging hook state?

## Interview Practice

31. Explain custom hooks without making them sound magical.
32. Explain why hooks are functions but components return UI.
33. Explain how custom hooks differ from utility functions.
34. Explain how a hook can make a component more readable.
35. Explain a scenario where you would not extract a hook yet.
36. Explain the top-level hook call rule with an example.
37. Explain how custom hooks prepare an app for larger architecture.
38. Explain how a hook can hide implementation details while exposing a clear API.
39. Explain why custom hooks are about reuse and clarity, not automatic performance.
40. Explain a custom hook you would design for any list page with search and loading.
