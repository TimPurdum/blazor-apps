using BlazorApps.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlazorApps.Test;
[TestClass]
public class ObservableDictionaryTests
{
    [TestMethod]
    public void CanSelect()
    {
        // Arrange
        var dict = new ObservableDictionary<string, double>();
        dict["test1"] = 1;
        dict["test2"] = 2;
        dict["test3"] = 3;
        dict["test4"] = 4;

        // Act
        var result = dict.Select(x => x.Value).ToArray();

        // Assert
        Assert.AreEqual(2, result[1]);
    }
}