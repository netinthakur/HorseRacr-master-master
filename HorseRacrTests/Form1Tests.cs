using Microsoft.VisualStudio.TestTools.UnitTesting;
using HorseRacr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacr.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void checkingException()
        {
            Form1 objform = new Form1();
            try {
                
            }
            catch (Exception ex) {
                
                StringAssert.Contains(ex.Message," error ");
            }
            Assert.Fail("No Exception wasThrown");
        }
    }
}