using System;
using System.Collections.Generic;
using System.Text;

namespace PokerBot
{
    public class Card
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }

        public Card(string name, int value, string type)
        {
            Name = name;
            Value = value;
            Type = type;
            if (Type == "heart" || Type == "tile")
            {
                Color = "red";
            }
            else
            {
                Color = "black";
            }
        }

        public override string ToString()
        {
            return Name + ", " + Type;
        }
    }
}
