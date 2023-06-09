using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipGameFront
{
    public class CreateGame
    {
        public string playerName { get; set; }
        public List<Point> ships { get; set; }
    }

    public class Point
    {
       public int? x { get; set; }
        public int? y { get; set; }

    }

    public class AddPlayerTwo
    {
        public string tableName { get; set; }
        public string playerName { get; set; }
        public List<Point> ships { get; set; }


    }

    public class DestroyShip
    {
        public string tableName { get; set; }

        public string playerName { get; set; }
        public Point ship { get; set; }

    }

    public class SetPlayerTour
    {
    public int playerId { get; set; }
    public string tableName { get; set; }
}
}
