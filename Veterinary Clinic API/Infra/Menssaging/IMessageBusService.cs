namespace Veterinary_Clinic_API.Infra.Menssaging
{
    public interface IMessageBusService
    {
        void Publish(object data, string routingKey);
    }
}
