using PackIT.Domain.Entity;
using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.UnitTests;

public class PackingListTests
{
    #region ARRANGE
    private readonly IPackingListFactory _packingListFactory;
    public PackingListTests()
    {
        _packingListFactory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolicy>());
    }

    private PackingList GetPackingList()
    {

        var packingList = _packingListFactory.Create(Guid.NewGuid(), "MyList", Localization.Create("Gdansk,Poland"));
        packingList.ClearEvents();

        return packingList;
    }
    #endregion

    [Fact]
    public void AddItem_Throws_PackingItemAlreadyExistsException_When_There_Is_Already_Item_With_The_Name()
    {
        //ARRANGE
        var packingList = GetPackingList();
        packingList.AddItem(new("Item 1", 2));

        //ACT
        var exception = Record.Exception(() => packingList.AddItem(new("Item 1", 2)));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PackingItemAlreadyExistsException>();
    }

    [Fact]
    public void AddItem_Adds_PackingItemAdded_Domain_Event_On_Success()
    {
        // ARRANGE
        var packingList = GetPackingList();
        const int eventTriggeredCount = 1;
        const string itemName = "Item 1";

        //ACT
        var exception = Record.Exception(() => packingList.AddItem(new(itemName, 2)));
        var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;

        // ASSERT
        exception.ShouldBeNull();
        packingList.Events.Count().ShouldBe(eventTriggeredCount);

        @event.ShouldNotBeNull();
        @event.PackingItem.Name.ShouldBe(itemName);
    }
}
