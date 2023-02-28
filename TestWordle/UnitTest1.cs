using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestWordle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            M3P1WordleGaliOriol.Wordle wordle = new M3P1WordleGaliOriol.Wordle();
            string[] array = wordle.File2Array(@"\lang\en\lang.txt", @"..\..\..\files");
            //Assert.AreEqual(?,?);
        }
    }
}
