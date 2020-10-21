using Xunit;
using System.Collections.Generic;
namespace MatrixSubregion
{
    public class TestClass
    {
        [Theory]
        
        [InlineData(200, 3, new int[] { 210, 239, 250 })]
        [InlineData(150, 2, new int[] { 212, 210 })]
        
        public void averageTheory(int trashold, int regionCount ,int[] avgArray)
        {
            // int [][] matrix = new int[6][];
            // matrix[0] = new int[] { 0, 80, 45, 95, 170, 145 };
            // matrix[1] = new int[] { 115, 210, 60, 5, 230,220 };
            // matrix[2] = new int[] { 5, 0, 145, 250, 245, 140 };
            // matrix[3] = new int[] { 15, 5, 175, 250, 185, 160 };
            // matrix[4] = new int[] { 0, 5, 95, 115, 165, 250 };
            // matrix[5] = new int[] { 5, 0, 25, 5, 145, 250 };

            int [,] matrix = 
            { { 0, 80, 45, 95, 170, 145 },
             { 115, 210, 60, 5, 230,220 },
             { 5, 0, 145, 250, 245, 140 },
             { 15, 5, 175, 250, 185, 160 },
             { 0, 5, 95, 115, 165, 250 },
             { 5, 0, 25, 5, 145, 250 }};

            Subregion ms = new Subregion();
            
            Assert.Equal(regionCount, ms.regionCount(matrix,trashold));

            int [] avg = ms.calcAverage();

            for( int i = 0; i < avg.Length; i++)
                Assert.Equal(avg[i], avgArray[i]);

            List<List<Coords>> coordsList = ms.calcCoords();
            foreach (List<Coords> subList in coordsList)
            {
                foreach (Coords item in subList)
                {
                    Assert.True(matrix[item.row,item.col]>=trashold); 
                }      
            }
        }
    }
}