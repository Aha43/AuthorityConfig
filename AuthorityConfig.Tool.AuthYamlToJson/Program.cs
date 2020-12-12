using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NodeDeserializers;

namespace AuthorityConfig.Tool.AuthYamlToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            var yamlPath = args[0];

            // Read yaml
            var config = LoadFromYaml(yamlPath);

            // Generate json
            var json = GenerateJson(config);

            // Write json
            Console.Out.Write(json);
        }

        private static string GenerateJson(IdserverConfig conf)
        {
            string json = JsonSerializer.Serialize(conf, new JsonSerializerOptions { 
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            });
            return json;
        }

        private static IdserverConfig LoadFromYaml(string path)
        {
            var deserializer = new DeserializerBuilder()
                 .WithNodeDeserializer(inner => new ValidatingNodeDeserializer(inner), s => s.InsteadOf<ObjectNodeDeserializer>())
                 .Build();

            var yf = File.OpenText(path);
            var idConf = deserializer.Deserialize<IdserverConfig>(yf);

            return idConf;
        }

        public class ValidatingNodeDeserializer : INodeDeserializer
        {
            private readonly INodeDeserializer _nodeDeserializer;

            public ValidatingNodeDeserializer(INodeDeserializer nodeDeserializer)
            {
                _nodeDeserializer = nodeDeserializer;
            }

            public bool Deserialize(IParser parser, Type expectedType, Func<IParser, Type, object> nestedObjectDeserializer, out object value)
            {
                if (!_nodeDeserializer.Deserialize(parser, expectedType, nestedObjectDeserializer, out value))
                    return false;

                var context = new ValidationContext(value, null, null);
                Validator.ValidateObject(value, context, true);
                return true;
            }
        }

    }

}
