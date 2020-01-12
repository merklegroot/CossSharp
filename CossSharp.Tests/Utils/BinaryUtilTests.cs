using CossSharp.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace CossSharp.Tests.Utils
{
    [TestClass]
    public class BinaryUtilTests
    {
        private BinaryUtil _binaryUtil;

        [TestInitialize]
        public void Initialize()
        {
            _binaryUtil = new BinaryUtil();
        }

        [TestMethod]
        public void Should_get_upper_case_hex_values()
        {
            _binaryUtil.ByteArrayToUpperHex(new byte[] { 0xDE, 0xAD, 0xBE, 0xEF })
                .ShouldBe("DEADBEEF");
        }

        [TestMethod]
        public void An_empty_array_should_generate_an_empty_string()
        {
            _binaryUtil.ByteArrayToUpperHex(new byte[] { })
                .ShouldBe(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void A_null_array_should_cause_an_exception()
        {
            _binaryUtil.ByteArrayToUpperHex(null);
        }
    }
}
