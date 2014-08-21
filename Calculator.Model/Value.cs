using Calculator.Model.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class Value : ICloneable
    {
        #region Fields

        private static string dateTimeFormat = Config.DateFormat;
        private string currentValue;

        #endregion // Fields

        #region Properties

        public string CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; }
        }

        public bool IsNumeric
        {
            get
            {
                double numeric;
                return double.TryParse(currentValue, out numeric);
            }
        }

        public bool IsDate
        {
            get
            {

                    DateTime date;
                    return  DateTime.TryParseExact(currentValue,
                                         dateTimeFormat,
                                         CultureInfo.CurrentCulture,
                                         DateTimeStyles.None,
                                         out date);
            }
        }

        public bool IsTime
        {
            get
            {
                bool isTime= false;
                if (currentValue.Contains(":"))
                {
                    TimeSpan time;
                    isTime = TimeSpan.TryParse(currentValue, out time);
                }

                return isTime;

            }
        }

        #endregion // Properties
       
        #region Ctor

        public Value() : 
            this("")
        {

        }

        public Value(string newValue)
        {
            currentValue = newValue;
        }

        #endregion // Ctor

        #region Public methods

        public T GetRealValue<T>()
        {
            return (T)Convert.ChangeType(currentValue, typeof(T));
        }

        public void Sqrt()
        {
            if (!IsNumeric)
            {
                throw new NotANumberException();
            }

            double sqrt = Math.Sqrt(double.Parse(CurrentValue));
            CurrentValue = sqrt.ToString();
        }

        public void Inv()
        {
            if (!IsNumeric)
            {
                throw new NotANumberException();
            }

            double invValue = 1 / double.Parse(CurrentValue);
            CurrentValue = invValue.ToString();
        }

        public void Pow(double index)
        {
            if (!IsNumeric)
            {
                throw new NotANumberException();
            }

            double powValue = Math.Pow(double.Parse(CurrentValue), index);
            CurrentValue = powValue.ToString();
        }

        public void Rev()
        {
            if (!IsNumeric)
            {
                throw new NotANumberException();
            }

            double revValue = double.Parse(CurrentValue) * (-1);
            CurrentValue = revValue.ToString();
        }

        #endregion

        #region Override operators

        public static Value operator +(Value v1, Value v2)
        {
            Value value = new Value("");

            if (v1.IsNumeric && v2.IsNumeric)
            {
               double returnValue = double.Parse(v1.CurrentValue) + double.Parse(v2.CurrentValue);
               value.CurrentValue = returnValue.ToString();
            }

            else if (v1.IsDate && v2.IsDate)
            {
                DateTime dateV1 = GetDateTime(v1.currentValue);
                DateTime dateV2 = GetDateTime(v2.currentValue);

                TimeSpan timespan = dateV2 - dateV1;

                value.currentValue = timespan.Days.ToString();                
            }

            else if (v1.IsTime && v2.IsTime)
            {

                TimeSpan returnValue = GetTimeSpan(v1.CurrentValue) + GetTimeSpan(v2.CurrentValue);
                value.currentValue = returnValue.ToString();
            }

            else
            {
                throw new OperationNotValidException();
            }

            return value;
        }

        public static Value operator -(Value v1, Value v2)
        {
            Value value = new Value("");

            if (v1.IsNumeric && v2.IsNumeric)
            {
                double returnValue = double.Parse(v1.CurrentValue) - double.Parse(v2.CurrentValue);
                value.CurrentValue = returnValue.ToString();
            }

            else if (v1.IsDate && v2.IsDate)
            {
                DateTime dateV1 = GetDateTime(v1.currentValue);
                DateTime dateV2 = GetDateTime(v2.currentValue);

                TimeSpan timespan = dateV2 - dateV1;

                value.currentValue = timespan.Days.ToString();
            }

            else if (v1.IsTime && v2.IsTime)
            {
                TimeSpan returnValue = GetTimeSpan(v1.CurrentValue) - GetTimeSpan(v2.CurrentValue);
                value.CurrentValue = returnValue.ToString();
            }

            else
            {
                throw new OperationNotValidException();
            }

            return value;
        }

        public static Value operator *(Value v1, Value v2)
        {
            Value value = new Value("");

            if (v1.IsNumeric && v2.IsNumeric)
            {
                double returnValue = double.Parse(v1.CurrentValue) * double.Parse(v2.CurrentValue);
                value.CurrentValue = returnValue.ToString();
            }

            else
            {
                throw new NotANumberException();
            }

            return value;
        }

        public static Value operator /(Value v1, Value v2)
        {
            Value value = new Value("");

            if (v1.IsNumeric && v2.IsNumeric)
            {
                double returnValue = double.Parse(v1.CurrentValue) / double.Parse(v2.CurrentValue);
                value.CurrentValue = returnValue.ToString();
            }

            else
            {
                throw new NotANumberException();
            }

            return value;
        }

        #endregion

        #region Helpers

        private static DateTime GetDateTime(string date)
        {
            DateTime datetime;
            DateTime.TryParseExact(date, dateTimeFormat,
                                         CultureInfo.CurrentCulture,
                                         DateTimeStyles.None,
                                         out datetime);

            return datetime;
        }

        private static TimeSpan GetTimeSpan(string time)
        {
            TimeSpan timeSpan;
            TimeSpan.TryParse(time, out timeSpan);
            return timeSpan;
        }

        #endregion

        #region ICloneable        

        public object Clone()
        {
            return new Value(this.CurrentValue);
        }

        #endregion
    }
}
