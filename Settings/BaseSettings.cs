using System;
using System.Collections.Generic;

namespace SharpLog.Settings
{
    public class BaseSettings : IDisposable
    {
        public BaseSettings() : this(
            fomat: "$D$: [$L$]$Cp{ [}s{] }$$Tp{ [}s{] }$ $M$$Ep{\n}$$Sp{\n}$",
            levels: null,
            outputs: null,
            tags: null)
        { }
        
        public BaseSettings(
            string fomat = "$D$: [$L$]$Cp{ [}s{] }$$Tp{ [}s{] }$ $M$$Ep{\nException: }$$Sp{\nStackTrace: }$", 
            LevelContainer levels = null,
            OutputContainer outputs = null,
            Dictionary<string, Tag> tags = null)
        {
            Format = fomat;
            Levels = levels ?? new LevelContainer(
                debug: new Level('?'),
                trace: new Level('&'),
                info: new Level('+'),
                warn: new Level('!'),
                error: new Level('x'),
                fatal: new Level('X'));
            Outputs = outputs ?? new OutputContainer();
            Tags = tags ?? new Dictionary<string, Tag>();
        }
        
        public string Format { get; set; }
        public LevelContainer Levels { get; set; }
        public OutputContainer Outputs { get; set; }
        public Dictionary<string, Tag> Tags { get; set; }

        public void Dispose()
        {
            Outputs?.Dispose();
            if (Tags != null)
            {
                foreach (var tag in Tags.Values)
                {
                    tag.Dispose();
                }
            }
        }
    }
}
