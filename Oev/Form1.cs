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
        private String input;
        public Form1()
        {
            InitializeComponent();
            InitLists();
            testee = new Transport();
         //   this.comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
         //   this.comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
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
            abfahrtsTafel.Columns.Add("Abfahrt", 150, HorizontalAlignment.Left);
            abfahrtsTafel.Columns.Add("Kategorie", 150, HorizontalAlignment.Left);
            abfahrtsTafel.Columns.Add("Name", 150, HorizontalAlignment.Left);
            abfahrtsTafel.Columns.Add("Von", 150, HorizontalAlignment.Center);
            abfahrtsTafel.Columns.Add("Nach", 150, HorizontalAlignment.Left);
            



        }

        private void searchVerbindungen_Click(object sender, EventArgs e)
        {
            abfahrtsTafel.Items.Clear();
            testee = new Transport();
            Stations stations = testee.GetStations(comboBox2.Text);
            Station station = stations.StationList[0];
            String id = station.Id;

            

            StationBoardRoot stationBoard = testee.GetStationBoard(comboBox2.Text, id);


            foreach (StationBoard entries in stationBoard.Entries)
            {
                
                var item = new ListViewItem(new[] { entries.Stop.Departure.ToString(), entries.Category, entries.Name, station.Name , entries.To });
                abfahrtsTafel.Items.Add(item);
            }

        }

        private void tbVon_TextChanged(object sender, EventArgs e)
        {
           /* input = tbVon.Text;

                var stations = testee.GetStations(input);

                foreach (Station stationName in stations.StationList)
                {
                    tbVon.AutoCompleteCustomSource.Add(stationName.Name);
                }
            */
               


        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
        /*    
             input = comboBox1.Text;
            
           if(input.Length > 6) { 
                var stations = testee.GetStations(input);

                foreach (Station stationName in stations.StationList)
                {
                    comboBox1.AutoCompleteCustomSource.Add(stationName.Name);
                }
            this.comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            
    */
        }

        private void searchStation_Click(object sender, EventArgs e)
        {
            String input = comboBox1.Text;

            var stations = testee.GetStations(input);

            foreach (Station stationName in stations.StationList)
            {
                comboBox1.Items.Add(stationName.Name);
            }
            this.comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void searchStationAF_Click(object sender, EventArgs e)
        {
            String input = comboBox2.Text;

            var stations = testee.GetStations(input);

            foreach (Station stationName in stations.StationList)
            {
                comboBox2.Items.Add(stationName.Name);
            }
            this.comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }
    }
    }
 
