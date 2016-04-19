﻿using RaceDirector.Enums;
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

        public static void StartSession(IArduinoService caller)
        {
            string command = $"!{(int)TrackCommands.StartSession:00}.";

            caller.Write(command);
        }
    }
}