using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;


namespace _21._12._01._2
{
	public partial class ShtrikhKodi : Window
	{
		Dictionaries d = new Dictionaries();
        Random rand = new Random();

        int[] numbers = new int[13];

        string str = "101";
		string str7;

        public ShtrikhKodi()
		{
			InitializeComponent();

			GenerarionShtrikhKodi();
		}

		public void GenerarionShtrikhKodi()
        {
            tbxChisla.Text = null;
            lblDvoichnie.Content = null;

			byte set = 0;
			int chet = 0, nechet = 0, x = 40, y = 10, height = 150, widht = 4;

			for (int i = 0; i < 12; i++)
			{
				numbers[i] = rand.Next(0, 10);
                tbxChisla.Text += numbers[i].ToString();

                if ((i + 1) % 2 == 0)
				{
					chet += numbers[i];
				}

				if ((i + 1) % 2 == 1)
				{
					nechet += numbers[i];
				}

				if (i == 0 || i == 6)
				{
					tbxChisla.Text += "    ";
                }
            }

            numbers[12] = ((chet * 3 + nechet) / 10 + 1) * 10 - (chet * 3 + nechet);

			if (numbers[12] == 10)
            {
				numbers[12] = 0;
            }

            tbxChisla.Text += numbers[12].ToString();

			int a;

            for (int i = 1; i < 7; i++)
            {
                a = numbers[i];

                set = d.RightPart[numbers[0], i - 1];

                str7 = d.Sets[numbers[i], set];

                str += str7;

                lblDvoichnie.Content += $" {str7}";
            }

			lblDvoichnie.Content += "\n";

			str += "01010";

            for (int i = 7; i < 13; i++)
            {
				a = numbers[i];

				str7 = d.Sets[numbers[i], 2];

                str += str7;

                lblDvoichnie.Content += $" {str7}";
            }

			str += "101";

			char[] ch = str.ToCharArray();

			for (int i = 0; i < 95; i++)
			{
				Line line = new Line();

				line.Stroke = Brushes.Black;
				line.StrokeThickness = widht;
				line.X1 = x;
                line.X2 = x;

                if (i == 0 || i == 2 || i == 46 || i == 48 || i == 92 || i == 94)
                {
                    line.Y1 = y;
					line.Y2 = y + height + height / 5;
                }
				else
                {
					line.Y1 = y;
					line.Y2 = y + height;
				}

				if (ch[i] == '1')
				{
					canvas.Children.Add(line);
				}

				x += widht;
			}
		}

        private void btnPeregenirovanie_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
			Application.Current.Shutdown();
		}
    }
}
