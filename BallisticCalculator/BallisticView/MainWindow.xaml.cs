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
using BallisticController;
using BallisticModel;
using System.Linq;

namespace BallisticView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow : Window
    {
        private Create _create;
        private Read _read;
        private Update _update;
        private Delete _delete;
        public MainWindow()
        {
            InitializeComponent();
            _create = new Create();
            _read = new Read();
            _update = new Update();
            _delete = new Delete();
            PopulateControls();
        }

        private void PopulateControls()
        {
           
            ListBoxFirearm.ItemsSource = _read.RetrieveAllFirearm();
            ListBoxAmmunition.ItemsSource = _read.RetrieveAllAmmunition();
            ListBoxFirearmType.ItemsSource = _read.RetrieveAllFirearmType();
            ComboBoxFirearmType.ItemsSource = _read.RetrieveAllFirearmType();
            ComboBoxAmmunition.ItemsSource = _read.RetrieveAllAmmunition();
            

        }

        private void ListBoxFirearm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxFirearm.SelectedItem != null)
            {
                Firearm currentFirearm = ListBoxFirearm.SelectedItem as Firearm;

               

                TextBoxFirearmName.Text = currentFirearm.FirearmName;
                TextBoxMuzzleVelocity.Text = currentFirearm.MuzzleVelocity.ToString();
                
                foreach (var item in ComboBoxFirearmType.ItemsSource)
                {

                    if (((FirearmType)item).FirearmTypeID == currentFirearm.FirearmTypeID) {
                        ComboBoxFirearmType.SelectedItem = item;
                    }
                }
                
                foreach (var item in ComboBoxAmmunition.ItemsSource)
                {

                    if (((Ammunition)item).AmmunitionID == currentFirearm.AmmunitionID) {

                        ComboBoxAmmunition.SelectedItem = item;
                    }
                }
                
                
            }
            
        }

        private void ListBoxAmmunition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxAmmunition.SelectedItem != null)
            {
                Ammunition currentAmmunition = ListBoxAmmunition.SelectedItem as Ammunition;

                TextBoxAmmunitionName.Text = currentAmmunition.AmmunitionName;
                TextBoxCoefficient.Text = currentAmmunition.Coefficient.ToString();
                TextBoxDiameter.Text = currentAmmunition.Diameter.ToString();
                TextBoxGrain.Text = currentAmmunition.Grain.ToString();
            }
        }

        private void ListBoxFirearmType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxFirearmType.SelectedItem != null)
            {
                FirearmType currentType = ListBoxFirearmType.SelectedItem as FirearmType;

                TextBoxTypeName.Text = currentType.TypeName;
            }
        }

        private void FirearmCreate_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxFirearmName.Text != "" && TextBoxMuzzleVelocity.Text != "" && ComboBoxAmmunition.SelectedItem != null && ComboBoxFirearmType.SelectedItem != null)
            {
                FirearmType currentFirearmType = ComboBoxFirearmType.SelectedItem as FirearmType;
                Ammunition currentAmmunition = ComboBoxAmmunition.SelectedItem as Ammunition;
                _create.AddFirearm(TextBoxFirearmName.Text, Int32.Parse(TextBoxMuzzleVelocity.Text), currentFirearmType.FirearmTypeID, currentAmmunition.AmmunitionID);
                PopulateControls();
            }
        }

        private void FirearmDelete_Click(object sender, RoutedEventArgs e)
        {
            Firearm currentFirearm = ListBoxFirearm.SelectedItem as Firearm;

            _delete.DeleteFirearm(currentFirearm.FirearmID);
            PopulateControls();
        }

        private void AmmunitionCreate_Click(object sender, RoutedEventArgs e)
        {
            _create.AddAmmunition(TextBoxAmmunitionName.Text, float.Parse(TextBoxCoefficient.Text), float.Parse(TextBoxGrain.Text), float.Parse(TextBoxDiameter.Text));
            PopulateControls();
        }

        private void AmmunitionDelete_Click(object sender, RoutedEventArgs e)
        {
            Ammunition currentAmmunition = ListBoxAmmunition.SelectedItem as Ammunition;
            _delete.DeleteAmmunition(currentAmmunition.AmmunitionID);
            PopulateControls();
        }

        private void FirearmTypeAdd_Click(object sender, RoutedEventArgs e)
        {
            _create.AddFirearmType(TextBoxTypeName.Text);
            PopulateControls();
        }

        private void FirearmTypeDelete_Click(object sender, RoutedEventArgs e)
        {
            FirearmType currentType = ListBoxFirearmType.SelectedItem as FirearmType;
            _delete.DeleteFirearmType(currentType.FirearmTypeID);
            PopulateControls();
        }

        private void FirearmUpdate_Click(object sender, RoutedEventArgs e)
        {
            Firearm currentFirearm = ListBoxFirearm.SelectedItem as Firearm;
            Ammunition currentAmmunition = ComboBoxAmmunition.SelectedItem as Ammunition;
            FirearmType currentType = ComboBoxFirearmType.SelectedItem as FirearmType;

            _update.UpdateFirearm(currentFirearm.FirearmID, TextBoxFirearmName.Text, Int32.Parse(TextBoxMuzzleVelocity.Text), currentType.FirearmTypeID, currentAmmunition.AmmunitionID);
            PopulateControls();
        }

        private void FirearmClear_Click(object sender, RoutedEventArgs e)
        {
            ListBoxFirearm.SelectedItem = null;
            ComboBoxFirearmType.SelectedItem = null;
            ComboBoxAmmunition.SelectedItem = null;
            TextBoxFirearmName.Text = "";
            TextBoxMuzzleVelocity.Text = "";
        }

        private void AmmunitionClear_Click(object sender, RoutedEventArgs e)
        {
            ListBoxAmmunition.SelectedItem = null;
            TextBoxAmmunitionName.Text = "";
            TextBoxCoefficient.Text = "";
            TextBoxDiameter.Text = "";
            TextBoxGrain.Text = "";
        }

        private void FirearmTypeClear_Click(object sender, RoutedEventArgs e)
        {
            ListBoxFirearmType.SelectedItem = null;
            TextBoxTypeName.Text = "";
        }
    }
}
