//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Orion.Net.Core.Results;

//namespace Orion.Net.Core.UnitTests.Results.FileContent
//{
//    /// <summary>
//    /// Unit Test for <see cref="FileContentResult"/>
//    /// <list type="number">
//    /// <item>Verify <see cref="FileContentResult.FileAsByteArray"/> is not instantiated</item>
//    /// <item>Verify <see cref="FileContentResult.FileAsByteArray"/> set and get</item>
//    /// </list>
//    /// </summary>
//    [TestClass]
//    public class FileContentTestFileByte
//    {
//        [TestMethod]
//        public void FileTestFileByte()
//        {
//            byte[] testByte = new byte[] { 0, 1 };
//            FileContentResult testContent = new FileContentResult();

//            Assert.IsNull(testContent.FileAsByteArray);

//            testContent.FileAsByteArray = testByte;

//            Assert.AreEqual(testByte, testContent.FileAsByteArray);
//        }
//    }
//}