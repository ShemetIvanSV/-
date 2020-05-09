using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel;

namespace Учёт_Технических_Ресурсов.TechnicalCreator
{
    class CreateApp:AddTechnical
    {
        public CreateApp(TechnicalResourcesBaseModel ResourcesBaseModel, int? computerId)
: base(ResourcesBaseModel,computerId)
        {
            ApplicationProgram = new ApplicationProgram()
            {
                PicturePath = this.PicturePath,
                DocumentPath = this.DocumentPath,
                ComputerId = this.ComputerId,
                Price = this.Price,
                IsUsed = this.IsUsed,
                Description = this.Description,
                Title = this.Title
            };
        }

        public ApplicationProgram ApplicationProgram { get; set; }
        public override TechnicalResourcesBaseModel CreateTechnical()
        {
            using (TechnicalResourcesContext context = new TechnicalResourcesContext())
            {
                context.ApplicationPrograms.Add(ApplicationProgram);
                context.SaveChanges();
                return ApplicationProgram;
            }
        }
    }
}
