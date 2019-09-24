using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GPMDP_Api.Extras
{
    public static class Extras
    {
        public static async Task<string> GetTrackUrl(this Client c)
        {
            //this is not working at the moment...
            return await c.GetCommand("extras", "getTrackUrl");
        }
    }
}
