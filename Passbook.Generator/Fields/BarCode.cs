using Newtonsoft.Json;

namespace Passbook.Generator.Fields
{
    public class Barcode(BarcodeType type, string? message, string? encoding, string? alternateText)
    {
        public Barcode(BarcodeType type, string? message, string? encoding)
            : this(type, message, encoding, default) { }

        /// <summary>
        /// Required. Barcode format
        /// </summary>
        public BarcodeType Type { get; set; } = type;

        /// <summary>
        /// Required. Message or payload to be displayed as a barcode.
        /// </summary>
        public string? Message { get; set; } = message;

        /// <summary>
        /// Required. Text encoding that is used to convert the message from the string representation to a data representation to render the barcode. The value is typically iso-8859-1, but you may use another encoding that is supported by your barcode scanning infrastructure.
        /// </summary>
        public string? Encoding { get; set; } = encoding;

        /// <summary>
        /// Optional. Text displayed near the barcode. For example, a human-readable version of the barcode data in case the barcode doesn’t scan.
        /// </summary>
        public string? AlternateText { get; set; } = alternateText;

        public void Write(JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("format");
            writer.WriteValue(Type.ToString());
            writer.WritePropertyName("message");
            writer.WriteValue(Message);
            writer.WritePropertyName("messageEncoding");
            writer.WriteValue(Encoding);

            if (!string.IsNullOrEmpty(AlternateText))
            {
                writer.WritePropertyName("altText");
                writer.WriteValue(AlternateText);
            }

            writer.WriteEndObject();
        }
    }
}
