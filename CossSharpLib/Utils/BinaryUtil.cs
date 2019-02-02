using System;
using System.Linq;

namespace CossSharpLib.Utils
{
    public class BinaryUtil : IBinaryUtil
    {
        /// <summary>
        /// Converts an array of bytes to a Hex string.
        /// There is no prefix.
        /// All Hex digits are upper case.
        /// e.g. { 123, 234 } => "78EA"
        /// </summary>
        /// <param name="data">An array of bytes</param>
        /// <returns>The bytes represented as a hex string.</returns>
        public string ByteArrayToUpperHex(byte[] data)
        {
            if(data == null) { throw new ArgumentNullException(nameof(data)); }
            return string.Join(string.Empty, data.Select(queryHashedByte => string.Format("{0:X2}", queryHashedByte)));
        }
    }
}
