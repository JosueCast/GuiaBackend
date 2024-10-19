namespace Backend.services
{
    public class RamdonServices:IRamdonServices
    {
        private readonly int _value;
        public int Value
        {
            get => _value;
        }

        public RamdonServices()
        {
            _value = new Random().Next(1000);
        }

        
    }
}
