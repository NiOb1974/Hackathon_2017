using System;
using Microsoft.ServiceBus.Messaging;
using System.Text;
using Newtonsoft.Json;

namespace HackathonVinci2.Fassade
{
    public static class EventHubClientFacade
    {
        private static EventHubClient eventHubClient = null;
        private static string connectionString = "Endpoint=sb://before.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=wiXmiv8Yl+Z2Loaaf0aZXl+yta20gMJwjZK0pVDv3VE=";
        private static string eventHubName = "default";

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