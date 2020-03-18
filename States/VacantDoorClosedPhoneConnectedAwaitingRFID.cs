using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.States
{
    class VacantDoorClosedPhoneConnectedAwaitingRFID : IState
    {
        public StationControl StationControlRef { get; set; }

        public VacantDoorClosedPhoneConnectedAwaitingRFID(StationControl stationControlRef)
        {
            StationControlRef = stationControlRef;
        }
        public void OnDoorClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDoorOpened()
        {
            throw new NotImplementedException();
        }

        public void OnRfidDetected()
        {
            throw new NotImplementedException();
        }

        public void OnPhoneConnected()
        {
            throw new NotImplementedException();
        }

        public void OnPhoneDisconnected()
        {
            throw new NotImplementedException();
        }
    }
}
