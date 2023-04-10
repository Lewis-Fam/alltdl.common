using System;

namespace alltdl.Events
{
    public abstract class EventPublisherBase
    {
        // Declare the event using EventHandler<T>
        public event EventHandler<CustomEventArgs>? RaiseCustomEvent;

        public void DoSomething()
        {
            // Write some code that does something useful here then raise the event. You can also raise an event before you execute a block of code.
            OnRaiseCustomEvent(new CustomEventArgs("Event triggered"));
        }

        // Wrap event invocations inside a protected virtual method to allow derived classes to override the event invocation behavior
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of a race condition if the last subscriber unsubscribes immediately after the null check and before the
            // event is raised.
            EventHandler<CustomEventArgs>? raiseEvent = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (raiseEvent != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Message += $" at {DateTime.Now}";

                // Call to raise the event.
                raiseEvent(this, e);
            }
        }
    }
}