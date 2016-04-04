using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using end_user_gui.Modules;
using end_user_gui.Models;

namespace end_user_gui.Tests
{
    [TestClass]
    public class EADSearchTests
    {
        [TestMethod]
        public void Search()
        {
            var searchModule = new EADSearchModule();
            var req = new ArchiveSearchObject() { name = "Ein" };
            var ret = searchModule.Search(req);
        }
    }
}
