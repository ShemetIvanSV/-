using Учёт_Технических_Ресурсов.Model;

namespace Учёт_Технических_Ресурсов
{
    abstract class AddTechnical
    {
        public int? ComputerId { get; set; }
        public int Price { get; set; }
        public bool IsUsed { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public string DocumentPath { get; set; }

        public AddTechnical(TechnicalResourcesBaseModel model, int? computerId)
        {
            DocumentPath = model.DocumentPath; 
            Price = model.Price;
            IsUsed = model.IsUsed;
            Description = model.Description;
            Title = model.Title;
            ComputerId = computerId;
        }

        public AddTechnical(TechnicalResourcesBaseModel model)
        {
            DocumentPath = model.DocumentPath;
            Price = model.Price;
            IsUsed = model.IsUsed;
            Description = model.Description;
            Title = model.Title;
        }

        abstract public TechnicalResourcesBaseModel CreateTechnical();
    }
}
