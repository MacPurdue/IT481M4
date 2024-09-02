using System;
using System.Diagnostics;
using System.IO;

namespace BubbleSortApp
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Collections.Generic;

    namespace SortComparisonApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    // Step 1: Read data from file
                    string filePath = "C:\\Users\\Dylan\\Downloads\\IT481M4\\data.txt"; // Ensure this path points to your file
                    string[] lines = File.ReadAllLines(filePath);

                    // Convert string array to integer array, filtering out empty or invalid lines
                    var numberList = new List<int>();
                    foreach (string line in lines)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            numberList.Add(number);
                        }
                    }

                    int[] numbersForBubbleSort = numberList.ToArray();
                    int[] numbersForQuickSort = (int[])numbersForBubbleSort.Clone(); // Clone for independent sorting

                    if (numbersForBubbleSort.Length == 0)
                    {
                        Console.WriteLine("No valid numbers found in the file.");
                        return;
                    }

                    // Step 2: Perform Bubble Sort
                    Stopwatch bubbleStopwatch = new Stopwatch();
                    bubbleStopwatch.Start();

                    BubbleSort(numbersForBubbleSort);

                    bubbleStopwatch.Stop();

                    // Step 3: Perform Quick Sort
                    Stopwatch quickStopwatch = new Stopwatch();
                    quickStopwatch.Start();

                    QuickSort(numbersForQuickSort, 0, numbersForQuickSort.Length - 1);

                    quickStopwatch.Stop();

                    // Step 4: Display the sorted array and elapsed time for Bubble Sort
                    Console.WriteLine("Bubble Sort Results:");
                    foreach (var number in numbersForBubbleSort)
                    {
                        Console.WriteLine(number);
                    }
                    Console.WriteLine($"\nBubble Sort time elapsed: {bubbleStopwatch.Elapsed.TotalMilliseconds} ms");

                    // Step 5: Display the sorted array and elapsed time for Quick Sort
                    Console.WriteLine("\nQuick Sort Results:");
                    foreach (var number in numbersForQuickSort)
                    {
                        Console.WriteLine(number);
                    }
                    Console.WriteLine($"\nQuick Sort time elapsed: {quickStopwatch.Elapsed.TotalMilliseconds} ms");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            // Bubble Sort Algorithm
            static void BubbleSort(int[] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            // Swap temp and arr[i]
                            int temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }
                }
            }

            // Quick Sort Algorithm
            static void QuickSort(int[] arr, int left, int right)
            {
                if (left < right)
                {
                    int pivotIndex = Partition(arr, left, right);

                    // Recursively sort elements before and after partition
                    QuickSort(arr, left, pivotIndex - 1);
                    QuickSort(arr, pivotIndex + 1, right);
                }
            }

            static int Partition(int[] arr, int left, int right)
            {
                int pivot = arr[right];
                int i = left - 1;

                for (int j = left; j < right; j++)
                {
                    if (arr[j] < pivot)
                    {
                        i++;
                        Swap(arr, i, j);
                    }
                }

                Swap(arr, i + 1, right);
                return i + 1;
            }

            static void Swap(int[] arr, int i, int j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }
}