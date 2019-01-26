using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            Smoothsort sort = new Smoothsort(11);
            sort.GenRandom();
            sort.Sort();
        }

    }
    class Smoothsort
    {
        int[] unsorted;
        List<int> presort;
        int[] sorted;
        int i;
        int n;
        List<int> sizeList;
        List<int> ln;
        Dictionary<int, int> lookup;

        public Smoothsort(int n)
        {
            unsorted = new int[n];
            presort = new List<int>();
            sorted = new int[unsorted.Length];
            sizeList = new List<int>();
            ln = new List<int>() { 1, 1, 3, 5, 9, 15, 25, 41, 67, 109, 177, 287, 465, 753, 1219, 1973, 3193, 5167, 8361, 13529, 21891 };
            lookup = new Dictionary<int, int>()
            {
                {1,0 },{3,2},{5,3},{9,4},{15,5},{25,6},{41,7},{67,8},{109,9},{117,10},{287,11},{465,12},{753,13},{1219,14},{1973,15},{3193,16},{5167,17},{8361,18},{13529,19},{21891,20}
            };
            i = 0;
            n = 0;
        }
        public void GenRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < unsorted.Length; i++)
            {
                unsorted[i] = rnd.Next(0, 100);
            }
        }
        public void Sort()
        {
            while (presort.Count != unsorted.Length)
            {
                Heapify(unsorted);
                FixHeap();
            }
            while (presort.Count != 0)
            {
                Remove();
            }
            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
        }

        public void Heapify(int[] arr)
        {
            n = sizeList.Count - 1;

            if (sizeList.Count > 1 && CheckLeonardo(sizeList[n], sizeList[n - 1]))
            {
                int x = sizeList[n] + sizeList[n - 1] + 1;
                sizeList.RemoveAt(n);
                sizeList.RemoveAt(n - 1);
                sizeList.Add(x);
                presort.Add(arr[i]);
            }
            else if (sizeList.Count > 0 && sizeList[n] != 1)
            {
                presort.Add(arr[i]);
                sizeList.Add(ln[1]);
            }
            else
            {
                presort.Add(arr[i]);
                sizeList.Add(ln[0]);
            }
            i++;
        }

        public void FixHeap()
        {
            int s = presort.Count() - 1;
            int current = presort[s];
            int l = sizeList.Count - 1;

            while (l > 0 && presort[s - sizeList[l]] > current && s >= l)
            {
                int temp = presort[s - 1];
                presort[s - 1] = presort[s];
                presort[s] = temp;
                current = presort[s - 1];
                s--;
                l--;
            }
            int k = lookup[sizeList[l]];
            int a = s;
            while (ln[k] > 1 && (presort[a - 1] > presort[a] || presort[a - 1 - ln[k - 2]] > presort[a]))
            {
                int left = presort[a - 1 - ln[k - 2]];
                int right = presort[a - 1];


                if (left > current && left > right)
                {
                    int temp = left;
                    presort[a - 1 - ln[k - 2]] = presort[a];
                    presort[a] = temp;
                    left = presort[s - 1 - ln[k - 2]];
                    a = a - 1 - ln[k - 2];
                    k = k - 1;
                }
                else if (right > current && right > left)
                {
                    int temp = right;
                    presort[a - 1] = presort[a];
                    presort[a] = temp;
                    right = presort[a - 1];
                    a = a - 1;
                    k = k - 2;
                }
            }
        }
        int l = 0;
        public void Remove()
        {
            int s = presort.Count - 1;
            int left = 0; int right = 0;
            l = sizeList.Count - 1;
            int prevSize = sizeList[l];

            sorted[s] = presort[s];
            fixHeapSize(l);
            l = sizeList.Count - 1;

            if (prevSize > 1)
            {
                left = s - 1 - ln[lookup[prevSize] - 2];
                right = s - 1;
            }

            if (l > 0 && prevSize > 1)
            {
                FixHeapChild(l - 1, left);
                FixHeapChild(l, right);
            }

            presort.RemoveAt(s);
            l--;

        }

        public bool CheckLeonardo(int a, int b)
        {
            int x = lookup[a];
            int y = lookup[b];

            if (a == 1)
                x += 1;
            else if (b == 1)
                y += 1;

            if (x - y == 1 || x - y == -1)
                return true;

            return false;
        }
        public void fixHeapSize(int l)
        {
            int current = lookup[sizeList[l]];
            sizeList.RemoveAt(l);
            if (current != 0)
            {
                sizeList.Add(ln[current - 1]);
                sizeList.Add(ln[current - 2]);
            }
        }

        public void FixHeapChild(int l, int s)
        {
            int current = presort[s];
            while (l > 0 && presort[s - sizeList[l]] > current && s >= l)
            {
                int temp = presort[s - 1];
                presort[s - 1] = presort[s];
                presort[s] = temp;
                current = presort[s - 1];
                s--;
                l--;
            }
            int k = lookup[sizeList[l]];
            int a = s;
            while (ln[k] > 1 && (presort[a - 1] > presort[a] || presort[a - 1 - ln[k - 2]] > presort[a]))
            {
                int left = presort[a - 1 - ln[k - 2]];
                int right = presort[a - 1];

                if (left > current && left > right)
                {
                    int temp = left;
                    presort[a - 1 - ln[k - 2]] = presort[a];
                    presort[a] = temp;
                    left = presort[s - 1 - ln[k - 2]];
                    a = a - 1 - ln[k - 2];
                    k = k - 1;
                }
                else if (right > current && right > left)
                {
                    int temp = right;
                    presort[a - 1] = presort[a];
                    presort[a] = temp;
                    right = presort[a - 1];
                    a = a - 1;
                    k = k - 2;
                }
            }
        }
    }
}

