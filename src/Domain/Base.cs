namespace BusinessLogicLayer.Domain
{
    public abstract class Base
    {
        public int Id { get; private set; }

        protected Base(int id)
        {
            Id = id;
        }
    }
}
