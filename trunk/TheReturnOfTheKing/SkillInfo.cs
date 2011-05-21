using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class SkillInfo
    {
        int _type;

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        int _x;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        int _y;

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }

    public class SkillLevel
    {
        List<SkillInfo> _listProjectileInSkillInfo;

        public List<SkillInfo> ListSkillInfo
        {
            get { return _listProjectileInSkillInfo; }
            set { _listProjectileInSkillInfo = value; }
        }
    }
}
