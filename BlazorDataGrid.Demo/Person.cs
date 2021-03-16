using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorDataGrid.Demo
{
    public class Person : IEquatable<Person>, INotifyPropertyChanged
    {
        public Person() {}
        
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }


        public bool IsEmployed
        {
            get => _isEmployed;
            set
            {
                _isEmployed = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public bool Equals(Person other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Age == other.Age && DateOfBirth.Equals(other.DateOfBirth) && FirstName == other.FirstName &&
                LastName == other.LastName && other.IsEmployed == IsEmployed;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Person) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Age, DateOfBirth, FirstName, LastName);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _age;
        private DateTime _dateOfBirth;
        private string _firstName = string.Empty;
        private bool _isEmployed;
        private string _lastName = string.Empty;
    }
}