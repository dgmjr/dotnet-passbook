using System;
using System.Globalization;

namespace Passbook.Generator.Fields
{
    public class DateField(
        string? key,
        string? label,
        FieldDateTimeStyle dateStyle,
        FieldDateTimeStyle timeStyle,
        DateTime value
    ) : Field<DateTime>(key, label)
    {
        public DateField()
            : this(default, default, default, default, default) { }

        public DateField(
            string key,
            string label,
            FieldDateTimeStyle dateStyle,
            FieldDateTimeStyle timeStyle
        )
            : this(key, label, dateStyle, timeStyle, default) { }

        public override DateTime Value { get; set; } = value;

        /// <summary>
        /// Style of date to display, must be a <see cref="FieldDateTimeStyle" />
        /// </summary>
        public FieldDateTimeStyle DateStyle { get; set; } = dateStyle;

        /// <summary>
        /// Style of time to display, must be a <see cref="FieldDateTimeStyle" />
        /// </summary>
        public FieldDateTimeStyle TimeStyle { get; set; } = timeStyle;

        /// <summary>
        /// <para>Optional. If true, the label's value is displayed as a relative date; otherwise, it is displayed as an absolute date. The default value is false.</para>
        /// <para>This does not affect how relevance is calculated.</para>
        /// </summary>
        public bool? IsRelative { get; set; }

        /// <summary>
        /// <para>Optional. Always display the time and date in the given time zone, not in the user's current time zone. The default value is false.</para>
        /// <para>The format for a date and time always requires a time zone, even if it will be ignored. For backward compatibility with iOS 6, provide an appropriate time zone, so that the information is displayed meaningfully even without ignoring time zones.</para>
        /// <para>This key does not affect how relevance is calculated.</para>
        /// <para>Available in iOS 7.0.</para>
        /// </summary>
        public bool? IgnoresTimeZone { get; set; }

        protected override void WriteKeys(Newtonsoft.Json.JsonWriter writer)
        {
            if (DateStyle != FieldDateTimeStyle.Unspecified)
            {
                writer.WritePropertyName("dateStyle");
                writer.WriteValue(DateStyle.ToString());
            }

            if (TimeStyle != FieldDateTimeStyle.Unspecified)
            {
                writer.WritePropertyName("timeStyle");
                writer.WriteValue(TimeStyle.ToString());
            }

            if (IsRelative.HasValue)
            {
                writer.WritePropertyName("isRelative");
                writer.WriteValue(IsRelative.Value);
            }

            if (IgnoresTimeZone.HasValue)
            {
                writer.WritePropertyName("ignoresTimeZone");
                writer.WriteValue(IgnoresTimeZone.Value);
            }
        }

        protected override void WriteValue(Newtonsoft.Json.JsonWriter writer)
        {
            if (Value.Kind == DateTimeKind.Utc || Value.Kind == DateTimeKind.Unspecified)
            {
                writer.WriteValue(Value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            }
            else
            {
                var localDate = new DateTime(
                    Value.Year,
                    Value.Month,
                    Value.Day,
                    Value.Hour,
                    Value.Minute,
                    Value.Second,
                    Value.Kind
                );
                var utcDate = new DateTime(
                    Value.Year,
                    Value.Month,
                    Value.Day,
                    Value.Hour,
                    Value.Minute,
                    Value.Second,
                    Value.Kind
                );
                var diff = utcDate - localDate.ToUniversalTime();

                string outputText = localDate.ToString(
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture
                );
                if (diff < TimeSpan.Zero)
                {
                    outputText = string.Format(
                        "{0}-{1:00}:{2:00}",
                        outputText,
                        Math.Abs(diff.Hours),
                        diff.Minutes
                    );
                }
                else
                {
                    outputText = string.Format(
                        "{0}+{1:00}:{2:00}",
                        outputText,
                        Math.Abs(diff.Hours),
                        diff.Minutes
                    );
                }

                writer.WriteValue(outputText);
            }
        }

        public override void SetValue(object value)
        {
            Value = (DateTime)value;
        }

        public override bool HasValue
        {
            get { return true; }
        }
    }
}
