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

        private readonly TcpListener _socket;
        public List<IObserver<ArduinoData>> Observers { get; private set; }

        public Observable()
        {
            Observers = new List<IObserver<ArduinoData>>();
            _socket = new TcpListener(GetLocalIPAddress(),80);
        }

        public void start() 
        {
            _socket.Start();
            new Thread(new ThreadStart(listen)).Start();

        }

        private void listen() {
            while(true) {
                new Thread(() => listenToClient(_socket.AcceptTcpClient())).Start();
            }
        }

        private void listenToClient(TcpClient client) {
            while(client.Connected) {
                while(client.Available > 0) {
                    var reader = client.GetStream();
                    while(reader.DataAvailable) {
                        var data = new ArduinoData();
                        data.Temperature = reader.ReadByte();
                        byte[] buffer = new byte[3];
                        reader.Read(buffer,0,2);
                        data.Moisture = BitConverter.ToUInt16(buffer);
                        buffer = new byte[3];
                        reader.Read(buffer,0,3);
                        data.Light = BitConverter.ToInt32(buffer);
                        data.Water = reader.ReadByte();

                        Notify(data);
                    }
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
