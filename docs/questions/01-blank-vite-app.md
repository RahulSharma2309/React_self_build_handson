# 01 — React App Setup Interview Questions

Use these to prepare for generic React setup and boot-flow interviews.

## Setup And Tooling

1. What problem does a build tool like Vite solve in a React project?
2. What happens when a developer runs `npm install` in a frontend project?
3. What happens when a developer runs a dev-server script such as `npm run dev`?
4. Where are npm scripts defined, and why are they useful on teams?
5. What is the difference between a development server, a production build, and a local preview server?
6. What is the difference between `dependencies` and `devDependencies`?
7. Why is a lock file such as `package-lock.json` usually committed?
8. Why should developers avoid manually editing lock files unless they know exactly why?
9. Why should `node_modules` not be committed to source control?
10. What does ES module syntax enable in modern JavaScript projects?

## Boot Flow

11. What role does the main HTML file play in a single-page React app?
12. Why does a React SPA usually have one root DOM element?
13. What is the responsibility of the JavaScript entry file?
14. What does `document.getElementById(...)` return in the boot process?
15. What does React's `createRoot(...)` do?
16. What does rendering a root component actually start?
17. Why is the root component usually kept separate from the entry file?
18. What does `StrictMode` help detect during development?
19. Does `StrictMode` create visible UI? Why or why not?
20. Scenario: the browser says the root element is missing. What would you inspect?

## React And JSX

21. How would you define a React component to a beginner?
22. Why are React component names capitalized?
23. What is JSX?
24. Why is JSX not exactly the same as HTML?
25. Why do React elements use `className` instead of `class`?
26. What is the difference between a lowercase JSX tag and an uppercase JSX tag?
27. Why do components need to be exported when used by other modules?
28. What is the difference between a default export and a named export?
29. How does hot module replacement improve frontend development?
30. Scenario: changing component text does not update the browser. What would you check?

## CSS And Debugging

31. What styles usually belong in a global CSS file?
32. What styles usually belong closer to a specific component or app section?
33. How can importing CSS from JavaScript make styles apply in a bundled app?
34. Scenario: a React page is blank. What would be your debugging order?
35. Scenario: the dev server reports an import error. What would you inspect?
36. Scenario: JSX syntax breaks compilation. Where would you look first?
37. What is the full path from opening a local URL to seeing React-rendered UI?
38. How would you explain the responsibilities of HTML shell, entry file, and root component?
39. What information in `package.json` would you inspect before running an unfamiliar React app?
40. In an interview, how would you explain a modern React app startup in under two minutes?
