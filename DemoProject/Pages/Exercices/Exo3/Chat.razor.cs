using DemoProject.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace DemoProject.Pages.Exercices.Exo3
{
    public partial class Chat
    {
        HubConnection _hubConnection;

        public List<Message> Messages { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Messages = new List<Message>();

            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7223/chatHub").Build();

            _hubConnection.On("RecieveMessage", (Message m) =>
            {
                Messages.Add(m);
                StateHasChanged();
            });

            await _hubConnection.StartAsync();
        }

        public string Username { get; set; }
        public string Content { get; set; }

        public async Task SendMessage()
        {
            await _hubConnection.SendAsync("SendMessage", new Message
            {
                Username = Username,
                Content = Content,
                SendDate = DateTime.Now
            });
        }

        public async Task JoinGroup()
        {
            await _hubConnection.SendAsync("JoinGroup", "private");
            _hubConnection.On("RecieveFromGroup", (Message m) =>
            {
                Messages.Add(m);
                StateHasChanged();
            });
        }

        public async Task SendMessageToGroup()
        {
            await _hubConnection.SendAsync("SendToGroup","private", new Message
            {
                Username = Username,
                Content = Content,
                SendDate = DateTime.Now
            });
        }
    }
}
