using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab 
{
    class DoorSensor : IDoorSensor
    {
        public event EventHandler<EventArgs> DoorOpened;
        public event EventHandler<EventArgs> DoorClosed;
        public void OnDoorOpened()
        {
            DoorOpened?.Invoke(this, EventArgs
        }

        public void OnDoorClosed()
        {
            DoorClosed?.Invoke(this, null);
        }
    }
}
