using Repository.Models;
using System;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Repository.Abstract;
using Repository.Concrete;

namespace ArduinoObserver
{
    public class Observer : IObserver<ArduinoData>, IDisposable
    {
        private readonly IServiceProvider _serviceCollection;
        private IDisposable _unsubscriber;
        private readonly EFDataLoggerPlantRepository _arduinoDataRepository;

        public Observer()//, IObservable<ArduinoData> observable)
        {
            _arduinoDataRepository = new EFDataLoggerPlantRepository(new EGardenerContext(
                new DbContextOptionsBuilder()
                   // .UseSqlServer("Server=127.0.0.1;Database=EGarden;User Id=SA;Password=Password0").Options)
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=E.Gardener;Trusted_Connection=True;MultipleActiveResultSets=true").Options)
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
