//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Orion.Net.Core.Results;

//namespace Orion.Net.Core.UnitTests.Results.FileContent
//{
//    /// <summary>
//    /// Unit Test for <see cref = "FileContentResult" />
//    /// < list type="number">
//    /// <item>Verify<see cref="FileContentResult.Mime"/> is not instantiated</item>
//    /// <item>Verify<see cref="FileContentResult.Mime"/> set and get</item>
//    /// </list>
//    /// </summary>    
//    [TestClass]
//    public class FileContentTestMime
//    {
//        [TestMethod]
//        public void FileTestMime()
//        {
//            FileContentResult testContent = new FileContentResult();

//            Assert.IsNull(testContent.Mime);

//            testContent.Mime = "toto";

//            Assert.AreEqual("toto", testContent.Mime);
//        }
//    }
//}