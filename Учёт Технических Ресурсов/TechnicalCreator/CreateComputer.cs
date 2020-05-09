using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;

namespace Учёт_Технических_Ресурсов.TechnicalCreator
{
    class CreateComputer : AddTechnical
    {
        public CreateComputer(TechnicalResourcesBaseModel resourcesBaseModel)
       : base(resourcesBaseModel)
        {
            Computer = new Computer()
            {
                PicturePath = this.PicturePath,
                DocumentPath = this.DocumentPath,
                Price = resourcesBaseModel.Price,
                IsUsed = resourcesBaseModel.IsUsed,
                Description = resourcesBaseModel.Description,
                Title = resourcesBaseModel.Title
            };
        }

        public Computer Computer { get; set; }

        public override TechnicalResourcesBaseModel CreateTechnical()
        {
            using (TechnicalResourcesContext context = new TechnicalResourcesContext())
            {
                context.Computers.Add(Computer);
                context.SaveChanges();
                return Computer;
            }
        }
    }
}
