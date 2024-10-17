/*
 * Field{OfT}.cs
 *     Created: 2024-10-17T20:18:50-04:00
 *    Modified: 2024-10-17T20:18:50-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

using System;

using Newtonsoft.Json;

namespace Passbook.Generator.Fields;

public abstract class Field<T>(
    string? key,
    string? label,
    string? changeMessage,
    FieldTextAlignment textAlignment,
    T? value
) : Field(key, label, changeMessage, textAlignment)
{
    protected Field()
        : this(default, default, default, default, default) { }

    protected Field(string? key, string? label)
        : this(key, label, default, default, default) { }

    public virtual T? Value { get; set; } = value;

    public override bool HasValue => !Value?.Equals(default) ?? false;

    public override void SetValue(object value) => Value = (T?)value;
}
