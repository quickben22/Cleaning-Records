using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonthCalendar
{
/// <summary>
/// This class is actually a stripped-down version of the actual Appointment class, which was generated using the 
/// Linq-to-SQL Designer (essentially a Linq ORM to the Appointments table in the db)
/// </summary>
/// <remarks>Obviously, you should use your own appointment object/classes, and change the code-behind in MonthView.xaml.vb to
/// support a List(Of T) where T is whatever the System.Type is for your appointment class.
/// </remarks>
/// <author>Kirk Davis, February 2009 (in like, 4 hours, and it shows!)</author>
    public class Appointment
    {

        private int _CleaningJobID;
        private string _Subject;

        private System.Nullable<System.DateTime> _Date;
 


        public Appointment()
            : base()
        {
        }

        public int CleaningJobID
        {
            get { return this._CleaningJobID; }
            set
            {
                if (((this._CleaningJobID == value) == false))
                {
                    this._CleaningJobID = value;
                }
            }
        }

        private int? _CleanerID;
        public int? CleanerID
        {
            get { return this._CleanerID; }
            set
            {
                if (((this._CleanerID == value) == false))
                {
                    this._CleanerID = value;
                }
            }
        }

        private int? _TeamID;
        public int? TeamID
        {
            get { return this._TeamID; }
            set
            {
                if (((this._TeamID == value) == false))
                {
                    this._TeamID = value;
                }
            }
        }

        private int? _ServiceId;
        public int? ServiceId
        {
            get { return this._ServiceId; }
            set
            {
                if (((this._ServiceId == value) == false))
                {
                    this._ServiceId = value;
                }
            }
        }


        private string _Color;
        public string Color
        {
            get { return this._Color; }
            set
            {
                if (((this._Color == value) == false))
                {
                    this._Color = value;
                }
            }
        }

        private string _ServiceColor;
        public string ServiceColor
        {
            get { return this._ServiceColor; }
            set
            {
                if (((this._ServiceColor == value) == false))
                {
                    this._ServiceColor = value;
                }
            }
        }



        public string Subject
        {
            get { return this._Subject; }
            set
            {
                if ((string.Equals(this._Subject, value) == false))
                {
                    this._Subject = value;
                }
            }
        }

     

        public System.Nullable<System.DateTime> Date
        {
            get { return this._Date; }
            set
            {
                if ((this._Date.Equals(value) == false))
                {
                    this._Date = value;
                }
            }
        }

      

       
    }
}
