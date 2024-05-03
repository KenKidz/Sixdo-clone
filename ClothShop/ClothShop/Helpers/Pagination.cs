namespace ClothShop.Helpers
{
    public class Pagination<T>
    {
        public int total;
        public List<T> results;

        public Pagination(int total, List<T> result)
        {
            this.total = total;
            this.results = result;
        }
    }
}
