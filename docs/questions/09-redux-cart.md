# 09 — Redux Cart Questions

Use these after completing Story 09.

## Questions

1. What problem does Redux solve in this app?
2. Why is the cart a better Redux candidate than the theme?
3. What is global state?
4. Which components need to read or update cart state?
5. What is a Redux store?
6. What is a Redux action?
7. What is a reducer?
8. What is a selector?
9. What is a slice in Redux Toolkit?
10. What does `createSlice` generate for you?
11. Why does Redux Toolkit allow reducer code that looks like mutation?
12. What is Immer doing behind the scenes?
13. Why create `src/app/store.js`?
14. Why wrap the app with Redux `Provider`?
15. What does `dispatch(addToCart(product))` mean?
16. Why should `ProductCard` dispatch an action instead of editing cart state directly?
17. What should happen if the same product is added twice?
18. How should cart subtotal be calculated?
19. Should subtotal be stored in Redux or derived from items? Why?
20. How would you debug a cart count that does not update in the header?
21. How would you debug a reducer that changes the wrong quantity?
22. In an interview, how would you compare `useReducer`, Context, and Redux?
23. Why should not every local state value move into Redux?
24. What is the tradeoff of adding Redux to a small app?
25. Can you trace Add to Cart from click to UI update step by step?
