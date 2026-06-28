# 02 — Local Products And JSX Questions

Use these after completing Story 02.

## Questions

1. Why did we create `src/data/fallbackProducts.js` instead of hard-coding products in JSX?
2. Why is `fallbackProducts` plain JavaScript and not a React component?
3. What does `export const fallbackProducts = [...]` allow another file to do?
4. Why is `price` stored as a number instead of a formatted string?
5. Why does each product need a stable `id`?
6. What is a `slug`, and why will it matter when routing is added?
7. What is the job of `ProductCard.jsx`?
8. What are props?
9. In `ProductCard({ product })`, what does `{ product }` mean?
10. Why should `ProductCard` receive one product instead of importing the whole product list?
11. What does `{product.name}` mean inside JSX?
12. What is the difference between writing static text and rendering data with `{}`?
13. Why does `App.jsx` import both `fallbackProducts` and `ProductCard`?
14. What does `fallbackProducts.map((product) => ...)` return?
15. Why does React ask for a `key` when rendering a list?
16. Why is `key={product.id}` better than using the array index?
17. What would happen if you changed a product name in `fallbackProducts.js`?
18. Where would you add a new field like `rating`, and how would you show it?
19. How would you debug whether `ProductCard` is receiving the correct product prop?
20. In an interview, how would you explain the render path from data array to product cards on screen?
21. Why is `<article>` a reasonable HTML element for a product card?
22. Why is `alt=""` acceptable here, and when would it not be acceptable?
23. What does `toLocaleString('en-IN')` do for the price?
24. Which Story 02 files are new, and which existing files were modified?
25. What is the main React concept this story teaches?
