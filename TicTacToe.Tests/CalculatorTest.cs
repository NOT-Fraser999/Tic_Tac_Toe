using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Portable;

namespace TicTacToe.Tests {
  [TestClass]
  public class CalculatorTest {
    [TestMethod]
    public void AddTwoNumbers() {
      // add two positve numbers
      Assert.AreEqual(Calculator.Add(10, 1), 11);

      // add two negative numbers
      Assert.AreEqual(Calculator.Add(-10, -1), -11);

      // add a negative and positive number
      Assert.AreEqual(Calculator.Add(-10, 1), -9);

      // add two large numbers
      Assert.AreEqual(Calculator.Add(1000000, 100000), 1100000);

      // add two large negative numbers
      Assert.AreEqual(Calculator.Add(-1000000, -100000), -1100000);

      // add a large negative and large positive number
      Assert.AreEqual(Calculator.Add(-1000000, 100000), -900000);
    }

    [TestMethod]
    public void MultiplyTwoNumbers() {}
  }
}
