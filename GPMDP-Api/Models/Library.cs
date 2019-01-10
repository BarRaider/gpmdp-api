﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPMDP_Api.Models
{

    public class Library : Message
    {
        [JsonProperty("payload")]
        new public Contents Payload { get; set; }
    }

    public class Contents
    {
        public Album[] albums { get; set; }
        public Artist[] artists { get; set; }
        public Track[] tracks { get; set; }
    }
}
