using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using Lab1.Models;

namespace Lab1.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		string text;
		string prevtext;
		string commandtext;
		bool secnum = false;

		public MainWindowViewModel()
		{
			OnclickCommand = ReactiveCommand.Create<string>((str) =>
			{
				if (str != "+" && str != "-" && str != "*" && str != "/" && str != "=")
					Greeting = text + str;

				else if (secnum == false)
				{
					secnum = true;
					commandtext = str;
					prevtext = text;
					text = "";
				}
				else
				{
					if (text == "") commandtext = str;
					else
					{
						try
						{
							Greeting = Calculator.Calc(prevtext, text, commandtext);
						}
						catch (RomanNumberException e)
						{
							Greeting = "Ошибка!";
							text = "";
						}
						finally
						{
							prevtext = "";
							if (str == "=") secnum = false;
							else
							{
								prevtext = text;
								text = "";
								commandtext = str;
							}
						}
					}

				}
			});
		}
		public string Greeting
		{
			set
			{
				this.RaiseAndSetIfChanged(ref text, value);
			}
			get
			{
				return text;
			}
		}

		public ReactiveCommand<string, Unit> OnclickCommand { get; }

	}
}
