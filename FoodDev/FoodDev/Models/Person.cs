using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace FoodDev.Models
{
    public partial class Person
    {
        /// <summary>
        /// Using collection => Array
        /// </summary>
        
        [JsonProperty("Nr Klant")]
        public long NrKlant { get; set; }

        [JsonProperty("Contact")]
        public Contact Contact { get; set; }

        [JsonProperty("Onderneming")]
        public string Onderneming { get; set; }

        [JsonProperty("Adres")]
        public string Adres { get; set; }

        [JsonProperty("PC")]
        public Contact Pc { get; set; }

        [JsonProperty("Stad")]
        public string Stad { get; set; }

        [JsonProperty("Nr BTW")]
        public string NrBtw { get; set; }

        [JsonProperty("Tel")]
        public TelUnion Tel { get; set; }

        [JsonProperty("GSM")]
        public GsmUnion Gsm { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }
    }

    public enum GsmEnum { Anonymous, Empty, The491604E11 };

    public enum TelEnum { Anonymous, Empty, The421902E11, The440789E12 };

    public partial struct Contact
    {
        public long? Integer;
        public string String;

        public static implicit operator Contact(long Integer) => new Contact { Integer = Integer };
        public static implicit operator Contact(string String) => new Contact { String = String };
    }

    public partial struct GsmUnion
    {
        public GsmEnum? Enum;
        public long? Integer;

        public static implicit operator GsmUnion(GsmEnum Enum) => new GsmUnion { Enum = Enum };
        public static implicit operator GsmUnion(long Integer) => new GsmUnion { Integer = Integer };
    }

    public partial struct TelUnion
    {
        public TelEnum? Enum;
        public long? Integer;

        public static implicit operator TelUnion(TelEnum Enum) => new TelUnion { Enum = Enum };
        public static implicit operator TelUnion(long Integer) => new TelUnion { Integer = Integer };
    }

    public partial class Clients
    {
        public static Clients[] FromJson(string json) => JsonConvert.DeserializeObject<Clients[]>(json, FoodDev.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Clients[] self) => JsonConvert.SerializeObject(self, FoodDev.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ContactConverter.Singleton,
                GsmUnionConverter.Singleton,
                GsmEnumConverter.Singleton,
                TelUnionConverter.Singleton,
                TelEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ContactConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Contact) || t == typeof(Contact?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new Contact { Integer = integerValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Contact { String = stringValue };
            }
            throw new Exception("Cannot unmarshal type Contact");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Contact)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            throw new Exception("Cannot marshal type Contact");
        }

        public static readonly ContactConverter Singleton = new ContactConverter();
    }

    internal class GsmUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GsmUnion) || t == typeof(GsmUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new GsmUnion { Integer = integerValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "":
                            return new GsmUnion { Enum = GsmEnum.Empty };
                        case "4,91604E+11":
                            return new GsmUnion { Enum = GsmEnum.The491604E11 };
                        case "Anonymous":
                            return new GsmUnion { Enum = GsmEnum.Anonymous };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type GsmUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (GsmUnion)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.Enum != null)
            {
                switch (value.Enum)
                {
                    case GsmEnum.Empty:
                        serializer.Serialize(writer, "");
                        return;
                    case GsmEnum.The491604E11:
                        serializer.Serialize(writer, "4,91604E+11");
                        return;
                    case GsmEnum.Anonymous:
                        serializer.Serialize(writer, "Anonymous");
                        return;
                }
            }
            throw new Exception("Cannot marshal type GsmUnion");
        }

        public static readonly GsmUnionConverter Singleton = new GsmUnionConverter();
    }

    internal class GsmEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GsmEnum) || t == typeof(GsmEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return GsmEnum.Empty;
                case "4,91604E+11":
                    return GsmEnum.The491604E11;
                case "Anonymous":
                    return GsmEnum.Anonymous;
            }
            throw new Exception("Cannot unmarshal type GsmEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (GsmEnum)untypedValue;
            switch (value)
            {
                case GsmEnum.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case GsmEnum.The491604E11:
                    serializer.Serialize(writer, "4,91604E+11");
                    return;
                case GsmEnum.Anonymous:
                    serializer.Serialize(writer, "Anonymous");
                    return;
            }
            throw new Exception("Cannot marshal type GsmEnum");
        }

        public static readonly GsmEnumConverter Singleton = new GsmEnumConverter();
    }

    internal class TelUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TelUnion) || t == typeof(TelUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new TelUnion { Integer = integerValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "":
                            return new TelUnion { Enum = TelEnum.Empty };
                        case "4,21902E+11":
                            return new TelUnion { Enum = TelEnum.The421902E11 };
                        case "4,40789E+12":
                            return new TelUnion { Enum = TelEnum.The440789E12 };
                        case "Anonymous":
                            return new TelUnion { Enum = TelEnum.Anonymous };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type TelUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (TelUnion)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.Enum != null)
            {
                switch (value.Enum)
                {
                    case TelEnum.Empty:
                        serializer.Serialize(writer, "");
                        return;
                    case TelEnum.The421902E11:
                        serializer.Serialize(writer, "4,21902E+11");
                        return;
                    case TelEnum.The440789E12:
                        serializer.Serialize(writer, "4,40789E+12");
                        return;
                    case TelEnum.Anonymous:
                        serializer.Serialize(writer, "Anonymous");
                        return;
                }
            }
            throw new Exception("Cannot marshal type TelUnion");
        }

        public static readonly TelUnionConverter Singleton = new TelUnionConverter();
    }

    internal class TelEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TelEnum) || t == typeof(TelEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return TelEnum.Empty;
                case "4,21902E+11":
                    return TelEnum.The421902E11;
                case "4,40789E+12":
                    return TelEnum.The440789E12;
                case "Anonymous":
                    return TelEnum.Anonymous;
            }
            throw new Exception("Cannot unmarshal type TelEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TelEnum)untypedValue;
            switch (value)
            {
                case TelEnum.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case TelEnum.The421902E11:
                    serializer.Serialize(writer, "4,21902E+11");
                    return;
                case TelEnum.The440789E12:
                    serializer.Serialize(writer, "4,40789E+12");
                    return;
                case TelEnum.Anonymous:
                    serializer.Serialize(writer, "Anonymous");
                    return;
            }
            throw new Exception("Cannot marshal type TelEnum");
        }

        public static readonly TelEnumConverter Singleton = new TelEnumConverter();
    }
}
