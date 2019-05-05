using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Threading;
using System.Windows.Media.Animation;

namespace RealArtist
{
    //КАК же тяжело придумать нормальный комментарий

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string Shape { get; set; } = "noShape";                  //значение выбранной фигуры

        public Brush drawC;                                             //свойство цвета
        private Brush DrawC
        {
            get
            {
                return drawC;
            }
            set
            {
                drawC = value;
                BNowColor.Background = DrawC;
            }
        }
        public Color drawBrushC;                                        //свойство цвета 
        private Color DrawBrushC
        {
            get
            {
                return drawBrushC;
            }
            set
            {
                drawBrushC = value;
                Album.DefaultDrawingAttributes.Color = DrawBrushC;
            }
        }                                  //цвет кисьти

        public double StrokeShape { get; set; } = 2;                 //толщина рисуемой фигуры        
        public bool Toggle { get; set; } = false;                    //включатель 
        public bool TogglePolyLine { get; set; } = false;

        public Point FirstPoint { get; set; }                           //точка нажатия мыши    
        public PointCollection PointC { get; set; }                     //коллекция точек

        public void PenEraser_Click(object sender, RoutedEventArgs e)       //стирает нарисованное
        {
            Shape = "noShape";
            Album.DefaultDrawingAttributes.Height = 40;
            Album.DefaultDrawingAttributes.Width = 40;
            Album.DefaultDrawingAttributes.Color = Colors.White;
        }

        private void BGray_Click(object sender, RoutedEventArgs e)      //меняет цвет кисти
        {
            DrawBrushC = Colors.Gray;
            DrawC = Brushes.Gray;
        }

        private void BBlack_Click(object sender, RoutedEventArgs e)
        {
            DrawBrushC = Colors.Black;
            DrawC = Brushes.Black;
        }

        private void BWhite_Click(object sender, RoutedEventArgs e)
        {
            DrawBrushC = Colors.White;
            DrawC = Brushes.White;
        }

        private void BRed_Click(object sender, RoutedEventArgs e)
        {
            DrawBrushC = Colors.Red;
            DrawC = Brushes.Red;
        }

        private void BOrange_Click(object sender, RoutedEventArgs e)
        {
            DrawBrushC = Colors.Orange;
            DrawC = Brushes.Orange;
        }

        private void BYellow_Click(object sender, RoutedEventArgs e)
        {
            DrawBrushC = Colors.Yellow;
            DrawC = Brushes.Yellow;
        }

        private void BLawnGreen_Click(object sender, RoutedEventArgs e)
        {
            DrawBrushC = Colors.LawnGreen;
            DrawC = Brushes.LawnGreen;
        }

        private void BGreen_Click(object sender, RoutedEventArgs e)
        {
            DrawBrushC = Colors.Green;
            DrawC = Brushes.Green;
        }

        private void BAquamarine_Click(object sender, RoutedEventArgs e)
        {
            DrawBrushC = Colors.Aquamarine;
            DrawC = Brushes.Aquamarine;
        }

        private void BSkyBlue_Click(object sender, RoutedEventArgs e)
        {
            DrawBrushC = Colors.DeepSkyBlue;
            DrawC = Brushes.DeepSkyBlue;
        }

        private void BBlue_Click(object sender, RoutedEventArgs e)
        {
            DrawBrushC = Colors.Blue;
            DrawC = Brushes.Blue;
        }

        private void BPurple_Click(object sender, RoutedEventArgs e)
        {
            DrawBrushC = Colors.Purple;
            DrawC = Brushes.Purple;
        }

        private void BPink_Click(object sender, RoutedEventArgs e)
        {
            DrawBrushC = Colors.HotPink;
            DrawC = Brushes.HotPink;
        }

        private void BSmall_Click(object sender, RoutedEventArgs e)     //устанавливает толщину кисти на минимальный
        {
            Album.DefaultDrawingAttributes.Height = 2;
            Album.DefaultDrawingAttributes.Width = 2;
            StrokeShape = 2;
        }

        private void BMiddle_Click(object sender, RoutedEventArgs e)     //устанавливает толщину кисти на средний   
        {
            Album.DefaultDrawingAttributes.Height = 10;
            Album.DefaultDrawingAttributes.Width = 10;
            StrokeShape = 10;
        }

        private void BBig_Click(object sender, RoutedEventArgs e)       //устанавливает толщину кисти на большой
        {
            Album.DefaultDrawingAttributes.Height = 20;
            Album.DefaultDrawingAttributes.Width = 20;
            StrokeShape = 20;
        }

        private void Pencil_Click(object sender, RoutedEventArgs e)             //выбор карандаша
        {
            Shape = "noShape";
            Album.DefaultDrawingAttributes.Color = DrawBrushC;
            Album.DefaultDrawingAttributes.Height = 2;
            Album.DefaultDrawingAttributes.Width = 2;
        }

        private void BRectangle_Click(object sender, RoutedEventArgs e)         //выбор рисования прямоугольника
        {
            Shape = "Rectangle";
        }

        private void BEllipse_Click(object sender, RoutedEventArgs e)           //выбор рисования овала
        {
            Shape = "Ellipse";
        }

        private void BCircle_Click(object sender, RoutedEventArgs e)            //выбор рисования круга
        {
            Shape = "Circle";
        }

        private void BLine_Click(object sender, RoutedEventArgs e)                      //определяет форму рисунка
        {
            Shape = "Line";
        }

        private void Brush_Click(object sender, RoutedEventArgs e)                          //определяет форму кисти шётки
        {
            Shape = "noShape";
            Album.DefaultDrawingAttributes.Color = DrawBrushC;
            try
            {
                int tempHeight = Convert.ToInt16(HeigthBrush.Text);
                int tempWidth = Convert.ToInt16(WidthBrush.Text);
                Album.DefaultDrawingAttributes.Height = tempHeight;
                Album.DefaultDrawingAttributes.Width = tempWidth;
            }
            catch
            {
                MessageBox.Show("Введите целые числа ниже Кисточки (H-высоту кисти и W-ширину кисти)");
            }

        }

        private void SizeOfAlbum_Click(object sender, RoutedEventArgs e)                    //меняет размер холста
        {
            try
            {
                int tempHeight = Convert.ToInt16(HeightAlbum.Text);
                int tempWidth = Convert.ToInt16(WidthAlbum.Text);
                Album.Height = tempHeight;
                Album.Width = tempWidth;
            }
            catch
            {
                MessageBox.Show("Введите целые числа ниже(H-высоту и W-ширину)");
            }
        }

        private void Album_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)     //событие при отпускании кнопки мыши
        {
            Toggle = false;
        }

        private void Album_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)        //действия при нажатии левой кнопки мыши мыши
        {
            FirstPoint = new Point(e.GetPosition(Album).X, e.GetPosition(Album).Y);
            FormSelection();
            Toggle = true;
        }

        private void Album_PreviewMouseMove(object sender, MouseEventArgs e)                //собыьтие при перемещении мыши 
        {
            if (Shape == "noShape")
            {
                return;
            }
            if (Toggle == false)
            {
                return;
            }
            Point MovePoint = new Point()
            {
                X = e.GetPosition(Album).X,
                Y = e.GetPosition(Album).Y
            };
            switch (Shape)
            {
                case "Line":
                    FinishLine(MovePoint);
                    break;
                case "Circle":
                    FinishCircle(MovePoint);
                    break;
                case "Rectangle":
                    FinishShape(MovePoint);
                    break;
                case "Ellipse":
                    FinishShape(MovePoint);
                    break;
                default:
                    break;
            }
        }

        private void FormSelection()                                                    //вызов функции отвечающей за конкретныую форму
        {
            PreFormSelection();
            switch (Shape)
            {
                case "Line":
                    DrawLine(FirstPoint, FirstPoint);
                    break;
                case "Rectangle":
                    DrawRectangle(FirstPoint.X, FirstPoint.Y);
                    break;
                case "Ellipse":
                    DrawEllipse(FirstPoint.X, FirstPoint.Y);
                    break;
                case "Circle":
                    DrawEllipse(FirstPoint.X, FirstPoint.Y);
                    break;
                case "PolyLine":
                    if (TogglePolyLine)
                    {
                        FinishPolyLine();
                    }
                    else DrawPolyLine();
                    break;
 
                default:
                    break;
            }
        }
       

        private void DrawLine(Point p1, Point p2)                                                 //рисует линию
        {
            Line myLine = new Line
            {
                Stroke = DrawC,
                X1 = p1.X,
                X2 = p2.X,
                Y1 = p1.Y,
                Y2 = p2.Y,
                StrokeThickness = StrokeShape
            };
            Album.Children.Add(myLine);
        }

        private void DrawRectangle(double X, double Y)                                            //рисует прямоугольник
        {
            Rectangle myRectangle = new Rectangle()
            {
                Stroke = DrawC,
                Margin = new Thickness(X, Y, 0, 0),
                StrokeThickness = StrokeShape,
                Height = 1,
                Width = 1
            };
            Album.Children.Add(myRectangle);
        }

        private void DrawEllipse(double X, double Y)                                              //рисует овал 
        {
            Ellipse myEllipse = new Ellipse()
            {
                Stroke = DrawC,
                Margin = new Thickness(X, Y, 0, 0),
                StrokeThickness = StrokeShape,
                Height = 1,
                Width = 1
            };
            Album.Children.Add(myEllipse);
        }

        

        private void DrawPolyLine()                                             //создание объекта, многоугольника не замкнутого
        {
            TogglePolyLine = true;
            PointC = new PointCollection
            {
                FirstPoint
            };
            Polyline myPolyline = new Polyline
            {
                Stroke = DrawC,
                StrokeThickness = StrokeShape
            };
            myPolyline.Points = PointC;
            Album.Children.Add(myPolyline);
        }

        

        private void FinishPolyLine()                                               //добавление на рисунок обьекта многолинейника :) 
        {
            Polyline Poly = (Polyline)Album.Children[Album.Children.Count - 1];
            Poly.Points.Add(FirstPoint);
        }

        private void FinishShape(Point p)
        {
            Shape newShape = (Shape)Album.Children[Album.Children.Count - 1];       //Если фигура прямоугольник или ОВАЛ
            double tempX, tempY;
            if (((p.X) - FirstPoint.X) > 0)
            {
                newShape.Width = (p.X) - FirstPoint.X;
                tempX = FirstPoint.X;
            }
            else
            {
                newShape.Width = FirstPoint.X - p.X;
                tempX = p.X;
            }
            if (((p.Y) - FirstPoint.Y) > 0)
            {
                newShape.Height = (p.Y) - FirstPoint.Y;
                tempY = FirstPoint.Y;
            }
            else
            {
                newShape.Height = FirstPoint.Y - p.Y;
                tempY = p.Y;
            }
            newShape.Margin = new Thickness(tempX, tempY, 0, 0);
        }

        private void FinishLine(Point p)                                            //рисование прямой при нажатой левой кнопки мыши
        {
            Line newLine = (Line)Album.Children[Album.Children.Count - 1];
            newLine.X2 = p.X;
            newLine.Y2 = p.Y;
        }

        private void FinishCircle(Point p)                                          //рисование круга при нажатой левой кнопки мыши
        {
            
            Ellipse newCircle = (Ellipse)Album.Children[Album.Children.Count - 1];
            double tempX, tempY, tempW, tempH;

            //определение диаметра круга
        
            tempW = 2 * Math.Abs((p.X) - FirstPoint.X);
            tempH = 2 * Math.Abs((p.Y) - FirstPoint.Y);

            if (tempH >= tempW)                                     //определение диаметра круга
            {
                newCircle.Height = tempH;
                newCircle.Width = tempH;
                tempX = FirstPoint.X - tempH / 2;
                tempY = FirstPoint.Y - tempH / 2;
            }
            else
            {
                newCircle.Width = tempW;
                newCircle.Height = tempW;
                tempX = FirstPoint.X - tempW / 2;
                tempY = FirstPoint.Y - tempW / 2;
            }
            newCircle.Margin = new Thickness(tempX, tempY, 0, 0);      //определение координат круга, от краёв альбома
        }



        private void BClear_Click(object sender, RoutedEventArgs e)                         //очистка рисунка от изменений
        {
            Album.Children.Clear();
            Album.Strokes.Clear();
            Toggle = false;
            TogglePolyLine = false;
        }

        private void SaveP_Click(object sender, RoutedEventArgs e)                          //сохранение рисунка
        {
            SaveFileDialog saveimg = new SaveFileDialog();
            saveimg.FileName = "Рисунок";
            saveimg.Filter = "Bitmap Image (.bmp)|*.bmp";

            bool? result = saveimg.ShowDialog();
            if (result == true)
            {
                string filename = saveimg.FileName;
                var fs = new FileStream(filename, FileMode.Create);
                Album.Strokes.Save(fs);
            }
        }

        private void OpenP_Click(object sender, RoutedEventArgs e)                          //открытие рисунка
        {
            OpenFileDialog openImg = new OpenFileDialog();
            openImg.FileName = "*";
            openImg.Filter = "Bitmap Image (.bmp)|*.bmp";
            var result = openImg.ShowDialog();
            if (result != true) return;
            string filename = openImg.FileName;
            var fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            Album.Strokes = new StrokeCollection(fs);
        }

        private void BPolyLine_Click(object sender, RoutedEventArgs e)                  //меняет режим рисования фигуры
        {

            Shape = "PolyLine";

        }

        private void BBack_Click(object sender, RoutedEventArgs e)                      //удаляет последнее изменение рисунка
        {
            try
            {
                Album.Children.RemoveAt(Album.Children.Count - 1);
            }
            catch { };
            try
            {
                Album.Strokes.RemoveAt(Album.Strokes.Count - 1);
            }
            catch { };
        }


        


        private void PreFormSelection()                                 //дополнительные настройки 
        {
            if (Shape != "PolyLine")
            {
                TogglePolyLine = false;
            }
            
            if (Shape != "noShape")
            {
                Album.UseCustomCursor = true;
                Album.DefaultDrawingAttributes.Color = Colors.Transparent;
            }
            else
                Album.UseCustomCursor = false;
        }

       
    }

}
