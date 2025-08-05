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
using TheMazeGame_Remarstered.MMXXV_.Classes;
using TheMazeGame_Remarstered.MMXXV_.Classes.Display;

namespace TheMazeGame_Remarstered.MMXXV_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int refreshRate = 50;
		DispatcherTimer gameClock = new DispatcherTimer();


		World gameWorld;
        
        TheMazeGame_Remarstered.MMXXV_.Classes.Inputs.Inputs inputStates = new Classes.Inputs.Inputs();

        public MainWindow()
        {
          
           // gameClock = new DispatcherTimer();

            gameClock.Interval = TimeSpan.FromMilliseconds(refreshRate);
           
            gameClock.Tick += RunGameLoop;


			InitializeComponent();

			//Display userWindow = new Display();
			gameWorld = new World();

			

			gameClock.Start();
        
        }

        private void RunGameLoop(object sender, EventArgs e)
        {
            //GetInputs
            inputStates.UpdateAllInputStates();

            //UpdateGameState
            gameWorld.UpdateGameState(inputStates);

           
            //GetCanvas
            //mainWindow.Content = Display.Show(gameWorld);
            mainWindow.Content = Display.Render(gameWorld); 
           
           
		}


	}
}