using Microsoft.EntityFrameworkCore;

namespace Core.Services.EnumTableCreators.Interfaces
{
    public interface IEnumTableCreator
    {
        void CreateAndFillTable<TEnum>(DbContext context);
        void FillTable<TEnum>(DbContext context);
    }
}
