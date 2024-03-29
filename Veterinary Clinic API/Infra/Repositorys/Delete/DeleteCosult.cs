﻿using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.Infra.Context;

namespace Veterinary_Clinic_API.Infra.Repositorys.Delete
{
    public class DeleteCosult : IDeleteConsultR
    {
        private readonly ContextVeterinaryClinic _context;
        public DeleteCosult(ContextVeterinaryClinic context)
        {
            _context = context;
        }
        public void DeleteAndTerminated(Guid idConsultation)
        {
            var userDatabase = _context.Consult.SingleOrDefault(de => de.IdConsultation == idConsultation);
            

            userDatabase.DeleteConsultation();
            _context.SaveChanges();
    
        }
    }
}
