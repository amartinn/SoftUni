namespace _02_
{
    public class Box<T>
    {
        private T test;

        public Box(T value)
        {
            this.Value = value;
        }
        public T Value
        {
            get { return test; }
            set { test = value; }
        }
        public override string ToString()
        {
            return $"{this.Value.GetType()}: {this.Value}";
        }

    }
}
