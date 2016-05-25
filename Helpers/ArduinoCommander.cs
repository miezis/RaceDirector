using RaceDirector.Enums;
using RaceDirector.ServiceContracts;

namespace RaceDirector.Helpers
{
    public static class ArduinoCommander
    {
        public static void SetLane(int lane, int pin, IArduinoService caller)
        {
            string command = $"!{(int)TrackCommands.SetLane:00}{pin:00}{lane:00}.";

            caller.Write(command);
        }

        public static void SetMinTime(int minTime, IArduinoService caller)
        {
            string command = $"!{(int) TrackCommands.SetMinTime:00}{minTime:0000}.";

            caller.Write(command);
        }

        public static void SetRelay(int relayPin, IArduinoService caller)
        {
            string command = $"!{(int) TrackCommands.SetRelay:00}{relayPin:00}.";

            caller.Write(command);
        }

        public static void StartSession(IArduinoService caller)
        {
            string command = $"!{(int)TrackCommands.StartSession:00}.";

            caller.Write(command);
        }

        public static void PauseSession(IArduinoService caller)
        {
            string command = $"!{(int)TrackCommands.PauseSession:00}.";

            caller.Write(command);
        }

        public static void StopSession(IArduinoService caller)
        {
            string command = $"!{(int)TrackCommands.StopSession:00}.";

            caller.Write(command);
        }
    }
}