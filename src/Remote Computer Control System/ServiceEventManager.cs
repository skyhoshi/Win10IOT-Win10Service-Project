using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote_Computer_Control_System
{
    class ServiceEventManager
    {
        public static void RecordEvent(string message, EventLogEntryType type)
        {
            System.Console.WriteLine(type.ToString() + ": " + message);
            System.Diagnostics.Debug.WriteLine(message, type.ToString());
            EventLog ev = new EventLog();
            try
            {
                string EventLogSourceName = "";
                ev.Log = "Application";
#if DEBUG
                EventLogSourceName = "Skyhoshi Control Service_Debug";
                if (!EventLog.SourceExists(EventLogSourceName))
                {
                    EventLog.CreateEventSource(EventLogSourceName, "Application");
                }
                ev.Source = EventLogSourceName;
#endif
#if STAGING
                EventLogSourceName = "Skyhoshi Control Service_Staging";
                if (!EventLog.SourceExists(EventLogSourceName))
                {
                    EventLog.CreateEventSource(EventLogSourceName, "Application");
                }
                ev.Source = EventLogSourceName;
#endif
#if RELEASE
                EventLogSourceName = "Skyhoshi Control Service";
                if (!EventLog.SourceExists(EventLogSourceName))
                {
                    EventLog.CreateEventSource(EventLogSourceName, "Application");
                }
                ev.Source = EventLogSourceName;
#endif
                if (ev.Source == string.Empty) { ev.Source = ""; }
                ev.WriteEntry(message, type);
            }
            catch (System.Security.SecurityException se)
            {
                //LogError("RecordEvent", "Settings.cs", ev.LogDisplayName + ":" + ev.Source + "-" + se.Message + " | Application must have administrative privilages. ");
            }
            catch (Exception e)
            {
                // Log error in database
                //LogError("RecordEvent", "Settings.cs", ev.LogDisplayName + ":" + ev.Source + "-" + e.Message);
            }
        }
    }
}
