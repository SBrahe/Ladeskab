﻿using System;
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

        private IState _currentState;
        public IDoorSensor DoorSensor { get; set; }
        public IUserOutput UserOutput { get; set; }
        public IRfidReader RfidReader { get; set; }
        public IChargeControl ChargeControl { get; set; }

        public StationControl(IDoorSensor doorSensor, IUserOutput userOutput, IRfidReader rfidReader, IChargeControl chargeControl)
        {
            //init states
            VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED=new VacantDoorClosedNoPhoneConnected(this);
            VACANT_DOOR_OPEN_NO_PHONE_CONNECTED=new VacantDoorOpenNoPhoneConnected(this);
            VACANT_DOOR_OPEN_PHONE_CONNECTED = new VacantDoorOpenPhoneConnected(this);
            VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID = new VacantDoorClosedPhoneConnectedAwaitingRFID(this);
            VACANT_DOOR_CLOSED_PHONE_CONNECTED_CHECKING_RFID = new VacantDoorClosedPhoneConnectedCheckingRFID(this);
            OCCUPIED_DOOR_CLOSED_AWAITING_RFID = new OccupiedDoorClosedAwaitingRFID(this);
            OCCUPIED_DOOR_CLOSED_CHECKING_RFID = new OccupiedDoorClosedCheckingRFID(this);

            //Initial state
            _currentState = VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED;

            //init properties
            DoorSensor = doorSensor;
            UserOutput = userOutput;
            RfidReader = rfidReader;
            ChargeControl = chargeControl;

            //Attaching events
            DoorSensor.DoorOpened += DoorOpenedHandler;
            DoorSensor.DoorClosed += DoorClosedHandler;
            RfidReader.RfidDetected += RfidDetectedHandler;
            ChargeControl.PhoneConnected += PhoneConnectedHandler;
            ChargeControl.PhoneDisconnected += PhoneDisconnectedHandler;
        }

        public void SetState(IState newState)
        { 
            _currentState = newState;
        }


        public void DoorOpenedHandler(object sender, EventArgs e)
        {
            _currentState.OnDoorOpened();
        }

        public void DoorClosedHandler(object sender, EventArgs e)
        {
            _currentState.OnDoorClosed();
        }

        public void PhoneConnectedHandler(object sender, EventArgs e)
        {
            _currentState.OnPhoneConnected();
        }

        public void PhoneDisconnectedHandler(object sender, EventArgs e)
        {
            _currentState.OnPhoneDisconnected();
        }

        public void RfidDetectedHandler(object sender, RfidDetectedEventArgs e)
        {
            _currentState.OnRfidDetected();
        }

    }
}
