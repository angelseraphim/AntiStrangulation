using Exiled.API.Interfaces;
using System.ComponentModel;

namespace AntiStrangulation
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = false;
        public bool Debug { get; set; } = false;
        [Description("Should spawn SCP-3114 early in the round? (false to prevent SCP-3114 from spawning at the beginning of the round)")]
        public bool ShouldSpawn { get; set; } = true;
    }
}
