using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherSubscriberDemo
{
    public class Publisher
    {
        public enum StatusEnum
        {
            Presubmission = 0,
            Submitted,
            Active,
            Paused,
            Approved,
            Rejected,
            Completed,
            Closed
        };

        public class PublisherEventArgs : EventArgs
        {
            public Publisher.StatusEnum Status { get; private set; }
            public int Age { get; private set; }

            public PublisherEventArgs(Publisher.StatusEnum status) { Status = status; }
            public PublisherEventArgs(int age) { Age = age; }
        }

        public delegate void UpdateHandler(Publisher publisher, PublisherEventArgs args);
        public event UpdateHandler OnStatusUpdate;
        public event UpdateHandler OnAgeUpdate;

        private StatusEnum _status;
        public StatusEnum Status
        {
            get { return _status; }
            set
            {
                // Assign the status
                _status = value;

                // Raise the event
                OnStatusUpdate?.Invoke(this, new PublisherEventArgs(_status)); 
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnAgeUpdate?.Invoke(this, new PublisherEventArgs(_age));
            }
        }

    }
}
