using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.MSMQServices
{
    public class MSMQ
    {
        private readonly MessageQueue messageQueue = new MessageQueue();

        public MSMQ()
        {
            this.messageQueue.Path = @".\private$\EmployeeQueue";
            if (MessageQueue.Exists(this.messageQueue.Path))
            {
                messageQueue = new MessageQueue(@".\private$\EmployeeQueue");
            }
            else
            {
                MessageQueue.Create(this.messageQueue.Path);
            }
        }

        public void AddToQueue(string message)
        {
            this.messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            this.messageQueue.ReceiveCompleted += this.ReceiveFromQueue;

            this.messageQueue.Send(message);

            this.messageQueue.BeginReceive();

            this.messageQueue.Close();
        }

        /// <summary>
        /// Method to fetch message from MSMQ.
        /// </summary>
        /// <param name=""sender""></param>
        /// <returns></returns>
        public void ReceiveFromQueue(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                var msg = this.messageQueue.EndReceive(e.AsyncResult);

                string data = msg.Body.ToString();

                // Process the logic be sending the message

                // Restart the asynchronous receive operation.
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\HP\source\repos\EmployeePayrollWebAPI\BusinessLayer\MSMQServices\msmq.txt", true))
                {
                    file.WriteLine(data);
                }

                this.messageQueue.BeginReceive();
            }
            catch (MessageQueueException qexception)
            {
                Console.WriteLine(qexception);
            }
        }
    }
}
