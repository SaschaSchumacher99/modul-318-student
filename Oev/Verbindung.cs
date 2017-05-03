using SwissTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oev
{
    class Verbindung
    {
        private ConnectionPoint from;
        private ConnectionPoint to;
        private Connection result;
       

        

        public Verbindung(ConnectionPoint from, ConnectionPoint to, Connection result)
        {
            this.from = from;
            this.to = to;
            this.result = result;
            

        }
        public String getStartStation()
        {
            return from.Station.Name;

        }
        public String getEndStation()
        {
            return to.Station.Name;
        }
        public String getDeparture()
        {
            return ValidateDateTime(result.From.Departure);
        }
        public String getArrival()
        {
            return ValidateDateTime(result.To.Arrival);
        }
        public String getDuration()
        {
          return  ValidateDuration(result.Duration);
        }

        private  String ValidateDateTime(String time)
        {

            DateTimeOffset dateTime = DateTimeOffset.Parse(time);
            String result = dateTime.ToString();

            result = result.Split('+')[0];

            return result;
        }

        private String ValidateDuration(String duration)
        {

            int days = Convert.ToInt32(duration.Substring(0, 2));
            int hours = Convert.ToInt32(duration.Substring(3, 2));
            int mins = Convert.ToInt32(duration.Substring(6, 2));
            int durationInMins = (days * 24) + (hours * 60) + mins;


            return Convert.ToString(durationInMins) + " min";
        }


    }
}
