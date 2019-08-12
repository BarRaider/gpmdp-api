using System;
using System.Collections.Generic;
using System.Text;

namespace GPMDP_Api.Volume
{
    public static class Volume
    {
        public static int GetVolume(this Client c)
        {
            string result = c.GetCommand("volume", "getVolume").Result;
            if (Int32.TryParse(result, out int volume))
            {
                return volume;
            }
            c.RaiseError($"Invalid GetVolume received: {result}");
            
            return 0;
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
