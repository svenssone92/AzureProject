using BlazorApp.DataModels;

namespace BlazorApp.Services
{
    public class BasicModelService
    {
        private readonly HttpClient _httpClient;

        public BasicModelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BasicModelDTO>?> GetBasicModels()
        {
            try
            {
                var bM = await _httpClient.GetFromJsonAsync<IEnumerable<BasicModelDTO>>("api/BasicModel");
                return bM;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BasicModelDTO?> GetBasicModel(int id)
        {
            try
            {
                var bM = await _httpClient.GetFromJsonAsync<BasicModelDTO>($"api/BasicModel/{id}");
                return bM;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddBasicModelAsync(BasicModelDTO basicModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"api/BasicModel", basicModel);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteBasicModelAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/BasicModel/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateBasicModelAsync(BasicModelDTO basicModel)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/BasicModel/{basicModel.Id}", basicModel);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
