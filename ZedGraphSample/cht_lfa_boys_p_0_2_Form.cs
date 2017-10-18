using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGraphSample
{
    public partial class cht_lfa_boys_p_0_2_Form : Form
    {
        public cht_lfa_boys_p_0_2_Form()
        {
            InitializeComponent();
        }

        private readonly Color[] _colorList =  { Color.Chartreuse, Color.Red, Color.Green, Color.Blue, Color.Cyan };
        private readonly string[] _nameList =  { "3rd", "15th", "50th", "85th", "97th" };

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateGraph(zg1);
            SetSize();
        }

        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "0~2岁身高趋势表";
            myPane.XAxis.Title.Text = "月数";
            myPane.XAxis.Scale.MajorStep = 30;
            myPane.XAxis.Scale.MinorStep = 30;
            myPane.XAxis.Scale.Max = 720;
            myPane.XAxis.ScaleFormatEvent += XAxis_ScaleFormatEvent;

            myPane.YAxis.Title.Text = "身高";
            myPane.YAxis.Scale.Max = 95;
            myPane.YAxis.Scale.Min = 45;
            myPane.YAxis.Scale.MajorStep = 5;
            myPane.YAxis.Scale.MinorStep = 1;

            myPane.YAxis.MajorGrid.IsVisible = true; //'水平辅助线
            myPane.XAxis.MajorGrid.IsVisible = true;//'垂直辅助线

            zgc.IsShowPointValues = true;//鼠标悬停

            // Make up some data points from the Sine function

            PointPairList list2 = new PointPairList();
            var list1 = LoadPointsHelper.GetPointPairList("");
            //         for ( double x = 0; x < 36; x++ )
            //{
            //	//double y = Math.Sin( x * Math.PI / 15.0 );

            //	list1.Add( x, x );
            //    list2.Add(x+1, x+10);
            //         }

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            for (int i = 0; i < list1.Count; i++)
            {
                LineItem myCurve1 = myPane.AddCurve(_nameList[i], list1[i], _colorList[i],
                    SymbolType.None);
                //LineItem myCurve2 = myPane.AddCurve("My Curve", list2, Color.Blue,
                //    SymbolType.Circle);
                // Fill the area under the curve with a white-red gradient at 45 degrees
                //myCurve.Line.Fill = new Fill( Color.White, Color.Red, 45F );
                // Make the symbols opaque by filling them with white
                //myCurve1.Symbol.Fill = new Fill(Color.Brown);

                //myCurve2.Symbol.Fill = new Fill(Color.Chartreuse);
            }
            
            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.White, 45F);

            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.White, 45F);

            double[] d=new double[]{100};
            double[] y = new double[] { 80 };
            myPane.AddCurve(null,d,y, Color.Red, SymbolType.Star);
            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
        }

        private string XAxis_ScaleFormatEvent(GraphPane pane, Axis axis, double val, int index)
        {
            var value = val / 30;
            if (value < 12)
            {
                return $"{value}月";
            }
            if (value == 12)
            {
                return $"1年";
            }
            if (value == 24)
            {
                return $"2年";
            }
            if (value > 12)
            {
                return $"{value - 12}月";
            }

            return null;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void SetSize()
        {
            zg1.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            zg1.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20);
        }
    }
}