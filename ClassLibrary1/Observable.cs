using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ArduinoObserver
{

    public class Observable :IDisposable, IObservable<ArduinoData>
    {

        private const int _port = 8080;
        private readonly TcpListener _socket;
        public List<IObserver<ArduinoData>> Observers { get; private set; }

        public Observable()
        {
            Observers = new List<IObserver<ArduinoData>>();
            _socket = new TcpListener(IPAddress.Any,_port);
            start();
        }

        public void start() 
        {
            _socket.Start();
            new Thread(new ThreadStart(listen)).Start();

        }

        private void listen() {
            while(true) {
                var client = _socket.AcceptTcpClient();
                new Thread(() => listenToClient(client)).Start();
            }
        }

        private void listenToClient(TcpClient client) {
            while(client.Connected) {
                    var reader = client.GetStream();
                while(client.Available > 0) {
                    // while(reader.DataAvailable) {
                    byte[] buffer = new byte[2];
                    var data = new ArduinoData();

                    reader.Read(buffer,0,2);
                    data.PlantId = BitConverter.ToUInt16(buffer);
                    data.Temperature = reader.ReadByte();
                    
                    data.Moisture = (uint) reader.ReadByte();
                    
                    buffer = new byte[4];
                    
                    reader.Read(buffer,0,4);
                    data.Light = BitConverter.ToInt32(buffer);
                    data.Water = reader.ReadByte();

                    Notify(data);
                    // }
                }
                Thread.Sleep(1000);
            }
            client.Close();
        }


        public void Dispose()
        {
            // closing 
            _socket.Stop();

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

        private static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }



    }
}
