using ServiceCustomers =  SparkDrums.Services.Models.Customers;
using EntityCustomers = SparkDrums.Data.Models.Customers;
using SparkDrums.Data.Readers.Customers;
using SparkDrums.Data.Writers.Customers;
using System.Collections.Generic;
using System.Linq;
using SparkDrums.Services.Serialisation;
using System;

namespace SparkDrums.Services.Customers
{
    public class CustomersService : ICustomersService
    {
        private ICustomersReader _customersReader { get; set; }

        private ICustomersWriter _customersWriter { get; set; }


        public CustomersService(ICustomersReader customersReader, ICustomersWriter customersWriter)
        {
            _customersReader = customersReader;
            _customersWriter = customersWriter;
        }


        public IEnumerable<ServiceCustomers.Customer> GetAllCustomers()
        {
            var entityCustomers = _customersReader.GetAllCustomersFromDb();
            var serviceCustomers = entityCustomers
                .Select(c => CustomerMapper
                .SerialiseCustomer(c));

            return serviceCustomers;
        }

        public ServiceCustomers.Customer GetCustomerById(int id)
        {
            var entityCustomer = _customersReader.GetCustomerFromDbById(id);
            var serviceCustomer = CustomerMapper.SerialiseCustomer(entityCustomer);
            return serviceCustomer;
        }

        public ServiceResponse<ServiceCustomers.Customer> CreateCustomer(ServiceCustomers.Customer customerToAdd)
        {
            var response = new ServiceResponse<ServiceCustomers.Customer>()
            {
                Time = DateTime.Now,
                Data = customerToAdd
            };

            try
            {
                var entityCustomerToAdd = CustomerMapper.SerialiseCustomer(customerToAdd);
                _customersWriter.AddCustomerToDb(entityCustomerToAdd);
                response.IsSuccessful = true;
                response.Message = $"Successfully added {customerToAdd.GivenName} {customerToAdd.Surname}";

            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Message = $"Failed to add {customerToAdd.GivenName} {customerToAdd.Surname}. Stack trace: {e.StackTrace}";
            }

            return response;
        }

        public ServiceResponse<ServiceCustomers.Customer> DeleteCustomer(int id)
        {
            var response = new ServiceResponse<ServiceCustomers.Customer>()
            {
                Time = DateTime.Now,
            };

            try
            {
                var entityCustomerToDelete = _customersReader.GetCustomerFromDbById(id);
                response.Data = CustomerMapper.SerialiseCustomer(entityCustomerToDelete);

                _customersWriter.DeleteCustomerFromDb(entityCustomerToDelete);
                response.IsSuccessful = true;
                response.Message = $"Successfully added {entityCustomerToDelete.GivenName} {entityCustomerToDelete.Surname}";

            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Message = $"Failed to add {response.Data.GivenName} {response.Data.Surname}. Stack trace: {e.StackTrace}";
            }

            return response;
        }
    }
}
