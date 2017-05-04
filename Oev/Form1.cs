
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
    public partial class OevVerbindungen : Form
    {
        private ITransport testee;
        private String input;
        private bool needAutoCompleteUpdate = false;

        public OevVerbindungen()
        {
            InitializeComponent();
            InitLists();
            testee = new Transport();
            dTPTime.Format = DateTimePickerFormat.Custom;
            dTPTime.CustomFormat = "dd.MM.yyyy | HH:mm";
            LoadToolTip();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LBverbindungen.Items.Clear();

            String inputTime = dTPTime.Text;
            var date = DateTime.Parse(inputTime.Substring(0, 10));
            String formattetDate = date.ToString("yyyy-MM-dd");
            String time = inputTime.Substring(12, 6);


            var connections = testee.GetConnections(tbVon.Text, tbNach.Text, formattetDate, time);

            for (int i = 0; i < connections.ConnectionList.Count; i++)
            {
                Connection result = connections.ConnectionList[i];

                ConnectionPoint from = result.From;
                ConnectionPoint to = result.To;

                Verbindung verbindung = new Verbindung(from, to, result);


                var item = new ListViewItem(new[] { verbindung.getStartStation(), verbindung.getEndStation(), verbindung.getDeparture(), verbindung.getArrival(), verbindung.getDuration() });

                LBverbindungen.Items.Add(item);

            }
        }

        public void LoadToolTip()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.autocomplete, "Nach vier Zeichen kurz warten bis die Ergebnisse angezeit werden!");
            toolTip1.SetToolTip(this.emailhint, "Du kannst deine ausgewählte Verbindung ganz einfach per Email senden.\n Dazu machst du einen Doppelklick auf die Startstation (Von Station)!");
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
            Stations stations = testee.GetStations(comboBox2.Text);
            Station station = stations.StationList[0];
            String id = station.Id;

            StationBoardRoot stationBoard = testee.GetStationBoard(comboBox2.Text, id);


            foreach (StationBoard entries in stationBoard.Entries)
            {
                var item = new ListViewItem(new[] { entries.Stop.Departure.ToString(), entries.Category, entries.Name, station.Name, entries.To });
                abfahrtsTafel.Items.Add(item);
            }

        }

        private void tbVon_TextChanged(object sender, EventArgs e)
        {
            if (autocomplete.Checked)
            {

                input = tbVon.Text;

                if (input.Length > 3)
                {
                    needAutoCompleteUpdate = true;
                }
                else
                {
                    needAutoCompleteUpdate = false;
                }
                if (needAutoCompleteUpdate)
                {
                    var stations = testee.GetStations(input);

                    foreach (Station stationName in stations.StationList)
                    {
                        tbVon.AutoCompleteCustomSource.Add(stationName.Name);
                    }
                    this.tbVon.AutoCompleteMode = AutoCompleteMode.Suggest;
                    this.tbVon.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else
            {
                this.tbVon.AutoCompleteMode = AutoCompleteMode.None;
            }
        }

        private void searchStation_Click(object sender, EventArgs e)
        {
            String input = tbVon.Text;

            var stations = testee.GetStations(input);

            foreach (Station stationName in stations.StationList)
            {
                tbVon.Items.Add(stationName.Name);
            }
            this.tbVon.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.tbVon.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
        private void openKarte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Stations stations = testee.GetStations(tbVon.Text);

            if (stations.StationList.Count > 0)
            {
                Station station = stations.StationList[0];
                System.Diagnostics.Process.Start("https://www.google.ch/maps/search/" + station.Name + " haltestelle");
            }
            else
            {
                MessageBox.Show("Bitte eine Station eintragen!");
            }
        }
        private void sendEmail(String startStation, String endStation, String departure, String arrival, String duration)
        {
            String url = "mailto:?subject=Öv%20Verbindungen&body=ÖV%20Verbindung%20zwischen%20" +
                            startStation + " - " + endStation + "%0A" +
                            "Abfahrt: " + departure + "%0A" +
                            "Ankunft: " + arrival + "%0A" +
                            "Dauer: " + duration;
            System.Diagnostics.Process.Start(url);

        }

        private void LBverbindungen_DoubleClick(object sender, EventArgs e)
        {
            sendEmail(LBverbindungen.SelectedItems[0].SubItems[0].Text,
                        LBverbindungen.SelectedItems[0].SubItems[1].Text,
                        LBverbindungen.SelectedItems[0].SubItems[2].Text,
                        LBverbindungen.SelectedItems[0].SubItems[3].Text,
                        LBverbindungen.SelectedItems[0].SubItems[4].Text
                        );


        }


    }
}

