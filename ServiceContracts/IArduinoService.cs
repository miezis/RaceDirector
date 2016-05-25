using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceDirector.DTO;
using RaceDirector.Services;

namespace RaceDirector.ServiceContracts
{
    public interface IArduinoService
    {
        event EventHandler<UpdateTimesEventArgs> UpdateTimes; 
        void Reset(TrackConnectionParameters parameters);
        void Disconnect();
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
        void OnRelaySet();
    }
}
