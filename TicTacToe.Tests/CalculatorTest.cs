using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Portable;

namespace TicTacToe.Tests {
  [TestClass]
  public class CalculatorTest {
    [TestMethod]
    public void AddTwoNumbers() {
      // Add two positve numbers
      Assert.AreEqual(Calculator.Add(10, 1), 11);

      // Add two negative numbers
      Assert.AreEqual(Calculator.Add(-10, -1), -11);

      // Add a negative number and positive number
      Assert.AreEqual(Calculator.Add(-10, 1), -9);

      // Add two large numbers
      Assert.AreEqual(Calculator.Add(1000000, 100000), 1100000);

      // Add two large negative numbers
      Assert.AreEqual(Calculator.Add(-1000000, -100000), -1100000);

      // Add a large negative number and large positive number
      Assert.AreEqual(Calculator.Add(-1000000, 100000), -900000);
    }

    [TestMethod]
    public void MultiplyTwoNumbers() {
      // Multiply two positive numbers
      Assert.AreEqual(Calculator.Multiply(5, 10), 50);

      // Multiply two negative numbers numbers
      Assert.AreEqual(Calculator.Multiply(-5, -10), 50);

      // Multiply one negative number and one positive number
      Assert.AreEqual(Calculator.Multiply(-5, 10), -50);

      // Multiply two large positive numbers
      Assert.AreEqual(Calculator.Multiply(50000, 20000), 1000000000);

      // Multiply two large negative numbers
      Assert.AreEqual(Calculator.Multiply(-50000, -20000), 1000000000);

      // Multiply one large negative number and one large postive number
      Assert.AreEqual(Calculator.Multiply(-50000, 20000), -1000000000);

      // Multiply two numbers one of them being zero
      Assert.AreEqual(Calculator.Multiply(5, 0), 0);

      // Multiply two numbers one of them being zero
      Assert.AreEqual(Calculator.Multiply(0, 5), 0);
    }

    [TestMethod]
    public void SubtractTwoNumbers() {
      // Subtract two positive numbers
      Assert.AreEqual(Calculator.Subtract(10, 5), 5);

      // Subtract two negative numbers
      Assert.AreEqual(Calculator.Subtract(-10, -5), -5);

      // Subtract one negative number and one positive number
      Assert.AreEqual(Calculator.Subtract(10, -5), 15);

      // Subtract two large positive numbers
      Assert.AreEqual(Calculator.Subtract(1000000, 500000), 500000);

      // Subtract two large negative numbers
      Assert.AreEqual(Calculator.Subtract(-1000000, -500000), -500000);

      // Subtract one large negative number and one large positive number
      Assert.AreEqual(Calculator.Subtract(1000000, -500000), 1500000);
    }

    [TestMethod]
    public void DivideTwoNumbers() {
      // Divide two positive numbers
      Assert.AreEqual(Calculator.Divide(10, 5), 2);

      // Divide two negative numbers
      Assert.AreEqual(Calculator.Divide(-10, -5), 2);

      // Divide one negative number and one positive number
      Assert.AreEqual(Calculator.Divide(10, -5), -2);

      // Divide two large positive numbers
      Assert.AreEqual(Calculator.Divide(10000000, 5000000), 2);

      // Divide two large negative numbers
      Assert.AreEqual(Calculator.Divide(-10000000, -5000000), 2);

      // Divide one large negative number and one large positive number
      Assert.AreEqual(Calculator.Divide(10000000, -5000000), -2);

      // Divide two numbers the second number being zero
      Assert.AreEqual(Calculator.Divide(10, 0), 0);

      // Divide two numbers the first number being zero
      Assert.AreEqual(Calculator.Divide(0, 10), 0);

      // Divide two positive numbers which would give a decimal answer
      Assert.AreEqual(Calculator.Divide(1, 2), 0);

    }
  }
}
