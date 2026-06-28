# 01 — Blank Vite App Questions

Use these after completing Story 01.

## Setup And Tooling

1. What problem does Vite solve in a React project?
2. What happens when you run `npm install`?
3. What happens when you run `npm run dev`?
4. Where is the `dev` command defined?
5. What is the difference between `npm run dev`, `npm run build`, and `npm run preview`?
6. What is the difference between `dependencies` and `devDependencies`?
7. Why should you usually commit `package-lock.json`?
8. Why should you normally not edit `package-lock.json` by hand?
9. Why should you normally not edit `node_modules`?
10. What does `"type": "module"` mean in `package.json`?

## Boot Flow

11. What is the job of `index.html` in a Vite React app?
12. Why does `index.html` contain `<div id="root"></div>`?
13. Which file connects React to that root DOM element?
14. What does `document.getElementById('root')` return?
15. What does `createRoot(...)` do?
16. What does `.render(<App />)` do?
17. Why does `main.jsx` render `<App />` instead of writing all UI directly there?
18. What role does `StrictMode` play?
19. Does `StrictMode` render visible UI?
20. What would happen if `id="root"` was renamed in `index.html` but not in `main.jsx`?

## React And JSX

21. What is a React component in the simplest possible words?
22. Why does a component name start with a capital letter?
23. What is JSX?
24. Why is JSX not exactly HTML?
25. Why do we use `className` instead of `class`?
26. What is the difference between `<App />` and `<div>` in JSX?
27. Why does `App.jsx` need to export `App`?
28. What is the difference between a default export and a named export?
29. Why does changing text in `App.jsx` update the browser quickly?
30. What is hot reload, and how does it help learning?

## CSS And Debugging

31. What kind of styles belong in `index.css`?
32. What kind of styles belong in `App.css` at this early stage?
33. How does importing CSS from JavaScript make styles apply?
34. If the page is blank, which files would you check first?
35. If Vite shows an import error, what would you inspect?
36. If the browser console says the root element is missing, what should you check?
37. If JSX syntax breaks, where will you usually see the error?
38. What is the full boot flow from browser URL to rendered UI?
39. How would you explain the responsibility of `index.html`, `main.jsx`, and `App.jsx` separately?
40. In an interview, how would you explain a Vite React app startup in under two minutes?
