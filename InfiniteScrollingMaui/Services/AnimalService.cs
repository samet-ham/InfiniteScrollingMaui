using InfiniteScrollingMaui.Models;
using Newtonsoft.Json;

namespace InfiniteScrollingMaui.Services;

public class AnimalService
{
    public async Task<List<EntryDetails>> GetAnimalList()
    {
        var returnResponse = new List<EntryDetails>();    
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync("https://api.publicapis.org/entries");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                var deserializeContent = JsonConvert.DeserializeObject<MainResponse>(content);

                if (deserializeContent.Entries?.Count > 0)
                {
                    returnResponse = deserializeContent.Entries;
                }
            }
        }
        return returnResponse;
    }
}
