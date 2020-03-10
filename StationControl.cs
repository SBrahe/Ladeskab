using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.States;

namespace Ladeskab
{
    class StationControl
    {
        public IState VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED { get; set; }
        public IState VACANT_DOOR_OPEN_NO_PHONE_CONNECTED { get; set; }
        public IState VACANT_DOOR_OPEN_PHONE_CONNECTED { get; set; }
        public IState VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID { get; set; }
        public IState VACANT_DOOR_CLOSED_PHONE_CONNECTED_CHECKING_RFID { get; set; }
        public IState OCCUPIED_DOOR_CLOSED_AWAITING_RFID { get; set; }
        public IState OCCUPIED_DOOR_CLOSED_CHECKING_RFID { get; set; }

        private IState currentState;

        public StationControl()
        {
            VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED=new VacantDoorClosedNoPhoneConnected(this);
            VACANT_DOOR_OPEN_NO_PHONE_CONNECTED=new VacantDoorOpenNoPhoneConnected(this);
            VACANT_DOOR_OPEN_PHONE_CONNECTED = new VacantDoorOpenPhoneConnected(this);
            VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID = new VacantDoorClosedPhoneConnectedAwaitingRFID(this);
            VACANT_DOOR_CLOSED_PHONE_CONNECTED_CHECKING_RFID = new VacantDoorClosedPhoneConnectedCheckingRFID(this);
            OCCUPIED_DOOR_CLOSED_AWAITING_RFID = new OccupiedDoorClosedAwaitingRFID(this);
            OCCUPIED_DOOR_CLOSED_CHECKING_RFID = new OccupiedDoorClosedCheckingRFID(this);


            currentState = VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED;
        }

        public void SetState(IState newState)
        {
            this.currentState = newState;
        }


        public void DoorOpenedHandler(object sender, EventArgs e)
        {
            currentState.OnDoorOpened();
        }

        public void DoorClosedHandler(object sender, EventArgs e)
        {
            currentState.OnDoorClosed();
        }

        public void PhoneConnectedHandler(object sender, EventArgs e)
        {
            currentState.OnPhoneConnected();
        }

        public void PhoneDisconnectedHandler(object sender, EventArgs e)
        {
            currentState.OnPhoneDisconnected();
        }

        public void RfidDetectedHandler(object sender, EventArgs e)
        {
            currentState.OnRfidDetected();
        }

    }
}
