using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace TheReturnOfTheKing
{
    public class Skill : VisibleGameEntity
    {
        /// <summary>
        /// Hinh anh dai dien cho skill
        /// </summary>
        Texture2D _skillIcon;

        public Texture2D SkillIcon
        {
            get { return _skillIcon; }
            set { _skillIcon = value; }
        }

        int _level = 0;

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        List<SkillLevel> _listLevel;

        public List<SkillLevel> ListLevel
        {
            get { return _listLevel; }
            set { _listLevel = value; }
        }

        public override VisibleGameObject Clone()
        {
            return new Skill
            {
                X = this.X,
                Y = this.Y,
                Level = this.Level,
                ListLevel = this.ListLevel,
                SkillIcon = this.SkillIcon,
            };
        }

    }
}
