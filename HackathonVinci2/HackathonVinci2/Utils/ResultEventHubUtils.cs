using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonVinci2.Utils
{
    public static class ResultEventHubUtils
    {
        public static string StorageKey = "9t57nZRVMnt0tXIekJlt7CQwgrf2wus2EdXBlnlrlWe5LaY7WSDY4Ow2kEFCAIU7ZPplBZzVaAghi89luufjXQ==";
        public static string StorageName = "vincihackathonstorage";
        public static string EventhubConnectionString = "Endpoint=sb://vincihackathon.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=LcXXWFabXrUybMMSp5whCtvH0IKs8dHmjrwxFkzyQdg=";
        public static string EventhubName = "resulteventhub";
        public static string StorageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", StorageName, StorageKey); 
    }
}