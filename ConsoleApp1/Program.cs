using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
             // var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("testmaor5");
             // Console.WriteLine(System.Convert.ToBase64String(plainTextBytes));
             // string CreateLinkUrl = "https://www.bet365partners.com/partnerscreativeapi/link-create?pid=149&p={0}&l=1";
             // Console.WriteLine(string.Format(CreateLinkUrl, System.Convert.ToBase64String(plainTextBytes)));
             //
             // var list = new List<string>() { "1", "2", "3" };
             // list.AddRange(null);
             
             var str = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");
             Console.WriteLine(str);

             ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("device-sync.sytl4r.ng.0001.use1.cache.amazonaws.com:6379");
             ISubscriber sub = redis.GetSubscriber();
             const string channel = "FlashStandingsScannerHost";
             var doAction = @"{  
                'ActionName': 'DoAction',  
                'Data': 'https://www.flashscore.com/football/argentina/copa-de-la-liga-profesional/standings/',
                 'ScannerName': 'Flash.Standings.FlashStandingsScanner',
                 
              }";

             var getConfigs = @"{  
                'ActionName': 'GetConfigurations',  
                'ScannerHostName': 'FlashStandingsScannerHost',
                'ScannerName': 'Flash.Standings.FlashStandingsScanner'
                 
              }";
             var setConfigs = @"{   
                'ActionName': 'SetConfigurations',  
                'ScannerName': 'Flash.Standings.FlashStandingsScanner',
                'ScannerHostName': 'FlashStandingsScannerHost',
                         
              }";
             var json = JObject.Parse(doAction);
             if (json.ContainsKey("ActionName"))
             {
                 var actionName = json["ActionName"]?.ToString();
                 switch (actionName)
                 {
                     case "DoAction":
                     {
                         json["Data"] = JObject.FromObject(new
                         {
                             URL = "https://www.flashscore.com/football/israel/ligat-ha-al/standings/?t=8CCDGhGU&ts=AJF8eYqC",
                         });
                         break;
                     }
                     case "GetConfigurations":
                     {
                         break;
                     }
                     case "SetConfigurations":
                     {
                         //["football", "basketball", "volleyball", "cricket", "american-football", "baseball", "handball"]
                         json["Data"] = JObject.FromObject(new
                         {
                             HostName = "FlashStandingsScannerHostDebug",
                             FlashStandingsFlashStandingsScanner = JObject.FromObject(new
                             {
                                 SportTypes = new[] { "football", "basketball", "volleyball", "cricket", "american-football", "baseball", "handball" },
                                 FullScanIntervalDays = "1.0",
                                 ParseAndUpdateIntervalMinutes = "1.0"
                             })
                         });
                         break;
                     }
                 }
             }

             // json["Data"] = JObject.FromObject(new
             // {
             //     HostName = "FlashStandingsScannerHostDebug",
             //     // URL = "https://www.flashscore.com/football/argentina/primera-c/",
             // });
             // json["Data"]["FlashStandingsFlashStandingsScanner"] = JObject.FromObject(new { SportTypes = new[] { "football" } });
             Console.WriteLine(json);
             Console.WriteLine(sub.Publish(channel, json.ToString()) == 1 ? "Success" : "Failed");
             Console.WriteLine(DateTime.UtcNow);
        }
    }
}