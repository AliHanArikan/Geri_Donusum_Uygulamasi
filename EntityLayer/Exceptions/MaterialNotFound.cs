namespace EntityLayer.Exceptions
{
    public abstract partial class NotFoundException
    {
        public class MaterialNotFound : NotFoundException
        {
            public MaterialNotFound(int id) : base($"The book with id {id} not found")
            {
            }
        }
    }
}
