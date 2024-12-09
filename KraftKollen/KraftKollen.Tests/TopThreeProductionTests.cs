using Xunit;
using KraftKollen.Models;
using System.Collections.Generic;
using Xunit.Abstractions;
using KraftKollen.Helpers;

namespace KraftKollen.Tests
{
    public class TopProductionTests : IClassFixture<TopProductionFixture>
    {
        private readonly TopProductionFixture _fixture;

        public TopProductionTests(TopProductionFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void GetTopProductionYears_WithSufficientData_ReturnsTopThreeYears() // Returnerar top 3 �ren med h�gst produktion
        {
            // Act
            var result = _fixture.ProductionAnalyzer.GetTopProductionYears(_fixture.SampleProductionData);

            // Assert
            Assert.Equal(3, result.Count);  //Kontrollera att det finns 3 resultat i listan
            Assert.Equal(2021, result[0].Year); //Kontrollera att det f�rsta �ret i listan �r 2021
            Assert.Equal(600.0, result[0].Production); //Kontrollera att produktionen f�r det f�rsta �ret �r 600
            Assert.Equal(2022, result[1].Year);
            Assert.Equal(550.0, result[1].Production);
            Assert.Equal(2020, result[2].Year);
            Assert.Equal(500.0, result[2].Production);
        }

        [Fact]
        public void GetTopProductionYears_WithInsufficientData_ReturnsEmptyList() // Returnerar tom lista om det inte finns tillr�ckligt med data(mindre �n 3 �r med produktionsdata)
        {
            // Act
            var result = _fixture.ProductionAnalyzer.GetTopProductionYears(_fixture.InsufficientProductionData); 

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetTopProductionYears_WithEmptyData_ReturnsEmptyList() // Returnerar tom lista om det inte finns tillr�ckligt med data
        {
            // Arrange
            var emptyData = new List<WindPowerProduction>();

            // Act
            var result = _fixture.ProductionAnalyzer.GetTopProductionYears(emptyData);

            // Assert
            Assert.Empty(result);
        }
    }
}
