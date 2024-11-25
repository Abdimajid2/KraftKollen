using Bunit;
using KraftKollen.Components;
using KraftKollen.Components.Components;
using KraftKollen.Models;
using Microsoft.AspNetCore.Components;

namespace KraftKollen.Tests;

public class test : TestContext
{
    [Fact]
    public void SelectAllRegions_Should_Invoke_OnAllRegionsSelected_With_All_RegionIds()
    {
        // Arrange
        var regions = AllRegions.GetAllRegions(); // Se till att Region.Regions ger en lista med regioner
        List<string> selectedRegionIds = null;

        // Rendera komponenten och bind `OnAllRegionsSelected` till en metod för att fånga det som skickas via callback
        var cut = Render<SelectAllRegionsComponent>(parameters => parameters
            .Add(p => p.OnAllRegionsSelected, EventCallback.Factory.Create<List<string>>(this, ids =>
            {
                selectedRegionIds = ids; // Spara listan som skickas via callbacken
            }))
        );

        // Act
        var checkbox = cut.Find("input[type='checkbox']");
        checkbox.Change(true); // Simulera att användaren kryssar i checkboxen

        // Assert
      
        Assert.Equal(regions.Count, selectedRegionIds.Count);
       
    }
}
