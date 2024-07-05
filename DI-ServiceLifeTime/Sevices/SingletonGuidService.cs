namespace DI_ServiceLifeTime.Sevices
{
    public class SingletonGuidService: ISingletonGuidServices
    {
        private readonly Guid Id;

        public SingletonGuidService()
        {
            Id = Guid.NewGuid();
        }

        public string GetGuid()
        {
            return Id.ToString();   
        }
    }
}
