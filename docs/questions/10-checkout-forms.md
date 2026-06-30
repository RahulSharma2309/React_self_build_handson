# 10 — Forms, Validation, And Refs Interview Questions

Use these to prepare for generic interviews about React forms and submit preparation.

## Controlled Forms

1. What is a controlled input?
2. Why should form values often live in React state?
3. What does `onChange` do in a controlled field?
4. What does the `value` prop do in an input?
5. What bug appears if an input has `value` but no working `onChange`?
6. What is an uncontrolled input?
7. When might an uncontrolled input be acceptable?
8. How would you explain controlled vs uncontrolled inputs in an interview?
9. Scenario: an input does not update while typing. What would you debug?
10. Scenario: a form resets unexpectedly. What would you inspect?

## Submit And Validation

11. Why should `event.preventDefault()` often be used on form submit in an SPA?
12. What is form submit state?
13. What should happen if required fields are empty?
14. Where should validation errors be shown?
15. Why should validation not exist only in logs?
16. What is the difference between field-level validation and form-level validation?
17. Scenario: a form depends on shared application data. How should validation account for that?
18. What data should be local form state?
19. What form-related values might be derived?
20. What should a submit payload contain before being sent to an API?

## Refs And Accessibility

21. What is a ref in React?
22. Why is focusing the first invalid field a good ref use case?
23. Why should refs not replace normal form state?
24. What are other valid ref use cases?
25. Why is accessibility important in forms?
26. Why should labels be connected to inputs?
27. How should error messages help keyboard and screen reader users?
28. What should visible focus styles communicate?
29. Scenario: pressing Enter submits the form unexpectedly. How would you reason about it?
30. Scenario: a screen reader user cannot understand an error. What would you improve?

## Interview Practice

31. Explain the flow from user typing to React state update.
32. Explain the flow from form submit to validation.
33. Explain when to use state and when to use refs in forms.
34. Explain how local form state can combine with shared app state.
35. Explain a robust form submit flow in an interview.
