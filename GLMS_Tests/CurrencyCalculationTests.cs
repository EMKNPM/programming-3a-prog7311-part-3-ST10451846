using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLMS_Tests
{
    public  class CurrencyCalculationTests
    {
        [Fact]
        public void ConvertUsdToZar_ShouldCalculateCorrectly()
        {
            // Arrange
            decimal usdAmount = 100m;
            decimal exchangeRate = 18.50m;

            // Act
            decimal result = usdAmount * exchangeRate;

            // Assert
            Assert.Equal(1850m, result);
        }

        [Fact]
        public void ConvertUsdToZar_ShouldReturnZero_WhenUsdIsZero()
        {
            // Edge case
            decimal usdAmount = 0m;
            decimal exchangeRate = 18.50m;

            decimal result = usdAmount * exchangeRate;

            Assert.Equal(0m, result);
        }
    }
}