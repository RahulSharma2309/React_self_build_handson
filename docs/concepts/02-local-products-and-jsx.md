# 02 — Local Products And JSX Concepts

## Mental Model

React is strongest when UI is created from data.

Instead of manually writing six product cards, you keep product information in an array and let React render one card per item. This is your first real taste of declarative UI: describe what should appear for the current data.

The senior-level idea is separation of concerns:

- data file owns product facts,
- card component owns how one product looks,
- app component owns the list rendering.

When these responsibilities stay separate, the code grows without becoming confusing.

## Files Added And Modified In This Story

### New Files Added

- `src/data/fallbackProducts.js`
  Holds the local product array. This is plain JavaScript data, not React UI.

- `src/components/ProductCard.jsx`
  Defines the reusable product card component. It receives one `product` through props and renders that product.

### Existing Files Modified

- `src/App.jsx`
  Changed from the blank Story 01 screen into the catalog page. It imports `fallbackProducts`, loops over the array with `map`, and renders `ProductCard` for each item.

- `src/App.css`
  Adds layout and card styles for the catalog page.

- `src/index.css`
  Adds global foundation styles like background color, default text color, and `box-sizing`.

- `docs/concepts/02-local-products-and-jsx.md`
  Expanded with explanation of the new files, render flow, and debugging steps.

## Important Files

### `src/data/fallbackProducts.js`

This file holds plain JavaScript data. It has no React. That is deliberate.

Keeping data separate from UI makes the app easier to test, replace, and understand. Later this same shape will help when products come from the backend.

The file exports one named value:

```js
export const fallbackProducts = [
  {
    id: 1,
    name: 'Arduino Sensor Starter Lab',
    slug: 'arduino-sensor-starter-lab',
    category: 'Microcontrollers',
    price: 2499,
    image: '...',
    summary: '...',
  },
]
```

Understand every field:

- `id` is the stable identity used by React as the list `key`.
- `name` is what the user reads as the product title.
- `slug` is a URL-safe name. Story 05 will use it for product detail routes.
- `category` is plain text for now. Story 03 will use it for filtering.
- `price` is a number, not a formatted string. That lets code format it later.
- `image` is a URL used by the card image.
- `summary` is the short description shown on the card.

Why use `export const`? Because another file can import exactly this data by name:

```js
import { fallbackProducts } from './data/fallbackProducts.js'
```

### Named Export vs Default Export

This file uses a named export:

```js
export const fallbackProducts = [...]
```

That means imports must use the exported name:

```js
import { fallbackProducts } from './data/fallbackProducts.js'
```

If you wrote only:

```js
const fallbackProducts = [...]
```

then the data would be private to that file. `App.jsx` could not import it.

If you wrote:

```js
export default fallbackProducts
```

then another file would import it without braces:

```js
import fallbackProducts from './data/fallbackProducts.js'
```

Named export is useful for learning because the import name must match the exported name. It makes the data flow explicit.

### `src/components/ProductCard.jsx`

This file teaches the component idea.

`ProductCard` should receive a product through props and render only that product. It should not know where the product came from or how many products exist.

Current component shape:

```jsx
export function ProductCard({ product }) {
  return (
    <article className="product-card">
      <img className="product-card__image" src={product.image} alt="" />
      <div className="product-card__body">
        <p className="product-card__category">{product.category}</p>
        <h2 className="product-card__title">{product.name}</h2>
        <p className="product-card__summary">{product.summary}</p>
        <p className="product-card__price">₹{product.price.toLocaleString('en-IN')}</p>
      </div>
    </article>
  )
}
```

Line by line:

- `export function ProductCard(...)` makes this component available to import in `App.jsx`.
- `{ product }` is destructuring props. React passes one props object, and this pulls out the `product` property.
- `<article>` is semantic HTML for a self-contained item.
- `className` connects the JSX to CSS rules in `App.css`.
- `src={product.image}` reads the image URL from the product object.
- `alt=""` means this image is decorative for now because the product name is already shown as text.
- `{product.category}`, `{product.name}`, and `{product.summary}` insert JavaScript values into JSX.
- `product.price.toLocaleString('en-IN')` formats `2499` as `2,499` for Indian number formatting.

### Props In Depth

Props are read-only inputs to a component.

Parent:

```jsx
<ProductCard product={product} />
```

Child:

```jsx
export function ProductCard({ product }) {
```

The parent decides what data to pass. The child decides how to display it.

The child should not modify `product`. React components are easier to reason about when props are treated as immutable.

If `ProductCard` imported `fallbackProducts` directly, it would become tightly coupled to one data source. Passing props keeps it reusable.

### `src/App.jsx`

For this story, `App.jsx` coordinates the page:

- imports the data,
- loops over it,
- renders many `ProductCard` components.

That makes `App.jsx` the temporary page owner.

The important imports are:

```jsx
import { ProductCard } from './components/ProductCard.jsx'
import { fallbackProducts } from './data/fallbackProducts.js'
```

This tells you the direction of dependency:

`App.jsx` knows about the data and the card component.

`ProductCard.jsx` does not know about `fallbackProducts`.

The render loop is:

```jsx
{fallbackProducts.map((product) => (
  <ProductCard key={product.id} product={product} />
))}
```

Read it slowly:

1. `fallbackProducts` is the array.
2. `.map(...)` visits each product.
3. For each product, React gets one `<ProductCard />`.
4. `key={product.id}` gives React stable identity for the list item.
5. `product={product}` passes the current product object as a prop.

### Why Keys Matter

React uses keys to track list items across renders.

Imagine a list changes from:

```text
Arduino
Raspberry Pi
ESP32
```

to:

```text
Raspberry Pi
ESP32
```

React needs to know which item was removed. A stable key helps it do that correctly.

Good key:

```jsx
key={product.id}
```

Weak key:

```jsx
key={index}
```

Index keys can cause bugs when items are inserted, removed, or reordered because the index changes even when the real item is the same.

### `src/App.css`

This file styles the page and the card.

Important classes:

- `.app` centers the content and gives the page breathing room.
- `.hero` styles the heading section.
- `.product-grid` creates the responsive card grid.
- `.product-card` styles one product card.
- `.product-card__image` makes all product images the same visual size.
- `.product-card__body`, `__title`, `__summary`, and `__price` style the text inside the card.

The double-underscore class names are just a naming style. They make it clear that those classes belong to the product card.

## Render Flow In Detail

Initial render:

1. `main.jsx` renders `<App />`.
2. `App.jsx` imports `fallbackProducts`.
3. `App.jsx` imports `ProductCard`.
4. `App` returns JSX.
5. Inside the JSX, `fallbackProducts.map(...)` runs.
6. The first product becomes `<ProductCard product={firstProduct} />`.
7. React calls `ProductCard` with that prop.
8. `ProductCard` returns JSX for one card.
9. React repeats that for every product.
10. React creates DOM nodes.
11. CSS styles those DOM nodes.

This is important: `ProductCard` is not manually called by you like a normal function. You describe `<ProductCard />` in JSX, and React calls it as part of rendering.

### `src/index.css`

This file still handles global foundation styles:

- `:root` sets the default font, text color, and page background.
- `body { margin: 0; }` removes the browser's default page margin.
- `* { box-sizing: border-box; }` makes layout sizing easier because padding and borders are included in element width.

## What Each Move Teaches

Creating `fallbackProducts` teaches that frontend apps often begin with local seed data before backend integration.

Using `map` teaches how arrays become UI.

Passing `product={product}` teaches props: parent components pass data down to child components.

Adding `key={product.id}` teaches React identity. React uses keys to understand which list item is which between renders.

## When This Pattern Is Fit

Use this data-to-components pattern when:

- you have a list of similar items,
- each item has the same display shape,
- the data might later come from an API,
- you want one reusable component per item.

Avoid hard-coding repeated JSX because it makes updates painful and hides the data structure.

## When This Pattern Needs To Evolve

This pattern is simple now, but later it may evolve:

- Story 03 filters the array before rendering.
- Story 05 links each card to a route.
- Story 06 replaces local data with API data.
- Story 09 adds cart actions from each card.

The clean separation in Story 02 makes those changes easier.

## Render Flow To Debug

Use this flow when you debug in the browser:

1. Browser loads `index.html`.
2. `index.html` loads `/src/main.jsx`.
3. `main.jsx` renders `<App />`.
4. `App.jsx` imports `fallbackProducts`.
5. `App.jsx` runs `fallbackProducts.map(...)`.
6. Each product object becomes one `<ProductCard product={product} />`.
7. `ProductCard` reads fields from `product` and returns JSX.
8. React turns the JSX into DOM nodes.
9. `App.css` and `index.css` style those DOM nodes.

## Debugging Exercises

Try these in order:

1. In `src/data/fallbackProducts.js`, change one product's `name`.
   The card title should update. This proves the UI is coming from data.

2. In `src/App.jsx`, temporarily add:

   ```jsx
   {console.log(fallbackProducts)}
   ```

   Open the browser console. You should see the array. Remove this after observing it.

3. In `src/components/ProductCard.jsx`, temporarily add:

   ```jsx
   console.log(product)
   ```

   Put it just inside the function body, before `return`. You should see one log per product card render. Remove this after observing it.

4. Open React DevTools if installed.
   Find `App`, then find each `ProductCard`. Inspect the `product` prop.

5. Remove `key={product.id}` temporarily.
   The app may still render, but React should warn in the console. Put the key back.

## JSX Is Not HTML

JSX looks like HTML, but it can use JavaScript expressions inside `{}`.

Examples:

- `{product.name}` inserts a value.
- `{products.map(...)}` inserts many elements.
- `className` is used instead of `class` because JSX is JavaScript.

## Mistakes To Watch For

- Do not call `map` without returning JSX.
- Do not use array index as the key when each product has a stable `id`.
- Do not make `ProductCard` import the whole product list. A card should receive one product.
- Do not put prices or names directly in JSX if they already exist in data.
- Do not store formatted price as the source data if you later need numeric sorting.
- Do not forget braces for named imports.
- Do not mutate props inside `ProductCard`.

## Interview Explanation

If asked about this story:

> I separated product data from UI. The product array is exported from a data module. `App` imports that array and maps over it to render a `ProductCard` for each item. The card receives one product via props and renders its fields. Each card gets `key={product.id}` so React can track list identity. This pattern scales naturally when the data later comes from an API or needs filtering.

## Check Yourself

- What is a prop?
- Why is `ProductCard` reusable?
- Why does React need a `key` in a list?
- What is the difference between data and UI?
