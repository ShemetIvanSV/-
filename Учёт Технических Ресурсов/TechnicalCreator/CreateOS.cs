using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel;

namespace Учёт_Технических_Ресурсов.TechnicalCreator
{
    class CreateOS : AddTechnical
    {
        public CreateOS(TechnicalResourcesBaseModel ResourcesBaseModel, int? computerId)
       : base(ResourcesBaseModel, computerId)
        {
            OperatingSystem = new OperatingSystem()
            {
                DocumentPath = this.DocumentPath,
                ComputerId = (int)this.ComputerId,
                Price = this.Price,
                IsUsed = this.IsUsed,
                Description = this.Description,
                Title = this.Title
            };
        }

        public OperatingSystem OperatingSystem { get; set; }

        public override TechnicalResourcesBaseModel CreateTechnical()
        {
            using (TechnicalResourcesContext context = new TechnicalResourcesContext())
            {
                context.OperatingSystems.Add(OperatingSystem);
                context.SaveChanges();
                return OperatingSystem;
            }
        }
    }
}
