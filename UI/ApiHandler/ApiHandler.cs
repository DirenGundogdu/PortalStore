using Newtonsoft.Json;
using System.Text;

namespace UI.ApiHandler
{
    public class ApiHandler : IApiHandler
    {
        public T GetApi<T>(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var model = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                        return model;
                    }
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return default(T);
            }
        }

        public T PostApi<T>(dynamic dynamicModel, string Url)
        {
            using (var client = new HttpClient())
            {

                var serializeObject = JsonConvert.SerializeObject(dynamicModel);
                StringContent stringContent = new StringContent(serializeObject, Encoding.UTF8, "application/json");
                var result = client.PostAsync(Url, stringContent).Result;
                if (result.IsSuccessStatusCode)
                {
                    return default(T);
                }
                return default(T);
            }
        }
    }
}
