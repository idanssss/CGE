namespace Engine
{
    public class Window
    {
        private int _width;
        public int Width
        {
            get => _width;
            private set
            {
                if (!ValidateWidth(value) || value == _width)
                    return;

                _width = value;
            }
        }

        private int _height;
        public int Height
        {
            get => _height;
            private set
            {
                if (!ValidateHeight(value) || value == _height)
                    return;

                _height = value;
            }
        }

        public Window(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Update()
        {
            
        }

        public void Draw()
        {

        }

        #region Scale Validations
        private static bool ValidateWidth(int width)
        {
            if (width <= 0)
                throw new IndexOutOfRangeException("Width cannot be ≤ 0!");

            return true;
        }
        private static bool ValidateHeight(int height)
        {
            if (height <= 0)
                throw new IndexOutOfRangeException("Height cannot be ≤ 0!");

            return true;
        }
        #endregion
    }
}