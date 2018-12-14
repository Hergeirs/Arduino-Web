using System;
using System.Collections.Generic;
using System.Text;
using Repository.Concrete;
using Repository.Models;

namespace ArduinoObserver
{
    public class Observer : IObserver<ArduinoData>
    {
        private IDisposable _unsubscriber;
        public EFArduinoDataRepository ArduinoDataRepository { get; set; }

      
        public void Subscribe(IObservable<ArduinoData> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine($"connection to observer closed.");
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine($"Observer: Error in connection or transmission of data.");
        }

        // This runs when data from arduino is received.
        public virtual void OnNext(ArduinoData value)
        {
            ArduinoDataRepository.SaveData(value);
           // Data.Add(value);
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}
