using StreetlightDistribution.Logic;
using StreetlightDistribution.Model.DTO;

namespace StreetLightDistribution.Tests.UnitTest
{
    public class StreetlightDistributorTest
    {
        private readonly StreetlightDistributor _distributor;

        public StreetlightDistributorTest()
        {
            _distributor = new StreetlightDistributor();
        }
        [Fact]
        public void Test_EvenNumberOfRows_WithOnePark()
        {
            // Arrange
            var input = new StreetlightRequest {
                Neighbourhood = new List<List<string>>
                {
                    new List<string> { "H", "H", "P", "H", "H" },
                    new List<string> { "H", "H", "H", "H", "H", "H", "H" }, 
                    new List<string> { "H", "H", "H", "H", "H", "H", "H" }, 
                    new List<string> { "H", "H", "H", "H", "H", "H", "H" }  
                } 
            };

            var expected = new StreetlightResponse
            {
                Plots = new List<List<string>>
                {
                    new List<string> { "N", "N", "N", "B", "R" },
                    new List<string> { "B", "R", "R", "R", "R", "R", "R" },
                    new List<string> { "B", "R", "R", "R", "R", "R", "R" },
                    new List<string> { "N", "N", "N", "N", "N", "N", "N" } 
                }
            };

            // Act
            var result = _distributor.DistributeStreetlights(input);

            // Assert
            Assert.Equal(expected.Plots, result.Plots);
        }
        [Fact]
        public void Test_OddNumberOfRows_WithOnePark()
        {
            // Arrange
            var neighborhood = new StreetlightRequest
            {
                Neighbourhood = new List<List<string>>
                {
                    new List<string> { "H", "H", "P", "H", "H" },
                    new List<string> { "H", "H", "H", "H", "H", "H", "H" }, 
                    new List<string> { "H", "H", "H", "H", "H", "H", "H" } 
                }
            };

            // Expected output
            var expected = new StreetlightResponse
            {
                Plots = new List<List<string>>
                {
                    new List<string> { "N", "N", "N", "B", "R" }, 
                    new List<string> { "B", "R", "R", "R", "R", "R", "R" },
                    new List<string> { "B", "R", "R", "R", "R", "R", "R" }

                }
            };

            // Act
            var result = _distributor.DistributeStreetlights(neighborhood);

            // Assert
            Assert.Equal(expected.Plots, result.Plots);
        }
        [Fact]
        public void Test_EvenNumberOfRows_NoPark()
        {
            var input = new StreetlightRequest
            {
                Neighbourhood = new List<List<string>>
                {
                    new List<string> { "H", "H", "H", "H", "H", "H", "H" },
                    new List<string> { "H", "H", "H", "H", "H", "H", "H" },
                    new List<string> { "H", "H", "H", "H", "H", "H", "H" },
                    new List<string> { "H", "H", "H", "H", "H", "H", "H" }
                }
            };

            var expected = new StreetlightResponse
            {
                Plots = new List<List<string>>
                {
                    new List<string> { "B", "R", "R", "R", "R", "R", "R" },
                    new List<string> { "N", "N", "N", "N", "N", "N", "N" },
                    new List<string> { "B", "R", "R", "R", "R", "R", "R" },
                    new List<string> { "N", "N", "N", "N", "N", "N", "N" }
                }
            };

            var result = _distributor.DistributeStreetlights(input);

            Assert.Equal(expected.Plots, result.Plots);
        }

        [Fact]
        public void Test_OddNumberOfRows_NoPark()
        {
            // Arrange
            var input = new StreetlightRequest
            {
                Neighbourhood = new List<List<string>>
                {
                    new List<string> { "H", "H", "H", "H", "H", "H", "H" }, // Row 1
                    new List<string> { "H", "H", "H", "H", "H", "H", "H" }, // Row 2
                    new List<string> { "H", "H", "H", "H", "H", "H", "H" }
                }
            };

            var expected = new StreetlightResponse
            {
                Plots = new List<List<string>>
                {
                    new List<string> { "B", "R", "R", "R", "R", "R", "R" }, // Lights between Row 1 and Row 2
                    new List<string> { "N", "N", "N", "N", "N", "N", "N" },
                    new List<string> { "B", "R", "R", "R", "R", "R", "R" }
                }
            };

            // Act
            var result = _distributor.DistributeStreetlights(input);

            // Assert
            Assert.Equal(expected.Plots, result.Plots);
        }

    }
}