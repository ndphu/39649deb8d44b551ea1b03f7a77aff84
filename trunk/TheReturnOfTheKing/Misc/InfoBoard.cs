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
    public class InfoBoard : Misc
    {
        PlayerCharacter _character;
        public PlayerCharacter Character
        {
            get { return _character; }
            set { _character = value; }
        }

        GameFrame _mainFrame;
        public GameFrame MainFrame
        {
            get { return _mainFrame; }
            set { _mainFrame = value; }
        }

        MotionInfo _motionGoIn;
        public MotionInfo MotionGoIn
        {
            get { return _motionGoIn; }
            set { _motionGoIn = value; }
        }

        MotionInfo _motionGoOut;
        public MotionInfo MotionGoOut
        {
            get { return _motionGoOut; }
            set { _motionGoOut = value; }
        }

        Button _exit;

        Color _color1 = new Color(255, 242, 0);
        Color _color2 = new Color(181, 230, 29);
        Color _color3 = new Color(255, 128, 0);

        Label _lbLevel;
        Label _lbEXP;
        Label _lbNextLevel;

        Label _lbCurrentHP;
        Label _lbMaxHp;

        Label _lbCurrentMP;
        Label _lbMaxMP;

        Label _lbMinDamage;
        Label _lbMaxDamage;
        Label _lbCritRate;

        Label _lbDefence;
        Label _lbDodge;

        Label _lbMS;

        Label _lbHealing;
        Label _lbMana;
        Label _lbStore;

        public void GetResources(List<GameObjectManager> _resources)
        {
            _mainFrame = (GameFrame)_resources[0].CreateObject(11);
            _mainFrame.IsVisible = false;

            _exit = (Button)_resources[1].CreateObject(11);
            _exit.Mouse_Click += new Button.OnMouseClickHandler(Exit_Click);
            _exit.OffSetX = 207;
            _exit.OffSetY = 453;
            _mainFrame.AddChild(_exit);

            _lbLevel = (Label)_resources[2].CreateObject(19);
            _lbLevel.StringColor = _color1;
            _mainFrame.AddChild(_lbLevel);

            _lbEXP = (Label)_resources[2].CreateObject(20);
            _lbEXP.StringColor = _color1;
            _mainFrame.AddChild(_lbEXP);

            _lbNextLevel = (Label)_resources[2].CreateObject(21);
            _lbNextLevel.StringColor = _color1;
            _mainFrame.AddChild(_lbNextLevel);

            _lbCurrentHP = (Label)_resources[2].CreateObject(22);
            _lbCurrentHP.StringColor = _color2;
            _mainFrame.AddChild(_lbCurrentHP);

            _lbMaxHp = (Label)_resources[2].CreateObject(23);
            _lbMaxHp.StringColor = _color2;
            _mainFrame.AddChild(_lbMaxHp);

            _lbCurrentMP = (Label)_resources[2].CreateObject(24);
            _lbCurrentMP.StringColor = _color2;
            _mainFrame.AddChild(_lbCurrentMP);

            _lbMaxMP = (Label)_resources[2].CreateObject(25);
            _lbMaxMP.StringColor = _color2;
            _mainFrame.AddChild(_lbMaxMP);

            _lbMinDamage = (Label)_resources[2].CreateObject(26);
            _lbMinDamage.StringColor = _color2;
            _mainFrame.AddChild(_lbMinDamage);

            _lbMaxDamage = (Label)_resources[2].CreateObject(27);
            _lbMaxDamage.StringColor = _color2;
            _mainFrame.AddChild(_lbMaxDamage);

            _lbCritRate = (Label)_resources[2].CreateObject(28);
            _lbCritRate.StringColor = _color2;
            _mainFrame.AddChild(_lbCritRate);

            _lbDefence = (Label)_resources[2].CreateObject(29);
            _lbDefence.StringColor = _color2;
            _mainFrame.AddChild(_lbDefence);

            _lbDodge = (Label)_resources[2].CreateObject(30);
            _lbDodge.StringColor = _color2;
            _mainFrame.AddChild(_lbDodge);

            _lbMS = (Label)_resources[2].CreateObject(31);
            _lbMS.StringColor = _color2;
            _mainFrame.AddChild(_lbMS);

            _lbHealing = (Label)_resources[2].CreateObject(32);
            _lbHealing.StringColor = _color3;
            _mainFrame.AddChild(_lbHealing);

            _lbMana = (Label)_resources[2].CreateObject(33);
            _lbMana.StringColor = _color3;
            _mainFrame.AddChild(_lbMana);

            _lbStore = (Label)_resources[2].CreateObject(34);
            _lbStore.StringColor = _color3;
            _mainFrame.AddChild(_lbStore);
        }

        public void SetCharacter(PlayerCharacter _char)
        {
            _character = _char;
            _char.Infoboard = this;
        }

        public override void Update(GameTime gameTime)
        {
            _mainFrame.Update(gameTime);

            _lbLevel.StringInfo = _character.Level.ToString();
            _lbLevel.UpdateOffset();
            _lbEXP.StringInfo = _character.CurrentEXP.ToString();
            _lbEXP.UpdateOffset();
            _lbNextLevel.StringInfo = _character.NextLevelEXP.ToString();
            _lbNextLevel.UpdateOffset();

            //Hp
            if (_character.Hp >= 0)
                _lbCurrentHP.StringInfo = _character.Hp.ToString();
            else
                _lbCurrentHP.StringInfo = (0).ToString();
            _lbCurrentHP.UpdateOffset();

            _lbMaxHp.StringInfo = _character.MaxHp.ToString();
            _lbMaxHp.UpdateOffset();

            //Mp
            if (_character.Mp >= 0)
                _lbCurrentMP.StringInfo = _character.Mp.ToString();
            else
                _lbCurrentMP.StringInfo = (0).ToString();
            _lbCurrentMP.UpdateOffset();

            _lbMaxMP.StringInfo = _character.MaxMp.ToString();
            _lbMaxMP.UpdateOffset();

            //damage
            _lbMinDamage.StringInfo = _character.MinDamage.ToString();
            _lbMinDamage.UpdateOffset();
            _lbMaxDamage.StringInfo = _character.MaxDamage.ToString();
            _lbMaxDamage.UpdateOffset();
            _lbCritRate.StringInfo = _character.CriticalRate.ToString() + "%";
            _lbCritRate.UpdateOffset();

            //kháng đòn
            _lbDefence.StringInfo = _character.Defense.ToString();
            _lbDefence.UpdateOffset();
            _lbDodge.StringInfo = _character.ChangeToDodge.ToString() + "%";
            _lbDodge.UpdateOffset();

            //move speed
            _lbMS.StringInfo = _character.Speed.ToString() + " MS";
            _lbMS.UpdateOffset();

            //portion
            _lbHealing.StringInfo = _character.HPPortion.Count.ToString();
            _lbHealing.UpdateOffset();

            _lbMana.StringInfo = _character.MPPortion.Count.ToString();
            _lbMana.UpdateOffset();

            _lbStore.StringInfo = _character.RestorePortion.Count.ToString();
            _lbStore.UpdateOffset();

            if (_mainFrame.Rect.Contains(GlobalVariables.CurrentMouseState.X, GlobalVariables.CurrentMouseState.Y))
            {
                GlobalVariables.AlreadyUseLeftMouse = true;
                GlobalVariables.AlreadyUseRightMouse = true;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(_mainFrame._sprite[0].Texture2D[0], new Vector2(_mainFrame.X, _mainFrame.Y), Color.White);
            for (int i = 0; i < _mainFrame.Child.Count; i++)
            {
                _mainFrame.Child[i].Draw(gameTime, sb);
            }
        }

        //Su kien button exit
        public void Exit_Click(object sender, EventArgs e)
        {
            CreateMotion_GoOut();
            _mainFrame.Motion = _motionGoOut;
            _mainFrame.Motion.IsStanding = false;
        }

        //Mot so ham tao khác
        public void CreateMotion_GoIn()
        {
            _motionGoIn = new MotionInfo();
            _motionGoIn.FirstDection = "Right";
            _motionGoIn.IsStanding = true;
            _motionGoIn.StandingGround = 0;
            _motionGoIn.Vel = new Vector2(31, 0);
            _motionGoIn.Accel = new Vector2(1.055f, 0);
            _motionGoIn.DecelerationRate = 0.6f;
        }

        public void CreateMotion_GoOut()
        {
            _motionGoOut = new MotionInfo();
            _motionGoOut.FirstDection = "Right";
            _motionGoOut.IsStanding = true;
            _motionGoOut.StandingGround = float.MinValue;
            _motionGoOut.Vel = new Vector2(0, 0);
            _motionGoOut.Accel = new Vector2(1.8f, 0);
            _motionGoOut.DecelerationRate = 0.6f;
        }

        //Ham dung chung
    }
}
