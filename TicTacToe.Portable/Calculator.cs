namespace TicTacToe.Portable {
  public class Calculator {
    //Method to add two numbers
    public static int Add(int numberOne, int numberTwo) {
      return numberOne + numberTwo;
    }

    //Method to Subtract two numbers
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
        if (0 != numberTwo){
            return numberOne / numberTwo;
        }else{
            // return 0 if user is trying to divide by 0 to stop crashes
            return 0;
        }
    }
  }
}