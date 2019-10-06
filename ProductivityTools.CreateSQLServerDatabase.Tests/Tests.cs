using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.IO;

namespace ProductivityTools.CreateSQLServerDatabase.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestIfDatabaseExists()
        {
            string name="DB"+ Path.GetRandomFileName().Replace('.','x');
            Database database = new Database(name, "Server=.\\SQL2017;Trusted_Connection=True;");
            var r=database.Exists();
            Assert.IsFalse(r);

            database.Create();
            r = database.Exists();
            Assert.IsTrue(r);
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void TryCreateDatabaseTwice()
        {
            string name = "DB" + Path.GetRandomFileName().Replace('.', 'x');
            Database database = new Database(name, "Server=.\\SQL2017;Trusted_Connection=True;");
            database.Create();
            database.Create();
        }
    }
}
