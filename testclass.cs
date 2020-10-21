using Xunit;

public class testclass
{
    [Theory]

    // [InlineData(new object[] { new int[] { 0, 80, 45, 95, 170, 145 } ,
    //                         new int[] { 115, 210, 60, 5, 230,220 },
    //                         new int[] { 5, 0, 145, 250, 245, 140 },
    //                         new int[] { 15, 5, 175, 250, 185, 160 },
    //                         new int[] { 0, 5, 95, 115, 165, 250 },
    //                         new int[] { 5, 0, 25, 5, 145, 250 }
    //                         })]
    // [InlineData(3)]
    [InlineData(200,3)]
    [InlineData(150,5)]
    public void regionCountTheory(int trashold,int count)
    {
        int [][] M1 = new int[6][];
        M1[0] = new int[] { 0, 80, 45, 95, 170, 145 };
        M1[1] = new int[] { 115, 210, 60, 5, 230,220 };
        M1[2] = new int[] { 5, 0, 145, 250, 245, 140 };
        M1[3] = new int[] { 15, 5, 175, 250, 185, 160 };
        M1[4] = new int[] { 0, 5, 95, 115, 165, 250 };
        M1[5] = new int[] { 5, 0, 25, 5, 145, 250 };
        Assert.Equal(count, MatrixSubregion.regionCount(M1,trashold));
    }
}