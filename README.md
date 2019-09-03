# TechnicalAssignmentTest
What we have,
1. IoC setup (SimpleInjector with a constructor automation injection)
2. Unit tests (as a db integration, so we don't need to bother with SQL script)
3. Swagger as a basic setup

# Remark
* Please make sure running/testing machine is running on .NET framework 4.8 (the latest version) otherwise you may need to re-add a reference to 'system.xml' library to 'Customer.Inquiry.Service' project.
* Test data can be generating along with a database creation using current windows authorisation.
* To generate a mockdata, execute a unit test on category => 'integration', this will automatically create a new database as well.
* After a database has been created, a customer with id '1' with 6 transactions will be ready for test. (this case you'll get 5 recent transactions via an api calling according to a requirement)
* On category => 'unittest' was implemented following test requirement except for an extension tests.
* Swagger can be access via http://{endpoint}:{port}/swagger
* GET /api/customers can be used as a data debugging route due it returns 'all' customers with a full json content regardless to a requirement.
