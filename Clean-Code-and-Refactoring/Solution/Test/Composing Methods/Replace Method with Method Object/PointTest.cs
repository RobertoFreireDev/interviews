using ComposingMethods.ReplaceMethodWithMethodObject;
using Xunit;

namespace Test.Composing_Methods.Replace_Method_with_Method_Object
{
    public class PointTest
    {
        [Fact(DisplayName = "Must Calculate Distance")]
        [Trait("Replace Method with Method Object", "Point")]
        public void MustCalculateDistance()
        {
            double expectedDistance = 16.113;
            var pointA = new Point(-20.021937, -44.057844);
            var pointB = new Point(-19.936868, -43.933015);

            var result = pointA.CalculateDistance(pointB);

            Assert.Equal(expectedDistance, result);
        }
    }
}
