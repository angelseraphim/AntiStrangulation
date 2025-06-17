using System.ComponentModel;

namespace AntiStrangulation
{
    public class Config
    {
        public bool Debug { get; set; } = false;
        public bool DisableStrangulation { get; set; } = true;
        public bool DisableAutoSpawn { get; set; } = false;
        
        [Description("The minimum amount of players that need to be in a server in order for SCP-3114 to spawn")]
        public int MinimumPlayers { get; set; } = 5;

        [Description("The chance SCP-3114 can spawn (given there are enough players)")]
        public int SpawnChance { get; set; } = 20;
    }
}
