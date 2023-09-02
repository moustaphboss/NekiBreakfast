using NekiBreakfast.Contracts.Breakfast;
using NekiBreakfast.Models;

namespace NekiBreakfast.Services.Breakfasts;

public interface IBreakfastService
{
    void CreateBreakfast(Breakfast breakfast);
    Breakfast GetBreakfast(Guid id);
    Breakfast UpsertBreakfast(Breakfast breakfast);
    void DeleteBreakfast(Guid id);
}