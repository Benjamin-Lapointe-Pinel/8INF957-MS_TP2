﻿using System;
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
using Microsoft.Win32;
using TP01_HeartDiseaseDiagnostic;
using TP1_app_BLP.Model;
using TP1_app_BLP.Services;
using TP1_app_BLP.Views;

namespace TP1_app_BLP.ViewsModels
{
    public class AccueilViewModel : DoctorEditorViewModel
    {
        public List<string> Distances { get; private set; } = new()
        {
            "Euclidienne",
            "Manhattan"
            
        };
        public List<string> TypesDouleurThoracique { get; set; } = new()
        {
            "Angine typique",
            "Angine atypique",
            "Douleur non angineuse",
            "Asymptomatique"
        };
        public int SelectedTypesDouleurThoracique { get; set; } = 0;
        public List<string> Thalassemie { get; set; } = new()
        {
            "Normale",
            "Défaut corrigé",
            "Défaut réversible"
        };
        public int SelectedThalassemie { get; set; } = 0;
        public float OldPeak { get; set; } = 0;
        public int Fluoroscopie { get; set; } = 0;
        public ObservableCollection<Patient> Patients { get; private set; }
        public Patient SelectedPatient { get; set; }
        private string trainFile;
        private string testFile;
        private IKNN knn;
        private bool diagnoseReady =>
            OldPeak >= 0 && OldPeak <= 6.2 &&
            Fluoroscopie >= 0 && Fluoroscopie <= 3;
        public int K { get; set; } = 1;
        public int Distance { get; set; }
        private bool configIaFormIsValid =>
            !string.IsNullOrWhiteSpace(trainFile) &&
            !string.IsNullOrWhiteSpace(testFile) &&
            K > 0;
        private string _successRateMessage;
        public string SuccessRateMessage
        {
            get => _successRateMessage;
            set
            {
                if (_successRateMessage != value)
                {
                    _successRateMessage = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _diagnosticMessage;
        public string DiagnosticMessage
        {
            get => _diagnosticMessage;
            set
            {
                if (_diagnosticMessage != value)
                {
                    _diagnosticMessage = value;
                    OnPropertyChanged();
                }
            }
        }
        public new Doctor Doctor
        {
            get
            {
                return base.Doctor;
            }
            set
            {
                if (base.Doctor != value)
                {
                    base.Doctor = value;
                    OnPropertyChanged();
                    Greeting = $"Bienvenue Dr. {Doctor}";
                }
            }
        }
        public string greeting;
        public string Greeting
        {
            get => greeting;
            set
            {
                if (greeting != value)
                {
                    greeting = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand ModifyDoctor { get; private set; }
        public ICommand CancelDoctor { get; private set; }
        public ICommand TrainCommand { get; private set; }
        public ICommand TestCommand { get; private set; }
        public ICommand EvaluateCommand { get; private set; }

        public ICommand InfoPatient { get; private set; }
        public ICommand ComptePatient { get; private set; }
        public ICommand Diagnose { get; private set; }

        public AccueilViewModel() : base(null)
        {
            Doctor = RestApi.Client.GetDoctor();
            Patients = new ObservableCollection<Patient>(RestApi.Client.GetPatients());
            SelectedPatient = Patients[0];

            ModifyDoctor = new RelayCommand(() => Doctor = RestApi.Client.PutDoctor(Doctor), () => Doctor.IsValid);
            CancelDoctor = new RelayCommand(() => Doctor = RestApi.Client.GetDoctor());
            TrainCommand = new RelayCommand(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                bool? result = openFileDialog.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    trainFile = openFileDialog.FileName;
                }
            });
            TestCommand = new RelayCommand(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                bool? result = openFileDialog.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    testFile = openFileDialog.FileName;
                }
            });
            EvaluateCommand = new RelayCommand(() =>
            {
                knn = new KNN();
                knn.Train(trainFile, K, Distance);
                float successRate = knn.Evaluate(testFile) * 100;
                SuccessRateMessage = $"Taux de reconnaissance : {successRate:F2}%";
            }, () => configIaFormIsValid);
            ComptePatient = new RelayCommand(() =>
            {
                var comptePatient = new ComptePatient();
                bool? result = comptePatient.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    Patient patient = comptePatient.patientViewModel.Patient;
                    Patients.Add(RestApi.Client.PostPatient(patient));
                }
            });
            InfoPatient = new RelayCommand(() =>
            {
                var infoPatient = new ComptePatient(SelectedPatient, true);
                infoPatient.Show();
            });
            Diagnose = new RelayCommand(() =>
            {
                Diagnostic diagnostic = new(SelectedTypesDouleurThoracique, SelectedThalassemie + 1, OldPeak, Fluoroscopie);
                diagnostic = RestApi.Client.Diagnose(SelectedPatient, diagnostic);
                SelectedPatient.Diagnostics.Add(diagnostic);
                if (diagnostic.Target)
                {
                    DiagnosticMessage = "Résultat : Présence de Maladie";
                }
                else
                {
                    DiagnosticMessage = "Résultat : Absence de Maladie";
                }
            }, () => diagnoseReady);
        }
    }
}
