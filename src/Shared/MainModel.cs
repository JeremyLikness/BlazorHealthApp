using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorHealthApp.Shared
{
    public class MainModel : IModel
    {
        private readonly List<Action> registrations = new List<Action>();

        private void Changed()
        {
            registrations.ForEach(a => a());
        }

        private int BmrWoman()
        {
            return (int)(655 + (4.35 * WeightPounds) + (4.7 * HeightInches) - (4.7 * AgeYears));
        }

        private int BmrMan()
        {
            return (int)(66 + (6.23 * WeightPounds) + (12.7 * HeightInches) - (6.8 * AgeYears));
        }

        private bool _isMale = true;
        private bool _isImperial = true;
        private double _heightInches = 60;
        private double _weightPounds = 130;
        private int _ageYears = 40;

        public bool IsMale
        {
            get
            {
                return _isMale;
            }
            set
            {
                if (value != _isMale)
                {
                    _isMale = value;
                    Changed();
                }
            }
        }

        public bool IsFemale
        {
            get { return !IsMale; }
            set
            {
                IsMale = !value;
            }
        }

        public bool IsImperial
        {
            get
            {
                return _isImperial;
            }
            set
            {
                if (value != _isImperial)
                {
                    _isImperial = value;
                    Changed();
                }
            }
        }

        public bool IsMetric
        {
            get { return !IsImperial; }
            set { IsImperial = !value; }
        }

        public double HeightInches
        {
            get => _heightInches;
            set
            {
                if (value != _heightInches)
                {
                    _heightInches = value;
                    Changed();
                }
            }
        }

        public double WeightPounds
        {
            get => _weightPounds;
            set
            {
                if (value != _weightPounds)
                {
                    _weightPounds = value;
                    Changed();
                }
            }
        }

        public int AgeYears
        {
            get => _ageYears;
            set
            {
                if (value != _ageYears)
                {
                    _ageYears = value;
                    Changed();
                }
            }
        }

        public void ToggleGender()
        {
            IsMale = !IsMale;
        }

        public void ToggleImperial()
        {
            IsImperial = !IsImperial;
        }

        public int Bmr
        {
            get
            {
                return IsMale ? BmrMan() : BmrWoman();
            }
        }

        public double Bmi
        {
            get
            {
                var bmi = (WeightPounds * 703) / (HeightInches * HeightInches);
                return Math.Round(bmi * 10.0) / 10.0;
            }
        }

        public TargetHeartRate Thr
        {
            get
            {
                var max = 220.0 - AgeYears;
                var min = Math.Round(5.0 * max) / 10.0;
                var maxRate = Math.Round(8.5 * max) / 10.0;
                return new TargetHeartRate
                {
                    Low = (int)min,
                    High = (int)maxRate
                };
            }
        }

        public void Register(Action callback)
        {
            registrations.Add(callback);
        }

        public double KilogramsToPounds(double kilograms)
        {
            return kilograms * Globals.KilogramsPerPound;
        }

        public double PoundsToKilograms(double pounds)
        {
            return pounds / Globals.KilogramsPerPound;
        }

        public double InchesToCentimeters(double inches)
        {
            return inches * Globals.CentimetersPerInch;
        }

        public double CentimetersToInches(double centimeters)
        {
            return centimeters / Globals.CentimetersPerInch;
        }

        public string InchesToFeetDisplay(double inches)
        {
            var heightInches = inches;
            var sb = new StringBuilder();
            var ft = Math.Floor(heightInches / Globals.InchesPerFoot);
            if (ft > 0)
            {
                sb.Append($"{(int)ft} ft. ");
            }
            heightInches -= (ft * Globals.InchesPerFoot);
            if (heightInches >= 1)
            {
                sb.Append($"{(int)Math.Floor(heightInches)} in.");
            }
            return sb.ToString();
        }
    }
}
