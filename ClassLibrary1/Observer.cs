﻿using Repository.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Repository.Concrete;

namespace ArduinoObserver
{
    public class Observer : IObserver<ArduinoData>, IDisposable
    {
        private IDisposable _unsubscriber;
        private readonly EFDataLoggerPlantRepository _arduinoDataRepository;

        public Observer()//, IObservable<ArduinoData> observable)
        {
            _arduinoDataRepository = new EFDataLoggerPlantRepository(new EGardenerContext(
                new DbContextOptionsBuilder()
                   .UseSqlServer("Server=127.0.0.1;Database=EGarden;User Id=SA;Password=Password0").Options)
//                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=E.Gardener;Trusted_Connection=True;MultipleActiveResultSets=true").Options)
            );
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
           _arduinoDataRepository.SavePlantData(value);
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
