using Учёт_Технических_Ресурсов.Model;

namespace Учёт_Технических_Ресурсов
{
    abstract class AddTechnical
    {
        public abstract void CreateTechnical(TechnicalResourcesBaseModel model, int? computerId);
    }
}
