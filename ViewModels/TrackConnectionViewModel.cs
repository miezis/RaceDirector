﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using RaceDirector.Commands;
using RaceDirector.DTO;
using RaceDirector.Models;
using RaceDirector.ServiceContracts;

namespace RaceDirector.ViewModels
{
    public class TrackConnectionViewModel
    {
        private TrackConnection _trackConnection;
        private IArduinoService _arduinoService;
        private static readonly List<int> _validBaudRates = new List<int> {300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, 115200};

        public TrackConnection TrackConnection => _trackConnection;
        public ICommand ConnectToTrackCommand { get; private set; }

        public bool CanConnect
        {
            get
            {
                if (TrackConnection == null)
                {
                    return false;
                }

                return !String.IsNullOrWhiteSpace(TrackConnection.Port)
                       && _validBaudRates.Contains(TrackConnection.BaudRate);
            }
        }

        public TrackConnectionViewModel()
        {
            _trackConnection = new TrackConnection();
            _arduinoService = Container.Resolve<IArduinoService>();

            ConnectToTrackCommand = new ConnectToTrackCommand(this);
        }

        public void ConnectToTrack()
        {
            var connectionParameters = new TrackConnectionParameters
            {
                BaudRate = _trackConnection.BaudRate,
                Port = _trackConnection.Port,
                MinTime = _trackConnection.MinTime,
                LanePins = _trackConnection.LanePins.ToList()
            };

            _arduinoService.Reset(connectionParameters);
        }
    }
}
