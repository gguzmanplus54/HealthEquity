namespace CrudSite.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public bool GuessPrice(double guessPrice)
        {
            double diffRes = this.Price - guessPrice;
            if (diffRes < 0)
            {
                diffRes = -diffRes;
            }

            if (diffRes <= 5000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
