# Clean Crud 

Clean CRUD exercise

---

## Purpose

The idea with this execise is to create a simple application that follows **Clean Architecture** principles and **TDD** methodologies.

The imaginary scenario is for a Medical Practice Center that wishes to have a way to manage Representatives. Be it a Medical Science Liason, Field Reimbursement Officers or Sales Reps.

## Assumptions/ Decissions

- For simplicity purposes:
  - A user can register to the app and have immediate access to restricted actions. No user activation is required by an admin user.
  - I am not using Automapper for mappings. But normally this would be benefitial for larger projects.
  - SQL Lite was used as the persistance engine. A clean DB is added to the solution.
  - The User API has no security.

## Use Cases

1. As a practice user I want to be able to sign in the application in order to have access to restricted actions on it.
2. As an authenticated practice user, I want to be able to manage Representative information, so that I can register, edit, list and remove all the reps that interact with us, and have the information readily available to consult for our day to day operation.





