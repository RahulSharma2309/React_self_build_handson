# 02 — Local Products And JSX Questions

Use these after completing Story 02.

## Data And Modules

1. Why did we create `src/data/fallbackProducts.js` instead of hard-coding products in JSX?
2. Why is `fallbackProducts` plain JavaScript and not a React component?
3. What does `export const fallbackProducts = [...]` do?
4. What problem happens if you write `const fallbackProducts = [...]` without exporting it?
5. What is the difference between a named export and a default export?
6. Why does a named import use braces?
7. Why is `price` stored as a number instead of a formatted string?
8. Why does each product need a stable `id`?
9. What is a `slug`, and why will it matter when routing is added?
10. What fields would you add if the card needed ratings and stock status?

## Components And Props

11. What is the job of `ProductCard.jsx`?
12. What are props?
13. In `ProductCard({ product })`, what does `{ product }` mean?
14. Why should `ProductCard` receive one product instead of importing the whole product list?
15. Why should props be treated as read-only?
16. What does `{product.name}` mean inside JSX?
17. What is the difference between static text and rendering data with `{}`?
18. Why is `<article>` a reasonable HTML element for a product card?
19. Why is `alt=""` acceptable here, and when would it not be acceptable?
20. What does `toLocaleString('en-IN')` do for the price?

## Lists And Keys

21. Why does `App.jsx` import both `fallbackProducts` and `ProductCard`?
22. What does `fallbackProducts.map((product) => ...)` return?
23. How does an array of data become an array of React elements?
24. Why does React ask for a `key` when rendering a list?
25. Why is `key={product.id}` better than using the array index?
26. What kind of bug can happen with index keys when items are reordered?
27. What would happen if you changed a product name in `fallbackProducts.js`?
28. Where would you add a new field like `rating`, and how would you show it?
29. Why does `ProductCard` not need to know how many products exist?
30. How would the pattern change if products came from an API?

## Debugging And Interview Practice

31. How would you debug whether `App.jsx` imported the data correctly?
32. How would you debug whether `ProductCard` is receiving the correct product prop?
33. How can React DevTools help inspect this story?
34. Which Story 02 files are new, and which existing files were modified?
35. What is the main React concept this story teaches?
36. How would you explain the dependency direction between `App.jsx`, `fallbackProducts.js`, and `ProductCard.jsx`?
37. Why is separation of data and UI useful?
38. Why is component reuse useful even with only three products?
39. How would you explain this implementation in an interview?
40. What later stories depend on this Story 02 structure being clean?
