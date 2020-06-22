using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocketClient.player.algorithms;

namespace UnitTests
{
    [TestClass]
    public class MergeSortTest
    {
        [TestMethod]
        public void TestMergeSort()
        {
            var cmp = Comparer<string>.Default;

            List<string> playlist = new List<string>();
            for (int i = 1; i < 10; i++)
                playlist.Add("song" + i);

            playlist.Reverse();

            Console.WriteLine("List prior to sorting: ");
            foreach (string s in playlist)
            {
                Console.WriteLine(s);
            }

            var arr = playlist.ToArray();

            MergeSort<string> sorter = new MergeSort<string>();
            sorter.sort(arr, cmp, true);

            Console.WriteLine("Sorted list: ");
            foreach (string s in arr)
            {
                Console.WriteLine(s);
            }

        }
    }
}
