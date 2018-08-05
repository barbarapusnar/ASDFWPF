using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace ASDFWPF
{
    public class StoparicaViewModel : INotifyPropertyChanged
    {
        private ModelStoparice _stModel = new ModelStoparice();

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        

        public bool Teče { get { return _stModel.Teče; } }

        public StoparicaViewModel()
        {
            dispatcherTimer.Tick += TimerTick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds (50);
        }

        public void Start()
        {
             dispatcherTimer.Start();
            _stModel.Start();
        }

        public void Stop()
        {
            dispatcherTimer.Stop();
            _stModel.Stop();
        }

      
        public void Reset()
        {
            bool teče = Teče;
            _stModel.Reset();
            if (teče)
                _stModel.Start();
        }

        int _zadnjaUra;
        int _zadnjeMinute;
        decimal _zadnjeSekunde;
        bool _zadnjičTeče;
        void TimerTick(object sender, object e)
        {
            if (_zadnjičTeče != Teče)
            {
                _zadnjičTeče = Teče;
                OnPropertyChanged("Teče");
            }
            if (_zadnjaUra != Ure)
            {
                _zadnjaUra = Ure;
                OnPropertyChanged("Ure");
            }
            if (_zadnjeMinute != Minute)
            {
                _zadnjeMinute = Minute;
                OnPropertyChanged("Minute");
            }
            if (_zadnjeSekunde != Sekunde)
            {
                _zadnjeSekunde = Sekunde;
                OnPropertyChanged("Sekunde");
            }
        }

        public int Ure
        {
            get { return _stModel.PretečeniČas.HasValue ? _stModel.PretečeniČas.Value.Hours : 0; }
        }

        public int Minute
        {
            get { return _stModel.PretečeniČas.HasValue ? _stModel.PretečeniČas.Value.Minutes : 0; }
        }

        public decimal Sekunde
        {
            get
            {
                if (_stModel.PretečeniČas.HasValue)
                {
                    return (decimal)_stModel.PretečeniČas.Value.Seconds
                        + (_stModel.PretečeniČas.Value.Milliseconds * .001M);
                }
                else
                    return 0.0M;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}


