using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Newtonsoft.Json;
using OSTicketAPI.NET.DTO;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace OSTicketAPI.NET.Helpers
{
    public class TicketCreationOptionsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var options = (TicketCreationOptions)value;
            var nonIgnoredProperties = options.GetType().GetProperties()
                .Where(o => !o.IsDefined(typeof(JsonIgnoreAttribute), false)).ToList();
            var jsonPropertyInfos = options.GetType().GetProperties()
                .Where(o => o.IsDefined(typeof(JsonPropertyAttribute), false)).ToList();

            writer.WriteStartObject();
            foreach (var prop in nonIgnoredProperties)
            {
                var propName = prop.Name.ToCamelCase();
                var propValue = prop.GetValue(options);

                if (jsonPropertyInfos.Contains(prop))
                {
                    var customName =
                        prop.CustomAttributes.FirstOrDefault(o => o.AttributeType == typeof(JsonPropertyAttribute))?.NamedArguments?.FirstOrDefault(o => o.MemberName == "PropertyName").TypedValue.Value.ToString();
                    if (customName != null)
                        propName = customName;
                }

                writer.WritePropertyName(propName);
                writer.WriteValue(propValue);
            }

            foreach (var custom in options.CustomProperties)
            {
                writer.WritePropertyName(custom.Key);
                writer.WriteValue(custom.Value);
            }
            writer.WriteEndObject();
        }

        [SuppressMessage("NotRequired", "RCS1079")]
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        [SuppressMessage("NotRequired", "RCS1079")]
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
