/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System;

namespace alltdl.Observable.Reporter
{
    public class TemperatureReporter : IObserver<Temperature>
    {
        private bool first = true;

        private Temperature last;

        private IDisposable? _unsubscriber;

        public virtual void OnCompleted()
        {
            Console.WriteLine("Additional temperature data will not be transmitted.");
        }

        public virtual void OnError(Exception error)
        {
            // Do nothing.
        }

        public virtual void OnNext(Temperature value)
        {
            Console.WriteLine("The temperature is {0}°C at {1:g}", value.Degrees, value.Date);
            if (first)
            {
                last = value;
                first = false;
            }
            else
            {
                Console.WriteLine("   Change: {0}° in {1:g}", value.Degrees - last.Degrees,
                    value.Date.ToUniversalTime() - last.Date.ToUniversalTime());
            }
        }

        public virtual void Subscribe(IObservable<Temperature> provider)
        {
            _unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber?.Dispose();
        }
    }
}