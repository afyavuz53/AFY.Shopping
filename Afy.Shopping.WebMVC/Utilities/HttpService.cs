using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Afy.Shopping.WebMVC.Utilities
{
    public class HttpService
    {
        public static string Get(string path)
        {
            try
            {
                string servicepath = path;
                using (HttpClient client = new HttpClient())
                {
                    var resuly = client.GetAsync(new Uri(servicepath));
                    return resuly.Result.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public static string Post<TEntity>(string path, TEntity entity)
        {
            try
            {
                string servicepath = path;
                StringContent httpContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage responseMessage = client.PostAsync(servicepath, httpContent).Result;
                    responseMessage.EnsureSuccessStatusCode();
                    return responseMessage.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public static string Delete(string path)
        {
            try
            {
                string servicepath = path;
                using (HttpClient client = new HttpClient())
                {
                    var resuly = client.DeleteAsync(new Uri(servicepath));
                    return resuly.Result.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception)
            {
                return null!;
            }
        }
    }
}
