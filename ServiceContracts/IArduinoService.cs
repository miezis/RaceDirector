using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceDirector.DTO;

namespace RaceDirector.ServiceContracts
{
    public interface IArduinoService
    {
        void Reset(TrackConnectionParameters parameters);
        void StartSession();
        void PauseSession();
        void ResumeSession();
        void StopSession();
        void Write(string message);
        void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e);
        void OnUpdateTimes(int lane, int time);
        void OnSessionStarted();
        void OnLaneSet();
        void OnMinTimeSet(int minTime);
    }
}
