namespace Encapsulation
{
    using System;
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;
        private readonly int multiplyer = 2;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return this.length; }
            private set {
                if (value <= 0)
                {
                    throw new Exception("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            private set {
                if (value<=0)
                {
                    throw new Exception("Width cannot be zero or negative.");
                }
                this.width = value; 
            
            }
        }
        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Height cannot be zero or negative.");
                }
                this.height = value;

            }
        }
        public double GetSurfaceArea()
        {
            var surfaceArea = this.multiplyer * this.length * this.width
                + this.multiplyer * this.length * this.height
                + this.multiplyer * this.width * this.height;
            return surfaceArea;
                
        }
        public double GetLateralSurfaceArea()
        {
            var lateralArea = this.multiplyer * this.length * this.height + this.multiplyer * this.width * this.height;
            return lateralArea;
        }
        public double GetVolume()
        {
            var volume = this.width * this.length * this.height;
            return volume;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.GetSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.GetVolume():f2}");
            return sb.ToString();

        }
    }
}
