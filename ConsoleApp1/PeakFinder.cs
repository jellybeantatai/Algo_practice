using System;

class PeakFinder
{
    /// <summary>
    /// The Main Method. Handles initial UI.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        bool loopExitFlag = false;
        do
        {
            Console.WriteLine("Select the number for peak finding method do you want to choose...");
            Console.WriteLine("1-> Finding a peak for a 1 Dimensional array in a straight forward way");
            Console.WriteLine("2-> Finding a peak for a 1 Dimensional array using Divide and Conquer");
            Console.WriteLine("3-> Finding a peak for a 2 Dimensional array using Divide and Conquer");
            Console.WriteLine("5-> Exit");

            PeakFinder pf = new PeakFinder();

            int chosenOption = 0;
            int.TryParse(Console.ReadLine(), out chosenOption);

            switch (chosenOption)
            {
                case 1:
                    int[] arrInput = pf.Get1DArrayInput();
                    pf.StraightForward_1D(arrInput);
                    break;
                case 2:
                    int[] arrInput2 = pf.Get1DArrayInput();
                    pf.DivideAndConquer_1D(arrInput2);
                    break;
                case 3:
                    int[,] arrInput3 = pf.Get2DArrayInput();
                    pf.Print2DMatrix(arrInput3);
                    int numberOfColumns = arrInput3.GetLength(1);
                    pf.DivideAndConquer_2D(arrInput3,0,numberOfColumns-1);
                    break;
                case 5:
                    loopExitFlag = true;
                    break;
                default:
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Please enter an appropriate input");
                    break;
            }
        }
        while (loopExitFlag == false);
    }

    /// <summary>
    /// Used to fetch input from user for 1-D Arrays
    /// </summary>
    /// <returns></returns>
    int[] Get1DArrayInput()
    {
        Console.Write("What is the length of your 1 Dimensional Array?");
        int arrayLength = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[arrayLength];
        Console.WriteLine("Enter the array of 10 integers:");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("Enter the {0}th integer:", i + 1);
            arr[i] = int.Parse(Console.ReadLine());
        }
        return arr;
    }

    /// <summary>
    /// Used to fetch input from users for 2D Arrays
    /// </summary>
    /// <returns></returns>
    int[, ] Get2DArrayInput()
    {
        int rows, columns = 0;

        Console.WriteLine("\n\n");
        Console.Write("Enter the number of ROWS for the 2D array: ");
        rows = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of COLUMNS for the 2D array: ");
        columns = int.Parse(Console.ReadLine());

        int[,] arrayInput = new int[rows,columns];
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                Console.Write("Enter the value for the array at [{0},{1}] position: ",i+1,j+1);
                arrayInput[i, j] = int.Parse(Console.ReadLine());
            }
        }

        return arrayInput;
    }

    /// <summary>
    /// Used to look for Peak in a 1D array. Has been used in DivideAndConquer_1D() method.
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="fromIndex"></param>
    /// <param name="toIndex"></param>
    void LookForPeak(int[] arr, int fromIndex, int toIndex)
    {
        if (fromIndex == toIndex)
        {
            Console.WriteLine(arr[fromIndex] + "is a peak");
            return;
        }

        int mid = ((fromIndex + toIndex) / 2) + 1;

        if (arr[mid] < arr[mid - 1])
        {
            LookForPeak(arr, fromIndex, mid - 1);
        }
        else if (arr[mid] < arr[mid + 1])
        {
            LookForPeak(arr, mid + 1, toIndex);
        }
        else
        {
            Console.WriteLine("\n\n");
            Console.WriteLine(arr[mid] + "is a peak");
            return;
        }
    }

    /// <summary>
    /// Prints the 2D array matrix for visual aid 
    /// </summary>
    /// <param name="arr"></param>
    void Print2DMatrix(int[, ] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write("|" + arr[i, j] + "|");
            }
            Console.WriteLine("");
            for (int k = 0; k < arr.GetLength(1); k++)
            {
                Console.Write("---");
            }
            Console.WriteLine("");
        }
    }

    void StraightForward_1D(int[] arr)
    {
        //Starting Timer
        var watch = System.Diagnostics.Stopwatch.StartNew();

        //Start to finding Peak
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == 0)
            {
                if (arr[i] >= arr[i + 1])
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine(arr[i] + "is a peak");
                    break;
                }
                else
                {
                    continue;
                }
            }
            else if (i == arr.Length - 1)
            {
                if (arr[i] >= arr[i - 1])
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine(arr[i] + "is a peak");
                    break;
                }
                else
                {
                    continue;
                }
            }
            else
            {
                if (arr[i] >= arr[i - 1] && arr[i] >= arr[i + 1])
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine(arr[i] + "is a peak");
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        //Stopping Timer
        watch.Stop();
        var elapsedMs = watch.Elapsed;
        Console.WriteLine("\n\n");
        Console.WriteLine("Execution Time is" + elapsedMs);
    }

    void DivideAndConquer_1D(int[] arr)
    {
        //Starting Timer
        var watch = System.Diagnostics.Stopwatch.StartNew();
        //PeakFinder pf = new PeakFinder();

        LookForPeak(arr, 0, arr.Length - 1);

        //Stopping Timer
        watch.Stop();
        var elapsedMs = watch.Elapsed;
        Console.WriteLine("\n\n");
        Console.WriteLine("Execution Time is" + elapsedMs);
    }

    void DivideAndConquer_2D(int[, ] arr,int leftIndex,int rightIndex)
    {
        int numberOfRows = arr.GetLength(0);
        int numberOfColumns = rightIndex - leftIndex;

        int midColumn = numberOfColumns / 2;

        int largestNumberInColumn = 0;
        int rowNumberForLargestNumber = -1;

        for(int i = 0; i < numberOfRows; i++)
        {
            if(arr[i,midColumn] > largestNumberInColumn)
            {
                largestNumberInColumn = arr[i, midColumn];
                rowNumberForLargestNumber = i;
            }
        }

        if (arr[rowNumberForLargestNumber, midColumn]<arr[rowNumberForLargestNumber,midColumn-1])
        {
            DivideAndConquer_2D(arr,leftIndex, midColumn - 1);
        }

        else if (arr[rowNumberForLargestNumber, midColumn] < arr[rowNumberForLargestNumber, midColumn + 1])
        {
            DivideAndConquer_2D(arr, midColumn + 1, rightIndex);
        }

        else
        {
            Console.WriteLine("\n");
            Console.WriteLine(arr[rowNumberForLargestNumber, midColumn] + "is a peak");
            Console.WriteLine("\n");
        }
    }
}


