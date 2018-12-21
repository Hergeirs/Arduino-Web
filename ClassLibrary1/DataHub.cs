using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Repository;
using Repository.Abstract;
using Repository.Models;

namespace ArduinoObserver
{
    public class DataHub : Hub
    {
        public DataHub(IHubContext<DataHub> context)
        {
            
        }
        public async void UpdateData(ArduinoData data)
        {
            var clients = Clients;
            IClientProxy user = clients?.All;
            var task = user?.SendAsync("UpdateData", data);
            if (task != null)
            {
                await task;
            }
        }
    }
}