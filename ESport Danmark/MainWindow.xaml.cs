using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ESport_Danmark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Logic logic = new Logic();
        public MainWindow()
        {
            InitializeComponent();
            UpdateDatagrid();
        }
        private void UpdateDatagrid()
        {
            logic.GetAllSpillers();
            Spiller_datagrid.ItemsSource = logic.Spillers;
        }

        private void AddPlayer_btn_Click(object sender, RoutedEventArgs e)
        {
            if(AddNewPlayer_grid.Visibility == Visibility.Visible)
            {
                AddNewPlayer_grid.Visibility = Visibility.Hidden;
            }
            else
            {
                AddNewPlayer_grid.Visibility = Visibility.Visible;
            }
        }

        private void NewPlayerConfirm_btn_Click(object sender, RoutedEventArgs e)
        {
            logic.Api.ValidateSpillerNavn(Summonername_input.Text);
            SummonerWarning_txtblock.Foreground = new SolidColorBrush(Colors.Black);
            TelefonnummerWarning_txtblock.Foreground = new SolidColorBrush(Colors.Black);
            TelefonnummerNumberWarning.Foreground = new SolidColorBrush(Colors.Black);
            TuneringstypeWarning_txtblock.Foreground = new SolidColorBrush(Colors.Black);
            if (logic.Api.ValidName&&logic.CheckPhoneNummber(Telefonnummer_input.Text) == 0 && logic.CheckTurnementtype(Tuneringstype_input.Text))
            {
                logic.AddSpiller(Playername_input.Text, Summonername_input.Text, Rang_input.Text, Convert.ToInt32(Telefonnummer_input.Text), Tuneringstype_input.Text);
                UpdateDatagrid();
                Playername_input.Text = "";
                Summonername_input.Text = "";
                Rang_input.Text = "";
                Telefonnummer_input.Text = "";
                Tuneringstype_input.Text = "";
                AddNewPlayer_grid.Visibility = Visibility.Hidden;
            }
            else
            {
                if (!logic.Api.ValidName)
                {
                    SummonerWarning_txtblock.Foreground = new SolidColorBrush(Colors.Red);
                }
                if(logic.CheckPhoneNummber(Telefonnummer_input.Text) == 1)
                {
                    TelefonnummerWarning_txtblock.Foreground = new SolidColorBrush(Colors.Red);
                }
                if (logic.CheckPhoneNummber(Telefonnummer_input.Text) == 2)
                {
                    TelefonnummerNumberWarning.Foreground = new SolidColorBrush(Colors.Red);
                }
                if (!logic.CheckTurnementtype(Tuneringstype_input.Text))
                {
                    TuneringstypeWarning_txtblock.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
        }
    }
}
