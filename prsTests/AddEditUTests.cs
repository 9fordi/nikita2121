using Microsoft.VisualStudio.TestTools.UnitTesting;
using prs.appdata;
using prs.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prs.pages.Tests
{ 
     [TestClass()]

public class AddEditUTests
    { 
        [TestMethod()]
        public void CheckAccountingTest()
        {
            uchetnaya inf = new uchetnaya { Nomer_postuplenya = 5, Kod_tovara = 5, Data = "2023-03-15", Cena = "10000", Kolichestvo_tovara = "5" };
            bool expected = true;
            bool actual = AddEditU.CheckAccounting(inf);
            Assert.AreEqual(expected, actual);
        }

       

        [TestMethod()]
        public void CheckAccountingTest3() // Исправленное имя
        {
            uchetnaya inf = new uchetnaya { Nomer_postuplenya = 3, Kod_tovara = 3, Data = "2023-03-18", Cena = "10000", Kolichestvo_tovara = "3" };
            bool expected = true;
            bool actual = AddEditU.CheckAccounting(inf);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckAccountingTest4() // Исправленное имя
        {
            uchetnaya inf = new uchetnaya { Nomer_postuplenya = 4, Kod_tovara = 4, Data = "2023-03-25", Cena = "10000", Kolichestvo_tovara = "8" };
            bool expected = true;
            bool actual = AddEditU.CheckAccounting(inf);
            Assert.AreEqual(expected, actual);
        }
    }
}