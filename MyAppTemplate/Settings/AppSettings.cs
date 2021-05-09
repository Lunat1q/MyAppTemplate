using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using MyAppTemplate.Annotations;
using TiqUtils.SettingsController;
using TiqUtils.Wpf.UIBuilders;

namespace MyAppTemplate.Settings
{
    public class AppSettings : INotifyPropertyChanged
    {
        #region SettingsController and saving
        private static readonly SettingsController<AppSettings> SettingsController;
        internal static AppSettings Settings => SettingsController.Settings;

        static AppSettings()
        {
            SettingsController = new SettingsController<AppSettings>(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        public void Save()
        {
            if (Settings == this)
            {
                SettingsController.Save();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string _value = "000";

        [PropertyMember]
        public string Value
        {
            get => this._value;
            set
            {
                if (value == this._value) return;
                this._value = value;
                this.OnPropertyChanged();
            }
        }
    }
}