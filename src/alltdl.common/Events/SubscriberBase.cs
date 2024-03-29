﻿using System;

namespace alltdl.Events
{
    public abstract class SubscriberBase
    {
        public SubscriberBase(string id, PublisherBase pub)
        {
            _id = id;

            // Subscribe to the event
            pub.RaiseCustomEvent += HandleCustomEvent!;
        }

        private readonly string _id;

        // Define what actions to take when the event is raised.
        private void HandleCustomEvent(object sender, BaseEventArgs e)
        {
            Console.WriteLine($"{_id} received this message: {e.Message}");
        }
    }
}