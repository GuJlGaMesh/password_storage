using System;
using System.Collections.Generic;
using System.Text;
using PasswordStorage;
using Xunit;
using Moq;
using System.Linq;

namespace Password_Storage
{
    public class PasswordGeneratorShould
    {

        private Mock<IGenerator> SetUpMock(int length, string symbol)
        {
            var mock = new Mock<IGenerator>();
            mock.Setup(_ => _.MinLength).Returns(length).Verifiable();
            mock.Setup(_ => _.GetChar()).Returns(symbol).Verifiable();
            return mock;
        }

        [Fact]
        public void GeneratePassword()
        {
            var firstMock = SetUpMock(1, "A");
            var secondMock = SetUpMock(1, "B");
            var thirdMock = SetUpMock(1, "C");

            // помещаем все моки в коллекцию - массив
            var generatorMocks = new[] { firstMock, secondMock, thirdMock };

            // используем методы расширения Linq, чтобы взять настроенные объекты 
            var sut = new PasswordGenerator(generatorMocks.Select(_ => _.Object));
            // act
            var password = sut.GetPassword();

            // assert
            Mock.Verify(generatorMocks); // проверка, что все методы, настроенные в Setup были вызваны
            Assert.Contains("A", password); // проверка, что пароль содержит символы, которые вернули наши моки
            Assert.Contains("B", password);
            Assert.Contains("C", password);
            Assert.InRange(password.Length, 3, 6); // проверка, что длина пароля выбрана на интервале [l, l*2];
        }

        [Theory]
        [InlineData(8, 16)]
        [InlineData(16, 32)]
        public void MinLengthRule(int minRange, int maxRange)
        {
            var lenMock = new Mock<IGenerator>();
            lenMock.Setup(_ => _.MinLength).Returns(minRange);
            lenMock.Setup(_ => _.GetChar()).Returns("a");
            var pg = new PasswordGenerator(new List<IGenerator>() { lenMock.Object });
            Assert.InRange(pg.GetPassword().Length, minRange, maxRange);
        }
    }
}
