# Story Map

Follow these in order. The final result should feel like the finished `React Learning` app, but you will understand it because you built every part.

| Story | Build Outcome | Main Concepts | Read First | Then Build |
| --- | --- | --- | --- | --- |
| 01 | Understand the blank Vite app | project setup, npm, Vite, entry point | `concepts/01-blank-vite-app.md` | `stories/01-blank-vite-app.md` |
| 02 | Render the first product list from local data | JSX, components, props, arrays | `concepts/02-local-products-and-jsx.md` | `stories/02-local-products-and-jsx.md` |
| 03 | Make search, category filter, and sort work | `useState`, events, derived data | `concepts/03-state-events-and-derived-data.md` | `stories/03-state-events-and-derived-data.md` |
| 04 | Extract reusable product UI | component boundaries, composition | `concepts/04-components-and-composition.md` | `stories/04-components-and-composition.md` |
| 05 | Add product detail pages | React Router, links, URL params | `concepts/05-routing-and-pages.md` | `stories/05-routing-and-pages.md` |
| 06 | Fetch products from the backend | `useEffect`, loading, error, API layer | `concepts/06-backend-data-and-effects.md` | `stories/06-backend-data-and-effects.md` |
| 07 | Build custom hooks | reusable behavior, hook rules | `concepts/07-custom-hooks.md` | `stories/07-custom-hooks.md` |
| 08 | Add theme switching | Context, provider pattern, CSS variables | `concepts/08-context-and-theme.md` | `stories/08-context-and-theme.md` |
| 09 | Add the cart drawer | Redux Toolkit, global state | `concepts/09-redux-cart.md` | `stories/09-redux-cart.md` |
| 10 | Build checkout | forms, controlled inputs, refs, submit flow | `concepts/10-checkout-forms.md` | `stories/10-checkout-forms.md` |
| 11 | Add orders and backend writes | POST requests, async state, data refresh | `concepts/11-orders-api.md` | `stories/11-orders-api.md` |
| 12 | Polish into the finished app | performance hooks, accessibility, responsive CSS | `concepts/12-polish-and-final-app.md` | `stories/12-polish-and-final-app.md` |

## Finished App Checklist

When all stories are done, your app should have:

- Product catalog with search, category filtering, and sorting.
- Product detail route.
- Cart drawer with quantity changes and totals.
- Checkout page that places an order.
- Orders page that reads submitted orders.
- Light/dark theme.
- A small in-app learning page or concept map.
- Clean folder structure: `api`, `app`, `components`, `contexts`, `data`, `features`, `hooks`, `pages`, `utils`.
