//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Orion.Net.Core.Results;

//namespace Orion.Net.Core.UnitTests.Results.FileContent
//{
//    /// <summary>
//    /// Unit Test for <see cref = "FileContentResult" />
//    /// < list type="number">
//    /// <item>Verify<see cref="FileContentResult.FileName"/> is not instantiated</item>
//    /// <item>Verify<see cref="FileContentResult.FileName"/> set and get</item>
//    /// </list>
//    /// </summary> 
//    [TestClass]
//    public class FileContentTestFileName
//    {
//        [TestMethod]
//        public void FileTestFileName()
//        {
//            FileContentResult testContent = new FileContentResult();

//            Assert.IsNull(testContent.FileName);

//            testContent.FileName = "toto";

//            Assert.AreEqual("toto", testContent.FileName);
//        }
//    }
//}