using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace PublisherSubscriberDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            DisplayBanner();

            // Create the publisher
            Publisher publisher = new Publisher();
            Console.WriteLine("Publisher object created.");

            // Create the subscriber and subscribe to event
            Subscriber subscriber = new Subscriber(publisher);
            Console.WriteLine("Subscriber object created.");
            subscriber.SubscribeToPublisherEvent();
            Console.WriteLine("Subscriber subscribes to Publisher Event.");

            // Set the publisher status
            // An event will fire each time the status is set
            publisher.Status = Publisher.StatusEnum.Presubmission;
            publisher.Status = Publisher.StatusEnum.Submitted;
            publisher.Status = Publisher.StatusEnum.Approved;
            publisher.Status = Publisher.StatusEnum.Rejected;
            publisher.Status = Publisher.StatusEnum.Active;
            publisher.Status = Publisher.StatusEnum.Completed;
            publisher.Status = Publisher.StatusEnum.Closed;

            // Unsubscribe from the publisher event
            subscriber.UnsubscribeFromPublisherEvent();

            // Wait for user input
            Console.ReadLine();
        }

        private static void DisplayBanner()
        {
            const string title = "Publisher/Subscriber Demonstration";
            string divider = new string('-', title.Length + 4);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(divider);
            Console.WriteLine(title);
            Console.WriteLine("Note: Requires C# Version 6 and Up");
            Console.WriteLine();
            Console.WriteLine("This application shall demonstrate");
            Console.WriteLine("the publisher/subscriber pattern.");
            Console.WriteLine(divider);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

