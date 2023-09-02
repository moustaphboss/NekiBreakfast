using NekiBreakfast.Contracts.Breakfast;
using NekiBreakfast.Models;

namespace NekiBreakfast.Services.Breakfasts;

public interface IBreakfastService
{
    void CreateBreakfast(Breakfast breakfast);
}