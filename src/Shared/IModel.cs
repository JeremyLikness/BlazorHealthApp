using System;

namespace src.Shared
{
    public interface IModel
    {
        bool IsMale { get; set; }
        bool IsFemale { get; set; }
        bool IsImperial { get; set; }
        bool IsMetric { get; set; }
        double HeightInches { get; set; }
        double WeightPounds { get; set; }
        int AgeYears { get; set; }
        void ToggleGender();
        void ToggleImperial();
        int Bmr { get; }
        double Bmi { get; }
        TargetHeartRate Thr { get; }
        void Register(Action callback);
        double KilogramsToPounds(double kilograms);
        double PoundsToKilograms(double pounds);
        double InchesToCentimeters(double inches);
        double CentimetersToInches(double centimeters);
        string InchesToFeetDisplay(double inches);
    }
}
