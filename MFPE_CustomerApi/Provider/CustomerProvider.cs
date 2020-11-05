using MFPE_CustomerApi.Models;
using MFPE_CustomerApi.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MFPE_CustomerApi.Provider
{
    public class CustomerProvider : IProvider<Customer>
    {
        IRepository<Customer> _custom;


        public CustomerProvider(IRepository<Customer> custrepo)
        {
            _custom = custrepo;

        }
        public bool Add(Customer item)
        {
            if (_custom.Add(item))
            {

                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44369");
                HttpResponseMessage response1 = client.PostAsJsonAsync("api/Account/createAccount", new { CustomerId = Convert.ToInt32(item.CustomerId) }).Result;
                var result1 = response1.Content.ReadAsStringAsync().Result;
                AccountCreationStatus st = JsonConvert.DeserializeObject<AccountCreationStatus>(result1);

                return true;
            }
            else
            {
                return false;
            }
        }

        

        public Customer Get(int id)
        {
            return _custom.Get(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _custom.GetAll();
        }

        
    }
}
