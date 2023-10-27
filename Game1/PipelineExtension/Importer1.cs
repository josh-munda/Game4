using Microsoft.Xna.Framework.Content.Pipeline;

using TiledSharp;

namespace PipelineExtension
{
    [ContentImporter(".tmx", DisplayName = "Importer1.Game1", DefaultProcessor = "Processor1")]
    public class Importer1 : ContentImporter<TmxMap>
    {
        public override TmxMap Import(string filename, ContentImporterContext context)
        {
            TmxMap map = new TmxMap(filename);
            return map;
        }
    }
}