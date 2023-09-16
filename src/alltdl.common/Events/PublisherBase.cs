using System;

namespace alltdl.Events
{
    /// <summary>
    /// The PublisherBase class.
    /// </summary>
    /// <remarks>
    /// <para>To learn how to publish events that conform to .NET guidelines. See the C# programming guide <a href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines">here</a></para>
    /// To review how to raise a base class event in derived classes. See the C# programming guide <a href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-raise-base-class-events-in-derived-classes">here</a>
    /// </remarks>
    public abstract class PublisherBase
    {
        // Declare the event using EventHandler<T>
        public virtual event EventHandler<BaseEventArgs>? RaiseCustomEvent;

        public abstract void DoSomething();

        //public virtual void DoSomething()
        //{
        //    // Write some code that does something useful here then raise the event. You can also raise an event before you execute a block of code.
        //    OnRaiseBaseEvent(new BaseEventArgs("Event triggered"));
        //}

        // Wrap event invocations inside a protected virtual method to allow derived classes to override the event invocation behavior
        protected virtual void OnRaiseCustomEvent(BaseEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of a race condition if the last subscriber unsubscribes immediately after the null check and before the
            // event is raised.
            EventHandler<BaseEventArgs>? raiseEvent = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (raiseEvent != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Message += $" at {DateTime.Now}";

                // Call to raise the event.
                raiseEvent(this, e);

                // Another way to call to raise the event.
                // raiseEvent.Invoke(this, e);
            }
        }
    }
}