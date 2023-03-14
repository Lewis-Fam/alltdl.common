/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System;
using System.Collections.Generic;

namespace alltdl.Observable.Provider
{
    public class TemperatureMonitor : IObservable<Temperature>
    {
        private class Unsubscriber : IDisposable
        {
            public Unsubscriber(List<IObserver<Temperature>> observers, IObserver<Temperature> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            private readonly IObserver<Temperature> _observer;

            private readonly List<IObserver<Temperature>> _observers;

            public void Dispose()
            {
                _observers.Remove(_observer);
            }
        }

        public TemperatureMonitor()
        {
            _observers = new List<IObserver<Temperature>>();
        }

        private readonly List<IObserver<Temperature>> _observers;

        public void GetTemperature()
        {
            // Create an array of sample data to mimic a temperature device.
            Nullable<Decimal>[] temps = {14.6m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m, 15.25m, 15.2m,
                15.4m, 15.45m, null };

            // Store the previous temperature, so notification is only sent after at least .1 change.
            decimal? previous = null;
            bool start = true;

            foreach (var temp in temps)
            {
                System.Threading.Thread.Sleep(2500);
                if (temp.HasValue)
                {
                    if (previous != null && (start || (Math.Abs(temp.Value - previous.Value) >= 0.1m)))
                    {
                        Temperature tempData = new Temperature(temp.Value, DateTime.Now);
                        foreach (var observer in _observers)
                            observer.OnNext(tempData);
                        previous = temp;
                        if (start) start = false;
                    }
                }
                else
                {
                    foreach (var observer in _observers.ToArray())
                        observer.OnCompleted();

                    _observers.Clear();
                    break;
                }
            }
        }

        public IDisposable Subscribe(IObserver<Temperature> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
        }
    }
}