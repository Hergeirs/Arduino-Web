using System;
using System.Collections.Generic;
using System.Text;

namespace ArduinoObserver
{
    public class Observer : IObserver<ArduinoData>
    {
        private IDisposable _unsubscriber;
        public ArduinoData data { get; private set; }

        public Observer(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public virtual void Subscribe(IObservable<ArduinoData> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine($"connection to {Name} closed.");
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine($"{Name}: Error in connection or transmission of data.");
        }

        // This runs when data from arduino is received.
        public virtual void OnNext(ArduinoData value)
        {
            data = value;
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}
