using System;
namespace Labb2CSharp
{
    public class Position
    {
        private int xPosition;
        public int XPosition
        {
            get
            {
                return xPosition;
            }
            set
            {
                xPosition = value >= 0 ? value : 0;
            }
        }
        private int yPosition;
        public int YPosition
        {
            get
            {
                return yPosition;
            }
            set
            {
                yPosition = value >= 0 ? value : 0;
            }
        }

        public Position(int xPosition, int yPosition)
        {
            YPosition = yPosition;
            XPosition = xPosition;
        }

        public double Length()
        {
            double length = Math.Sqrt((Math.Pow(XPosition, 2) + Math.Pow(YPosition, 2)));
            return length;
        }

        public bool Equals(Position p)
        {
            return (p.XPosition == XPosition && p.YPosition == YPosition);
        }

        public Position Clone()
        {
            return new Position(XPosition, YPosition);
        }

        public override string ToString()
        {
            return "(" + XPosition + "," + YPosition + ")";
        }

        public static bool operator >(Position p1, Position p2)
        {
            if (p1.Length() > p2.Length())
            {
                return true;
            }
            else if (p1.Length() == p2.Length())
            {
                return p1.XPosition > p2.XPosition;
            }
            return false;
        }

        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length() < p2.Length())
            {
                return true;
            }
            else if (p1.Length() == p2.Length())
            {
                return p1.XPosition < p2.XPosition;
            }
            return false;
        }

        public static Position operator +(Position p1, Position p2)
        {
            return new Position(p1.XPosition + p2.XPosition, p1.YPosition + p2.YPosition);
        }

        public static Position operator -(Position p1, Position p2)
        {
            if (p1 < p2)
            {
                return new Position(p2.XPosition - p1.XPosition, p2.YPosition - p1.YPosition);
            }
            return new Position(p1.XPosition - p2.XPosition, p1.YPosition - p2.YPosition);
        }

        public static double operator %(Position p1, Position p2)
        {
            return Math.Sqrt(Math.Pow(p1.XPosition - p2.XPosition, 2) + Math.Pow(p1.YPosition - p2.YPosition, 2));
        }
    }
}
