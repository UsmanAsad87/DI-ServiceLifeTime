namespace DI_ServiceLifeTime.Sevices
{
    public class TransientGuidService : ITransientGuidService
    {
        private readonly Guid Id;
        public TransientGuidService()
        {
            Id = Guid.NewGuid();
        }

public string GetGuid()
        {
            return Id.ToString();
        }
    }
    }
