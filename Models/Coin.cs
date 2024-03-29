namespace CoinWeb.Models
{

    public class Coin
    {
        private int year;
        public int Id { get; set; }
        public int Year 
        {
            get => year;
            set
            {
                if(value <0 || value > DateTime.Now.Year)
                    throw new ArgumentOutOfRangeException($"Year out of [0, {DateTime.Now.Year}]");
                year = value;
            }
        }
        public string? Country { get; set; }
        public string? Metal { get; set; }
        public string? Face { get; set; }
        public string? Denomination { get; set; }
    }
}