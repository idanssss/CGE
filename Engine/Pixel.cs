namespace Engine
{
    public struct Pixel
    {
        /// <summary>
        /// The position of the <see cref="Pixel"/> on its <see cref="Frame"/>.
        /// </summary>
        /// <value></value>
        public Vector2 Position { get; private set; }

        /// <summary>
        /// The <see cref="ConsoleColor"/> of the <see cref="Pixel"/> on the <see cref="Frame"/>
        /// </summary>
        public ConsoleColor Color { get; private set; }

        /// <summary>
        /// Is the pixel empty?
        /// </summary>
        public bool IsBlank => Color == ConsoleColor.Black;

        public Pixel(Vector2 position, ConsoleColor color = ConsoleColor.Black)
        {
            Position = position;
            Color = color;
        }
    }
}