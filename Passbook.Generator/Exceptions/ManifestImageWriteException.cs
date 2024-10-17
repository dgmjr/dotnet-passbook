/*
 * ManifestImageWriteException.cs
 *     Created: 2024-10-17T16:53:06-04:00
 *    Modified: 2024-10-17T16:53:06-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passbook.Generator.Exceptions
{
    public class ManifestImageWriteException(string message, Exception? innerException)
        : Exception(message, innerException)
    {
        public ManifestImageWriteException()
            : this("", default) { }

        public ManifestImageWriteException(string message)
            : this(message, default) { }
    }
}
