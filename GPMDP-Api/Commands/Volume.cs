using System;
using System.Collections.Generic;
using System.Text;

namespace GPMDP_Api.Volume
{
    public static class Volume
    {
        public static void GetVolume(this Client c)
        {
            c.SendCommand("volume", "getVolume");
        }

        public static void SetVolume(this Client c, int value)
        {
            c.SendCommand("volume", "setVolume", value);
        }

        public static void IncreaseVolume(this Client c, int amount = 5)
        {
            c.SendCommand("volume", "increaseVolume", amount);
        }

        public static void DecreaseVolume(this Client c, int amount = 5)
        {
            c.SendCommand("volume", "decreaseVolume", amount);
        }
    }
}
