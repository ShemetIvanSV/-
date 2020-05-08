using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов
{
    class CreateRUM : AddTechnical
    {
        public CreateRUM(TechnicalResourcesBaseModel ResourcesBaseModel, int? computerId)
       : base(ResourcesBaseModel, computerId)
        {
            RUM = new RUM()
            {
                DocumentPath = this.DocumentPath,
                ComputerId = this.ComputerId,
                Price = this.Price,
                IsUsed = this.IsUsed,
                Description = this.Description,
                Title = this.Title
            };
        }

        public RUM RUM { get; set; }

        public override TechnicalResourcesBaseModel CreateTechnical()
        {
            using (TechnicalResourcesContext context = new TechnicalResourcesContext())
            {
                context.RUMs.Add(RUM);
                context.SaveChanges();
                return RUM;
            }
        }
    }
}
