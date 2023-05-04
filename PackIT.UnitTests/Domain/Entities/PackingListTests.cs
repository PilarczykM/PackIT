using PackIT.Domain.Entities;
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

    [Fact]
    public void AddItems_Throws_PackingItemAlreadyExistsException_When_There_Is_Already_Item_With_The_Name()
    {
        //ARRANGE
        var packingList = GetPackingList();

        //ACT
        var exception = Record.Exception(
            () => packingList.AddItems(new List<PackingItem>()
            {
                new("Item 1", 2),
                new("Item 2", 1),
                new("Item 1", 1),
            }));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PackingItemAlreadyExistsException>();
    }

    [Fact]
    public void AddItems_Adds_PackingItemAdded_Domain_Event_On_Success()
    {
        //ARRANGE
        var packingList = GetPackingList();
        var listOfItems = new List<PackingItem>()
            {
                new("Item 1", 2),
                new("Item 2", 1),
                new("Item 3", 1),
            };

        //ACT
        var exception = Record.Exception(() => packingList.AddItems(listOfItems));

        //ASSERT
        exception.ShouldBeNull();
        packingList.Events.Count().ShouldBe(listOfItems.Count());

        var @events = packingList.Events;
        var packingItemNames = listOfItems.Select(i => i.Name);

        foreach (PackingItemAdded @event in events)
        {
            @event.ShouldNotBeNull();
            @event.ShouldBeOfType<PackingItemAdded>();
            packingItemNames.ShouldContain(@event.PackingItem.Name);
        }
    }

    [Fact]
    public void PackItem_Throws_PackingItemNotFound_When_There_Is_No_Item_With_Specific_Name()
    {
        //ARRANGE
        var packingList = GetPackingList();
        packingList.AddItem(new("Item 1", 2));
        packingList.ClearEvents();

        //ACT
        var exception = Record.Exception(() => packingList.PackItem("Item 2"));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PackingItemNotFound>();
        packingList.Events.Count().ShouldBe(0);
    }

    [Fact]
    public void PackItem_Adds_PackingItemPacked_Domain_Event_On_Success()
    {
        //ARRANGE
        var packingList = GetPackingList();
        packingList.AddItem(new("Item 1", 1));
        packingList.ClearEvents();

        //ACT
        var exception = Record.Exception(() => packingList.PackItem("Item 1"));

        //ASSERT
        exception.ShouldBeNull();

        var @event = packingList.Events.FirstOrDefault() as PackingItemPacked;
        @event.PackingItem.IsPacked.ShouldBe(true);
        @event.PackingItem.Name.ShouldBe("Item 1");
    }

    [Fact]
    public void RemoveItem_Throws_PackingItemNotFound_When_There_Is_Item_With_Specific_Name()
    {
        //ARRANGE
        var packingList = GetPackingList();
        packingList.AddItem(new("Item 1", 2));
        packingList.ClearEvents();

        //ACT
        var exception = Record.Exception(() => packingList.RemoveItem("Item 2"));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PackingItemNotFound>();
        packingList.Events.Count().ShouldBe(0);
    }

    [Fact]
    public void RemoveItem_Adds_PackingItemRemoved_Domain_Event_On_Success()
    {
        //ARRANGE
        var packingList = GetPackingList();
        packingList.AddItem(new("Item 1", 1));
        packingList.ClearEvents();

        //ACT
        var exception = Record.Exception(() => packingList.RemoveItem("Item 1"));

        //ASSERT
        exception.ShouldBeNull();

        var @event = packingList.Events.FirstOrDefault() as PackingItemRemoved;
        @event.PackingItem.Name.ShouldBe("Item 1");
    }
}
