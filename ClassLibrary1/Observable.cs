using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace ArduinoObserver
{
    public class Observable :IDisposable, IObservable<ArduinoData>
    {
        private SerialPort _serialPort;

        public List<IObserver<ArduinoData>> Observers { get; private set; }

        public Observable()
        {
            Observers = new List<IObserver<ArduinoData>>();
            _serialPort = new SerialPort
            {
                PortName = "COM4",
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One
            };
            _serialPort.Open();
        }


        public void Dispose()
        {
            // closing 
            _serialPort.Close();
            _serialPort = null;

            foreach (var observer in Observers.ToArray())
                if (Observers.Contains(observer))
                    observer.OnCompleted();

            Observers.Clear();

        }



        public IDisposable Subscribe(IObserver<ArduinoData> observer)
        {
            if (!Observers.Contains(observer))
                Observers.Add(observer);
            return new Unsubscriber(Observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private readonly List<IObserver<ArduinoData>> _observers;
            private readonly IObserver<ArduinoData> _observer;

            public Unsubscriber(List<IObserver<ArduinoData>> observers, IObserver<ArduinoData> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void FetchData()
        {
            _serialPort.WriteLine("hey");
            var data =  new ArduinoData()
            {
                Moisture = (uint) _serialPort.ReadByte(),
                Temperature = _serialPort.ReadByte()
            };
            Notify(data);

        }


        public void Notify(ArduinoData? data)
        {
            foreach (var observer in Observers)
            {
                if (!data.HasValue)
                    observer.OnError(new Exception("Notifying corrupt data from arduino"));
                else
                    observer.OnNext(data.Value);
            }
        }



    }
}
