using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KraftKollen.Helpers;
using KraftKollen;


namespace KraftKollen.Tests
{
    public class CalculateProductionDifferencePerYear
    {
        [Fact]
        public void CalculateProductionFor2019And2020ReturnsCorrectDifference()  // Åren 2010 och 2020
        {
            // Arrange
            double production2019 = 19234852; // Produktionsvärde år 2019
            double production2020 = 26306655; // Produktionsvärde år 2020
            double expectedDifference = production2020 - production2019; // Förväntad skillnad mellan åren

            var calculator = new CalculateProductionDifference(); // Ny beräkning från isolerad klass som ska testas

            // Act
            double actualDifference = calculator.CalculateDifference(production2019, production2020); // Anropar metoden i den isolerade klassen  

            // Assert
            Assert.Equal(expectedDifference, actualDifference); // Kontrollera faktiska resultatet
        }

        [Fact]
        public void CalculateProductionFor2020And2021ReturnsCorrectDifference() // Åren 2020 och 2021
        {
            // Arrange
            double production2020 = 26306655; 
            double production2021 = 26520886; 
            double expectedDifference = production2021 - production2020;

            var calculator = new CalculateProductionDifference();

            // Act
            double actualDifference = calculator.CalculateDifference(production2020, production2021);

            // Assert
            Assert.Equal(expectedDifference, actualDifference);
        }

        [Fact]
        public void CalculateProductionFor2021And2022ReturnsCorrectDifference() // Åren 2021 och 2022
        {
            // Arrange
            double production2021 = 26520886; 
            double production2022 = 32483482; 
            double expectedDifference = production2022 - production2021;

            var calculator = new CalculateProductionDifference();

            // Act
            double actualDifference = calculator.CalculateDifference(production2021, production2022);

            // Assert
            Assert.Equal(expectedDifference, actualDifference);
        }
    }
}
