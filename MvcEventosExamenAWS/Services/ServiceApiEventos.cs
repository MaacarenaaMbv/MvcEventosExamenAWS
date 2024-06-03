using MvcEventosExamenAWS.Models;
using System.Net.Http.Headers;

namespace MvcEventosExamenAWS.Services
{
    public class ServiceApiEventos
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceApiEventos(KeysModel keys)
        {
            this.UrlApi = keys.ApiEventos;
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            string request = "api/eventos";
            List<Evento> data =
                await this.CallApiAsync<List<Evento>>(request);
            return data;
        }

        public async Task<Evento> FindEventoAsync(int id)
        {
            string request = "api/eventos/" + id;
            Evento data =
                await this.CallApiAsync<Evento>(request);
            return data;
        }

        public async Task<List<Evento>> GetEventosCategoriaAsync(int idcategoria)
        {
            string request = "api/eventos/findeventocategoria/" + idcategoria;
            List<Evento> data =
                await this.CallApiAsync<List<Evento>>(request);
            return data;
        }
 
    }
}
