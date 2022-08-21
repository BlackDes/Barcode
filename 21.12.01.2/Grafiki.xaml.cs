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
using System.Windows.Shapes;

using System.Windows.Forms.DataVisualization.Charting;

namespace _21._12._01._2
{
	/// <summary>
	/// Логика взаимодействия для Grafiki.xaml
	/// </summary>
	public partial class Grafiki : Window
	{
		public Grafiki()
		{
			InitializeComponent();

			tbxXminBogidaev.Text = "-1,5";
			tbxXmaxBogidaev.Text = "-2,5";
			tbxStepBogidaev.Text = "-0,5";

			tbxXminDolgikh.Text = "-4";
			tbxXmaxDolgikh.Text = "-6,2";
			tbxStepDolgikh.Text = "-0,2";
		}

		private void BtnOutput_Click(object sender, RoutedEventArgs e)
		{
			double Xmin = 0, Xmax = 0, Step = 0, XminD = 0, XmaxD = 0, StepD = 0;

			if ((!double.TryParse(tbxXminBogidaev.Text, out Xmin)) || (!double.TryParse(tbxXmaxBogidaev.Text, out Xmax)) || (!double.TryParse(tbxStepBogidaev.Text, out Step)) ||
				(!double.TryParse(tbxXminDolgikh.Text, out XminD)) || (!double.TryParse(tbxXmaxDolgikh.Text, out XmaxD)) || (!double.TryParse(tbxStepDolgikh.Text, out StepD)))
			{
				MessageBox.Show("Введите числа! Дробные числа вводятся с помощью запятой!", "Ошибка при ввводе");
			}
			else
			{
				if ((((Step < 0) && (Xmax > Xmin)) || ((Step > 0) && (Xmax < Xmin))) || (Math.Abs(Step) > Math.Abs(Xmax - Xmin)) ||
					(((StepD < 0) && (XmaxD > XminD)) || ((StepD > 0) && (XmaxD < XminD))) || (Math.Abs(StepD) > Math.Abs(XmaxD - XminD)))
				{
					MessageBox.Show("Введите корректные значения.\n1)Если шаг больше нуля, то Xmax должен быть больше Xmin.\n2)Если же шаг меньше нуля, то Xmax должен быть меньше Xmin.\n" +
										"3)Шаг не должен превышать разность иксов");
				}
				else
				{
					int count = Convert.ToInt32((Xmax - Xmin) / Step + 1);

					double[] x = new double[count];
					double[] y = new double[count];

					for (int i = 0; i < count; i++)
					{
						x[i] = Xmin + Step * i;
						y[i] = Math.Pow(x[i], 2) + Math.Tan(5 * x[i] - 0.8 / x[i]);
					}



					int countD = Convert.ToInt32((XmaxD - XminD) / StepD + 1);

					double[] xD = new double[countD];
					double[] yD = new double[countD];

					for (int i = 0; i < countD; i++)
					{
						xD[i] = XminD + StepD * i;
						yD[i] = xD[i] + Math.Sqrt(Math.Abs(Math.Pow(xD[i], 3) + 0.1 - Math.Exp(xD[i])));
					}



					chart.ChartAreas.Clear();
					chart.ChartAreas.Add(new ChartArea("ChartArea"));

					chart.Series.Clear();

					chart.Series.Add(new Series("Series1"));
					chart.Series["Series1"].ChartArea = "ChartArea";
					chart.Series["Series1"].ChartType = SeriesChartType.Line;
					chart.Series["Series1"].Points.DataBindXY(x, y);

					chart.Series.Add(new Series("Series2"));
					chart.Series["Series2"].ChartArea = "ChartArea";
					chart.Series["Series2"].ChartType = SeriesChartType.Line;
					chart.Series["Series2"].Points.DataBindXY(xD, yD);
				}
			}
		}
	}
}
