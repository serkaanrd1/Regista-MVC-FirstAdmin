namespace RegistaMVC.ApiServices
{
    public interface IHttpApiService
    {
        Task<T> GetData<T>(string requestUri);
        Task<t> PostData<t>(string requestUri, string jsonData);
        Task<bool> DeleteData(string requestUri, string token = null);
    }
}
