using System;
using System.Collections.Generic;
using System.Text;
using DZ_2.Models;
using Avalonia.Media;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;

namespace DZ_2.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
        public MainWindowViewModel()
        {
            Notes = BuildAllNotes();
            foreach (var note in Notes)
                note.PropertyChanged += ContentCollectionChanged;

            ChangeAverage();
        }

        string control1;
        public string Control1
        {
            get { return control1; }
            set { this.RaiseAndSetIfChanged(ref control1, value); }
        }

        string control2;
        public string Control2
        {
            get { return control2; }
            set { this.RaiseAndSetIfChanged(ref control2, value); }
        }

        string control3;
        public string Control3
        {
            get { return control3; }
            set { this.RaiseAndSetIfChanged(ref control3, value); }
        }

        string control4;
        public string Control4
        {
            get { return control4; }
            set { this.RaiseAndSetIfChanged(ref control4, value); }
        }

        string control5;
        public string Control5
        {
            get { return control5; }
            set { this.RaiseAndSetIfChanged(ref control5, value); }
        }

        string control6;
        public string Control6
        {
            get { return control6; }
            set { this.RaiseAndSetIfChanged(ref control6, value); }
        }

        string control7;
        public string Control7
        {
            get { return control7; }
            set { this.RaiseAndSetIfChanged(ref control7, value); }
        }

        public void ChangeAverage()
        {
            double sum1 = 0;
            double sum2 = 0;
            double sum3 = 0;
            double sum4 = 0;
            double sum5 = 0;
            double sum6 = 0;
            double sum7 = 0;
            bool er1 = false;
            bool er2 = false;
            bool er3 = false;
            bool er4 = false;
            bool er5 = false;
            bool er6 = false;
            bool er7 = false;
            double count = 0;
            double gradeint;
            foreach (var note in Notes)
            {
                count++;
                if (double.TryParse(note.Grade1, out gradeint)) sum1 += gradeint;
                else { er1 = true; Control1 = "#ERROR"; Color1 = Brushes.White; }
                if (double.TryParse(note.Grade2, out gradeint)) sum2 += gradeint;
                else { er2 = true; Control2 = "#ERROR"; Color2 = Brushes.White; }
                if (double.TryParse(note.Grade3, out gradeint)) sum3 += gradeint;
                else { er3 = true; Control3 = "#ERROR"; Color3 = Brushes.White; }
                if (double.TryParse(note.Grade4, out gradeint)) sum4 += gradeint;
                else { er4 = true; Control4 = "#ERROR"; Color4 = Brushes.White; }
                if (double.TryParse(note.Grade5, out gradeint)) sum5 += gradeint;
                else { er5 = true; Control5 = "#ERROR"; Color5 = Brushes.White; }
                if (double.TryParse(note.Grade6, out gradeint)) sum6 += gradeint;
                else { er6 = true; Control6 = "#ERROR"; Color6 = Brushes.White; }
                if (double.TryParse(note.Grade7, out gradeint)) sum7 += gradeint;
                else { er7 = true; Control7 = "#ERROR"; Color7 = Brushes.White; }
            }

            if (!er1)
            {
                Control1 = (sum1 / count).ToString("N2");
                if (sum1 / count < 1) Color1 = Brushes.Red;
                if (sum1 / count >= 1 && sum1 / count < 1.5) Color1 = Brushes.Yellow;
                if (sum1 / count >= 1.5) Color1 = Brushes.Green;
            }
            if (!er2)
            {
                Control2 = (sum2 / count).ToString("N2");
                if (sum2 / count < 1) Color2 = Brushes.Red;
                if (sum2 / count >= 1 && sum2 / count < 1.5) Color2 = Brushes.Yellow;
                if (sum2 / count >= 1.5) Color2 = Brushes.Green;
            }
            if (!er3)
            {
                Control3 = (sum3 / count).ToString("N2");
                if (sum3 / count < 1) Color3 = Brushes.Red;
                if (sum3 / count >= 1 && sum3 / count < 1.5) Color3 = Brushes.Yellow;
                if (sum3 / count >= 1.5) Color3 = Brushes.Green;
            }
            if (!er4)
            {
                Control4 = (sum4 / count).ToString("N2");
                if (sum4 / count < 1) Color4 = Brushes.Red;
                if (sum4 / count >= 1 && sum4 / count < 1.5) Color4 = Brushes.Yellow;
                if (sum4 / count >= 1.5) Color4 = Brushes.Green;
            }
            if (!er5)
            {
                Control5 = (sum5 / count).ToString("N2");
                if (sum5 / count < 1) Color5 = Brushes.Red;
                if (sum5 / count >= 1 && sum5 / count < 1.5) Color5 = Brushes.Yellow;
                if (sum5 / count >= 1.5) Color5 = Brushes.Green;
            }
            if (!er6)
            {
                Control6 = (sum6 / count).ToString("N2");
                if (sum6 / count < 1) Color6 = Brushes.Red;
                if (sum6 / count >= 1 && sum6 / count < 1.5) Color6 = Brushes.Yellow;
                if (sum6 / count >= 1.5) Color6 = Brushes.Green;
            }
            if (!er7)
            {
                Control7 = (sum7 / count).ToString("N2");
                if (sum7 / count < 1) Color7 = Brushes.Red;
                if (sum7 / count >= 1 && sum7 / count < 1.5) Color7 = Brushes.Yellow;
                if (sum7 / count >= 1.5) Color7 = Brushes.Green;
            }
        }

        ObservableCollection<Note> notes;
        public ObservableCollection<Note> Notes
        {
            get
            {
                return notes;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref notes, value);
                ChangeAverage();
            }
        }
        public void ContentCollectionChanged(object? sender, PropertyChangedEventArgs e)
        {
            ChangeAverage();
        }

        private ObservableCollection<Note> BuildAllNotes()
        {
            return new ObservableCollection<Note>
            {
                new Note("Генрих Алексей Олегович","0","1","2","0","1","1","2",false),
                new Note("Александр Сергеевич Пушкин","2","1","2","1","2","1","0",false),
                new Note("Владимир Владимирович Пупкин","2","2","2","0","1","2","2",false),
                new Note("Милешко Антон Владимирович","0","2","0","0","0","1","2",false),
                new Note("Это шутка._.не принимайте близко","2","0","1","1","1","1","1",false)
            };
        }

        ISolidColorBrush color1;
        public ISolidColorBrush Color1
        {
            get { return color1; }
            set { this.RaiseAndSetIfChanged(ref color1, value); }
        }

        ISolidColorBrush color2;
        public ISolidColorBrush Color2
        {
            get { return color2; }
            set { this.RaiseAndSetIfChanged(ref color2, value); }
        }

        ISolidColorBrush color3;
        public ISolidColorBrush Color3
        {
            get { return color3; }
            set { this.RaiseAndSetIfChanged(ref color3, value); }
        }

        ISolidColorBrush color4;
        public ISolidColorBrush Color4
        {
            get { return color4; }
            set { this.RaiseAndSetIfChanged(ref color4, value); }
        }
        ISolidColorBrush color5;
        public ISolidColorBrush Color5
        {
            get { return color5; }
            set { this.RaiseAndSetIfChanged(ref color5, value); }
        }

        ISolidColorBrush color6;
        public ISolidColorBrush Color6
        {
            get { return color6; }
            set { this.RaiseAndSetIfChanged(ref color6, value); }
        }

        ISolidColorBrush color7;
        public ISolidColorBrush Color7
        {
            get { return color7; }
            set { this.RaiseAndSetIfChanged(ref color7, value); }
        }

    }
}
