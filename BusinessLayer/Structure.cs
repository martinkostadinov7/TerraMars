using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer
{
    public enum StructureType
    {
        GreenHouse,
        Fertiliser
    }

    public class Structure
    {
        [Key]
        public int Id { get; set; }

        [Range(0, 99)]
        public int X { get; set; }

        [Range(0, 99)]
        public int Y { get; set; }

        [Required]
        public int MapId { get; set; }

        [ForeignKey(nameof(MapId))]
        public Map Map { get; set; }

        [Required]
        public char Symbol { get; set; }

        [Required]
        public StructureType StructureType { get; set; }

        private Structure() { }

        public Structure(int x, int y, Map map, char symbol, StructureType structureType)
        {
            X = x;
            Y = y;
            Map = map;
            MapId = map.Id;
            Symbol = symbol;
            StructureType = structureType;
        }
    }
}
