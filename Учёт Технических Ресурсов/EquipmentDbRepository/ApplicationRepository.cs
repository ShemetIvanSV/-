using System.Collections.Generic;
using System.Data.Entity;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel;

namespace Учёт_Технических_Ресурсов.EquipmentDbRepository
{
    class ApplicationRepository : IEquipmentRepository<ApplicationProgram>
    {
        private TechnicalResourcesContext Technicaldb { get;}

        public ApplicationRepository()
        {
            Technicaldb = new TechnicalResourcesContext();
        }

        public void Remove(ApplicationProgram selectedCpu)
        {
            var dataContextApplication = Technicaldb.ApplicationPrograms;
            dataContextApplication.Attach(selectedCpu);
            dataContextApplication.Remove(selectedCpu);
            Technicaldb.SaveChanges();
        }

        public IEnumerable<ApplicationProgram> Return()
        {
            var applications = Technicaldb.ApplicationPrograms.Include(app => app.Computer);
            return applications;
        }

        public void SaveChange(IEnumerable<ApplicationProgram> inputCPUs)
        {
            foreach (var app in inputCPUs)
            {
                Technicaldb.Entry(app).State = EntityState.Modified;
            }
            Technicaldb.SaveChanges();
        }
    }
}
