/*
 * SHA256HashExtensions.cs
 *     Created: 2024-10-17T17:05:36-04:00
 *    Modified: 2024-10-17T17:05:36-04:00
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
    public static class Sha256HashExtensions
    {
        private static readonly SHA256CryptoServiceProvider Sha256 = new();

        public static byte[] GetSha256HashBytes(this byte[] bytes) => Sha256.ComputeHash(bytes);

        public static string GetSha256HashString(this byte[] bytes) =>
            bytes.GetSha256HashBytes().ToHexString();
    }
}
