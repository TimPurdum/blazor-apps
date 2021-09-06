using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApps.Shared
{
    public class ObservableValue<T> : INotifyPropertyChanged where T : IEquatable<T>, IComparable<T>
    {
        private T? _value;

        public ObservableValue(T value) => Value = value;
        public T Value { 
            get => _value;
            set
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            } 
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
