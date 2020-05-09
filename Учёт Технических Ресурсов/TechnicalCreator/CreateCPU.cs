using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;

namespace Учёт_Технических_Ресурсов.TechnicalCreator
{
    class CreateCPU : AddTechnical
    {
        public CreateCPU(TechnicalResourcesBaseModel resourcesBaseModel, int? computerId)
       : base(resourcesBaseModel, computerId)
        {
            CPU = new CPU()
            {
                PicturePath = this.PicturePath,
                DocumentPath = this.DocumentPath,
                ComputerId = (int)computerId,
                Price = this.Price,
                IsUsed = this.IsUsed,
                Description = this.Description,
                Title = this.Title
            };
        }

        public CPU CPU { get; set; }

        public override TechnicalResourcesBaseModel CreateTechnical()
        {
            using (TechnicalResourcesContext context = new TechnicalResourcesContext())
            {
                context.CPUs.Add(CPU);
                context.SaveChanges();
                return CPU;
            }
        }
    }
}
