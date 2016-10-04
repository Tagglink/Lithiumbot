using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Lithiumbot.Modules.CustomCommands
{
    public class CustomCommClient : IDisposable {

        private string _endpoint;
        private HttpClient _client;

        public CustomCommClient() {
            _endpoint = GlobalSettings.Custom.Endpoint;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_endpoint);
        }

        public async Task<IEnumerable<Command>> GetCommands() {
            var response = await _client.GetAsync("api/commands");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IEnumerable<Command>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Command> AddCommand(Command com) {
            var response = await _client.PostAsync("api/commands", new StringContent(JsonConvert.SerializeObject(com), System.Text.Encoding.UTF8, "application/json") );
            //response.EnsureSuccessStatusCode();
            if (response.StatusCode != System.Net.HttpStatusCode.InternalServerError && response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new HttpRequestException();
            return JsonConvert.DeserializeObject<Command>(await response.Content.ReadAsStringAsync());
        }

        public async Task RemoveCommand(Command com) {
            var response = await _client.DeleteAsync($"api/commands/{com.CommandId}");
            response.EnsureSuccessStatusCode();
        }

        public void Dispose() {
            _client.Dispose();
        }

    }
}
