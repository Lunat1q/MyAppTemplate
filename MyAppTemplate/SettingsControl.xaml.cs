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
using MyAppTemplate.Settings;
using TiqUtils.Wpf.UIBuilders;

namespace MyAppTemplate
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
            AppSettings.Settings.CreateAutoSettingsControl(this.ContentControl);
        }

        public event EventHandler OnSave;

        protected virtual void OnOnSave()
        {
            this.OnSave?.Invoke(this, EventArgs.Empty);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppSettings.Settings.Save();
        }
    }
}
