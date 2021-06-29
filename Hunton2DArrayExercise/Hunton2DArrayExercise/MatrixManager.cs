//Jeremy Hunton
//CPT244 - Data Structures
//6/8/2021
//The purpose of this program is to load a text file containing a 2D matrix and gain information from/manipulate the matrix
//once it is loaded. The purpose of MatrixManager is to manage the file handling for the incoming matrix, as well as methods
//for transposing the matrix and checking the symmetry/trace of the matrix. 

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hunton2DArrayExercise
{
    class MatrixManager
    {
       
        //declare class variables
        private static int maxRowLength;
        private static int maxColLength;
        private static int[,] array;

        //constructor
        public MatrixManager()
        {}//end constructor

        //start of setter methods 

        //loadArray method accepts the incoming file, determines the size of the array, and assigns the array to the class array
        public void loadArray(string fileName)
        {
            //declare local variable for row count
            int rowCount = 0;

            //use StreamReader to read the file
            StreamReader infile = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read));

            //read the first line  
            string firstLine = infile.ReadLine();

            //split the line by the delimeter. 
            string[] firstFields = firstLine.Split(',');

            //assign the row and column length based upon the first line
            maxRowLength = int.Parse(firstFields[0]);
            maxColLength = int.Parse(firstFields[1]);

            //declare the array from the first fields
            array = new int[maxRowLength, maxColLength];

            //while loop checking for the end of the file
            while (!infile.EndOfStream)
            {
                //read the next line
                string line = infile.ReadLine();

                //split the line by the delimeter. 
                string[] fields = line.Split(',');

                //for loop filling one array line
                for (int i = 0; i < maxRowLength; i++)
                {
                    //for array at the row count, add the fields @ the index. 
                    array[rowCount, i] = int.Parse(fields[i]);

                }//end for loop filling the array line

                //increment the row count for the record added
                rowCount++;           
            }//end of the file loop

            infile.Close();
        }//end loadArray


        //transposeMatrix takes the matrix that was loaded and transposes it 
        public void transposeMatrix()
        {
            //declare local variables
            int swapValue = 0;
            int rowCount = 0;

            //while loop making sure the rowCount isn't larger than the array row
            while(rowCount < maxRowLength)
            {
                //for loop cycling the array rows
                for(int col =0; col < maxColLength; col++)
                {
                    //selection structure making sure the cell hasn't been swapped already
                    if(col >= rowCount)
                    {
                        //for the value, assign it to the swap value 
                       swapValue = array[rowCount, col];

                        //assign the array to the inverted array position
                        array[rowCount, col] = array[col, rowCount];

                        //assign the swap value to the inverted array position
                        array[col, rowCount] = swapValue;
                    }//end skip the rows that have already been swapped
                                        
                }//end for loop cycling the one row

                //increment the row count
                rowCount++;

            }//end the end of the array loop
        }//end transposeMatrix

        //end of setters

        //start of getters

        //checkSymmetry checks is the matrix is symmetrical and returns true or false
        public bool checkSymmetry()
        {
            //declare local variables
            bool symmetryStatus = false;
            bool breakStatus = false;
            int rowCount = 0;

           //selection structure checking if the matrix is square. if not, false.

            if(maxRowLength != maxColLength)
            {
                symmetryStatus = false;
            }//end the size isn't the same so not symmetrical

            //else they are square and we need to check the contents
            else
            {
                //while loop making sure the rowCount isn't larger than the array row size and the breakStatus isn't triggered
                while (rowCount < maxRowLength && breakStatus == false)
                {
                    //for loop cycling the columns within the row
                    for(int col=0; col< maxColLength; col++)
                    {
                        //selection structure checking that the inverse cells match each other
                        if(array[rowCount,col] != array[col,rowCount])
                        {
                            //set break status to true
                            breakStatus = true;
                        }//end the array line is not symmetrical so false and break

                        //else the inverse cells match each other so the status is true for this line
                        else
                        {
                            symmetryStatus = true;
                        }//end else the inverse is true
                    }//end for loop cycling each column within the row

                    //increment the row count for the one row done
                    rowCount++;
                }//end while loop cycling the array row count

            }//end else the array is square

            //if a break happened in the while loop, set the symmetryStatus to false
            if(breakStatus == true)
            {
                symmetryStatus = false;
            }//end no symmetry because of break.

            return symmetryStatus;
        }//end checkSymmetry

        //getMatrixTrace calculates the trace of the matrix and returns it 
        public int getMatrixTrace()
        {
            //declare local variable 
            int trace = 0;
            int rowCount = 0;

            //while loop checking that the rowCount isn't larger than the array row size
            while(rowCount < maxRowLength)
            {
                //for loop cycling the columns within a row
                for(int col = 0; col<maxColLength; col++)
                {
                    //selection structure checking if the column and rowCount match each other
                    if(rowCount == col)
                    {
                        trace += array[rowCount, col];
                    }//end trace is found and accumulate the trace
                }//end for loop cycling each column within a row

                //increment rowCount to for a row processed
                rowCount++;
            }//end while loop cycling the array row count

            return trace;
        }//end getMatrixTrace

        //getMatrix returns the matrix
        public int[,] getMatrix()
        {
            return array;
        }//end getMatrix
    }//end MatrixManager
}//end of Hunton2DArrayExercise
