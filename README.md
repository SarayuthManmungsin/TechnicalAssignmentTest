# TechnicalAssignmentTest
What we have here,
1. IoC setup (SimpleInjector with a constructor automation injection)
2. Unit tests (as a db integration, so we don't need to bother with SQL script)
3. Swagger as a basic setup

Test data can be generate along with a database creation using current windows authorisation.
Execution a test category 'integration' will create,
a customer with id '1' with 6 transactions (this case you'll get 5 recent transactions via an api calling according to a requirement)
