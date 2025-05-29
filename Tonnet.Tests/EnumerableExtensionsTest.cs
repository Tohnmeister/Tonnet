namespace Tonnet.Tests
{
    [TestClass]
    public class EnumerableExtensionsTest
    {
        [TestMethod]
        public void EmptyIfNull_ReturnsEmptyEnumerable_WhenSourceIsNull()
        {
            // Arrange
            IEnumerable<int>? source = null;

            // Act
            var result = source.EmptyIfNull();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void EmptyIfNull_ReturnsSource_WhenSourceIsNotNull()
        {
            // Arrange
            List<int> source = [1, 2, 3];

            // Act
            var result = source.EmptyIfNull();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreSame(source, result);
        }
    }
}
