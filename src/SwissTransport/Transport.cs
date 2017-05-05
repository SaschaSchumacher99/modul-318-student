using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace SwissTransport
{
    public class Transport : ITransport
    {
        public Stations GetStations(string query)
        {
            try
            {
                var request = CreateWebRequest("http://transport.opendata.ch/v1/locations?query=" + query);
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();

                if (responseStream != null)
                {
                    var message = new StreamReader(responseStream).ReadToEnd();
                    var stations = JsonConvert.DeserializeObject<Stations>(message);
                    return stations;
                }
            }
            catch (WebException)
            {
                return null;
            }

            return null;
        }

        public StationBoardRoot GetStationBoard(string station, string id)
        {
            try
            {
                var request = CreateWebRequest("http://transport.opendata.ch/v1/stationboard?Station=" + station + "&id=" + id);
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();

                if (responseStream != null)
                {
                    var readToEnd = new StreamReader(responseStream).ReadToEnd();
                    var stationboard =
                        JsonConvert.DeserializeObject<StationBoardRoot>(readToEnd);
                    return stationboard;
                }
            }
            catch (WebException)
            {
                return null;
            }

            return null;
        }

        public Connections GetConnections(string fromStation, string toStattion)
        {
            try
            {
                var request = CreateWebRequest("http://transport.opendata.ch/v1/connections?from=" + fromStation + "&to=" + toStattion);
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();

                if (responseStream != null)
                {
                    var readToEnd = new StreamReader(responseStream).ReadToEnd();
                    var connections =
                        JsonConvert.DeserializeObject<Connections>(readToEnd);
                    return connections;
                }
            }
            catch (WebException)
            {
                return null;
            }

            return null;
        }
        public Connections GetConnections(string fromStation, string toStattion, string date,string time)
        {
            try
            {
                var request = CreateWebRequest("http://transport.opendata.ch/v1/connections?from=" + fromStation + "&to=" + toStattion + "&date=" + date + "&time=" + time);
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();

                if (responseStream != null)
                {
                    var readToEnd = new StreamReader(responseStream).ReadToEnd();
                    var connections =
                        JsonConvert.DeserializeObject<Connections>(readToEnd);
                    return connections;
                }
            }
            catch (WebException)
            {
                return null;
            }

            return null;
        }
        public Connections GetConnections(string fromStation, string toStattion, string date, string time,string via)
        {
            try
            {
                var request = CreateWebRequest("http://transport.opendata.ch/v1/connections?from=" + fromStation + "&to=" + toStattion + "&date=" + date + "&time=" + time + "&via=" + via);
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();

                if (responseStream != null)
                {
                    var readToEnd = new StreamReader(responseStream).ReadToEnd();
                    var connections =
                        JsonConvert.DeserializeObject<Connections>(readToEnd);
                    return connections;
                }
            }
            catch (WebException)
            {
                return null;
            }

            return null;
        }

        private static WebRequest CreateWebRequest(string url)
        {
            var request = WebRequest.Create(url);
            var webProxy = WebRequest.DefaultWebProxy;

            webProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Proxy = webProxy;
            
            return request;
        }
    }
}
