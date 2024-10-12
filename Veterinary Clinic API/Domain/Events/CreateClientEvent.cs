namespace Veterinary_Clinic_API.Domain.Events
{
    public class CreateClientEvent
    {
        public CreateClientEvent(Guid clientCode,int cpf)
        {
            ClientCode = clientCode;
            CPF = cpf;
        }

        public Guid ClientCode { get; set; }
        public int CPF { get; set; }
    }
}
