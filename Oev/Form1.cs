using SwissTransport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oev
{
    public partial class Form1 : Form
    {
        private ITransport testee;
        public Form1()
        {
            InitializeComponent();
            InitLists();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            testee = new Transport();
            var connections = testee.GetConnections(tbVon.Text, tbNach.Text);


            for(int i = 0; i < connections.ConnectionList.Count; i++) 
            {
                Connection result = connections.ConnectionList[i];

                ConnectionPoint from = result.From;
                ConnectionPoint to = result.To;

                Verbindung verbindung = new Verbindung(from, to, result);


                var item = new ListViewItem(new[] { verbindung.getStartStation(), verbindung.getEndStation(), verbindung.getDeparture(), verbindung.getArrival(), verbindung.getDuration() });
                
          
                LBverbindungen.Items.Add(item);

            }
        }


    
        private void InitLists()
        {
            LBverbindungen.View = View.Details;
            LBverbindungen.Columns.Add("Von", 150, HorizontalAlignment.Center);
            LBverbindungen.Columns.Add("Nach", 150, HorizontalAlignment.Center);
            LBverbindungen.Columns.Add("Abfahrt", 150, HorizontalAlignment.Center);
            LBverbindungen.Columns.Add("Ankunft", 150, HorizontalAlignment.Center);
            LBverbindungen.Columns.Add("Dauer", 60, HorizontalAlignment.Center);

            abfahrtsTafel.View = View.Details;
            abfahrtsTafel.Columns.Add("Von", 150, HorizontalAlignment.Center);
            abfahrtsTafel.Columns.Add("Nach", 150, HorizontalAlignment.Center);
            abfahrtsTafel.Columns.Add("Abfahrt", 150, HorizontalAlignment.Center);
            abfahrtsTafel.Columns.Add("Ankunft", 150, HorizontalAlignment.Center);
            abfahrtsTafel.Columns.Add("Dauer", 60, HorizontalAlignment.Center);



        }

        private void searchVerbindungen_Click(object sender, EventArgs e)
        {
            testee = new Transport();
            var stationBoard = testee.GetStationBoard("Sursee", "8502007");

           // var item = new ListViewItem(new[] { verbindung.getStartStation(), verbindung.getEndStation(), verbindung.getDeparture(), verbindung.getArrival(), verbindung.getDuration() });


            //LBverbindungen.Items.Add(item);

        }
    }
}
