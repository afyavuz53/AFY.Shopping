using Newtonsoft.Json;

namespace Afy.Shopping.WebMVC.Utilities
{
    public class ApiJsonHelper
    {
        public static TREntity? PostEntity<TSEntity, TREntity>(string path, TSEntity entityVM)
        {
            string jsonEntity = HttpService.Post(path, entityVM);
            TREntity? result = JsonConvert.DeserializeObject<TREntity>(jsonEntity);
            return result;
        }

        public static T? GetEntity<T>(string path)
        {
            string jsonEntity = HttpService.Get(path);
            T? result = JsonConvert.DeserializeObject<T>(jsonEntity);
            return result;
        }

        public static void DeleteEntity(string path)
        {
            string jsonEntity = HttpService.Delete(path);
        }
    }
}
