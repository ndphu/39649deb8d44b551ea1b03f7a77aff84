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
    public class HealthBar : Dialog
    {
        HealthBarMainFrame _mainFrame;

        public HealthBarMainFrame MainFrame
        {
            get { return _mainFrame; }
            set { _mainFrame = value; }
        }

        ProcessBar _bloodProcessbar;

        public ProcessBar BloodProcessbar
        {
            get { return _bloodProcessbar; }
            set { _bloodProcessbar = value; }
        }

        ProcessBar _manaProcessbar;

        public ProcessBar ManaProcessbar
        {
            get { return _manaProcessbar; }
            set { _manaProcessbar = value; }
        }

        LeftSkillButton _leftSkillButon;

        public LeftSkillButton LeftSkillButon
        {
            get { return _leftSkillButon; }
            set { _leftSkillButon = value; }
        }

        RightSkillButton _rightSkillButton;

        public RightSkillButton RightSkillButton
        {
            get { return _rightSkillButton; }
            set { _rightSkillButton = value; }
        }

        LeftCommandButton _leftCommandButton;

        public LeftCommandButton LeftCommandButton
        {
            get { return _leftCommandButton; }
            set { _leftCommandButton = value; }
        }

        RightCommandButton _rightCommandButton;

        public RightCommandButton RightCommandButton
        {
            get { return _rightCommandButton; }
            set { _rightCommandButton = value; }
        }

        public override float X
        {
            get
            {
                return base.X;
            }
            set
            {
                base.X = value;
                for (int i = 0; i < _nsprite; ++i)
                    _sprite[i].X = value;
            }
        }

        public override float Y
        {
            get
            {
                return base.Y;
            }
            set
            {
                base.Y = value;
                for (int i = 0; i < _nsprite; ++i)
                    _sprite[i].Y = value;
            }
        }

        public HealthBar (HealthBar _toCopy)
        {
            X = _toCopy.X;
            Y = _toCopy.Y;
            Width = _toCopy.Width;
            Height = _toCopy.Height;

            //_frogOwner = _toCopy._frogOwner;
            _owner = (Frog)_toCopy._owner;

            _mainFrame = _toCopy._mainFrame;
            _mainFrame.X += X;
            _mainFrame.Y += Y;

            //2 cai processbar ko xai owner..
            _bloodProcessbar = _toCopy._bloodProcessbar;
            _bloodProcessbar.X += X;
            _bloodProcessbar.Y += Y;

            _manaProcessbar = _toCopy._manaProcessbar;
            _manaProcessbar.X += X;
            _manaProcessbar.Y += Y;

            _leftSkillButon = _toCopy._leftSkillButon;
            _rightSkillButton = _toCopy.RightSkillButton;

            _leftCommandButton = _toCopy._leftCommandButton;
            _rightCommandButton = _toCopy._rightCommandButton;
        }

        public HealthBar()
        {
 
        }

        //Clone này chẳng qua la lấy thông tin của cái healthbar chứ ko dính dáng gì tới các thành phần bên trong
        public override VisibleGameObject Clone()
        {
            //Health bar hien tai chi là một vùng có độ lớn nhất định chứ không chứa bất kì một sprite nào.
            HealthBar _newHealthBar = new HealthBar ();
            _newHealthBar.Width = this.Width;
            _newHealthBar.Height = this.Height;
            _newHealthBar.Rect = this.Rect;
            _newHealthBar.X = this.X;
            _newHealthBar.Y = this.Y;
            return _newHealthBar;
        }

        public override void Update(GameTime gameTime)
        {
            _mainFrame.Update(gameTime);
            _leftSkillButon.Update(gameTime);
            _rightSkillButton.Update(gameTime);
            _leftCommandButton.Update(gameTime);
            _rightCommandButton.Update(gameTime);
            float _rateToDrawBlood = (float)((Frog)_owner).Character.Hp / (float)((Frog)_owner).Character.MaxHp;
            _bloodProcessbar.UpdateDrawRect(_rateToDrawBlood);

            float _rateToDrawMana = (float)((Frog)_owner).Character.Mp / (float)((Frog)_owner).Character.MaxMp;
            _manaProcessbar.UpdateDrawRect(_rateToDrawMana);
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _leftSkillButon.Draw(gameTime, sb);
            _rightSkillButton.Draw(gameTime, sb);
            _leftCommandButton.Draw(gameTime, sb);
            _rightCommandButton.Draw(gameTime, sb);
            _mainFrame.Draw(gameTime, sb);
            _bloodProcessbar.Draw(gameTime, sb);
            _manaProcessbar.Draw(gameTime, sb);
        }
    }
}