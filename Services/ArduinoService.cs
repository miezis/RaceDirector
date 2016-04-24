using System;
using System.IO.Ports;
using RaceDirector.DTO;
using RaceDirector.Helpers;
using RaceDirector.ServiceContracts;

namespace RaceDirector.Services
{
    public class ArduinoService : IArduinoService
    {
        private static SerialPort _serialPort;
        private string _buffer;

        public event EventHandler<UpdateTimesEventArgs> UpdateTimes; 

        public void Reset(TrackConnectionParameters parameters)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }

            _serialPort = new SerialPort(parameters.Port, parameters.BaudRate)
            {
                ReadTimeout = 500,
                WriteTimeout = 500
            };

            _serialPort.DataReceived += DataReceivedHandler;
            _buffer = "";

            _serialPort.Open();

            foreach (var pin in parameters.LanePins)
            {
                var lane = parameters.LanePins.IndexOf(pin) + 1;
                ArduinoCommander.SetLane(lane, pin, this);
            }

            //temp
            this.StartSession();
        }

        public void StartSession()
        {
            ArduinoCommander.StartSession(this);
        }

        public void PauseSession()
        {
            throw new System.NotImplementedException();
        }

        public void ResumeSession()
        {
            throw new System.NotImplementedException();
        }

        public void StopSession()
        {
            throw new System.NotImplementedException();
        }

        public void Write(string message)
        {
            _serialPort.WriteLine(message);
        }

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = (SerialPort)sender;
            var readData = serialPort.ReadExisting();

            _buffer = _buffer + readData;

            if (_buffer.EndsWith("\n"))
            {
                var responses = _buffer.Split('\n');
                foreach (var response in responses)
                {
                    if (response.Length > 2)
                        ArduinoResponseParser.ParseResponse(response.Substring(0, response.Length - 1), this);
                }

                _buffer = "";
            }
        }

        public void OnUpdateTimes(int lane, int time)
        {
            var handler = UpdateTimes;

            // invoke the subscribed event-handler(s)
            handler?.Invoke(this, new UpdateTimesEventArgs(lane, time));
        }

        public void OnSessionStarted()
        {
            throw new System.NotImplementedException();
        }

        public void OnLaneSet()
        {
            throw new System.NotImplementedException();
        }

        public void OnMinTimeSet(int minTime)
        {
            throw new System.NotImplementedException();
        }
    }
}