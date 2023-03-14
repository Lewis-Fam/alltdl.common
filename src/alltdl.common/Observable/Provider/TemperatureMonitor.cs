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

            private IObserver<Temperature> _observer;

            private List<IObserver<Temperature>> _observers;

            public void Dispose()
            {
                if (_observer != null) _observers.Remove(_observer);
            }
        }

        public TemperatureMonitor()
        {
            observers = new List<IObserver<Temperature>>();
        }

        private List<IObserver<Temperature>> observers;

        public void GetTemperature()
        {
            // Create an array of sample data to mimic a temperature device.
            Nullable<Decimal>[] temps = {14.6m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m, 15.25m, 15.2m,
                15.4m, 15.45m, null };

            // Store the previous temperature, so notification is only sent after at least .1 change.
            Nullable<Decimal> previous = null;
            bool start = true;

            foreach (var temp in temps)
            {
                System.Threading.Thread.Sleep(2500);
                if (temp.HasValue)
                {
                    if (start || (Math.Abs(temp.Value - previous.Value) >= 0.1m))
                    {
                        Temperature tempData = new Temperature(temp.Value, DateTime.Now);
                        foreach (var observer in observers)
                            observer.OnNext(tempData);
                        previous = temp;
                        if (start) start = false;
                    }
                }
                else
                {
                    foreach (var observer in observers.ToArray())
                        if (observer != null) observer.OnCompleted();

                    observers.Clear();
                    break;
                }
            }
        }

        public IDisposable Subscribe(IObserver<Temperature> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }
    }
}