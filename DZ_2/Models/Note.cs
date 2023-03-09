using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.ReactiveUI;

namespace DZ_2.Models
{
    public class Note : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Note(string f, string gr1, string gr2, string gr3, string gr4, string gr5, string gr6, string gr7, bool ch)
        {
            Fio = f;
            Grade1 = gr1;
            Grade2 = gr2;
            Grade3 = gr3;
            Grade4 = gr4;
            Grade5 = gr5;
            Grade6 = gr6;
            Grade7 = gr7;
            Check = ch;
            ChangeAverage();
        }

        string fio;
        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }

        string grade1;
        public string Grade1
        {
            get { return grade1; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade1 = value;
                else grade1 = "#ERROR";
                ChangeAverage();
            }
        }

        string grade2;
        public string Grade2
        {
            get { return grade2; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade2 = value;
                else grade2 = "#ERROR";
                ChangeAverage();
            }
        }

        string grade3;
        public string Grade3
        {
            get { return grade3; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade3 = value;
                else grade3 = "#ERROR";
                ChangeAverage();
            }
        }

        string grade4;
        public string Grade4
        {
            get { return grade4; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade4 = value;
                else grade4 = "#ERROR";
                ChangeAverage();
            }
        }

        string grade5;
        public string Grade5
        {
            get { return grade5; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade5 = value;
                else grade5 = "#ERROR";
                ChangeAverage();
            }
        }
        string grade6;
        public string Grade6
        {
            get { return grade6; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade6 = value;
                else grade6 = "#ERROR";
                ChangeAverage();
            }
        }

        string grade7;
        public string Grade7
        {
            get { return grade7; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade7 = value;
                else grade7 = "#ERROR";
                ChangeAverage();
            }
        }


        bool check;
        public bool Check
        {
            get { return check; }
            set { check = value; NotifyPropertyChanged(); }
        }

        string average;
        public string Average
        {
            get { return average; }
            set { average = value; NotifyPropertyChanged(); }
        }

        ISolidColorBrush brush;
        public ISolidColorBrush MyBrush
        {
            get { return brush; }
            set
            {
                brush = value;
                NotifyPropertyChanged();
            }
        }


        private void ChangeAverage()
        {
            double gradeint;
            double sum = 0;
            if (double.TryParse(Grade1, out gradeint)) sum += gradeint;
            else { Average = "#ERROR"; MyBrush = Brushes.White; return; }
            if (double.TryParse(Grade2, out gradeint)) sum += gradeint;
            else { Average = "#ERROR"; MyBrush = Brushes.White; return; }
            if (double.TryParse(Grade3, out gradeint)) sum += gradeint;
            else { Average = "#ERROR"; MyBrush = Brushes.White; return; }
            if (double.TryParse(Grade4, out gradeint)) sum += gradeint;
            else { Average = "#ERROR"; MyBrush = Brushes.White; return; }
            if (double.TryParse(Grade5, out gradeint)) sum += gradeint;
            else { Average = "#ERROR"; MyBrush = Brushes.White; return; }
            if (double.TryParse(Grade6, out gradeint)) sum += gradeint;
            else { Average = "#ERROR"; MyBrush = Brushes.White; return; }
            if (double.TryParse(Grade7, out gradeint)) sum += gradeint;
            else { Average = "#ERROR"; MyBrush = Brushes.White; return; }

            sum /= 7;
            Average = sum.ToString("N2");
            if (sum < 1) MyBrush = Brushes.Red;
            if (sum >= 1 && sum < 1.5) MyBrush = Brushes.Yellow;
            if (sum >= 1.5 && sum <= 2) MyBrush = Brushes.Green;

        }

    }

}
