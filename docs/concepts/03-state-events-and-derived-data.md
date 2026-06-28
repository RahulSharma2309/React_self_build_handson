# 03 — State, Events, And Derived Data Concepts

## Why This Story Matters

Story 03 is the first time the app stops being a static display and starts reacting to the user.

Before this story, React rendered the same product cards every time. After this story, the visible UI depends on user choices:

- What did the user type?
- Which category did the user choose?
- Which sort order did the user choose?

This is the heart of React:

> UI is a function of state.

That sentence means: React does not ask you to manually hide cards, move DOM nodes, or update text. You change state. React calls your component again. Your component returns the UI that matches the new state.

## Files Modified In This Story

- `src/App.jsx`
  Adds state, event handlers, controlled form inputs, derived categories, derived visible products, conditional rendering, and an empty state.

- `src/App.css`
  Adds styles for the filter panel, controls, focus states, and empty result message.

- `docs/stories/03-state-events-and-derived-data.md`
  Becomes the practical build guide for this story.

- `docs/concepts/03-state-events-and-derived-data.md`
  Becomes the deep concept explanation you are reading now.

- `docs/questions/03-state-events-and-derived-data.md`
  Adds interview and self-check questions.

No new React component file is added in this story. That is intentional. Story 03 teaches the behavior in one place. Story 04 will teach you how to extract this growing UI into components.

## The Big Mental Model

Think of the product catalog as a machine:

```text
original product data
        +
user choices in state
        ↓
calculated visible products
        ↓
rendered UI
```

The original data is `fallbackProducts`.

The user choices are:

- `searchTerm`
- `selectedCategory`
- `sortBy`

The calculated output is:

- `categories`
- `normalizedSearchTerm`
- `visibleProducts`

The rendered UI is:

- search input
- category select
- sort select
- product grid
- empty state

An experienced React developer tries to keep these layers separate.

## What Is State?

State is data React remembers for a component between renders.

In regular JavaScript, a variable inside a function disappears after the function finishes:

```js
function App() {
  let searchTerm = ''
}
```

Every time `App` runs, `searchTerm` becomes `''` again. That is not useful for user input.

React state is different:

```jsx
const [searchTerm, setSearchTerm] = useState('')
```

React remembers `searchTerm` between renders. When you call `setSearchTerm`, React schedules another render with the new value.

## What Is `useState`?

`useState` is a React hook.

In this story:

```jsx
const [searchTerm, setSearchTerm] = useState('')
```

Break it down:

- `useState('')` creates state with an initial value of an empty string.
- `searchTerm` is the current state value.
- `setSearchTerm` is the only correct way to ask React to change it.

The array syntax is JavaScript destructuring. `useState` returns an array with two items:

```js
[currentValue, setterFunction]
```

You choose the names:

```jsx
const [searchTerm, setSearchTerm] = useState('')
```

The naming convention matters:

- value: `searchTerm`
- setter: `setSearchTerm`

That pattern makes React code easy to read.

## When `useState` Is Fit

Use `useState` when a value:

- changes over time,
- is controlled by user interaction,
- affects what appears on screen,
- must be remembered between renders.

Good Story 03 state:

```jsx
const [searchTerm, setSearchTerm] = useState('')
const [selectedCategory, setSelectedCategory] = useState('All')
const [sortBy, setSortBy] = useState('featured')
```

These are all user choices. The user can change them, and the screen should respond.

## When `useState` Is Not Fit

Do not use state for values you can calculate from existing data.

Bad idea:

```jsx
const [visibleProducts, setVisibleProducts] = useState([])
```

Why is that usually bad here?

Because `visibleProducts` can be calculated from:

- `fallbackProducts`
- `searchTerm`
- `selectedCategory`
- `sortBy`

If you store `visibleProducts` separately, you now have duplicate state. Duplicate state can go stale.

Example bug:

1. User types `robot`.
2. You update `searchTerm`.
3. You forget to update `visibleProducts`.
4. The input says `robot`, but the grid still shows old results.

Senior React habit: store the source of truth, derive everything else.

## The Three State Values In This Story

### `searchTerm`

```jsx
const [searchTerm, setSearchTerm] = useState('')
```

This stores what the user typed in the search input.

Initial value: `''`

Why empty string? Because before the user types, there is no search filter.

### `selectedCategory`

```jsx
const [selectedCategory, setSelectedCategory] = useState('All')
```

This stores which category the user selected.

Initial value: `'All'`

Why `All`? Because before the user narrows the catalog, every product should be shown.

### `sortBy`

```jsx
const [sortBy, setSortBy] = useState('featured')
```

This stores how the user wants products ordered.

Initial value: `'featured'`

Why `featured`? Because it keeps the original product order, using `id`.

## What Is An Event Handler?

An event handler is a function React runs when something happens in the browser.

In this story, the important event is `onChange`.

```jsx
onChange={(event) => setSearchTerm(event.target.value)}
```

This is an inline event handler.

Read it as:

> When this input changes, take the new input value and store it in React state.

The `event` object comes from React. It describes what happened.

For an input:

```js
event.target.value
```

means:

> the current text/value inside the input that triggered this event.

## What Happens After A User Types?

Suppose the search input is empty, and the user types `r`.

Flow:

1. Browser notices the input changed.
2. React calls the `onChange` handler.
3. `event.target.value` is now `'r'`.
4. `setSearchTerm('r')` runs.
5. React schedules a re-render.
6. `App` runs again.
7. `searchTerm` is now `'r'`.
8. `normalizedSearchTerm` is recalculated.
9. `visibleProducts` is recalculated.
10. React updates the DOM to match the new product list.

You did not manually touch the DOM. React did it from state.

## Controlled Inputs

A controlled input has its value controlled by React state.

Search input:

```jsx
<input
  type="search"
  value={searchTerm}
  onChange={(event) => setSearchTerm(event.target.value)}
  placeholder="Try robot or pi"
/>
```

Two parts make it controlled:

- `value={searchTerm}`
- `onChange={(event) => setSearchTerm(event.target.value)}`

`value` controls what the browser displays.

`onChange` updates the state when the user types.

If you remove `value`, the browser owns the input value more directly.

If you remove `onChange`, React keeps forcing the old value back into the input.

Controlled inputs are common in React because they make form state explicit and debuggable.

## Select Inputs Are Controlled Too

Category select:

```jsx
<select
  value={selectedCategory}
  onChange={(event) => setSelectedCategory(event.target.value)}
>
```

Sort select:

```jsx
<select value={sortBy} onChange={(event) => setSortBy(event.target.value)}>
```

Same pattern:

- state controls the selected option,
- event updates the state.

This pattern repeats throughout React forms.

## What Is Derived Data?

Derived data is data you calculate from other data.

In this story:

```jsx
const categories = ['All', ...new Set(fallbackProducts.map((product) => product.category))]
```

`categories` is derived from `fallbackProducts`.

```jsx
const normalizedSearchTerm = searchTerm.trim().toLowerCase()
```

`normalizedSearchTerm` is derived from `searchTerm`.

```jsx
const visibleProducts = fallbackProducts.filter(...).sort(...)
```

`visibleProducts` is derived from product data plus state.

Derived data should usually not be state.

## Why Duplicate State Is Dangerous

Imagine storing both:

```jsx
const [searchTerm, setSearchTerm] = useState('')
const [visibleProducts, setVisibleProducts] = useState(fallbackProducts)
```

Now there are two pieces of state that must stay synchronized.

Every time search changes, you must remember to update `visibleProducts`.

Every time category changes, you must remember to update `visibleProducts`.

Every time sort changes, you must remember to update `visibleProducts`.

Every time product data changes, you must remember to update `visibleProducts`.

That is a lot of chances to create bugs.

Better:

```jsx
const visibleProducts = calculateFromCurrentInputs()
```

Now React recalculates during render and there is no stale copy.

## JavaScript Concept: `map`

`map` transforms every item into something else.

In Story 03:

```jsx
fallbackProducts.map((product) => product.category)
```

This turns:

```js
[
  { name: 'Arduino Sensor Starter Lab', category: 'Microcontrollers' },
  { name: 'Raspberry Pi Home Automation Pack', category: 'IoT' },
]
```

into:

```js
['Microcontrollers', 'IoT']
```

Later, `map` renders JSX:

```jsx
visibleProducts.map((product) => (
  <ProductCard key={product.id} product={product} />
))
```

Same JavaScript method, different output.

## JavaScript Concept: `Set`

`Set` stores unique values.

This line:

```jsx
const categories = ['All', ...new Set(fallbackProducts.map((product) => product.category))]
```

prevents duplicate category options.

If two products have category `Robotics`, the dropdown still shows `Robotics` once.

## JavaScript Concept: Spread `...`

`...` spreads values from one iterable into another place.

Here:

```js
[...new Set(...)]
```

turns a `Set` back into an array.

Why?

Because arrays are easier to render with `.map(...)`.

## JavaScript Concept: `trim`

`trim()` removes spaces at the start and end of a string.

```js
' robot '.trim()
```

becomes:

```js
'robot'
```

This avoids search bugs where accidental spaces prevent matches.

## JavaScript Concept: `toLowerCase`

`toLowerCase()` makes string comparison case-insensitive.

```js
'Robot'.toLowerCase()
```

becomes:

```js
'robot'
```

That means user input `ROBOT` can still match product text `Robotics`.

## JavaScript Concept: `includes`

`includes` checks whether a string contains another string.

```js
'esp32 robotics controller kit'.includes('robot')
```

returns:

```js
true
```

In this story, we check both product name and summary:

```jsx
product.name.toLowerCase().includes(normalizedSearchTerm) ||
product.summary.toLowerCase().includes(normalizedSearchTerm)
```

The `||` means OR. If either name or summary matches, the product passes the search test.

## JavaScript Concept: `filter`

`filter` creates a new array containing only items that return `true`.

In this story:

```jsx
.filter((product) => {
  const matchesSearch = ...
  const matchesCategory = ...

  return matchesSearch && matchesCategory
})
```

The `&&` means AND. A product must match search and category.

If `matchesSearch` is `true` but `matchesCategory` is `false`, the product is removed.

## JavaScript Concept: `sort`

`sort` orders an array.

Price low to high:

```js
firstProduct.price - secondProduct.price
```

If first price is smaller, the result is negative, so first product comes earlier.

Price high to low:

```js
secondProduct.price - firstProduct.price
```

This reverses the order.

Featured:

```js
firstProduct.id - secondProduct.id
```

This restores the original order by id.

Important: `sort` mutates the array it is called on. In our chain, `filter` returns a new array first, so we are sorting that filtered copy. If you ever sort `fallbackProducts` directly, copy it first:

```js
[...fallbackProducts].sort(...)
```

## Conditional Rendering

At the bottom of `App.jsx`, the UI chooses between two outputs:

```jsx
{visibleProducts.length > 0 ? (
  <section className="product-grid" aria-label="Product catalog">
    {visibleProducts.map((product) => (
      <ProductCard key={product.id} product={product} />
    ))}
  </section>
) : (
  <p className="empty-state">No products match your filters. Try a different search.</p>
)}
```

This is a ternary expression:

```js
condition ? valueIfTrue : valueIfFalse
```

Meaning:

- If there are visible products, show the grid.
- Otherwise, show the empty state.

This is common React code because JSX is JavaScript.

## Why `ProductCard` Did Not Change

`ProductCard` receives one product and renders it.

That is still its only job.

Filtering and sorting are catalog-level behavior, not card-level behavior.

This separation is important:

- `App` decides which products are visible.
- `ProductCard` decides how one product looks.

This is how experienced developers keep components understandable.

## Why We Did Not Create `ProductFilters` Yet

You might notice the controls make `App.jsx` longer.

That is okay for this story.

Story 03 teaches state and events. Keeping the code in one file makes the flow easier to see.

Story 04 will extract the controls into `ProductFilters.jsx`. That teaches component boundaries after you understand the behavior.

## Render Cycle In Detail

Initial render:

1. `App` runs.
2. `useState('')` gives `searchTerm = ''`.
3. `useState('All')` gives `selectedCategory = 'All'`.
4. `useState('featured')` gives `sortBy = 'featured'`.
5. `categories` is calculated.
6. `normalizedSearchTerm` is calculated.
7. `visibleProducts` is calculated.
8. JSX is returned.
9. React updates the DOM.

After typing:

1. User types.
2. `onChange` runs.
3. Setter function runs.
4. React schedules a re-render.
5. `App` runs again with the new state.
6. Derived values are recalculated.
7. JSX is returned again.
8. React compares old UI and new UI.
9. React updates only the DOM parts that changed.

## Debugging Like A Developer

### Debug State

Temporarily add before `return`:

```jsx
console.log({ searchTerm, selectedCategory, sortBy })
```

Change each control and confirm the correct state changes.

### Debug Derived Products

Temporarily log:

```jsx
console.log(visibleProducts)
```

Search and filter. Confirm the array contents match the UI.

### Debug Filter Logic

Inside `filter`, temporarily log:

```jsx
console.log(product.name, { matchesSearch, matchesCategory })
```

This helps when a product appears or disappears unexpectedly.

### Debug With React DevTools

Inspect `App`.

You should see:

- `searchTerm`
- `selectedCategory`
- `sortBy`

Inspect `ProductCard`.

You should only see `product` props. You should not see search/filter state there.

## Common Beginner Mistakes

- Storing `visibleProducts` in state even though it can be derived.
- Forgetting `onChange`, making the input impossible to edit.
- Sorting the original array directly.
- Comparing category text with different casing.
- Putting filtering logic inside `ProductCard`.
- Assuming state changes immediately on the next line after calling a setter.
- Writing too much logic directly inside JSX.
- Showing an empty blank screen instead of an empty state message.

## Senior-Level Thinking

A senior engineer asks:

- What is the source of truth?
- What is user-controlled state?
- What can be derived?
- Which component should own this behavior?
- Can the UI be explained as a pure calculation from data and state?
- Will this become easier to extract later?

In this story:

- Source data: `fallbackProducts`
- User state: `searchTerm`, `selectedCategory`, `sortBy`
- Derived data: `categories`, `normalizedSearchTerm`, `visibleProducts`
- Owner: `App`, for now
- Reusable child: `ProductCard`

This is a clean learning step.

## Interview Explanation

If someone asks, “How did you implement search, filter, and sort in React?” answer like this:

> I stored only the user's choices in state: search text, selected category, and sort order. I did not store the final filtered list because it can be derived. On every render, I normalize the search text, filter products by search and category, then sort the filtered result. The inputs are controlled, so their displayed values come from React state and their `onChange` handlers update that state. When state changes, React re-renders and the visible product list is recalculated.

That answer shows React understanding, JavaScript understanding, and state-design judgment.

## Check Yourself

- Why is `searchTerm` state?
- Why is `visibleProducts` not state?
- What exactly happens when you type one character?
- What does `event.target.value` contain?
- What makes the search input controlled?
- Why does `ProductCard` not know about filters?
- Why does `filter` come before `sort`?
- Why is an empty state better than showing nothing?
