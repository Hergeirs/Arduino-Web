using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Repository;
using Repository.Abstract;
using Repository.Models;

namespace ArduinoObserver
{
    public class DataHub : Hub
    {
        public async void UpdateData(ArduinoData data)
        {
            
            await
                Clients
                .User(data.Plant.ApplicationUser.Id)
                .SendAsync("UpdateData",data);
        }
    }
}