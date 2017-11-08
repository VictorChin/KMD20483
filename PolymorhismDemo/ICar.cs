namespace PolymorhismDemo
{
    interface ICar
    {
        int CompareTo(Car other);
        void Dispose();
        void Drive();
        void Drive(int x);
        void PrintGas();
    }
}