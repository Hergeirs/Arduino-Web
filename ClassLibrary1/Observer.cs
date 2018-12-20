using Repository.Models;
using System;
using Repository.Abstract;

namespace ArduinoObserver
{
    public class Observer : IObserver<ArduinoData>, IDisposable
    {
        private readonly IArduinoDataRepository _repository;
        private IDisposable _unsubscriber;

        public Observer(IArduinoDataRepository repository)
        {
            _repository = repository;
        }

        public Observer(IObservable<ArduinoData> observable)
        {
            observable.Subscribe(this);
        }

        public void Subscribe(IObservable<ArduinoData> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }

        public void OnCompleted()
        {
            Console.WriteLine($"connection to  closed.");
            this.Unsubscribe();
        }

        public void OnError(Exception e)
        {
            Console.WriteLine($": Error in connection or transmission of data.");
        }

        // This runs when data from arduino is received.
        public void OnNext(ArduinoData value)
        {
            _repository.SaveData(value);
        }

        public void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }

        public void Dispose()
        {
            _unsubscriber?.Dispose();
        }
    }
}
