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

    // Method to Subtract two numbers
    public static int Subtract(int numberOne, int numberTwo) {
      return numberOne - numberTwo;
    }

    // Method to Multiply two numbers
    public static int Multiply(int numberOne, int numberTwo) {
      return numberOne * numberTwo;
    }

    // Method to Divide two numbers
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
