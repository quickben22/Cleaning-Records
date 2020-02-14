using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class CalendarViewModel : INotifyPropertyChanged
    {


        private int? _CleanerId;
        public int? CleanerId { get { return _CleanerId; } set { _CleanerId = (value); this.OnPropertyChanged("CleanerId"); } }



        private int? _TeamId;
        public int? TeamId { get { return _TeamId; } set { _TeamId = (value); this.OnPropertyChanged("TeamId"); } }


        private int? _ClientId;
        public int? ClientId { get { return _ClientId; } set { _ClientId = (value); this.OnPropertyChanged("ClientId"); } }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {

                if (prop == "TeamId" && TeamId != null && CleanerId != 0)
                    CleanerId = 0;
                else if (prop == "CleanerId" && CleanerId != null && TeamId != 0)
                    TeamId = 0;


                PropertyChanged(this, new PropertyChangedEventArgs(prop));



            }
        }
    }
}
