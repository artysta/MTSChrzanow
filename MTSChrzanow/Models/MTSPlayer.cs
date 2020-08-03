using System;
using System.Collections.Generic;
using System.Text;

namespace MTSChrzanow.Models
{
    public class MTSPlayer
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public string BirthDate { get; set; }
        public double Height { get; set; }
        public int Weight { get; set; }
        public override string ToString() => $"{ Name }, { Number }, { Position }, { Nationality }, { BirthDate }, { Height } cm, { Weight } kg.";
    }
}
