using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding_TRPO
{
    internal class Wage : INotifyPropertyChanged, ICloneable
    {

        public object Clone()
        {
            return new Wage() {Id = _id, Name = _name, Salary = _salary, Bonus = _bonus, Deduction = _deduction };
        }

        private int _id = 0;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _name = "Имя сотрудника";
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _salary = 0.0;
        public double Salary
        {
            get => _salary;
            set
            {
                if (_salary != value)
                {
                    _salary = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Payment));
                }
            }
        }

        private double _bonus = 0.0;
        public double Bonus
        {
            get => _bonus;
            set
            {
                if (value != _bonus)
                {
                    _bonus = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Payment));
                }
            }
        }

        private double _deduction = 0.0;
        public double Deduction
        {
            get => _deduction;
            set
            {
                if (value != _deduction)
                {
                    _deduction = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Payment));
                }
            }
        }



        public double Payment
        {
            get => Salary + Bonus - Deduction;
            set
            {
                if (Salary + Bonus - Deduction != Payment)
                {
                    _deduction = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            Payment = Salary + Bonus - Deduction;
        }

        public void Clear()
        {
            Salary = 0.0;
            Deduction = 0.0;
            Bonus = 0.0;
            Id = 0;
            Name = string.Empty;
            Payment = 0;
        }
    }
}
