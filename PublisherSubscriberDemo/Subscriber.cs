using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PublisherSubscriberDemo
{
    public class Subscriber
    {
        private Publisher _publisher = null;

        public Subscriber(Publisher publisher)
        {
            this._publisher = publisher;
        }

        public void HandleJobStatusUpdate(Publisher sender, Publisher.PublisherEventArgs args)
        {
            Console.WriteLine($"Publisher Event Fired.  Subscriber handles event. -> Publisher.Status == {args.Status.ToString()}");
        }

        public void SubscribeToPublisherEvent()
        {
            // Connect the event handler here to the publisher
            _publisher.OnStatusUpdate += HandleJobStatusUpdate;
        }

        public void UnsubscribeFromPublisherEvent()
        {
            // Disconnect the event handler from the publishere
            _publisher.OnStatusUpdate -= HandleJobStatusUpdate;
        }
    }
}


