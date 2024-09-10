using Radio_Frequency_Monitoring_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Radio_Frequency_Monitoring_App.ViewModels
{
    public class SignalAnalyzer : INotifyPropertyChanged
    {
        private bool _isConnected;
        private double _samplingRate;
        private ObservableCollection<RFSignal> _signals;

        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                OnPropertyChanged();
            }
        }

        public double SamplingRate
        {
            get => _samplingRate;
            set
            {
                _samplingRate = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<RFSignal> Signals
        {
            get => _signals;
            set
            {
                _signals = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand ApplySettingsCommand { get; }

        public SignalAnalyzer()
        {
            Signals = new ObservableCollection<RFSignal>();
            StartCommand = new RelayCommand(StartAnalysis);
            StopCommand = new RelayCommand(StopAnalysis);
            ApplySettingsCommand = new RelayCommand(ApplySettings);
        }

        private void StartAnalysis()
        {
            IsConnected = true;
            // Start analysis logic
        }

        private void StopAnalysis()
        {
            IsConnected = false;
            // Stop analysis logic
        }

        private void ApplySettings()
        {
            // Apply settings logic
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
