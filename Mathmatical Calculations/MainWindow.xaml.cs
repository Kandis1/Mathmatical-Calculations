using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mathmatical_Calculations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static double Area(double theRad)
        {
            double theArea = Math.PI * (Math.Pow(theRad, 2));

            return theArea;
        }
        public static double Circumference(double circRad)
        {
            double theCircum = 2 * Math.PI * circRad;
            return theCircum;
        }
        public static double Hemisphere(double hemisphereRad)
        {
            //an alternate for the hemisphere equation: V = (2/3)(Pi)(Radius^2)
            double a = 2;
            double b = 3;
            double volume = (((a / b)) * Math.PI * (Math.Pow(hemisphereRad, 3)));
            return volume;
        }

        public static double SidesArea(double sideA, double sideB, double sideC)
        {
            double halfCircum = ((sideA + sideB + sideC) / 2);
            double sideArea = Math.Sqrt((halfCircum) * (halfCircum - sideA) * (halfCircum - sideB) * (halfCircum - sideC));
            return sideArea;
        }

        public static double QuadraticEquationPlus(double quadA, double quadB, double quadC)
        {
            double quadraticPlus = ((-1 * quadB) + (Math.Sqrt(((Math.Pow(quadB, 2))) - (4 * quadA * quadC))))
                / (2 * quadA);
            return quadraticPlus;
        }
        public static double QuadraticEquationMinus(double quadA, double quadB, double quadC)
        {
            double quadraticMinus = ((-1 * quadB) - (Math.Sqrt(((Math.Pow(quadB, 2))) - (4 * quadA * quadC))))
                / (2 * quadA);
            return quadraticMinus;
        }

        private void onClick(object sender, RoutedEventArgs e)
        {

            try
            {
                if ((bool)areanCirc.IsChecked)
                {
                    if (String.IsNullOrEmpty(UserInput1.Text))
                    {
                        throw new InvalidOperationException("No Input");
                    }
                    else if (Double.Parse(UserInput1.Text) <= 0)
                        throw new InvalidOperationException("Your input must be greater than zero.");
                    else
                    {
                        double aReaAnswer, circAnswer;
                        aReaAnswer = checked(Area(Double.Parse(UserInput1.Text)));
                        circAnswer = checked(Circumference(Double.Parse(UserInput1.Text)));
                        aNswerSection.Text = "";
                        aNswerSection.Text = $"The Area of the Circle is {Math.Round((aReaAnswer), 2)}.";
                        aNswerSection.Text += "\n";
                        aNswerSection.Text += "\n";
                        aNswerSection.Text += $"The Circumeference of the Circle is {Math.Round((circAnswer), 2)}";
                    }
                }
                else if ((bool)hemisphere.IsChecked)
                {
                    if (String.IsNullOrEmpty(UserInput1.Text))
                    {
                        throw new InvalidOperationException("No Input");
                    }
                    else if (Double.Parse(UserInput1.Text) <= 0)
                        throw new InvalidOperationException("Your input must be greater than zero.");
                    else
                    {
                        double hemisAnswer;
                        hemisAnswer = checked(Hemisphere(Double.Parse(UserInput1.Text)));
                        aNswerSection.Text = "";
                        aNswerSection.Text = $"The volume of a hemisphere is {Math.Round((hemisAnswer), 2)}";
                    }
                }
                else if ((bool)threeSideTriangle.IsChecked)
                {
                    if (String.IsNullOrEmpty(UserInput1.Text) || String.IsNullOrEmpty(UserInput2.Text) || String.IsNullOrEmpty(UserInput3.Text))
                    {
                        throw new InvalidOperationException("No Input");
                    }
                    else if (Double.Parse(UserInput1.Text) <= 0 || Double.Parse(UserInput2.Text) <= 0 || Double.Parse(UserInput1.Text) <= 0)
                        throw new InvalidOperationException("Your input must be greater than zero.");
                    else
                    {
                        double aSide, bSide, cSide, triAreaAnswer;
                        aSide = ((Convert.ToDouble(UserInput1.Text)));
                        bSide = ((Convert.ToDouble(UserInput2.Text)));
                        cSide = ((Convert.ToDouble(UserInput3.Text)));
                        triAreaAnswer = checked(SidesArea(aSide, bSide, cSide));
                        aNswerSection.Text = $"Using the sides of the triangle, the Area is: {Math.Round((triAreaAnswer), 2)}";
                    }

                }
                else if ((bool)quaDratic.IsChecked)
                {
                    if (String.IsNullOrEmpty(UserInput1.Text) || String.IsNullOrEmpty(UserInput2.Text) || String.IsNullOrEmpty(UserInput3.Text))
                    {
                        throw new InvalidOperationException("No Input");
                    }
                    else if (Double.Parse(UserInput1.Text) <= 0 || Double.Parse(UserInput2.Text) <= 0 || Double.Parse(UserInput1.Text) <= 0)
                        throw new InvalidOperationException("Your input must be greater than zero.");
                    else
                    {
                        double quaddoubleA, quaddoubleB, quaddoubleC;
                        quaddoubleA = Convert.ToDouble(UserInput1.Text);
                        quaddoubleB = Convert.ToDouble(UserInput2.Text);
                        quaddoubleC = Convert.ToDouble(UserInput3.Text);
                        if (quaddoubleA > 0 && quaddoubleB >= 0 && quaddoubleC >= 0)
                        {
                            if ((quaddoubleA * 2) > 0)
                            {
                                if ((((Math.Pow(quaddoubleB, 2)) - (4 * quaddoubleA * quaddoubleC))) >= 0)
                                {
                                    double solvePlus = checked(QuadraticEquationPlus(quaddoubleA, quaddoubleB, quaddoubleC));
                                    double solveMinus = checked(QuadraticEquationMinus(quaddoubleA, quaddoubleB, quaddoubleC));
                                    aNswerSection.Text = "";
                                    aNswerSection.Text = $"Answer: {Math.Round((solvePlus), 2)}, {Math.Round((solveMinus), 2)}";
                                }
                                else
                                {
                                    throw new InvalidOperationException("Discriminate must be zero or greater!");
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("Can not divide by zero!");
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("A must be greater than zero. B and C must be greater than " +
                                "or equal to zero!");
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException("No Selection");
                }
            }
            catch (FormatException fEx)
            {
                aNswerSection.Text = fEx.Message;
                aNswerSection.Text += "\n";
                aNswerSection.Text += "\n";
                aNswerSection.Text += "Please Try Again!";
                aNswerSection.Text += "\n";
                aNswerSection.Text += "\n";
                aNswerSection.Text += "Make the Selections and Press Calculate";
            }
            catch (OverflowException oEx)
            {
                aNswerSection.Text = oEx.Message;
                aNswerSection.Text += "\n";
                aNswerSection.Text += "\n";
                aNswerSection.Text += "Please Try Again!";
                aNswerSection.Text += "\n";
                aNswerSection.Text += "\n";
                aNswerSection.Text += "Make the Selections and Press Calculate";

            }
            catch (InvalidOperationException ioEx)
            {
                aNswerSection.Text = ioEx.Message;
                aNswerSection.Text += "\n";
                aNswerSection.Text += "\n";
                aNswerSection.Text += "Please Try Again!";
                aNswerSection.Text += "\n";
                aNswerSection.Text += "\n";
                aNswerSection.Text += "Make the Selections and Press Calculate";
            }
            catch (Exception ex)
            {
                aNswerSection.Text = ex.Message;
                aNswerSection.Text += "\n";
                aNswerSection.Text += "\n";
                aNswerSection.Text += "Please Try Again!";
                aNswerSection.Text += "\n";
                aNswerSection.Text += "\n";
                aNswerSection.Text += "Make the Selections and Press Calculate";
            }
            finally
            {
                UserInput1.Text = "";
                UserInput2.Text = "";
                UserInput2.IsEnabled = true;
                UserInput3.IsEnabled = true;
                TextBlock1.Text = "";
                TextBlock1.IsEnabled = true;
                TextBlock2.Text = "";
                TextBlock2.IsEnabled = true;
                TextBlock3.Text = "";
                TextBlock3.IsEnabled = true;
                TextBlocksPEC.Text = "";
                TextBlocksPEC.IsEnabled = true;
                UserInput1.Text = "";
                UserInput2.Text = "";
                UserInput3.Text = "";
                hemisphere.IsEnabled = true;
                quaDratic.IsEnabled = true;
                threeSideTriangle.IsEnabled = true;
                areanCirc.IsEnabled = true;
                hemisphere.IsChecked = false;
                quaDratic.IsChecked = false;
                threeSideTriangle.IsChecked = false;
                areanCirc.IsChecked = false;
            }
          
            
         }

        private void onArea(object sender, RoutedEventArgs e)
        {
            UserInput1.Text = "";
            UserInput2.IsEnabled= false;
            UserInput3.IsEnabled = false;
            TextBlock1.Text = "";
            TextBlocksPEC.Text = "Input Radius";
            TextBlock2.Text = "";
            TextBlock2.IsEnabled = false;
            TextBlock3.Text = "";           
            TextBlock3.IsEnabled = false;
            hemisphere.IsEnabled = false;            
            quaDratic.IsEnabled = false;
            threeSideTriangle.IsEnabled = false;
            hemisphere.IsChecked = false;
            quaDratic.IsChecked = false;
            threeSideTriangle.IsChecked = false;

        }

        private void onHemis(object sender, RoutedEventArgs e)
        {
            UserInput1.Text = "";
            UserInput2.IsEnabled = false;
            UserInput3.IsEnabled = false;
            TextBlock1.Text = "";
            TextBlocksPEC.Text = "Input Radius";
            TextBlock2.Text = "";
            TextBlock2.IsEnabled = false;
            TextBlock3.Text = "";
            TextBlock3.IsEnabled = false;
            areanCirc.IsEnabled = false;
            quaDratic.IsEnabled = false;
            threeSideTriangle.IsEnabled = false;
            areanCirc.IsChecked = false;
            quaDratic.IsChecked = false;
            threeSideTriangle.IsChecked = false;
        }

        private void onLength(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = "";
            TextBlock1.Text = "Side A";
            TextBlock2.Text = "";
            TextBlock2.Text = "Side B";
            TextBlock3.Text = "";
            TextBlock3.Text = "Side C";
            hemisphere.IsEnabled = false;
            quaDratic.IsEnabled = false;
            areanCirc.IsEnabled = false;
            hemisphere.IsChecked = false;
            quaDratic.IsChecked = false;
            areanCirc.IsChecked = false;
        }

        private void onQuad(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = "";
            TextBlock1.Text = "A =";
            TextBlock2.Text = "";
            TextBlock2.Text = "B = ";
            TextBlock3.Text = "";
            TextBlock3.Text = "C = ";     
            hemisphere.IsEnabled = false;
            threeSideTriangle.IsEnabled = false;
            areanCirc.IsEnabled = false;
            hemisphere.IsChecked = false;
            areanCirc.IsChecked = false;
            threeSideTriangle.IsChecked = false;
        }
    }   
}
