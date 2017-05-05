
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
        private bool needAutoCompleteUpdate = false;
        private ErrorHandling errors;
        private CheckConnection checkconnection;

        public OevVerbindungen()
        {
            InitializeComponent();
            InitLists();
            LoadToolTip();
            transport = new Transport();
            errors = new ErrorHandling();
            checkconnection = new CheckConnection();
            InitDateTimePicker();

            

        }
        public void LoadToolTip()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.autocompleteVonn, "Nach vier Zeichen kurz warten bis die Ergebnisse angezeit werden!");
            toolTip1.SetToolTip(this.emailhint, "Du kannst deine ausgewählte Verbindung ganz einfach per Email senden.\n Dazu machst du einen Doppelklick auf die Startstation (Von Station)!");
        }

        private void InitLists()
        {
            verbindungenTafel.View = View.Details;
            verbindungenTafel.Columns.Add("Von", 150, HorizontalAlignment.Center);
            verbindungenTafel.Columns.Add("Nach", 150, HorizontalAlignment.Center);
            verbindungenTafel.Columns.Add("Abfahrt", 150, HorizontalAlignment.Center);
            verbindungenTafel.Columns.Add("Ankunft", 150, HorizontalAlignment.Center);
            verbindungenTafel.Columns.Add("Dauer", 60, HorizontalAlignment.Center);

            abfahrtsTafel.View = View.Details;
            abfahrtsTafel.Columns.Add("Abfahrt", 150, HorizontalAlignment.Left);
            abfahrtsTafel.Columns.Add("Kategorie", 150, HorizontalAlignment.Left);
            abfahrtsTafel.Columns.Add("Name", 150, HorizontalAlignment.Left);
            abfahrtsTafel.Columns.Add("Von", 150, HorizontalAlignment.Center);
            abfahrtsTafel.Columns.Add("Nach", 150, HorizontalAlignment.Left);
        }

        private void InitDateTimePicker()
        {
            DateTimeEingabe.Format = DateTimePickerFormat.Custom;
            DateTimeEingabe.CustomFormat = "dd.MM.yyyy | HH:mm";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            verbindungenTafel.Items.Clear();

            String inputTime = errors.CheckInput(DateTimeEingabe.Text, "Datum");
            var date = DateTime.Parse(inputTime.Substring(0, 10));
            String formattetDate = date.ToString("yyyy-MM-dd");
            String time = inputTime.Substring(12, 6);
            Connections connections = new Connections();

            String fromStation = errors.CheckInput(vonEingabe.Text, "Von");
            String toStation = errors.CheckInput(nachEingabe.Text, "Nach");

            if (viaCheckBox.Checked)
            {
                String via = errors.CheckInput(viaEingabe.Text, "Via");
                connections = transport.GetConnections(fromStation, toStation, formattetDate, time, via);
            }
            else
            {
                connections = transport.GetConnections(fromStation, toStation, formattetDate, time);
            }
            if (errors.IsConnectionsNull(connections))
            {

                foreach (var result in connections.ConnectionList)
                {
                 
                    ConnectionPoint from = result.From;
                    ConnectionPoint to = result.To;

                    Verbindung verbindung = new Verbindung(from, to, result);
                    var item = new ListViewItem(new[] { verbindung.getStartStation(), verbindung.getEndStation(), verbindung.getDeparture(), verbindung.getArrival(), verbindung.getDuration() });

                    verbindungenTafel.Items.Add(item);
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
            Stations stations = transport.GetStations(searchStations.Text);
            Station station = stations.StationList[0];
            String id = station.Id;

            StationBoardRoot stationBoard = transport.GetStationBoard(searchStations.Text, id);
            if (errors.IsStationBoardNull(stationBoard))
            {

                foreach (StationBoard entries in stationBoard.Entries)
                {
                    var item = new ListViewItem(new[] { entries.Stop.Departure.ToString(), entries.Category, entries.To, station.Name, entries.To });
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
            AutoSearch(autocompleteVonn, vonEingabe);
        }
        private void SearchStation_Click(object sender, EventArgs e)
        {
            String input = vonEingabe.Text;

            var stations = transport.GetStations(input);

            foreach (Station stationName in stations.StationList)
            {
                vonEingabe.Items.Add(stationName.Name);
            }
            this.vonEingabe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.vonEingabe.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void SearchStationAF_Click(object sender, EventArgs e)
        {
            String input = searchStations.Text;


            var stations = transport.GetStations(input);

            foreach (Station stationName in stations.StationList)
            {
                searchStations.Items.Add(stationName.Name);
            }
            this.searchStations.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.searchStations.AutoCompleteSource = AutoCompleteSource.CustomSource;

            searchStations.Text = "Auswählen";
        }
        private void OpenKarte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Stations stations = transport.GetStations(vonEingabe.Text);
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
            SendEmail(verbindungenTafel.SelectedItems[0].SubItems[0].Text,
                        verbindungenTafel.SelectedItems[0].SubItems[1].Text,
                        verbindungenTafel.SelectedItems[0].SubItems[2].Text,
                        verbindungenTafel.SelectedItems[0].SubItems[3].Text,
                        verbindungenTafel.SelectedItems[0].SubItems[4].Text
                        );
        }

        private void ViaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (viaCheckBox.Checked)
            {
                viaEingabe.Enabled = true;
            }
            else
            {
                viaEingabe.Enabled = false;
            }
        }
        private void AutoSearch(CheckBox checkbox, ComboBox combobox)
        {
            if (checkbox.Checked)
            {

                String input = combobox.Text;

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
                        combobox.AutoCompleteCustomSource.Add(stationName.Name);
                    }
                    combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
                    combobox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
        }
        private void NachEingabe_TextChanged(object sender, EventArgs e)
        {
            AutoSearch(autocompleteNach, nachEingabe);
        }

        private void ViaEingabe_TextChanged(object sender, EventArgs e)
        {
            AutoSearch(autocompleteVia, viaEingabe);
        }

        private void SearchStations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchVerbindungen_Click((object)sender, (EventArgs)e);
            }
        }

        private void OevVerbindungen_Load(object sender, EventArgs e)
        {
            if (!checkconnection.CheckForInternetConnection())
            {
                errors.ShowError("Du hast zurzeit kein Internet!", "Kein Internet");
            }
        }
    }
}
