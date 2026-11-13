using System;

namespace LaboratoryWork9
{
    public class Time
    {
        private int _hours;
        private int _minutes;
        private static int _objectCount = 0;

        public static int ObjectCount => _objectCount;

        public int Hours
        {
            get => _hours;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Часы не могут быть отрицательными.");
                _hours = value;
            }
        }

        public int Minutes
        {
            get => _minutes;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Минуты не могут быть отрицательными.");
                
                _hours += value / 60;
                _minutes = value % 60;
            }
        }

        public Time()
        {
            Hours = 0;
            Minutes = 0;
            _objectCount++;
        }

        public Time(int hours, int minutes)
        {
            if (hours < 0 || minutes < 0)
                throw new ArgumentException("Время не может содержать отрицательные значения.");

            Hours = hours + minutes / 60;
            Minutes = minutes % 60;
            _objectCount++;
        }

        public Time(Time other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            Hours = other.Hours;
            Minutes = other.Minutes;
            _objectCount++;
        }

        public Time AddMinutes(int minutesToAdd)
        {
            int totalMinutes = this.Hours * 60 + this.Minutes + minutesToAdd;
            if (totalMinutes < 0)
                totalMinutes = 0;

            return new Time(totalMinutes / 60, totalMinutes % 60);
        }

        public static Time AddMinutesStatic(Time t, int minutesToAdd)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));

            return t.AddMinutes(minutesToAdd);
        }

        public static Time operator ++(Time t)
        {
            return t.AddMinutes(1);
        }

        public static Time operator --(Time t)
        {
            return t.AddMinutes(-1);
        }

        public static explicit operator int(Time t)
        {
            return t.Hours;
        }

        public static implicit operator bool(Time t)
        {
            if (t == null) return false;
            return t.Hours != 0 && t.Minutes != 0;
        }

        public static Time operator +(Time t, int minutes)
        {
            return t.AddMinutes(minutes);
        }

        public static Time operator +(int minutes, Time t)
        {
            return t.AddMinutes(minutes);
        }

        public static Time operator -(Time t, int minutes)
        {
            return t.AddMinutes(-minutes);
        }

        public static Time operator -(int minutes, Time t)
        {
            int total = minutes - (t.Hours * 60 + t.Minutes);
            if (total < 0) total = 0;
            return new Time(total / 60, total % 60);
        }

        public override string ToString()
        {
            return $"{Hours:D2} ч. {Minutes:D2} мин.";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Time other)
                return this.Hours == other.Hours && this.Minutes == other.Minutes;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes);
        }
    }
}
