using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace RealArtist
{
    //КАК же тяжело придумать нормальный комментарий

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            rectangle1();

        }

        public string Shape { get; set; } = "noShape";                  //значение выбранной фигуры
        public string CurShape = "noShape";     
        public string Space;                                           //расположние файла
        public bool SpaceToogle=false;
       
        Point start;

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
        private Polyline myPolyline;
        private Rectangle myRect;

        public void rectangle1()
        {
            myRect = new System.Windows.Shapes.Rectangle();
            myRect.Stroke = System.Windows.Media.Brushes.Black;
            myRect.Fill = System.Windows.Media.Brushes.SkyBlue;
            myRect.HorizontalAlignment = HorizontalAlignment.Left;
            myRect.VerticalAlignment = VerticalAlignment.Center;
            myRect.Height = 50;
            myRect.Width = 50;
            Album.Children.Add(myRect);
        }
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

        public void polyline1()
        {
            // Add the Polyline Element
            myPolyline = new Polyline();
            myPolyline.Stroke = System.Windows.Media.Brushes.SlateGray;
            myPolyline.StrokeThickness = 2;
            myPolyline.FillRule = FillRule.EvenOdd;
            System.Windows.Point Point4 = new System.Windows.Point(1, 50);
            System.Windows.Point Point5 = new System.Windows.Point(10, 80);
            System.Windows.Point Point6 = new System.Windows.Point(20, 40);
            PointCollection myPointCollection2 = new PointCollection();
            myPointCollection2.Add(Point4);
            myPointCollection2.Add(Point5);
            myPointCollection2.Add(Point6);
            myPolyline.Points = myPointCollection2;
            Album.Children.Add(myPolyline);
        }
        public void PenEraser_Click(object sender, RoutedEventArgs e)       //стирает нарисованное
        {
            Shape = "noShape";
            Album.EditingMode = InkCanvasEditingMode.EraseByPoint;
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

        public static void CopyUIElementToClipboard(FrameworkElement element) //Копирование канвы в bitmap в буфер обмена
        {
            double width = element.ActualWidth;
            double height = element.ActualHeight;
            RenderTargetBitmap bmpCopied = new RenderTargetBitmap((int)Math.Round(width), (int)Math.Round(height), 96,
                96, PixelFormats.Default);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(element);
                dc.DrawRectangle(vb, null, new Rect(new Point(), new Size(width, height)));
            }

            bmpCopied.Render(dv);
            Clipboard.SetImage(bmpCopied);
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
            Album.EditingMode = InkCanvasEditingMode.Ink;
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
            Album.EditingMode = InkCanvasEditingMode.Ink;
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
            
                start = e.GetPosition(this);
                FirstPoint = new Point(e.GetPosition(Album).X, e.GetPosition(Album).Y);
                FormSelection();
                Toggle = true;
        }

        private void Album_PreviewMouseMove(object sender, MouseEventArgs e)                //собыьтие при перемещении мыши 
        {

            NumCh.Content = Album.Children.Count;
            var x = e.GetPosition(Album).X - e.GetPosition(Album).X % 0.001;
            var y = e.GetPosition(Album).Y - e.GetPosition(Album).Y % 0.001;
            Coord.Text = x + " , " + y;
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



        private void FinishPolyLine()                                               //добавление на рисунок обьекта многолинейника
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
            var saveimg = new SaveFileDialog
            {
                FileName = "Изображение",
                Filter =
                    "Ink Serialized Format (*.isf)|*.isf|" +
                    "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png"
            };

            var result = saveimg.ShowDialog();
            if (result == true)
            {
                using (FileStream file = new FileStream(saveimg.FileName,
                    FileMode.Create, FileAccess.Write))
                {
                    if (saveimg.FilterIndex == 1)
                    {
                        //InkCanvas1.Children.
                        Album.Strokes.Save(file);
                        file.Close();
                    }
                    else
                    {
                        var marg = 0;
                        RenderTargetBitmap rtb = new RenderTargetBitmap((int)Album.ActualWidth - marg,
                            (int)Album.ActualHeight - marg, 0, 0, PixelFormats.Default);
                        rtb.Render(Album);
                        BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(rtb));
                        encoder.Save(file);
                        file.Close();
                    }
                }
            }

        }

        private void SaveP1_Click(object sender, RoutedEventArgs e)                          //сохранение рисунка
        {
           
            if (SpaceToogle == true)
            {
                using (FileStream file = new FileStream(Space,
                    FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    if (System.IO.Path.GetExtension(Space) == ".isf")
                    {
                        Album.Strokes.Save(file);
                        file.Close();
                    }
                    else
                    {
                        var marg = 0;   //int.Parse(Album.Margin.Right.ToString());
                        RenderTargetBitmap rtb = new RenderTargetBitmap((int)Album.ActualWidth - marg,
                            (int)Album.ActualHeight - marg, 0, 0, PixelFormats.Default);
                        rtb.Render(Album);
                        BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(rtb));
                        encoder.Save(file);
                        file.Close();
                    }
                }
            }
            else
            {
                SaveP_Click(sender, e);
            }

        }

        private void OpenP_Click(object sender, RoutedEventArgs e)                          //открытие рисунка
        {
            var openImg = new OpenFileDialog();
            openImg.FileName = "*";
            openImg.Filter =
                "Ink Serialized Format (*.isf)|*.isf|" +
                "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
            var result = openImg.ShowDialog();
            if (result == true)
            {
                Album.Background = Brushes.White;
                Album.Strokes.Clear();
                try
                {
                    using (FileStream file = new FileStream(openImg.FileName,
                        FileMode.Open, FileAccess.Read))
                    {
                        if (openImg.FileName.ToLower().EndsWith(".isf"))
                        {
                            Album.Strokes = new StrokeCollection(file);
                            file.Close();
                        }
                        else
                        {
                            ImageBrush brush = new ImageBrush();
                            brush.ImageSource = new BitmapImage(new Uri(openImg.FileName, UriKind.Relative));
                            Album.Background = brush;
                        }
                    }
                    SpaceLabel.Content = openImg.FileName;
                    SpaceToogle = true;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, Title);
                }
            }

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


        private void CopyCommand(object sender, ExecutedRoutedEventArgs e) //Обработчик ктрл+с
        {
            CopyUIElementToClipboard(Album);
        }

        private void PasteCommand(object sender, ExecutedRoutedEventArgs e) //обработчик ктрл+в
        {
            if (Album.CanPaste())
            {
                Album.Paste(new Point(100, 100));
            }
        }



     

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CurShape = Shape;
            Shape = "";
            Toggle = false;
            TogglePolyLine = false;
            Album.EditingMode = InkCanvasEditingMode.Select;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            
            Shape = CurShape;
            
            Album.EditingMode = InkCanvasEditingMode.Ink;
        }
      
    }
}
