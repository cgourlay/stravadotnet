﻿using System;
using System.Device.Location;
using Newtonsoft.Json.Linq;

namespace SwimBikeRun.Strive.Model.Converters
{
    public class GeoCoordinateConverter : JsonArrayConverter<GeoCoordinate>
    {
        protected override GeoCoordinate Create(Type @type, JArray json)
        {
            return json != null ? new GeoCoordinate((double)json.First, (double)json.Last) : null;
        }
    }
}
