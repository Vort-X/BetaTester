namespace PresentationLayer.Models
{
    public abstract class BaseModel
    {
        public int Id { get; private set; }

        protected BaseModel(int id)
        {
            Id = id;
        }
    }
}
