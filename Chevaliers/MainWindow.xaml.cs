using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Chevaliers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Dictionary<Place, Border> visiblePlaces = new();
        private Dictionary<(Place, Place), Line> paths = new();
        private Simulation simulator;
        private DispatcherTimer simTimer;
        private DispatcherTimer renderTimer;
        private const int simDelay = 10;
        private const int renderDelay = 250;
        private const int width = 1900;
        private const int height = 1100;
        private const int canvasPad = 15;

        private float zoomSpeed = 0.001f;
        private float zoom = 1;
        private float zoomMin = 0.5f;

        public MainWindow()
        {
            InitializeComponent();

            //Ellipse e = new Ellipse();
            //e.Height = 10;
            //e.Width = 10;
            //e.Fill = Brushes.Aqua;
            //e.Stroke = Brushes.Black;

            //plan.Children.Add(e);
            //Canvas.SetTop(e, 20);
            //Canvas.SetLeft(e, 50);

            Dictionary<int, Place> places = GameData.Knights3();
            //Dictionary<int, Place> places = Knights0();

            Place.EvaluateDeadEnds();

            simulator = new(places, width, height)
            {
                TopLeft = new Vector2(0, 0),
                BottomRight = new Vector2(width, height)
            };

            MakePlaces(places);

            //PlacePaths();

            simTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(simDelay)
            };
            simTimer.Tick += Step;
            simTimer.Start();

            renderTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(renderDelay)
            };
            renderTimer.Tick += Render;
            renderTimer.Start();
        }

        private void MakePlaces(Dictionary<int, Place> places)
        {
            foreach (Place place in places.Values)
            {
                MakePlace(place);
                //MovePlace(place, simulator.GetPosition(place));

                MakePaths(place);
            }
        }

        private (Vector2 topLeft, Vector2 bottomRight) FindBoundary()
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            Vector2 position;
            foreach(Place place in visiblePlaces.Keys)
            {
                position = simulator.GetPosition(place);

                if (position.X < minX)
                    minX = position.X;
                else if (position.X > maxX)
                    maxX = position.X;


                if (position.Y < minY)
                    minY = position.Y;
                else if (position.Y > maxY)
                    maxY = position.Y;
            }

            return (new Vector2(minX, minY), new Vector2(maxX, maxY));
        }

        private void Step(object? sender, EventArgs e)
        {
            simulator.Step();
        }

        private void Render(object? sender, EventArgs e)
        {
            (Vector2 topLeft, Vector2 bottomRight) = FindBoundary();
            Vector2 realDim = new Vector2(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
            Vector2 viewPortTopLeft = new Vector2(canvasPad, canvasPad);
            Vector2 viewDim = new Vector2((float)(plan.ActualWidth - 2 * canvasPad), (float)(plan.ActualHeight - 2 * canvasPad));

            foreach (Place place in visiblePlaces.Keys)
            {
                Vector2 screenPos = ScreenCoords(simulator.GetPosition(place), topLeft, realDim, viewPortTopLeft, viewDim);
                MovePlace(place, screenPos);
            }
            PlacePaths(topLeft, realDim, viewPortTopLeft, viewDim);
        }

        private void MakePlace(Place place)
        {
            TextBlock textBlock = new()
            {
                Text = place.ID.ToString(),
                FontSize = 14
            };

            if (place.ID == 0)
                textBlock.Background = Brushes.Green;

            else if (place.EndGame)
                textBlock.Background = Brushes.SandyBrown;

            else if (place.Enemies.Count > 0)
                textBlock.Background = Brushes.Orange;

            else if (place.IsDeadEnd)
                textBlock.Background = Brushes.Yellow;

            else if (place.HasNoEntry)
                textBlock.Background = Brushes.Red;

            else
                textBlock.Background = new SolidColorBrush(Color.FromArgb(200, 0, 255, 255));

            Border border = new()
            {
                Child = textBlock,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2)
            };

            plan.Children.Add(border);
            Canvas.SetZIndex(border, 1);

            visiblePlaces[place] = border;
        }
        
        private void MakePaths(Place place)
        {


            foreach (Path path in place.Paths)
            {
                //LinearGradientBrush gradientBrush = new();
                //gradientBrush.StartPoint = new Point(0, 0);
                //gradientBrush.EndPoint = new Point(1, 1);

                //GradientStop startGS = new GradientStop();
                //startGS.Color = Colors.Blue;
                //startGS.Offset = 0.0;
                //gradientBrush.GradientStops.Add(startGS);

                //GradientStop endGS = new GradientStop();
                //endGS.Color = Colors.Red;
                //endGS.Offset = 1;
                //gradientBrush.GradientStops.Add(endGS);

                var fromTo = (place, Place.PlaceIndex[path.To]);
                
                //if (paths.ContainsKey(fromTo))
                //    continue;

                Line line = new()
                {
                    StrokeThickness = 2,
                    //Stroke = gradientBrush
                    Stroke = Brushes.Black
                };

                paths[fromTo] = line;

                plan.Children.Add(line);
            }
        }

        private void PlacePaths(Vector2 topLeft, Vector2 realDim, Vector2 viewPortTopLeft, Vector2 viewDim)
        {
            foreach (KeyValuePair<(Place, Place), Line> kvp in paths)
            {
                Line line = kvp.Value;

                Vector2 from = ScreenCoords(simulator.GetPosition(kvp.Key.Item1), topLeft, realDim, viewPortTopLeft, viewDim);
                Vector2 to = ScreenCoords(simulator.GetPosition(kvp.Key.Item2), topLeft, realDim, viewPortTopLeft, viewDim);

                line.X1 = from.X + 1;
                line.X2 = to.X - 1;
                line.Y1 = from.Y + 1;
                line.Y2 = to.Y - 1;

                //LinearGradientBrush brush = (LinearGradientBrush)line.Stroke;
                //brush.StartPoint = new Point(from.X, from.Y);
                //brush.EndPoint = new Point(to.X, to.Y);
            }
        }

        private void MovePlace(Place place, Vector2 position)
        {
            Border border = visiblePlaces[place];
            Canvas.SetLeft(border, position.X - border.ActualWidth / 2);
            Canvas.SetTop(border, position.Y - border.ActualHeight / 2);
        }

        // Zoom on Mouse wheel
        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            zoom += zoomSpeed * e.Delta; // Ajust zooming speed (e.Delta = Mouse spin value )
            if (zoom < zoomMin) { zoom = zoomMin; } // Limit Min Scale
            //if (zoom > zoomMax) { zoom = zoomMax; } // Limit Max Scale

            Point mousePos = e.GetPosition(plan);

            if (zoom > 1)
            {
                plan.RenderTransform = new ScaleTransform(zoom, zoom, mousePos.X, mousePos.Y); // transform Canvas size from mouse position
            }
            else
            {
                plan.RenderTransform = new ScaleTransform(zoom, zoom); // transform Canvas size
            }
        }

        private Vector2 ScreenCoords(Vector2 coords, Vector2 topLeft, Vector2 realDimensoons, Vector2 viewPortTopLeft, Vector2 viewDimensions)
        {
            return new Vector2
            (
                (coords.X - topLeft.X) / realDimensoons.X * viewDimensions.X + viewPortTopLeft.X,
                (coords.Y - topLeft.Y) / realDimensoons.Y * viewDimensions.Y + viewPortTopLeft.Y
            );
        }
    }
}