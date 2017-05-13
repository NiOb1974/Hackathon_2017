using System;
using Microsoft.ServiceBus.Messaging;
using System.Text;
using Newtonsoft.Json;

namespace HackathonVinci2.Fassade
{
    public static class EventHubClientFacade
    {
        private static EventHubClient eventHubClient = null;
        static string connectionString = "Endpoint=sb://vincihackathon.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=LcXXWFabXrUybMMSp5whCtvH0IKs8dHmjrwxFkzyQdg=";
        static string eventHubName = "innereventhub";

        public static void InitEventHubClient()
        {
            if (eventHubClient != null)
                return;
            eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
        }

        static bool SendingRandomMessage()
        {
            try
            {
                var message = Guid.NewGuid().ToString();
                Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, message);
                var jsonMessage = JsonConvert.SerializeObject(message);
                eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(jsonMessage)));
                return true;
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} > Exception: {1}", DateTime.Now, exception.Message);
                Console.ResetColor();
                return false;
            }
        }
    }
}