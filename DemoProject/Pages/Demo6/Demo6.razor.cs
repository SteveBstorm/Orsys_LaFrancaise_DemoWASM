using DemoProject.Models;
using DemoProject.Tools;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Runtime.CompilerServices;
using System.Text;

namespace DemoProject.Pages.Demo6
{
    public partial class Demo6
    {
        [Inject]
        public IJSRuntime _js { get; set; }

        [Inject]
        public IServiceProvider service { get; set; }
        public User UserLogin { get; set; }
        private HttpClient _httpClient;
        public Demo6()
        {
            UserLogin = new User();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7223/api/");
        }

        public async Task OnSubmit()
        {
            string json = JsonConvert.SerializeObject(UserLogin);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
        
            using(HttpResponseMessage message = await _httpClient.PostAsync("user", content))
            {
                if (message.IsSuccessStatusCode)
                {
                    string token = await message.Content.ReadAsStringAsync();
                    await _js.InvokeVoidAsync("localStorage.setItem", "token", token);
                    ((AuthProvider)service.GetService<AuthenticationStateProvider>()).NotifyUserChanged();
                }
            }
        }
    }
}
