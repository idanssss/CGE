namespace Engine
{
    public class Frame
    {
        private Pixel[] Pixels;

        public Frame(IEnumerable<Pixel> pixels) => Pixels = RemoveBlanks(pixels).ToArray();

        public void Draw()
        {
            if (Pixels == null || Pixels.Length == 0)
                throw new NullReferenceException("Cannot draw frame without pixels.");

            for (int i = 0; i < Pixels.Length; i++)
                DrawPixel(Pixels[i]);
        }

        private void DrawPixel(Pixel pixel)
        {
            Vector2 position = pixel.Position;
            ConsoleColor color = pixel.Color;

            // Set the console's cursor position to the pixel's position
            Console.CursorLeft = position.X;
            Console.CursorTop = position.Y;

            // Set the console's color to the pixel's color
            Console.BackgroundColor = color;

            // Draw
            Console.Write(' ');
        }

        /// <summary>
        /// Get <paramref name="source"/> without blank pixels in it.
        /// </summary>
        /// <param name="source">The source to sort out</param>
        /// <returns><paramref name="source"/> without blank pixels.</returns>
        private static IEnumerable<Pixel> RemoveBlanks(IEnumerable<Pixel> source) =>
            source.ToList().FindAll(p => !p.IsBlank);
    }
}