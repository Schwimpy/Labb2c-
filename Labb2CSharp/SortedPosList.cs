using System;
using System.Collections.Generic;

namespace Labb2CSharp
{
    public class SortedPosList
    {
        private string FilePath { get; set; }
        private List<Position> PositionList { get; set; }
        public Position this[int index]
        {
            get
            {
                return PositionList[index];
            }
        }

        public SortedPosList()
        {
            PositionList = new List<Position>();
        }

        public int Count()
        {
            return PositionList.Count;
        }

        public void Add(Position pos)
        {
            for (int i = 0; i < Count(); i++)
            {
                if (PositionList[i].Length() > pos.Length())
                {
                    PositionList.Insert(i, pos);
                    return;
                }
            }
            PositionList.Insert(Count(), pos);
        }

        public bool Remove(Position pos)
        {
            for (int i = 0; i < Count(); i++)
            {
                if (pos.XPosition == PositionList[i].XPosition && pos.YPosition == PositionList[i].YPosition)
                {
                    PositionList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public SortedPosList Clone()
        {
            SortedPosList posList = new SortedPosList();
            foreach (Position position in PositionList)
            {
                posList.Add(position.Clone());
            }
            return posList;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList circleContList = new SortedPosList();
            foreach (Position position in PositionList)
            {
                if (Math.Pow((position.XPosition - centerPos.XPosition), 2) + Math.Pow((position.YPosition - centerPos.YPosition), 2) < Math.Pow(radius, 2))
                {
                    circleContList.Add(position.Clone());
                }
            }
            return circleContList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList sortedPosList = new SortedPosList();
            LoopThroughAndAdd(sp1, sortedPosList);
            LoopThroughAndAdd(sp2, sortedPosList);
            return sortedPosList;
        }

        private static void LoopThroughAndAdd(SortedPosList sp, SortedPosList newSortedPosList)
        {
            foreach (Position position in sp.PositionList)
            {
                newSortedPosList.Add(position.Clone());
            }
        }

        public override string ToString()
        {
            return string.Join(",", PositionList);
        }

        public static SortedPosList operator -(SortedPosList s1, SortedPosList s2)
        {
            for (int i = 0; i < s1.Count(); i++)
            {
                foreach (Position position2 in s2.PositionList)
                {
                    if (s1[i].Equals(position2))
                    {
                        s1.Remove(s1[i]);
                    }
                }
            }
            return s1;
        }

    }
}
