using Moq;

namespace Tonnet.Tests
{
    [TestClass]
    public sealed class ScopedTest
    {
        [TestMethod]
        public void Constructor_ExecutesCreationFunc()
        {
            // Arrange
            var createFuncMock = new Mock<Func<object>>();
            var destroyActionMock = new Mock<Action<object>>();

            // Act
            var scoped = new Scoped<object>(createFuncMock.Object, destroyActionMock.Object);

            // Assert
            createFuncMock.Verify(func => func(), Times.Once);
        }

        [TestMethod]
        public void Dispose_ExecutesDestroyFuncWithResource()
        {
            // Arrange
            var expectedResource = new object();
            var destroyActionMock = new Mock<Action<object>>();
            var scoped = new Scoped<object>(() => expectedResource, destroyActionMock.Object);

            // Act
            scoped.Dispose();

            // Assert
            destroyActionMock.Verify(action => action(expectedResource), Times.Once);
        }

        [TestMethod]
        public void DisposeTwice_DestroysOnlyOnce()
        {
            // Arrange
            var createFuncMock = new Mock<Func<object>>();
            var destroyActionMock = new Mock<Action<object>>();
            var scoped = new Scoped<object>(createFuncMock.Object, destroyActionMock.Object);

            // Act
            scoped.Dispose();
            scoped.Dispose();

            // Assert
            destroyActionMock.Verify(action => action(It.IsAny<object>()), Times.Once);
        }

        [TestMethod]
        public void Using_Disposes()
        {
            // Arrange
            var createFuncMock = new Mock<Func<object>>();
            var destroyActionMock = new Mock<Action<object>>();

            // Act
            {
                using var scoped = new Scoped<object>(createFuncMock.Object, destroyActionMock.Object);
            }

            // Assert
            destroyActionMock.Verify(action => action(It.IsAny<object>()), Times.Once);
        }
    }
}
