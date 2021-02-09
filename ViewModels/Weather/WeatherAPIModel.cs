﻿
using System.Collections.Generic;

namespace ViewModels
{
    public class WeatherAPIModel
    {
        public Root root { get; set; }
        public class Geometry
        {
            public string type { get; set; }
            public List<double> coordinates { get; set; }
        }

        public class Distance
        {
            public double value { get; set; }
            public string unitCode { get; set; }
        }

        public class Bearing
        {
            public int value { get; set; }
            public string unitCode { get; set; }
        }

        public class Properties
        {
            public string city { get; set; }
            public string state { get; set; }
            public Distance distance { get; set; }
            public Bearing bearing { get; set; }
            public string Id { get; set; }
            public string Type { get; set; }
            public string cwa { get; set; }
            public string forecastOffice { get; set; }
            public string gridId { get; set; }
            public int gridX { get; set; }
            public int gridY { get; set; }
            public string forecast { get; set; }
            public string forecastHourly { get; set; }
            public string forecastGridData { get; set; }
            public string observationStations { get; set; }
            public RelativeLocation relativeLocation { get; set; }
            public string forecastZone { get; set; }
            public string county { get; set; }
            public string fireWeatherZone { get; set; }
            public string timeZone { get; set; }
            public string radarStation { get; set; }
        }

        public class RelativeLocation
        {
            public string type { get; set; }
            public Geometry geometry { get; set; }
        }

        public class Root
        {
            public Properties properties { get; set; }
            public string id { get; set; }
            public string type { get; set; }
            public Geometry geometry { get; set; }
        }
    }
}
