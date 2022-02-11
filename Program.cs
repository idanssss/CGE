using Engine;

class Program
{
    static void Main(string[] args)
    {
        var window = new Window(5, 5);

        var app = new App(5, window);
        app.OnKeyPress += (ConsoleKeyInfo key) => {
            Console.WriteLine("You pressed: " + key.KeyChar);
        };

        // Game is running on a different thread, don't close the app.
        while (true) Task.Delay(1000).Wait();
    }
}