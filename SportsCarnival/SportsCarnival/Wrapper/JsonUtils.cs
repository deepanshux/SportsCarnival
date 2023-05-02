using System;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using SportsCarnival;
using System.IO;
using Org.BouncyCastle.Utilities.IO;

namespace SportsCarnival
{
    public class JSONSerializer
    {
        public static object? Deserialize(TextReader reader, System.Type objectType)
        {
            var serializer = new JsonSerializer();
            object? deserializedObject = new object();
            try
            {
                deserializedObject = serializer.Deserialize(reader, objectType);
            }
            catch(Exception ex)
            {
                Console.WriteLine("JSON Deserialize Exception " + ex.Message);
            }
            return deserializedObject;
        }

        public static void Serialize(TextWriter writer, System.Type objectType)
        {
            var serializer = new JsonSerializer();
            serializer.Serialize(writer, objectType);
        }
    }

    public class JSONConvert
    {
        private static readonly JsonSerializerSettings _options = new() { NullValueHandling = NullValueHandling.Ignore };

        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented, _options);
        }
    }

}