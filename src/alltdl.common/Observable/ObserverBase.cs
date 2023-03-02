/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

namespace alltdl.Observable;

public struct Temperature
{
    public Temperature(decimal temperature, DateTime dateAndTime)
    {
        this.temp = temperature;
        this.tempDate = dateAndTime;
    }

    private decimal temp;

    private DateTime tempDate;

    public DateTime Date
    { get { return this.tempDate; } }

    public decimal Degrees
    { get { return this.temp; } }
}

//public abstract class ObserverBase<T> : IObserver<T>
//{
//    private IDisposable unsubscriber;
//    private bool first = true;
//    private T last;

// public virtual void Subscribe(IObservable<T> provider) { unsubscriber = provider.Subscribe(this); }

// public virtual void Unsubscribe() { unsubscriber.Dispose(); }

// public abstract void OnCompleted();

// public abstract void OnError(Exception error);

//    public abstract void OnNext(T value);
//}