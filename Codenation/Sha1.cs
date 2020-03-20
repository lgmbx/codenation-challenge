using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Codenation {
    class Sha1 {

        public static string ShaConvert(string txt) {

            string text = txt.ToLower();

            SHA1 sha1 = new SHA1Managed();
            byte[] txtToBytes = Encoding.UTF8.GetBytes(text);
            byte [] hashBytes = sha1.ComputeHash(txtToBytes);
            StringBuilder sb = new StringBuilder();

            foreach (var hashByte in hashBytes) {
                sb.AppendFormat("{0:x2}", hashByte);
            }

            var hashString = sb.ToString();
            return hashString;

        }

    }
}
