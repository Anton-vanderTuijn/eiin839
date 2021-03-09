using System;
using System.Collections.Generic;
using System.Text;
using System.Device.Location;

namespace ContratList
{
    public class Position 
    {
        public double lat { get; set; }
        public double lng { get; set; }

        public Position(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }

        public Position()
        {
        }

        public Station findNearestStation(List<Station> stationList, Position pos)
        {

            GeoCoordinate geoCoordinate = new GeoCoordinate(pos.lat, pos.lng);
            double max = Int32.MaxValue;
            Station nearestStation = null;

            foreach (Station s in stationList)
            {
                double dist = geoCoordinate.GetDistanceTo(new GeoCoordinate(s.position.lat, s.position.lng));

                if (dist < max)
                {
                    max = dist;
                    nearestStation = s;
                }
            }

            return nearestStation;
        }
    }
}
