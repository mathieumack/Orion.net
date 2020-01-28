﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Core.UnitTests.Scripts.ExecuteScriptCom
{
    /// <summary>
    /// Unit Test for <see cref="ExecuteScriptCommand"/>
    /// <list type="number">
    /// <item>Verify <see cref="ExecuteScriptCommand.CommandParam"/> is not instantiated</item>
    /// <item>Verify <see cref="ExecuteScriptCommand.CommandParam"/> set and get</item>
    /// </list>
    /// </summary>
    [TestClass]
    public class ExecuteScriptTestCommandParam
    {
        [TestMethod]
        public void ExecuteScriptCommandTestCommandParam()
        {
            ExecuteScriptCommand testExecuteScript = new ExecuteScriptCommand();

            Assert.IsNull(testExecuteScript.CommandParam);

            testExecuteScript.CommandParam = "toto";

            Assert.AreEqual("toto", testExecuteScript.CommandParam);
        }
    }
}
