using Microsoft.AspNetCore.SignalR;
using Repository.Models;

namespace Hubs.Hubs
{
    public class DataHub : Hub
    {
        public async void UpdateData(ArduinoData data)
        {
            var clients = Clients;
            if (clients == null) return;
            
            await clients.All.SendAsync("UpdateData", data);
        }
    }
}