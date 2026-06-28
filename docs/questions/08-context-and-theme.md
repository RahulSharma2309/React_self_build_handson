# 08 — Context And Theme Questions

Use these after completing Story 08.

## Questions

1. What problem does React Context solve?
2. Why is theme a good use case for Context?
3. Why would passing theme through props become annoying?
4. What is a provider component?
5. What does `ThemeProvider` provide to the app?
6. Why should `ThemeProvider` wrap the app near the root?
7. What is the purpose of `themeContext.js`?
8. Why might the raw context object be separated from the provider component?
9. What does `useTheme` hide from the rest of the app?
10. Why should `useTheme` throw a clear error if used outside the provider?
11. What is the difference between Context and Redux?
12. Why should cart state not automatically go into Context just because Context exists?
13. Why use `localStorage` for theme?
14. What is the difference between React state and `localStorage`?
15. How do CSS variables help with theming?
16. Why is changing CSS variables better than adding conditionals around every styled element?
17. What is a `data-theme` attribute?
18. How would you debug a theme toggle that changes state but not colors?
19. How would you debug a theme that resets after refresh?
20. In an interview, how would you explain Context in one minute?
21. What values should be included in the theme context value?
22. What kind of values should not be placed in theme context?
23. How can unnecessary context updates cause extra renders?
24. Why is theme UI state different from product data?
25. How does this story prepare you for app-wide state decisions?
