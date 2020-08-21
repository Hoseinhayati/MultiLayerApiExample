using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApiExample.Web.Models;

namespace WebApiExample.Web.Repositories
{
    public class CustomerRepository
    {
        private string apiUrl = "http://localhost:5000/api/Customers";
        private HttpClient _client;

        public CustomerRepository()
        {
            _client = new HttpClient();
        }

        public List<Customer> GetAllCustomer(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = _client.GetStringAsync(apiUrl).Result;
            List<Customer> list = JsonConvert.DeserializeObject<List<Customer>>(result);
            return list;
        }

        public Customer GetCustomerById(int id)
        {
            var result = _client.GetStringAsync(apiUrl + "/" + id).Result;
            Customer customer = JsonConvert.DeserializeObject<Customer>(result);
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            string jsonCustomer = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");
            var result = _client.PostAsync(apiUrl, content).Result;
        }

        public void UpdateCustomer(Customer customer)
        {
            string jsonCustomer = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");
            var result = _client.PutAsync(apiUrl + "/" + customer.Id, content).Result;
        }

        public void DeleteCustomer(int id)
        {
            var result = _client.DeleteAsync(apiUrl + "/" + id).Result;
        }
    }


}
