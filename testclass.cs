using Xunit;
namespace MatrixSubregion
{
    public class TestClass
    {
        [Theory]
        
        [InlineData(200, 3, new int[] { 210, 239, 250 })]
        [InlineData(150, 2, new int[] { 212, 210 })]
        
        public void averageTheory(int trashold, int regionCount ,int[] avgArray)
        {
            int [][] M1 = new int[6][];
            M1[0] = new int[] { 0, 80, 45, 95, 170, 145 };
            M1[1] = new int[] { 115, 210, 60, 5, 230,220 };
            M1[2] = new int[] { 5, 0, 145, 250, 245, 140 };
            M1[3] = new int[] { 15, 5, 175, 250, 185, 160 };
            M1[4] = new int[] { 0, 5, 95, 115, 165, 250 };
            M1[5] = new int[] { 5, 0, 25, 5, 145, 250 };

            Subregion ms = new Subregion();
            ms.printSummary();
            
            Assert.Equal(regionCount, ms.regionCount(M1,trashold));

            int [] avg = ms.calcAverage();

            for( int i = 0; i < avg.Length; i++)
                Assert.Equal(avg[i], avgArray[i]);
        }
    }
}