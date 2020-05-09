using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;

namespace Учёт_Технических_Ресурсов.TechnicalCreator
{
    class CreateMotherboard : AddTechnical
    {
        public CreateMotherboard(TechnicalResourcesBaseModel ResourcesBaseModel, int? computerId)
       : base(ResourcesBaseModel, computerId)
        {
            Motherboard = new Motherboard()
            {
                PicturePath = this.PicturePath,
                DocumentPath = this.DocumentPath,
                ComputerId = (int)this.ComputerId,
                Price = this.Price,
                IsUsed = this.IsUsed,
                Description = this.Description,
                Title = this.Title
            };
        }

        public Motherboard Motherboard { get; set; }

        public override TechnicalResourcesBaseModel CreateTechnical()
        {
            using (TechnicalResourcesContext context = new TechnicalResourcesContext())
            {
                context.Motherboards.Add(Motherboard);
                context.SaveChanges();
                return Motherboard;
            }
        }
    }
}
