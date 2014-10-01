namespace TicTacToe.Portable {
  public class Calculator {
    /// <summary>
    /// Method to add two numbers
    /// </summary>
    /// <param name="numberOne">First Number</param>
    /// <param name="numberTwo">Second Number</param>
    /// <returns>Returns the result of addition</returns>
    public static int Add(int numberOne, int numberTwo) {
      return numberOne + numberTwo;
    }

    /// <summary>
    /// Method to Subtract two numbers
    /// </summary>
    /// <param name="numberOne">First Number</param>
    /// <param name="numberTwo">Second Number</param>
    /// <returns>Returns the result of subtraction</returns>
    public static int Subtract(int numberOne, int numberTwo) {
      return numberOne - numberTwo;
    }

    /// <summary>
    /// Method to Multiply two numbers
    /// </summary>
    /// <param name="numberOne">First Number</param>
    /// <param name="numberTwo">Second Number</param>
    /// <returns>Returns the result of multiplication</returns>
    public static int Multiply(int numberOne, int numberTwo) {
      return numberOne * numberTwo;
    }

    /// <summary>
    /// Method to Divide two numbers
    /// </summary>
    /// <param name="numberOne">First Number</param>
    /// <param name="numberTwo">Second Number</param>
    /// <returns>Returns the result of Division</returns>
    public static int Divide(int numberOne, int numberTwo) {
      // Check to make sure that user is not trying to divide by 0
      if (numberTwo != 0) {
        return numberOne / numberTwo;
      }

      // return 0 if user is trying to divide by 0 to stop crashes
      return 0;
    }
  }
}
