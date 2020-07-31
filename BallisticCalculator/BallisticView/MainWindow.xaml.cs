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
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Diagnostics;
using System.Windows.Controls.Primitives;

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
        private Default _constants = Read.ReadDefaults();

        public MainWindow()
        {
            InitializeComponent();
            _create = new Create();
            _read = new Read();
            _update = new Update();
            _delete = new Delete();
            
            PopulateControls();
            HeightDistance.Visibility = Visibility.Hidden;
            

        }
        private void PopulateControls()
        {         
            ListBoxFirearm.ItemsSource = _read.RetrieveAllFirearm();
            ListBoxAmmunition.ItemsSource = _read.RetrieveAllAmmunition();
            ListBoxFirearmType.ItemsSource = _read.RetrieveAllFirearmType();
            ComboBoxFirearmType.ItemsSource = _read.RetrieveAllFirearmType();
            ComboBoxAmmunition.ItemsSource = _read.RetrieveAllAmmunition();
            ComboBoxFirearm.ItemsSource = _read.RetrieveAllFirearm();
            TextBoxStartingHeight.Text = _constants.StartingHeight.ToString();
            TextBoxTimeInterval.Text = _constants.TimeInterval.ToString();
            TextBoxAirDensity.Text = _constants.AirDensity.ToString();
            TextBoxGravity.Text = _constants.Gravity.ToString();
            TextBoxAngle.Text = SliderAngle.Value.ToString();
            //LoadLineChartData();
        }

        private void LoadLineChartData()
        {
            Firearm currentFirearm = ComboBoxFirearm.SelectedItem as Firearm;
            if (graphType() == "HeightTime")
            {
                ((LineSeries)HeightTime.Series[0]).ItemsSource = Calculation.Speed(currentFirearm.FirearmID, Convert.ToInt32(SliderAngle.Value), Convert.ToDecimal(TextBoxStartingHeight.Text), Convert.ToDecimal(TextBoxTimeInterval.Text), "HeightTime");
            }
            else
            {
                ((LineSeries)HeightDistance.Series[0]).ItemsSource = Calculation.Speed(currentFirearm.FirearmID, Convert.ToInt32(SliderAngle.Value), Convert.ToDecimal(TextBoxStartingHeight.Text), Convert.ToDecimal(TextBoxTimeInterval.Text), "HeightDistance");
            }
        }
        
        #region listbox events
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

        #endregion

        #region firearm buttons
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
            if (ListBoxFirearm.SelectedItem != null)
            {
                Firearm currentFirearm = ListBoxFirearm.SelectedItem as Firearm;

                _delete.DeleteFirearm(currentFirearm.FirearmID);
                PopulateControls();
            }
        }

        private void FirearmUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxFirearm.SelectedItem != null && ComboBoxAmmunition.SelectedItem != null && ComboBoxFirearmType.SelectedItem != null && TextBoxFirearmName.Text != "" && TextBoxMuzzleVelocity.Text != null)
            {
                Firearm currentFirearm = ListBoxFirearm.SelectedItem as Firearm;
                Ammunition currentAmmunition = ComboBoxAmmunition.SelectedItem as Ammunition;
                FirearmType currentType = ComboBoxFirearmType.SelectedItem as FirearmType;

                _update.UpdateFirearm(currentFirearm.FirearmID, TextBoxFirearmName.Text, Int32.Parse(TextBoxMuzzleVelocity.Text), currentType.FirearmTypeID, currentAmmunition.AmmunitionID);
                PopulateControls();
            }
        }

        private void FirearmClear_Click(object sender, RoutedEventArgs e)
        {
            ListBoxFirearm.SelectedItem = null;
            ComboBoxFirearmType.SelectedItem = null;
            ComboBoxAmmunition.SelectedItem = null;
            TextBoxFirearmName.Text = "";
            TextBoxMuzzleVelocity.Text = "";
        }
        #endregion

        #region ammunition buttons
        private void AmmunitionCreate_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxAmmunitionName.Text != "" && TextBoxCoefficient.Text != null && TextBoxGrain.Text != "" && TextBoxDiameter.Text != null)
            {
                _create.AddAmmunition(TextBoxAmmunitionName.Text, float.Parse(TextBoxCoefficient.Text), float.Parse(TextBoxGrain.Text), float.Parse(TextBoxDiameter.Text));
                PopulateControls();
            }
        }

        private void AmmunitionDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAmmunition.SelectedItem != null)
            {
                Ammunition currentAmmunition = ListBoxAmmunition.SelectedItem as Ammunition;
                _delete.DeleteAmmunition(currentAmmunition.AmmunitionID);
                PopulateControls();
            }
        }

        private void AmmunitionClear_Click(object sender, RoutedEventArgs e)
        {
            ListBoxAmmunition.SelectedItem = null;
            TextBoxAmmunitionName.Text = "";
            TextBoxCoefficient.Text = "";
            TextBoxDiameter.Text = "";
            TextBoxGrain.Text = "";
        }

        private void AmmunitionUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAmmunition.SelectedItem != null && TextBoxAmmunitionName.Text != "" && TextBoxCoefficient.Text != "" && TextBoxGrain.Text != "" && TextBoxDiameter.Text != "")
            {
                Ammunition currentAmmunition = ListBoxAmmunition.SelectedItem as Ammunition;

                _update.UpdateAmmunition(currentAmmunition.AmmunitionID, TextBoxAmmunitionName.Text, float.Parse(TextBoxCoefficient.Text), float.Parse(TextBoxGrain.Text), float.Parse(TextBoxDiameter.Text));
                PopulateControls();
            }
        }
        #endregion

        #region firearm type buttons
        private void FirearmTypeAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxTypeName.Text != "")
            {
                _create.AddFirearmType(TextBoxTypeName.Text);
                PopulateControls();
            }
        }

        private void FirearmTypeDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxFirearmType.SelectedItem != null)
            {
                FirearmType currentType = ListBoxFirearmType.SelectedItem as FirearmType;
                _delete.DeleteFirearmType(currentType.FirearmTypeID);
                PopulateControls();
            }
        }





        private void FirearmTypeClear_Click(object sender, RoutedEventArgs e)
        {
            ListBoxFirearmType.SelectedItem = null;
            TextBoxTypeName.Text = "";
        }



        private void FirearmTypeUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxFirearmType.SelectedItem != null && TextBoxTypeName.Text != "")
            {
                FirearmType currentType = ListBoxFirearmType.SelectedItem as FirearmType;
                _update.UpdateFirearmType(currentType.FirearmTypeID, TextBoxTypeName.Text);
                PopulateControls();
            }
        }



        #endregion

        private void ComboBoxFirearm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxFirearm.SelectedItem != null)
            {
                LoadLineChartData();
            }
        }

        private void SliderAngle_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            TextBoxAngle.Text = SliderAngle.Value.ToString();
            LoadLineChartData();
        }

        //private void SliderAngle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    TextBoxAngle.Text = SliderAngle.Value.ToString();
        //    LoadLineChartData();
        //}

        public string graphType ()
        {
            if (HeightTime.Visibility == Visibility.Visible)
            {
                return "HeightTime";
            } else
            {
                return "HeightDistance";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Firearm currentFirearm = ComboBoxFirearm.SelectedItem as Firearm;
            if (graphType() == "HeightTime")
            {
                HeightTime.Visibility = Visibility.Hidden;
                HeightDistance.Visibility = Visibility.Visible;
                LoadLineChartData();
                //((LineSeries)HeightDistance.Series[0]).ItemsSource = Calculation.Speed(currentFirearm.FirearmID, Convert.ToInt32(SliderAngle.Value), Convert.ToDecimal(TextBoxStartingHeight.Text), Convert.ToDecimal(TextBoxTimeInterval.Text), graphType());
                
            } else
            {
                HeightTime.Visibility = Visibility.Visible;
                HeightDistance.Visibility = Visibility.Hidden;
                LoadLineChartData();
                //((LineSeries)HeightTime.Series[0]).ItemsSource = Calculation.Speed(currentFirearm.FirearmID, Convert.ToInt32(SliderAngle.Value), Convert.ToDecimal(TextBoxStartingHeight.Text), Convert.ToDecimal(TextBoxTimeInterval.Text), graphType());
            }
        }

        private void ButtonSaveAirDensity_Click(object sender, RoutedEventArgs e)
        {
            _update.UpdateAirDensity(float.Parse(TextBoxAirDensity.Text));
            LoadLineChartData();
        }

        private void ButtonSaveGravity_Click(object sender, RoutedEventArgs e)
        {
            _update.UpdateGravity(float.Parse(TextBoxGravity.Text));
            LoadLineChartData();
        }

        private void ButtonSaveStartingHeight_Click(object sender, RoutedEventArgs e)
        {
            _update.UpdateStartingHeight(float.Parse(TextBoxStartingHeight.Text));
           
            LoadLineChartData();
        }

        private void ButtonSaveTimeInterval_Click(object sender, RoutedEventArgs e)
        {
            _update.UpdateTimeInterval(float.Parse(TextBoxTimeInterval.Text));
           
            LoadLineChartData();
            
        }


    }
}
