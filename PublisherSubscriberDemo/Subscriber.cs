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
            Console.WriteLine($"Publisher Status Event Fired.  Subscriber handles event. -> Publisher.Status == {args.Status.ToString()}");
        }

        public void HandleAgeUpdate(Publisher sender, Publisher.PublisherEventArgs args)
        {
            Console.WriteLine($"Publisher Age Update Event Fired.  Subscriber handles event. -> Publisher.Age == {args.Age.ToString()}");
        }

        public void SubscribeToPublisherEvents()
        {
            // Connect the event handlers here to the publisher
            _publisher.OnStatusUpdate += HandleJobStatusUpdate;
            _publisher.OnAgeUpdate += HandleAgeUpdate;
        }

        public void UnsubscribeFromPublisherEvents()
        {
            // Disconnect the event handlers from the publisher
            _publisher.OnStatusUpdate -= HandleJobStatusUpdate;
            _publisher.OnAgeUpdate -= HandleAgeUpdate;
        }
    }
}


