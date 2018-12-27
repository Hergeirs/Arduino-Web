using System;
using System.Runtime.Serialization;
using System.Threading;

using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Repository.Models;
namespace ArduinoObserver
{
    public class DataPusherObserver: IObserver<ArduinoData>
    {
        HubConnection connection;

        private IDisposable _unsubscriber;

        public DataPusherObserver()//, IObservable<ArduinoData> observable)
        {
            connection = new HubConnectionBuilder().WithUrl("http://localhost:5001/dataHub").Build();
        }

        public virtual void Subscribe(IObservable<ArduinoData> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine($"connection closed.");
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine($"Error in connection or transmission of data.");
        }

        // This runs when data from arduino is received.
        public virtual async void OnNext(ArduinoData value)
        {
            await connection.StartAsync();
            await connection.InvokeAsync("UpdateData", value, CancellationToken.None);
            await connection.StopAsync();
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}