namespace NekiBreakfast.Services.Breakfasts;
using NekiBreakfast.Models;

public class BreakfastService : IBreakfastService
{
    private readonly Dictionary<Guid, Breakfast> _breakfasts = new();
    public void CreateBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
    }

    public Breakfast GetBreakfast(Guid id)
    {
        return _breakfasts[id];
    }

    public Breakfast UpsertBreakfast(Breakfast breakfast)
    {
        return _breakfasts[breakfast.Id] = breakfast;
    }

    public void DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);
    }
}