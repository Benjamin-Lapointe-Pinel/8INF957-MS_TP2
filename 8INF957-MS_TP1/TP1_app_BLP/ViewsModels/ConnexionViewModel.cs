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
        private RestApiClient restApiClient;
        public ICommand Connect { get; private set; }
        public ICommand CreateAccount { get; private set; }
        public AuthenticationRequest AuthenticationRequest { get; private set; }

        public ConnexionViewModel()
        {
            restApiClient = new();
            AuthenticationRequest = new();

            Connect = new RelayCommand<Window>(window =>
            {
                Doctor? doctor = restApiClient.Login(AuthenticationRequest);
                if (doctor == null)
                {
                    MessageBox.Show("Informations de connexion incorrectes", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var accueil = new Accueil(doctor);
                accueil.Show();
                window.Close();
            },
            window => AuthenticationRequest.IsValid);
            CreateAccount = new RelayCommand(() =>
            {
                var createAccount = new CreateAccount();
                bool? result = createAccount.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    //Doctors.Add(createAccount.doctorEditorViewModel.Doctor);
                }
            });
        }
    }
}
