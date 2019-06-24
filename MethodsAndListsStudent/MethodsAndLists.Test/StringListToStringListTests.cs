using System;
using System.Linq;
using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class StringListToStringListTests
    {
        readonly StringListToStringList x = new StringListToStringList();

        [TestMethod]
        [DataRow(null, new string[] { }, new[] { "a" })]
        [DataRow(null, new string[] { "b" }, new[] { "a", "b" })]
        [DataRow(null, new string[] { "b" }, new[] { "a", "b", "c" })]
        [DataRow(null, new string[] { "b", "d" }, new[] { "a", "b", "c", "d" })]
        [DataRow(null, new string[] { "b", "d" }, new[] { "a", "b", "c", "d", "e" })]
        public void GetEverySecondElement_MultipleTests(object dummy, string[] expected, string[] input)
        {
            CollectionAssert.AreEqual(expected, x.GetEverySecondElement(input).ToArray());
            //CollectionAssert.AreEqual(expected, x.GetEverySecondElement_OneLiner(input).ToArray());
            //CollectionAssert.AreEqual(expected, x.GetEverySecondElement_OneLiner_WithHelpMethod(input).ToArray());
            //CollectionAssert.AreEqual(expected, x.GetEverySecondElement_WithYield(input).ToArray());
        }

        [TestMethod]
        public void GetEverySecondElement_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => x.GetEverySecondElement(null).ToArray());
            Assert.ThrowsException<ArgumentNullException>(() => x.GetEverySecondElement_OneLiner(null).ToArray());
            Assert.ThrowsException<ArgumentNullException>(() => x.GetEverySecondElement_OneLiner_WithHelpMethod(null).ToArray());
            Assert.ThrowsException<ArgumentNullException>(() => x.GetEverySecondElement_WithYield(null).ToArray());
        }

    }
}
