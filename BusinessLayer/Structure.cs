using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text.Json;

namespace BusinessLayer
{
    public enum StructureType
    {
        GreenHouse,
        Fertiliser,
        Drill
    }

    public class Structure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MapId { get; set; }

        [ForeignKey(nameof(MapId))]
        public Map Map { get; set; }

        [Required]
        public StructureType StructureType { get; set; }
        
        [Required]
        public string CoordinatesJson { get; set; }

        [Required]
        public string SymbolsJson { get; set; }

        [Required]
        public string ColorsJson { get; set; }


        [NotMapped]
        public List<Coordinate> Coordinates
        {
            get => JsonSerializer.Deserialize<List<Coordinate>>(CoordinatesJson) ?? new List<Coordinate>();
            set => CoordinatesJson = JsonSerializer.Serialize(value);
        }

        [NotMapped]
        public List<char> Symbols
        {
            get => JsonSerializer.Deserialize<List<char>>(SymbolsJson) ?? new List<char>();
            set => SymbolsJson = JsonSerializer.Serialize(value);
        }

        [NotMapped]
        public List<Color> Colors
        {
            get => ColorHexes.Select(ColorTranslator.FromHtml).ToList();
            set => ColorHexes = value.Select(ColorTranslator.ToHtml).ToList();
        }

        // Вътрешна колекция от hex string-ове
        [NotMapped]
        private List<string> ColorHexes
        {
            get => JsonSerializer.Deserialize<List<string>>(ColorsJson) ?? new List<string>();
            set => ColorsJson = JsonSerializer.Serialize(value);
        }

        // Конструктор за EF Core
        private Structure() { }

        // Пълен конструктор
        public Structure(Map map, List<char> symbols,StructureType structureType, List<Coordinate> coordinates, List<Color> colors)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));

            Map = map;
            MapId = map.Id;
            StructureType = structureType;
            Symbols = symbols ?? new List<char>();
            Coordinates = coordinates ?? new List<Coordinate>();
            Colors = colors ?? new List<Color>();
        }

    }
}
