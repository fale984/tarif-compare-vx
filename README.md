# Tariff Comparison Tool

Utility to manage and compare Products based on their annual costs.

Project components:
- Data: Contains the required classes to store products on database.
  - The database is configured to run in memory to make it easy to run on different machines.
- Core: Provides functionality to calculate costs.
  - Using the factory pattern to select the appropriate calculator.
- Web: Interface to interact with products. Consist of:
  - Products API: RESTful service to get and update products.
  - MVC Site: HTML interface to interact with the API. Using jQuery to interact with HTML and make the API calls.
- Tests: xUnit tests for backend code.

Created by Francisco Lopez
