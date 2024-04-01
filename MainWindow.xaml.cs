// Path/filename: Calculator/MainWindow.xaml.cs
using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private double lastNumber, result;
        private SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender is Button button)
            {
                selectedValue = int.Parse(button.Content.ToString());
            }

            if (Display.Text == "0")
            {
                Display.Text = selectedValue.ToString();
            }
            else
            {
                Display.Text += selectedValue.ToString();
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                lastNumber = double.Parse(Display.Text);
                Display.Text = "0";

                switch (button.Content.ToString())
                {
                    case "+":
                        selectedOperator = SelectedOperator.Addition;
                        break;
                    case "-":
                        selectedOperator = SelectedOperator.Subtraction;
                        break;
                    case "*":
                        selectedOperator = SelectedOperator.Multiplication;
                        break;
                    case "/":
                        selectedOperator = SelectedOperator.Division;
                        break;
                }
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber = double.Parse(Display.Text);

            switch (selectedOperator)
            {
                case SelectedOperator.Addition:
                    result = SimpleMath.Add(lastNumber, newNumber);
                    break;
                case SelectedOperator.Subtraction:
                    result = SimpleMath.Subtract(lastNumber, newNumber);
                    break;
                case SelectedOperator.Multiplication:
                    result = SimpleMath.Multiply(lastNumber, newNumber);
                    break;
                case SelectedOperator.Division:
                    result = SimpleMath.Divide(lastNumber, newNumber);
                    break;
            }

            Display.Text = result.ToString();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            result = 0;
            lastNumber = 0;
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public static class SimpleMath
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b) => a / b;
    }
}
