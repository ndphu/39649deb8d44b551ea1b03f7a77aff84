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
        /// Tên của skill
        /// </summary>
        string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Player ra chiêu
        /// </summary>
        PlayerCharacter _playerOwner;

        public PlayerCharacter PlayerOwner
        {
            get { return _playerOwner; }
            set { _playerOwner = value; }
        }

        bool _isEffected;

        public bool IsEffected
        {
            get { return _isEffected; }
            set { _isEffected = value; }
        }
        /// <summary>
        /// Hinh anh dai dien cho skill (64x64)
        /// </summary>
        Texture2D _clickedIcon;

        public Texture2D ClickedIcon
        {
            get { return _clickedIcon; }
            set { _clickedIcon = value; }
        }

        /// <summary>
        /// Hinh anh dai dien cho skill (48x48)
        /// </summary>
        Texture2D _idleIcon;

        public Texture2D IdleIcon
        {
            get { return _idleIcon; }
            set { _idleIcon = value; }
        }
        /// <summary>
        /// Hinh anh dai dien cho skill (32x32)
        /// </summary>
        Texture2D _largeIcon;

        public Texture2D LargeIcon
        {
            get { return _largeIcon; }
            set { _largeIcon = value; }
        }

        int _level = 0;

        public int Level
        {
            get { return _level; }
            set 
            { 
                _level = value;
                if (value > 0)
                    Active();
            }
        }

        List<SkillLevel> _listLevel;

        public List<SkillLevel> ListLevel
        {
            get { return _listLevel; }
            set { _listLevel = value; }
        }

        bool _toShowDetails = false;

        public bool ToShowDetails
        {
            get { return _toShowDetails; }
            set { _toShowDetails = value; }
        }

        public override VisibleGameObject Clone()
        {
            return new Skill
            {
                X = this.X,
                Y = this.Y,
                Level = this.Level,
                ListLevel = this.ListLevel,
                IdleIcon = this.IdleIcon,
                LargeIcon = this.LargeIcon,
            };
        }

        public virtual void DoEffect(VisibleGameEntity _object)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            if (_toShowDetails)
            {
                sb.Draw(LargeIcon, new Vector2(X, Y), Color.White);
            }
        }

        public virtual void DoAdditionalEffect(VisibleGameEntity target)
        {
            
        }

        public virtual void Active()
        {
        }
        public virtual void Deactive()
        { 
        }
    }
}
