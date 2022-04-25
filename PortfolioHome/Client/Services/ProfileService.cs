using System.Net.Http;
using System.Net.Http.Json;

namespace Client.Services;

public class ProfileService : IProfileService
{
    private HttpClient _httpClient { get; set; }

    public ProfileService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<string>> GetProfiles()
    {
        //rest api call
        var ret = new List<string> { "kkk", "bbbb", "ccc" };

        return ret;
        //var ret = await _httpClient.GetFromJsonAsync<string>("/Introduce");
    }
}
