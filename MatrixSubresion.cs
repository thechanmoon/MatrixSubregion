using System;
using System.Collections.Generic;
namespace MatrixSubregion
{
    class Cell{
        public int x
        { get; set; }
        public int y
        { get; set; }
        public int value
        { get; set; }
        public int region
        { get; set; }
        // public bool check
        // { get; set; }

        public Cell(int x, int y, int value, int region, bool check)
        {
            this.x = x;
            this.y = y;
            this.value = value;
            this.region = region;
            // this.check = check;
        }
    }
    class Subregion
    {

        List<List<Cell>> myList = new List<List<Cell>>();
        int[] avgArray;
        int countCell = 0;
        public int regionCount(int[][] grid, int treshold)
        {
            countCell = 0;
            myList.Clear();
            if(grid == null || grid.Length == 0)
            {
                return 0;
            }

            for(int i = 0; i < grid.Length; i++){
                for(int j = 0; j < grid[0].Length; j++){
                    if(grid[i][j] >= treshold){
                        List<Cell> listCell = new List<Cell>();
                        dfs(grid, i, j ,treshold, listCell);
                        myList.Add(listCell);
                        countCell++;
                    }
                }
            }
            return countCell;
        }

        void dfs(int[][] grid, int i, int j, int treshold, List<Cell> listCell)
        {
            if(i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] < treshold){
                return;
            }

            listCell.Add(new Cell(i,j, grid[i][j], countCell,true));

            grid[i][j] = 0;
            dfs(grid, i + 1, j ,treshold ,listCell);
            dfs(grid, i - 1, j ,treshold ,listCell);
            dfs(grid, i, j + 1 ,treshold ,listCell);
            dfs(grid, i, j - 1 ,treshold ,listCell);

            dfs(grid, i + 1, j + 1 ,treshold ,listCell);
            dfs(grid, i + 1, j - 1 ,treshold ,listCell);
            dfs(grid, i - 1, j + 1 ,treshold ,listCell);
            dfs(grid, i - 1, j - 1 ,treshold ,listCell);
        }
        public int[] calcAverage()
        {
            int[] avgArray = new int[myList.Count];
            int sum = 0;
            int i = 0;
            int avg = 0;            
            int index = 0;
            foreach (List<Cell> subList in myList)
            {
                 sum = 0;
                 i = 0;
                foreach (Cell item in subList)
                {
                    sum += item.value;
                    i++;
                }
                if (i != 0)
                    avg = sum/i;
                avgArray[index++] = avg;
            }
            return avgArray;
        }

        public void printSummary()
        {
            int sum = 0;
            int i = 0;
            int avg = 0;
            System.Console.WriteLine("resiion: " + countCell);
            foreach (List<Cell> subList in myList)
            {
                 sum = 0;
                 i = 0;
                foreach (Cell item in subList)
                {
                    Console.WriteLine("row:"+item.x +", column:" +item.y + ", value:" + item.value + ", region=" + item.region);
                    sum += item.value;
                    i++;
                }
                if (i != 0)
                    avg = sum/i;

                Console.WriteLine("avg = " + avg);
            }
        }


    }

    class MatrixSubregion
    {
        static void Main(string[] args)
        {
            
            // Console.WriteLine("Hello World!");
            
            int [][] M1 = new int[6][];
            M1[0] = new int[] { 0, 80, 45, 95, 170, 145 };
            M1[1] = new int[] { 115, 210, 60, 5, 230,220 };
            M1[2] = new int[] { 5, 0, 145, 250, 245, 140 };
            M1[3] = new int[] { 15, 5, 175, 250, 185, 160 };
            M1[4] = new int[] { 0, 5, 95, 115, 165, 250 };
            M1[5] = new int[] { 5, 0, 25, 5, 145, 250 };

            Subregion ms = new Subregion();
            // System.Console.WriteLine(regionCount(M1,200));
            ms.regionCount(M1,200);
            ms.printSummary();
            
        }
    
    }
 }
