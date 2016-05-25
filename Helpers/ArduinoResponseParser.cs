using RaceDirector.ServiceContracts;
/*
Responses:
    Time Update:
    01:15484 (Lane1 - 15484 ms)

    Session Started:
    SS:15484 (Session Started 15484 ms from Arduino board power up)

    Lane Set:
    L:01P:07 (Lane 1 Set to Pin 7)

    Min time set:
    MT:4000 (Minimal time that is taken is set to 4s (4000ms) )
*/

namespace RaceDirector.Helpers
{
    public static class ArduinoResponseParser
    {
        public static void ParseResponse(string response, IArduinoService caller)
        {
            string[] data;
            switch (response[0])
            {
                case '0':
                    data = response.Split(':');

                    int lane = int.Parse(data[0]);
                    int time = int.Parse(data[1]);
                    caller.OnUpdateTimes(lane, time);
                    break;
                case 'S':
                    caller.OnSessionStarted();
                    break;
                case 'L':
                    caller.OnLaneSet();
                    break;
                case 'M':
                    data = response.Split(':');
                    int minTime = int.Parse(data[1]);
                    caller.OnMinTimeSet(minTime);
                    break;
                case 'P':
                    caller.OnRelaySet();
                    break;
            }    
        }
    }
}