using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;
using HandyCrew.Models;

namespace HandyCrew.Messages
{
    public class DeviceLocationMessage : ValueChangedMessage<DeviceLocation>
    {
        public DeviceLocationMessage(DeviceLocation deviceLocation) : base(deviceLocation)
        {



        }

    }
}
