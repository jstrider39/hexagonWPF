using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPainter
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      //DrawGridTEst();
      DrawTickTackToe();
    }

    public void DrawGrid()
    {

    }

    private void ccCAnvas_MouseDown(object sender, MouseButtonEventArgs e)
    {
      // TODO draw grid
    }

    public Func<int> GenNext()
    {
      int i = 0;
      return () => { return i++; };
    }

    public void DrawTickTackToe()
    {


      //var xStart = 10.0;
      //var xStep = 100.0;
      //var xStepCount = 3;
      //

      //I need to generate the pattern of true/false will create tick tack toe grid or not!!
      // So get the data/config that will be to draw each line, then do rules about it!
      // use semmetry so we only have one way
      // I can't write rule --need screen
      // I can't evaLUATE RULE --NEED SOME UNIT TEST FOR THAT.
      /*
       
        {
          StepNumber: <-- this is all I need !!
            
        }

       */


      var line = new LineGeometry();
      line.EndPoint = new Point(0, 10);
      line.EndPoint = new Point(0, 150);

      //GeometryGroup gg = new GeometryGroup();
      //gg.Children.Add(line);

      //Path p = new Path();
      
      //p.StrokeThickness = 3;
      //p.Stroke = Brushes.Black;
      //p.Data = gg;

      //ccCAnvas.Children.Add(p);
      //Canvas.SetTop(p, 0);
      //Canvas.SetLeft(p, 0);
      ccCAnvas.Background = Brushes.LightSlateGray;

      //https://stackoverflow.com/questions/8378252/draw-a-path-programmatically
      //myPath = new Path();
      //myPath.Stroke = System.Windows.Media.Brushes.Black;
      //myPath.Fill = System.Windows.Media.Brushes.MediumSlateBlue;
      //myPath.StrokeThickness = 4;
      //myPath.HorizontalAlignment = HorizontalAlignment.Left;
      //myPath.VerticalAlignment = VerticalAlignment.Center;
      //EllipseGeometry myEllipseGeometry = new EllipseGeometry();
      //myEllipseGeometry.Center = new System.Windows.Point(50, 50);
      //myEllipseGeometry.RadiusX = 25;
      //myEllipseGeometry.RadiusY = 25;
      //myPath.Data = myEllipseGeometry;

      
      
      double radius = 50;
      double xStep = GetPoint(new Point(0,0), 30, radius).X * 2;
      double yStep = GetPoint(new Point(0, 0), 90, radius).Y * 1.5;
      double rowStartAt = xStep;
      double colStartAT = xStep;

      int gridWidthCellCount = 4;
      int gridHeightCellCount = 4;
      var cellLeftRange = Enumerable.Range(0, gridWidthCellCount);
      var cellHeightRange = Enumerable.Range(0, gridHeightCellCount);

      var rowNum = GenNext();
      Point center = new Point(300, 300);
      foreach (var row in cellHeightRange)
      {
        
        var num = rowNum();
        center.Y = yStep * num + colStartAT;
        //Debug.WriteLine(num + " *************");
        //Debug.WriteLine(center.X);
        //center.Y = colStartAT;
        var colNum = GenNext();
        foreach (var col in cellLeftRange)
        {

          var colNumber = colNum();
          center.X = xStep * colNumber + rowStartAt;
          if (num % 2 == 1)
          {
            center.X += GetPoint(new Point(0, 0), 30, radius).X;
          }
          DrawHex(center, radius);
        }

      }


      //Point p44 = new Point(50, 50);
      //Point p33 = new Point(400, 500);

      ////DrawLine(p44, p33);
      //return;

      //
      //


    }

    public void DrawHex(Point center, double radius)
    {
      int i = -1;
      int max = 6;
      double angle2 = 30;
      while (++i < max)
      {
        Point p2 = GetPoint(center, angle2, radius);
        angle2 += 60;
        Point p3 = GetPoint(center, angle2, radius);
        DrawLine(p2, p3);
        //Debug.WriteLine(p2.X + ":" + p2.Y);
        //Debug.WriteLine(p3.X + ":" + p3.Y + " ------------------ ");
      }
    }

    public void DrawLine(Point one, Point two)
    {
      Line line2 = new Line();
      line2.StrokeThickness = 2;
      line2.X1 = one.X;
      line2.Y1 = one.Y;
      line2.X2 = two.X;
      line2.Y2 = two.Y;
      line2.Stroke = Brushes.Black;
      line2.Fill = Brushes.Purple;
      line2.StrokeEndLineCap = PenLineCap.Round;
      ccCAnvas.Children.Add(line2);
      Canvas.SetTop(line2, 0);
      Canvas.SetLeft(line2, 0);

      //var line = new LineGeometry();
      //line.StartPoint = one;
      //line.EndPoint = two;

      ////GeometryGroup gg = new GeometryGroup();
      ////gg.Children.Add(line);

      //Path p = new Path();

      //p.StrokeThickness = 3;
      //p.Stroke = Brushes.Purple;
      //p.Data = line;

      //ccCAnvas.Children.Add(p);
      //Canvas.SetTop(p, 0);
      //Canvas.SetLeft(p, 0);
    }

    public static Point GetPoint(Point StartAt, double angleDegrees, double hypotenuseLength)
    {
      double angle = angleDegrees * Math.PI / 180;
      Debug.WriteLine(angle);
      double x = Math.Cos(angle) * hypotenuseLength + StartAt.X;
      double y = Math.Sin(angle) * hypotenuseLength + StartAt.Y;
      return new Point(x, y);
    }
    
    public void DrawGridTEst()
    {
      var r = new RectangleGeometry();
      r.Rect = new Rect(100, 100, 400, 500);
      Path myPath = new Path();
      myPath.Fill = Brushes.Pink;
      myPath.Stroke = Brushes.Black;
      myPath.StrokeThickness = 1;
      myPath.Data = r;
      ccCAnvas.Children.Add(myPath);
    }
  }
}
