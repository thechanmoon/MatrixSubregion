using Xunit;

public class testclass
{
    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(6)]

    public void MyTheory(int number)
    {
        Assert.True(MatrixSubregion.IsOdd(number));
    }
    
    [Fact]
    public void PassingAddTest()
    {
        Assert.Equal(5, MatrixSubregion.Add(2,3));
    }

    [Fact]
    public void FailingTest()
    {
        Assert.NotEqual(4,MatrixSubregion.Add(2,3));
    }
}