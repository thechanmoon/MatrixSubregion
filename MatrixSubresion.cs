using System;
using System.Collections.Generic;
namespace MatrixSubregion
{
    class Coords 
    {
        public int row {get;set;}
        public int col {get;set;}

        public Coords(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    class Cell{
        public int row
        { get; set; }
        public int col
        { get; set; }
        public int value
        { get; set; }
        public int region
        { get; set; }

        public Cell(int row, int col, int value, int region)
        {
            this.row = row;
            this.col = col;
            this.value = value;
            this.region = region;
        }
    }
    class Subregion
    {
        int[] DIR_ROW = {1,-1,0,0,1,1,-1,-1};
        int[] DIR_COL = {0,0,1,-1,1,-1,1,-1};

        List<List<Cell>> myList = new List<List<Cell>>();
        // int[] avgArray;
        int countCell = 0;
        public int regionCount(int[,] grid, int treshold)
        {
            countCell = 0;
            bool[,] visited = new bool[grid.GetLength(0),grid.GetLength(1)];
            myList.Clear();
            if(grid == null || grid.GetLength(0) == 0)
            {
                return 0;
            }

            for(int i = 0; i < grid.GetLength(0); i++){
                for(int j = 0; j < grid.GetLength(1); j++){
                    if(grid[i,j] >= treshold){
                        int count = 0;
                        List<Cell> listCell = new List<Cell>();
                        count = dfs(grid, i, j ,treshold, listCell,visited);
                        if(count > 0)
                        {
                            myList.Add(listCell);
                            countCell++;
                        }
                    }
                }
            }
            return countCell;
        }

        int dfs(int[,] grid, int i, int j, int treshold, List<Cell> listCell, bool[,] visited)
        {
            if(i < 0 || i >= grid.GetLength(0) || j < 0 || j >= grid.GetLength(1) || grid[i,j] < treshold || visited[i,j] == true){
                return 0;
            }

            listCell.Add(new Cell(i,j, grid[i,j], countCell));

            // grid[i,j] = 0;
            visited[i,j] = true;
            for(int index = 0; index < DIR_ROW.Length; index++)
            {
                dfs(grid, i + DIR_ROW[index], j + DIR_COL[index] ,treshold ,listCell,visited);
            }
            // dfs(grid, i + 1, j ,treshold ,listCell);
            // dfs(grid, i - 1, j ,treshold ,listCell);
            // dfs(grid, i, j + 1 ,treshold ,listCell);
            // dfs(grid, i, j - 1 ,treshold ,listCell);

            // dfs(grid, i + 1, j + 1 ,treshold ,listCell);
            // dfs(grid, i + 1, j - 1 ,treshold ,listCell);
            // dfs(grid, i - 1, j + 1 ,treshold ,listCell);
            // dfs(grid, i - 1, j - 1 ,treshold ,listCell);
            return 1;
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

        public List<List<Coords>> calcCoords()
        {         
            List<List<Coords>> coordsList = new List<List<Coords>>();

            foreach (List<Cell> subList in myList)
            {
                List<Coords> coords = new List<Coords>();
                foreach (Cell item in subList)
                {
                    coords.Add(new Coords(item.row,item.col)); 
                } 
                coordsList.Add(coords);
            }
            return coordsList;
        }

        public void printCoords()
        {
            List<List<Coords>> coordsList = calcCoords();
            int index = 0;
            foreach (List<Coords> subList in coordsList)
            {
                System.Console.WriteLine("==region coords: " + index++);

                foreach (Coords item in subList)
                {
                    System.Console.WriteLine( item.row + "," +item.col ); 
                } 
                 
            }
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
                    Console.WriteLine("row:"+item.row +", column:" +item.col + ", value:" + item.value + ", region=" + item.region);
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

            int [,] M2 = 
            { { 0, 80, 45, 95, 170, 145 },
             { 115, 210, 60, 5, 230,220 },
             { 5, 0, 145, 250, 245, 140 },
             { 15, 5, 175, 250, 185, 160 },
             { 0, 5, 95, 115, 165, 250 },
             { 5, 0, 25, 5, 145, 250 }};

            Subregion ms = new Subregion();
            // System.Console.WriteLine(regionCount(M1,200));
            ms.regionCount(M2,200);
            ms.printSummary();
            ms.printCoords();

            // List<List<Coords>> coordsList = ms.calcCoords();
            // foreach (List<Coords> subList in coordsList)
            // {
            //     foreach (Coords item in subList)
            //     {
            //         System.Console.WriteLine( M2[item.row,item.col]);  
            //     }      
            // }
            
        }
    
    }
 }
