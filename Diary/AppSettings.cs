using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.Migrations;
using Diary.Properties;

namespace Diary
{
    public class AppSettings : IDataErrorInfo
    {
        public string DataBaseServerAdress
        {
            get
            {
                return Settings.Default.DataBaseServerAdress;
            }
            set
            {
                Settings.Default.DataBaseServerAdress = value;
            }

        }
        public string DataBaseServerName
        {
            get
            {
                return Settings.Default.DataBaseServerName;
            }
            set
            {
                Settings.Default.DataBaseServerName = value;
            }

        }
        public string DataBaseName
        {
            get
            {
                return Settings.Default.DataBaseName;
            }
            set
            {
                Settings.Default.DataBaseName = value;
            }

        }
        public string DataBaseLogin
        {
            get
            {
                return Settings.Default.DataBaseLogin;
            }
            set
            {
                Settings.Default.DataBaseLogin = value;
            }

        }
        public string DataBasePassword
        {
            get
            {
                return Settings.Default.DataBasePassword;
            }
            set
            {
                Settings.Default.DataBasePassword = value;
            }

        }
       

        private bool _isDataBaseServerAdressValid;
        private bool _isDataBaseServerNameValid;
        private bool _isDataBaseNameValid;
        private bool _isDataBaseLoginValid;
        private bool _isDataBasePasswordValid;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(DataBaseServerAdress):
                        if (string.IsNullOrWhiteSpace(DataBaseServerAdress))
                        {
                            Error = "Pole Adres serwera jest wymagane.";
                            _isDataBaseServerAdressValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isDataBaseServerAdressValid = true;
                        }
                        break;
                    case nameof(DataBaseServerName):
                        if (string.IsNullOrWhiteSpace(DataBaseServerName))
                        {
                            Error = "Pole Nazwa serwera jest wymagane.";
                            _isDataBaseServerNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isDataBaseServerNameValid = true;
                        }
                        break;
                    case nameof(DataBaseName):
                        if (string.IsNullOrWhiteSpace(DataBaseName))
                        {
                            Error = "Pole Nazwa bazy danych jest wymagane.";
                            _isDataBaseNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isDataBaseNameValid = true;
                        }
                        break;
                    case nameof(DataBaseLogin):
                        if (string.IsNullOrWhiteSpace(DataBaseLogin))
                        {
                            Error = "Pole Login jest wymagane.";
                            _isDataBaseLoginValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isDataBaseLoginValid = true;
                        }
                        break;
                    case nameof(DataBasePassword):
                        if (string.IsNullOrWhiteSpace(DataBasePassword))
                        {
                            Error = "Pole Hasło jest wymagane.";
                            _isDataBasePasswordValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isDataBasePasswordValid = true;
                        }
                        break;
                    default:
                        break;
                }

                return Error;
            }
        }

        public string Error { get; set; }

        public bool IsValid
        {
            get
            {
                return _isDataBaseServerAdressValid && _isDataBaseServerNameValid && _isDataBaseNameValid
                    && _isDataBaseLoginValid && _isDataBasePasswordValid;
            }
        }
        public void SaveAppSettings()
        {
            Settings.Default.Save();
        }

    }
}
