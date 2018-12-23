using System;
using System.Collections.Generic;
using E.Gardener.Hubs;
using Microsoft.AspNetCore.SignalR;
using Repository.Abstract;
using Repository.Models;
namespace ArduinoObserver
{
    public class DataPusherObserver: IObserver<ArduinoData>
    {
        private readonly IServiceProvider _provider;
        private readonly DataHub _dataHub;
        private IDisposable _unsubscriber;

        public DataPusherObserver(DataHub dataHub)//, IObservable<ArduinoData> observable)
        {
            _dataHub = dataHub;
//            Subscribe(observable);
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
        public virtual void OnNext(ArduinoData value)
        {
            _dataHub.UpdateData(value);
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}