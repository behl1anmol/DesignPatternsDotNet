using AdapterPattern.Features.Adapter;
using AdapterPattern.Features.Interfaces;

namespace AdapterPattern
{
    //add test collection
    [Collection(nameof(AdapterTests))]
    public class AdapterTests
    {
        public readonly IRoundPeg _roundPeg;
        public readonly IRoundHole _roundHole;
        public readonly ISquarePeg _squarePeg;
        public readonly ISquarePegAdapter _squarePegAdapter;
        public AdapterTests(ISquarePeg squarePeg, ISquarePegAdapter squarePegAdapter, IRoundHole roundHole, IRoundPeg roundPeg)
        {
            _squarePeg = squarePeg;
            _squarePegAdapter = squarePegAdapter;
            _roundHole = roundHole;
            _roundPeg = roundPeg;
        }

        [Fact]
        public void Given_RoundHole_When_RoundPegWithSmallerRadius_Then_Fits()
        {
            // Arrange
            _roundHole.SetRadius(5);
            _roundPeg.SetRadius(4);
            // Act
            var result = _roundHole.Fits(_roundPeg);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Given_RoundHole_When_RoundPegWithLargerRadius_Then_DoesNotFit()
        {
            // Arrange
            _roundHole.SetRadius(5);
            _roundPeg.SetRadius(6);
            // Act
            var result = _roundHole.Fits(_roundPeg);
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Given_RoundHole_When_SquarePegWithSmallerWidth_Then_Fits()
        {
            // Arrange
            _roundHole.SetRadius(5);
            _squarePeg.SetWidth(5);
            _squarePegAdapter.SetAdaptee(_squarePeg);
            // Act
            var result = _roundHole.Fits(_squarePegAdapter);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Given_RoundHole_When_SquarePegWithLargerWidth_Then_DoesNotFit()
        {
            // Arrange
            _roundHole.SetRadius(5);
            _squarePeg.SetWidth(10);
            _squarePegAdapter.SetAdaptee(_squarePeg);
            // Act
            var result = _roundHole.Fits(_squarePegAdapter);
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Given_SquarePegAdapter_When_AdapteeNotSet_Then_ThrowsInvalidOperationException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => _squarePegAdapter.GetAdaptee());
        }

        [Fact]
        public void Given_SquarePegAdapter_When_AdapteeSet_Then_GetAdapteeReturnsAdaptee()
        {
            // Arrange
            _squarePeg.SetWidth(5);
            _squarePegAdapter.SetAdaptee(_squarePeg);
            // Act
            var result = _squarePegAdapter.GetAdaptee();
            // Assert
            Assert.Equal(_squarePeg, result);
        }

        [Fact]
        public void Given_SquarePegAdapter_When_AdapteeSet_Then_RadiusIsCalculatedCorrectly()
        {
            // Arrange
            _squarePeg.SetWidth(5);
            _squarePegAdapter.SetAdaptee(_squarePeg);
            // Act
            var radius = _squarePegAdapter.Radius;
            // Assert
            Assert.Equal(5 * Math.Sqrt(2) / 2, radius);
        }

        [Fact]
        public void Given_SquarePegAdapter_When_SetRadius_Then_AdapteeWidthIsSetCorrectly()
        {
            // Arrange
            var expectedWidth = 5;
            var radius = expectedWidth * Math.Sqrt(2) / 2;
            _squarePegAdapter.SetAdaptee(_squarePeg);
            // Act
            _squarePegAdapter.SetRadius(radius);
            // Assert
            Assert.Equal(expectedWidth, _squarePeg.Width);
        }
    }
}
