using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

namespace YugiohDeck.Serialization
{
    class Json
    {
        private static readonly Encoding encoding = Encoding.UTF8;
        private static readonly DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings() { UseSimpleDictionaryFormat = true };
        private static readonly string jsonIndent = " ";
        private readonly string json;
        private Json(string json) => this.json = json;
        public override string ToString() => this.json;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <exception cref="System.Runtime.Serialization.InvalidDataContractException"></exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static Json Serialize<T>(T source, bool indent)
        {
            var serializer = new DataContractJsonSerializer(typeof(T), settings);
            using (var stream = new MemoryStream())
            {
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(stream, encoding, true, indent, jsonIndent))
                {
                    serializer.WriteObject(writer, source);
                    writer.Flush();
                }
                var json = encoding.GetString(stream.ToArray());
                return new Json(json);
            }
        }
        public static T Deserialize<T>(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(T), settings);
            var bytes = encoding.GetBytes(json);
            using (var stream = new MemoryStream(bytes))
            {
                return (T)serializer.ReadObject(stream);
            }
        }
    }
}
