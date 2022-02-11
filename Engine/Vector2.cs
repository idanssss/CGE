namespace Engine
{
    public struct Vector2
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector2() : this(0, 0) {}
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator Vector2((int x, int y) vec) => new Vector2(vec.x, vec.y);
    }
}