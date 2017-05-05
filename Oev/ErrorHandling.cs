using SwissTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oev
{
    class ErrorHandling
    {
        public ErrorHandling()
        {

        }
        public void ShowError(String errorMessage, String title)
        {
            MessageBox.Show(errorMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public Boolean IsStationsNull(Stations stations)
        {
            return stations != null;
        }
        public Boolean IsConnectionsNull(Connections connections)
        {
            return connections != null;
        }
        public Boolean IsStationBoardNull(StationBoardRoot stationBoardRoot)
        {
            return stationBoardRoot != null;
        }

    }
}
