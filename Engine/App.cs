namespace Engine
{
    public class App
    {
        /// <summary>
        /// The window list of the app.
        /// </summary>
        private List<Window> windows;

        private int _fps;
        /// <summary>
        /// At how many Frames Per Second does the App run?
        /// </summary>
        /// <value>The value indicates how fast the app redraws/refreshes (Does not affect input)</value>
        public int Fps
        {
            get => _fps;
            set
            {
                if (!ValidateFps(value) || value == _fps)
                    return;

                _fps = value;
                delay = 1000/value;
            }
        }

        /// <summary>
        /// The app's delay - 1000/<see cref="Fps"/>.
        /// </summary>
        private int delay;

        public delegate void KeyEvent(ConsoleKeyInfo key);
        public event KeyEvent OnKeyPress = (_) => {};
        
        /// <summary>
        /// Construct a new <see cref="App"/>.
        /// </summary>
        /// <param name="fps">How many Frames Per Second will the game run at?</param>
        /// <param name="startWindows">The windows with which to initialize the <see cref="App"/>.</param>s
        /// <returns></returns>
        public App(int fps, params Window[] startWindows)
        {
            if (startWindows.Length > 0)
                windows = startWindows.ToList();
            else
                windows = new List<Window>();
            
            Fps = fps;
            InitializeApp();
        }


        /// <summary>
        /// Initialize <see langword="this"/> <see cref="App"/>.
        /// </summary>
        private void InitializeApp()
        {
            // Null check windows
            if (windows == null)
                windows = new List<Window>();

            // Initialize input
            Task.Run(async () => await InputUpdate());

            // Initialize update
            Task.Run(async () => await GameUpdate());
        }


        /// <summary>
        /// Check for input
        /// </summary>
        /// <returns></returns>
        private async Task InputUpdate()
        {
            const int inputDelay = 1000/100; // Check for input 100 times a second

            while (true)
            {
                // Wait until a key is pressed
                while (!Console.KeyAvailable)
                    await Task.Delay(inputDelay);

                ConsoleKeyInfo key = Console.ReadKey(true);
                OnKeyPress?.Invoke(key);
            }
        }


        /// <summary>
        /// Update all <see cref="windows"/> every <see cref="delay"/>.
        /// </summary>
        /// <returns></returns>
        private async Task GameUpdate()
        {
            while (true)
            {
                CallUpdate();
                await Task.Delay(delay);
            }

            void CallUpdate()
            {
                for (int i = 0; i < windows.Count; i++)
                    windows[i].Update();
            }
        }


        /// <summary>
        /// Validate <paramref name="Fps"/>.
        /// </summary>
        /// <param name="fps">The fps to check</param>
        /// <returns>Is <paramref name="fps" valid?/></returns>
        private static bool ValidateFps(float fps)
        {
            if (fps < 0)
                throw new IndexOutOfRangeException("Fps value cannot be ≤ 0!");
            else if (fps > 60)
                throw new IndexOutOfRangeException("Fps value cannot be > 60!");

            return true;
        }
    }
}