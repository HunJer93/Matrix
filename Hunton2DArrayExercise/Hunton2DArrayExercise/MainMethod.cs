//Jeremy Hunton
//CPT244 - Data Structures
//6/8/2021
//The purpose of this program is to load a text file containing a 2D matrix and gain information from/manipulate the matrix
//once it is loaded. The purpose of MainMethod is to handle the display outputs of the program.
using System;

namespace Hunton2DArrayExercise
{
    class MainMethod
    {
        //declare class constants 
        const string FileName = "C:/Users/SMAUG/source/repos/Hunton2DArrayExercise/Hunton2DArrayExercise/4x4matrix.txt";

        static void Main(string[] args)
        {
            //create a new MatrixManager obj
            MatrixManager matrix = new MatrixManager();

            //displayWelcome
            displayWelcome();

            //pass the file name to the load matrix method
            matrix.loadArray(FileName);

            //get the matrix and print it
            displayOriginalMatrixText();
            printMatrix(matrix.getMatrix());

            //transpose the matrix
            matrix.transposeMatrix();

            //print the transposed matrix
            displayTransposedMatrixText();
            printMatrix(matrix.getMatrix());

            //print the other info for the matrix
            displayMatrixInfo(matrix.checkSymmetry(), matrix.getMatrixTrace());
            
        }//end main method

        //start of void methods 
       
        //displayWelcome displays the welcome banner 
        private static void displayWelcome()
        {
            Console.WriteLine("This program accepts a text file containing a square matrix and");
            Console.WriteLine("prints it, transposes it, determines if the matrix is symmetrical,");
            Console.WriteLine("and prints the trace of the matrix. The file being printed is from");
            Console.WriteLine("{0}.", FileName);
        }//end displayWelcome

        //displayOriginalMatrixText displays the text for the original matrix
        private static void displayOriginalMatrixText()
        {
            Console.WriteLine("\nThe original matrix loaded is below:\n");
        }//end displayOriginalMatrixText

        //displayTransposedMatrixText displays the text for the transposed matrix 
        private static void displayTransposedMatrixText()
        {
            Console.WriteLine("\nThe transposed matrix is below:\n");
        }//end displayTransposedMatrixText

        //displayMatrixInfo prints the text for the symmetry status and trace of the matrix
        private static void displayMatrixInfo(bool symmetryStatus, int trace)
        {
            Console.WriteLine("\nThe trace of the matrix is {0}", trace);

            //selection structure for symmetryStatus
            if(symmetryStatus == true)
            {
                Console.WriteLine("The matrix is symmetrical.");
            }//end matrix is symmetrical
            else
            {
                Console.WriteLine("The matrix is not symmetrical.");
            }//end the matrix is not symmetrical

            Console.WriteLine("Thank you for using the program!");
            
        }//end displayMatrixInfo

        //printMatrix prints the matrix that was loaded from the file
        private static void printMatrix(int[,] array)
        {
            //for loop cycling the rows in the array
            for(int row = 0; row < array.GetLength(0); row++)
            {
                //for loop cycling each column 
                for(int col = 0; col < array.GetLength(1); col++)
                {
                    //display the cell at the coordinates
                    Console.Write("{0} ", array[row, col]);
                }//end for loop cycling each column 
                Console.WriteLine();
            }//end for loop cycling each row

        }//end printMatrix
    }//end MainMethod class
}//end Hunton2DArrayExercise
