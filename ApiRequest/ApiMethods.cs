using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TEST_JAIRO_QUEVEDO.ViewModels;
using System.Threading.Tasks;

namespace TEST_JAIRO_QUEVEDO.ApiRequest
{
    public class ApiMethods
    {
        [HttpGet]
        public async Task<List<employee>> Employees(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string JsonEmployees = await response.Content.ReadAsStringAsync();
                    var JsonEmployeesObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonEmployees);
                    List<employee> employees = JsonConvert.DeserializeObject<List<employee>>(JsonEmployeesObject["data"].ToString());
                    return employees;
                }
                else
                {
                    return null;
                }

            }
        }

        [HttpGet]
        public async Task<employee> Employee(string apiUrl, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl + id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl + id);
                if (response.IsSuccessStatusCode)
                {
                    string JsonEmployee = await response.Content.ReadAsStringAsync();
                    var JsonEmployeeObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonEmployee);
                    employee employee = JsonConvert.DeserializeObject<employee>(JsonEmployeeObject["data"].ToString());
                    return employee;
                }
                else
                {
                    return null;
                }

            }
        }
    }
}