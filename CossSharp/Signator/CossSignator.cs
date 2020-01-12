using CossSharp.Utils;
using System.Security.Cryptography;
using System.Text;

namespace CossSharp.Signator
{
    public class CossSignator : ICossSignator
    {
        private readonly IBinaryUtil _binaryUtil;

        public CossSignator() : this (new BinaryUtil()) { }

        public CossSignator(IBinaryUtil binaryUtil)
        {
            _binaryUtil = binaryUtil;
        }

        public string SignPayload(string privateKey, string payload)
        {
            var privateKeyBytes = Encoding.ASCII.GetBytes(privateKey);
            var payloadBytes = Encoding.ASCII.GetBytes(payload);
            var sha = new HMACSHA256(privateKeyBytes);
            var signatureBytes = sha.ComputeHash(payloadBytes);
            var hexSignature = _binaryUtil.ByteArrayToUpperHex(signatureBytes);

            return hexSignature;
        }
    }
}
