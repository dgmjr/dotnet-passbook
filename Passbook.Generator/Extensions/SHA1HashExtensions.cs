/*
 * SHA1HashExtensions copy.cs
 *     Created: 2024-10-17T17:19:08-04:00
 *    Modified: 2024-10-17T17:19:08-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Passbook.Generator.Extensions
{
    public static class Sha1HashExtensions
    {
        private static readonly HashAlgorithm Sha1 = SHA1.Create();

        public static byte[] GetSha1HashBytes(this byte[] bytes) => Sha1.ComputeHash(bytes);

        public static string GetSha1HashString(this byte[] bytes) =>
            bytes.GetSha1HashBytes().ToHexString();
    }
}
