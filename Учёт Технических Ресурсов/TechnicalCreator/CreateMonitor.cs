using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.TechnicalCreator
{
    class CreateMonitor : AddTechnical
    {
        public CreateMonitor(TechnicalResourcesBaseModel ResourcesBaseModel, int? computerId)
       : base(ResourcesBaseModel, computerId)
        {
            Monitor = new Monitor()
            {
                PicturePath = this.PicturePath,
                ComputerId = this.ComputerId,
                DocumentPath = this.DocumentPath,
                Price = this.Price,
                IsUsed = this.IsUsed,
                Description = this.Description,
                Title = this.Title
            };
        }

        public Monitor Monitor { get; set; }

        public override TechnicalResourcesBaseModel CreateTechnical()
        {
            using (TechnicalResourcesContext context = new TechnicalResourcesContext())
            {
                context.Monitors.Add(Monitor);
                context.SaveChanges();
                return Monitor;
            }
        }
    }
}
