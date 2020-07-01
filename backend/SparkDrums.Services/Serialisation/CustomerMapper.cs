using EntityCustomers = SparkDrums.Data.Models.Customers;
using ServiceCustomers = SparkDrums.Services.Models.Customers;


namespace SparkDrums.Services.Serialisation
{
    public static class CustomerMapper
    {
        // in goes an entity model and out comes a service model
        public static ServiceCustomers.Customer SerialiseCustomer(EntityCustomers.Customer entityCustomer)
        {
            var serviceCustomer = new ServiceCustomers.Customer()
            {
                Id = entityCustomer.Id,
                GivenName = entityCustomer.GivenName,
                Surname = entityCustomer.Surname,
                PrimaryAddress = SerialiseCustomerAddress(entityCustomer.PrimaryAddress),
                CreatedOn = entityCustomer.CreatedOn,
                UpdatedOn = entityCustomer.UpdatedOn
            };

            return serviceCustomer;
        }

        public static ServiceCustomers.CustomerAddress SerialiseCustomerAddress(EntityCustomers.CustomerAddress entityCustomerAddress)
        {
            var serviceAddress = new ServiceCustomers.CustomerAddress()
            {
                Id = entityCustomerAddress.Id,
                Line1 = entityCustomerAddress.Line1,
                Line2 = entityCustomerAddress.Line2,
                Line3 = entityCustomerAddress.Line3,
                City = entityCustomerAddress.City,
                Region = entityCustomerAddress.Region,
                Country = entityCustomerAddress.Country,
                Postcode = entityCustomerAddress.Postcode,
                CreatedOn = entityCustomerAddress.CreatedOn,
                UpdatedOn = entityCustomerAddress.UpdatedOn
            };

            return serviceAddress;
        }


        // in comes a service model and out goes an entity model
        public static EntityCustomers.Customer SerialiseCustomer(ServiceCustomers.Customer serviceCustomer)
        {
            var entityCustomer = new EntityCustomers.Customer()
            {
                Id = serviceCustomer.Id,
                GivenName = serviceCustomer.GivenName,
                Surname = serviceCustomer.Surname,
                PrimaryAddress = SerialiseCustomerAddress(serviceCustomer.PrimaryAddress),
                CreatedOn = serviceCustomer.CreatedOn,
                UpdatedOn = serviceCustomer.UpdatedOn
            };

            return entityCustomer;
        }

        // in comes a service model id and out 

        public static EntityCustomers.CustomerAddress SerialiseCustomerAddress(ServiceCustomers.CustomerAddress serviceCustomerAddress)
        {
            var entityAddress = new EntityCustomers.CustomerAddress()
            {
                Id = serviceCustomerAddress.Id,
                Line1 = serviceCustomerAddress.Line1,
                Line2 = serviceCustomerAddress.Line2,
                Line3 = serviceCustomerAddress.Line3,
                City = serviceCustomerAddress.City,
                Region = serviceCustomerAddress.Region,
                Country = serviceCustomerAddress.Country,
                Postcode = serviceCustomerAddress.Postcode,
                CreatedOn = serviceCustomerAddress.CreatedOn,
                UpdatedOn = serviceCustomerAddress.UpdatedOn
            };

            return entityAddress;
        }
    }
}
