# 07 — Custom Hooks Questions

Use these after completing Story 07.

## Questions

1. What is a custom hook?
2. Why must custom hook names start with `use`?
3. What problem does `useProducts` solve?
4. What should `useProducts` return?
5. Why should `useProducts` not return JSX?
6. What problem does `useProductFilters` solve?
7. How does moving logic into hooks make `HomePage` easier to read?
8. What is the difference between reusable UI and reusable behavior?
9. Why is fetching behavior a good hook candidate?
10. Why is filtering behavior a good hook candidate?
11. What is debouncing?
12. Why might search input benefit from debouncing?
13. How does `useDebounce` likely use `useEffect` internally?
14. What cleanup might a debounce effect need?
15. What are the Rules of Hooks?
16. Why can hooks not be called inside conditions?
17. How would you debug a custom hook that keeps returning stale data?
18. How would you test whether `useProductFilters` is calculating correctly?
19. In an interview, how would you explain custom hooks without making them sound magical?
20. When should you avoid creating a custom hook?
21. Why is naming important for hooks?
22. What dependencies should an effect inside a custom hook include?
23. How can too many custom hooks make code harder instead of easier?
24. What does this story teach about separation of concerns?
25. How does this story prepare the app for theme and Redux?
26. Why do custom hooks return data and functions instead of JSX?
27. How does React track hook state by call order?
28. What bug can happen if a hook is called conditionally?
29. What should `useProducts` expose to the page?
30. What should `useProductFilters` expose to the page?
31. Why is debounce useful for search?
32. How would you debug a hook with a stale effect dependency?
33. What makes a hook name too vague?
34. How do custom hooks improve component readability?
35. How would you explain custom hooks in an interview?
