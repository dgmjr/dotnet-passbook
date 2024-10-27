/*
 * StringExtensions.cs
 *     Created: 2024-10-17T17:08:22-04:00
 *    Modified: 2024-10-17T17:08:22-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Passbook.Generator.Extensions;

using System;

public static class StringExtensions
{
    public static string ToHexString(this byte[] bytes) =>
        BitConverter.ToString(bytes).Replace("-", "").ToLower();
}
