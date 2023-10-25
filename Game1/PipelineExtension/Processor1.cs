using Microsoft.Xna.Framework.Content.Pipeline;

using TInput = System.String;
using TOutput = System.String;

using TiledSharp;

namespace PipelineExtension
{
    [ContentProcessor(DisplayName = "Processor1 - Game1")]
    internal class Processor1 : ContentProcessor<TmxMap, TmxMap>
    {
        public override TmxMap Process(TmxMap input, ContentProcessorContext context)
        {
            return input;
        }
    }
}
