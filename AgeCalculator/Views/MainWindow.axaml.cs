using Avalonia.Controls;
using System;
using System.Diagnostics;
using MsBox.Avalonia;

namespace AgeCalculator.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
    }

    private void getBirthDate(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {   
        string monthText = MonthInput.Text ;
        string dayText = DaysInput.Text;
        string yearText = YearsInput.Text;

        if(int.TryParse(monthText,out int month) && int.TryParse(dayText, out int day) && int.TryParse(yearText, out int year))
        {
            Debug.WriteLine($"Month: {month}, Day: {day}, Year: {year}");
            ageResult(month, day, year);    

        }
        else
        {
            Debug.WriteLine("Invalid input in one or more fields.");
        }

           
    }
    private void ageResult(int month, int day, int year)
    {
        // get the birthdate
        // minus to currentDate 

        // get years of existing 
        // get month of existing
        // get days of existing

        // Display years month and days 

        // Math psuedo
        // years = (birthyear - currentYear) * 12 - Monthnow
        // MonthNow = (birhtMonth - currentMonth) month = 7 - 4 = 3 months // 
        // totalMonth = MonthNow - 12
        // days = (birthDay - currentDay) days = 30 - 15 = 15 days

        try
        {
            DateTime birthDate = new DateTime(year, month, day);
            DateTime currentDate = DateTime.Now;
            int years = currentDate.Year - birthDate.Year;
            int months = currentDate.Month - birthDate.Month;
            int days = currentDate.Day - birthDate.Day;

            if (days < 0)
            {
                months--;
                DateTime previousMonth = currentDate.AddMonths(-1);
                days += DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }
            yearsResult.Text = years.ToString();
            monthsResult.Text = months.ToString();
            daysResult.Text = days.ToString();

        }
        catch (ArgumentOutOfRangeException)
        {
            Debug.WriteLine("Invalid date entered.");
            ShowErrorMessage();
        }
        
    }
    
    private async void ShowErrorMessage ()
    {
        var messagebox =  MessageBoxManager.GetMessageBoxStandard("Error", "Please enter a valid date");
        await messagebox.ShowAsync();

    }
}