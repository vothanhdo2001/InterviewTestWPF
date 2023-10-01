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

namespace INTERVIEW_TEST
{
    /// <summary>
    /// Interaction logic for Bai2.xaml
    /// </summary>
    public partial class Bai2 : Window
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void Caculator(object sender, RoutedEventArgs e)
        {
            try {
                Point3D P1 = new Point3D(Double.Parse(X1.Text), Double.Parse(Y1.Text), Double.Parse(Z1.Text));
                Point3D P2 = new Point3D(Double.Parse(X2.Text), Double.Parse(Y2.Text), Double.Parse(Z2.Text));
                AddResult.Text = "P1 + P2 = (" + P1.Add(P2).x.ToString() + ", " + P1.Add(P2).y.ToString() + ", " + P1.Add(P2).z.ToString() + ")";
                SubResult.Text = "P1 - P2 = (" + P1.Sub(P2).x.ToString() + ", " + P1.Sub(P2).y.ToString() + ", " + P1.Sub(P2).z.ToString() + ")";
                MulResult.Text = "P1 * K = (" + P1.Mul(Double.Parse(KValue.Text)).x.ToString() + ", " + P1.Mul(Double.Parse(KValue.Text)).y.ToString() + ", " + P1.Mul(Double.Parse(KValue.Text)).z.ToString() + ")";
                DivResult.Text = "P1 / K = (" + P1.Div(Double.Parse(KValue.Text)).x.ToString() + ", " + P1.Div(Double.Parse(KValue.Text)).y.ToString() + ", " + P1.Div(Double.Parse(KValue.Text)).z.ToString() + ")";
                DistanceResult.Text = "d(P1, P2)  = " + P1.DistanceTo(P2).ToString();
            } catch {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng !!!");
            }
        }
    }
}
