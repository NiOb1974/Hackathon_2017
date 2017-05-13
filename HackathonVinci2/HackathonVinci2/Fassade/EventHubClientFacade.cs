using System;
using Microsoft.ServiceBus.Messaging;
using System.Text;
using Newtonsoft.Json;

namespace HackathonVinci2.Fassade
{
    public static class EventHubClientFacade
    {
        private static EventHubClient eventHubClient = null;
        private static string connectionString = "Endpoint=sb://vincihackathon.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=LcXXWFabXrUybMMSp5whCtvH0IKs8dHmjrwxFkzyQdg=";
        private static string eventHubName = "innereventhub";

        static EventHubClientFacade()
        {
            if (eventHubClient != null)
                return;
            eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
        }

        public static bool SendObject<TObject>(TObject objectToSend)
        {
            try
            {
                var jsonObject = JsonConvert.SerializeObject(objectToSend);
                eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(jsonObject)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}