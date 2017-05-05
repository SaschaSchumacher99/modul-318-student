
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
        private ITransport transport;
        private String input;
        private bool needAutoCompleteUpdate = false;
        private ErrorHandling errors;

        public OevVerbindungen()
        {
            InitializeComponent();
            InitLists();
            LoadToolTip();
            transport = new Transport();
            errors = new ErrorHandling();




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

        private void InitDTP()
        {
            dTPTime.Format = DateTimePickerFormat.Custom;
            dTPTime.CustomFormat = "dd.MM.yyyy | HH:mm";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LBverbindungen.Items.Clear();

            String inputTime = dTPTime.Text;
            var date = DateTime.Parse(inputTime.Substring(0, 10));
            String formattetDate = date.ToString("yyyy-MM-dd");
            String time = inputTime.Substring(12, 6);

            var connections = transport.GetConnections(tbVon.Text, tbNach.Text, formattetDate, time);
            if (errors.IsConnectionsNull(connections))
            {

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
            else
            {
                errors.ShowError("Zu viele Anfragen. Bitte Versuchen Sie es später nochmals", "Zu viele Anfragen!");
            }

        }

        private void SearchVerbindungen_Click(object sender, EventArgs e)
        {
            abfahrtsTafel.Items.Clear();
            Stations stations = transport.GetStations(stationSearch.Text);
            Station station = stations.StationList[0];
            String id = station.Id;

            StationBoardRoot stationBoard = transport.GetStationBoard(stationSearch.Text, id);
            if (errors.IsStationBoardNull(stationBoard))
            {

                foreach (StationBoard entries in stationBoard.Entries)
                {
                    var item = new ListViewItem(new[] { entries.Stop.Departure.ToString(), entries.Category, entries.Name, station.Name, entries.To });
                    abfahrtsTafel.Items.Add(item);
                }
            }
            else
            {
                errors.ShowError("Zu viele Anfragen. Bitte Versuchen Sie es später nochmals", "Zu viele Anfragen!");
            }

        }

        private void TbVon_TextChanged(object sender, EventArgs e)
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
                    var stations = transport.GetStations(input);
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

        private void SearchStation_Click(object sender, EventArgs e)
        {
            String input = tbVon.Text;

            var stations = transport.GetStations(input);

            foreach (Station stationName in stations.StationList)
            {
                tbVon.Items.Add(stationName.Name);
            }
            this.tbVon.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.tbVon.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void SearchStationAF_Click(object sender, EventArgs e)
        {
            String input = stationSearch.Text;

            var stations = transport.GetStations(input);

            foreach (Station stationName in stations.StationList)
            {
                stationSearch.Items.Add(stationName.Name);
            }
            this.stationSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.stationSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void OpenKarte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Stations stations = transport.GetStations(tbVon.Text);
            if (stations != null)
            {

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
            else
            {
                errors.ShowError("Zu viele Anfragen. Bitte Versuchen Sie es später nochmals", "Zu viele Anfragen!");
            }
        }
        private void SendEmail(String startStation, String endStation, String departure, String arrival, String duration)
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
            SendEmail(LBverbindungen.SelectedItems[0].SubItems[0].Text,
                        LBverbindungen.SelectedItems[0].SubItems[1].Text,
                        LBverbindungen.SelectedItems[0].SubItems[2].Text,
                        LBverbindungen.SelectedItems[0].SubItems[3].Text,
                        LBverbindungen.SelectedItems[0].SubItems[4].Text
                        );

        }

    }
}