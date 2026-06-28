# 09 — Redux Cart

## Goal

Build a cart drawer that can be opened from anywhere and updated from product cards.

## Concepts

- global state
- Redux Toolkit
- slices
- actions
- reducers
- selectors
- `Provider`

## Build Steps

1. Install Redux Toolkit and React Redux:

   ```powershell
   npm install @reduxjs/toolkit react-redux
   ```

2. Create `src/features/cart/cartSlice.js`.
   Add state for:
   - `items`
   - `isCartOpen`

3. Add reducers for:
   - `addToCart`
   - `removeFromCart`
   - `increaseQuantity`
   - `decreaseQuantity`
   - `openCart`
   - `closeCart`
   - `clearCart`

4. Create `src/app/store.js`.
   Configure the Redux store with the cart reducer.

5. Wrap the app with Redux `Provider` in `src/main.jsx`.

6. Add an Add to Cart button in `ProductCard`.
   Dispatch `addToCart(product)`.

7. Create `src/components/CartDrawer.jsx`.
   Read cart items with `useSelector`, and dispatch quantity/remove actions.

8. Show cart count in `Header`.

## Done When

- Adding a product opens or updates the cart.
- Cart quantity changes update totals.
- The header cart count updates from any page.
- You can trace one button click from component to action to reducer to UI update.

## Reference

Read `React Learning/docs/17-redux-toolkit-state-management.md`, then compare with `React Learning/frontend/src/features/cart/cartSlice.js`.
