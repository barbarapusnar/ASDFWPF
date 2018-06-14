using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDFWPF
{
    class ModelStoparice
    {
        private DateTime? _začeto; 
        private TimeSpan? _prejšnjiČas;
        public bool Teče
        {
            get { return _začeto.HasValue; }
        }
        public TimeSpan? PretečeniČas
        {
            get 
            {
                if (_začeto.HasValue)
                {
                    if (_prejšnjiČas.HasValue)
                    {
                        return _prejšnjiČas + IzračunajPretečeniČasOdStarta();
                    }
                    else
                        return IzračunajPretečeniČasOdStarta();
                }
                else
                    return _prejšnjiČas;
            }
        }

        private TimeSpan? IzračunajPretečeniČasOdStarta()
        {
            return DateTime.Now - _začeto.Value;
        }
        public void Start()
        {
            _začeto = DateTime.Now;
            if (!_prejšnjiČas.HasValue)
                _prejšnjiČas = new TimeSpan(0);
        }
        public void Stop()
        {
            if (_začeto.HasValue)
                _prejšnjiČas += DateTime.Now - _začeto.Value;
            _začeto = null;
        }
        public ModelStoparice()
        {
            Reset();
        }
        public void Reset()
        {
            _prejšnjiČas = null;
            _začeto = null;
          
        }  

    }
}
