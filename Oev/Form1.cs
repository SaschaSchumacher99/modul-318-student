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


                MessageBox.Show("From: " + from.Station.Name + "\n" +
                    "Abfahrt: " + validateDateTime(result.From.Departure) + "\n" +
                                "To: " + to.Station.Name + "\n" +
                                "Ankunft: " + validateDateTime(result.To.Arrival) + "\n" +
                                "Length" + result.Duration);


                Console.WriteLine(result.From.Departure);
            }
        }
            private String validateDateTime(String time) {

            DateTimeOffset dateTime = DateTimeOffset.Parse(time);
            String result = dateTime.ToString();

            result = result.Split('+')[0];

            return result;
            }

        private String validateDuration(String duration)
        {
            String days = duration.Split('d')[0];
            



            return days;
        }





        
    }
}
