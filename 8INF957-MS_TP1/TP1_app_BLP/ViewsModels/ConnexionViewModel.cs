using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TP01_HeartDiseaseDiagnostic;
using TP1_app_BLP.Models;
using TP1_app_BLP.Services;
using TP1_app_BLP.Views;
using TP1_Projet.Views;

namespace TP1_app_BLP.ViewsModels
{
    public class ConnexionViewModel
    {
        public ICommand Connect { get; private set; }
        public AuthenticationRequest AuthenticationRequest { get; private set; }

        public ConnexionViewModel()
        {
            AuthenticationRequest = new();

            Connect = new RelayCommand<Window>(window =>
            {
                if (!RestApi.Client.Login(AuthenticationRequest))
                {
                    MessageBox.Show("Informations de connexion incorrectes", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var accueil = new Accueil();
                accueil.Show();
                window.Close();
            },
            window => AuthenticationRequest.IsValid);
        }
    }
}
