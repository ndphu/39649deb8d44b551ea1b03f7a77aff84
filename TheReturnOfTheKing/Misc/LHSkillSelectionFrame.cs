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
    public class LHSkillSelectionFrame : Dialog
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

        Button _btNormalAttack;
        public Button BtNormalAttack
        {
            get { return _btNormalAttack; }
            set { _btNormalAttack = value; }
        }

        Button _btSkillCleaving;
        public Button BtSkillCleaving
        {
            get { return _btSkillCleaving; }
            set { _btSkillCleaving = value; }
        }

        Button _btSkillCritical;
        public Button BtSkillCritical
        {
            get { return _btSkillCritical; }
            set { _btSkillCritical = value; }
        }

        Button _btSkillCurse;
        public Button BtSkillCurse
        {
            get { return _btSkillCurse; }
            set { _btSkillCurse = value; }
        }

        Button _btSkillOverspeed;
        public Button BtSkillOverspeed
        {
            get { return _btSkillOverspeed; }
            set { _btSkillOverspeed = value; }
        }

        Button _btSkillLifeSteal;
        public Button BtSkillLifeSteal
        {
            get { return _btSkillLifeSteal; }
            set { _btSkillLifeSteal = value; }
        }

        Button _btSkillBash;
        public Button BtSkillBash
        {
            get { return _btSkillBash; }
            set { _btSkillBash = value; }
        }

        MotionInfo _motionGoOut;
        public MotionInfo MotionGoOut
        {
            get { return _motionGoOut; }
            set { _motionGoOut = value; }
        }

        MotionInfo _motionGoIn;
        public MotionInfo MotionGoIn
        {
            get { return _motionGoIn; }
            set { _motionGoIn = value; }
        }

        public void GetResources(List<GameObjectManager> _resources)
        {
            _mainFrame = (GameFrame)_resources[0].CreateObject(5);
            _mainFrame.IsVisible = false;

            _btNormalAttack = (Button)_resources[1].CreateObject(15);
            _btNormalAttack.Owner = Character.ListLeftHandSkill[0];
            _btNormalAttack.GetNewIdleTexture(Character.ListLeftHandSkill[0].IdleIcon);
            _btNormalAttack.GetNewClickedTexture(Character.ListLeftHandSkill[0].ClickedIcon);
            _btNormalAttack.Mouse_Click += new Button.OnMouseClickHandler(NormalAttack_MouseClicked);
            _btNormalAttack.Mouse_Hover += new Button.OnMouseHoverHandler(NormalAttack_MouseHover);
            _btNormalAttack.Mouse_Released += new Button.OnMouseReleasedHandler(NormalAttack_MouseRelease);

            _btSkillCleaving = (Button)_resources[1].CreateObject(16);
            _btSkillCleaving.Owner = Character.ListLeftHandSkill[1];
            _btSkillCleaving.GetNewIdleTexture(Character.ListLeftHandSkill[1].IdleIcon);
            _btSkillCleaving.GetNewClickedTexture(Character.ListLeftHandSkill[1].ClickedIcon);
            _btSkillCleaving.Mouse_Click += new Button.OnMouseClickHandler(SkillCleaving_MouseClicked);
            _btSkillCleaving.Mouse_Hover += new Button.OnMouseHoverHandler(SkillCleaving_MouseHover);
            _btSkillCleaving.Mouse_Released += new Button.OnMouseReleasedHandler(SkillCleaving_MouseRelease);

            _btSkillCritical = (Button)_resources[1].CreateObject(17);
            _btSkillCritical.Owner = Character.ListLeftHandSkill[2];
            _btSkillCritical.GetNewIdleTexture(Character.ListLeftHandSkill[2].IdleIcon);
            _btSkillCritical.GetNewClickedTexture(Character.ListLeftHandSkill[2].ClickedIcon);
            _btSkillCritical.Mouse_Click += new Button.OnMouseClickHandler(SkillCritical_MouseClicked);
            _btSkillCritical.Mouse_Hover += new Button.OnMouseHoverHandler(SkillCritical_MouseHover);
            _btSkillCritical.Mouse_Released += new Button.OnMouseReleasedHandler(SkillCritical_MouseRelease);

            _btSkillCurse = (Button)_resources[1].CreateObject(18);
            _btSkillCurse.Owner = Character.ListLeftHandSkill[3];
            _btSkillCurse.GetNewIdleTexture(Character.ListLeftHandSkill[3].IdleIcon);
            _btSkillCurse.GetNewClickedTexture(Character.ListLeftHandSkill[3].ClickedIcon);
            _btSkillCurse.Mouse_Click += new Button.OnMouseClickHandler(SkillCurse_MouseClicked);
            _btSkillCurse.Mouse_Hover += new Button.OnMouseHoverHandler(SkillCurse_MouseHover);
            _btSkillCurse.Mouse_Released += new Button.OnMouseReleasedHandler(SkillCurse_MouseRelease);

            _btSkillOverspeed = (Button)_resources[1].CreateObject(19);
            _btSkillOverspeed.Owner = Character.ListLeftHandSkill[4];
            _btSkillOverspeed.GetNewIdleTexture(Character.ListLeftHandSkill[4].IdleIcon);
            _btSkillOverspeed.GetNewClickedTexture(Character.ListLeftHandSkill[4].ClickedIcon);
            _btSkillOverspeed.Mouse_Click += new Button.OnMouseClickHandler(SkillOverspeed_MouseClicked);
            _btSkillOverspeed.Mouse_Hover += new Button.OnMouseHoverHandler(SkillOverSpeed_MouseHover);
            _btSkillOverspeed.Mouse_Released += new Button.OnMouseReleasedHandler(SkillOverSpeed_MouseRelease);

            _btSkillLifeSteal = (Button)_resources[1].CreateObject(20);
            _btSkillLifeSteal.Owner = Character.ListLeftHandSkill[5];
            _btSkillLifeSteal.GetNewIdleTexture(Character.ListLeftHandSkill[5].IdleIcon);
            _btSkillLifeSteal.GetNewClickedTexture(Character.ListLeftHandSkill[5].ClickedIcon);
            _btSkillLifeSteal.Mouse_Click += new Button.OnMouseClickHandler(SkillLifeSteal_MouseClicked);
            _btSkillLifeSteal.Mouse_Hover += new Button.OnMouseHoverHandler(SkillLifeSteal_MouseHover);
            _btSkillLifeSteal.Mouse_Released += new Button.OnMouseReleasedHandler(SkillLifeSteal_MouseRelease);

            _btSkillBash = (Button)_resources[1].CreateObject(21);
            _btSkillBash.Owner = Character.ListLeftHandSkill[6];
            _btSkillBash.GetNewIdleTexture(Character.ListLeftHandSkill[6].IdleIcon);
            _btSkillBash.GetNewClickedTexture(Character.ListLeftHandSkill[6].ClickedIcon);
            _btSkillBash.Mouse_Click += new Button.OnMouseClickHandler(SkillBash_MouseClicked);
            _btSkillBash.Mouse_Hover += new Button.OnMouseHoverHandler(SkillBash_MouseHover);
            _btSkillBash.Mouse_Released += new Button.OnMouseReleasedHandler(SkillBash_MouseRelease);

            _mainFrame.AddChild(_btNormalAttack);
            _mainFrame.AddChild(_btSkillCleaving);
            _mainFrame.AddChild(_btSkillCritical);
            _mainFrame.AddChild(_btSkillCurse);
            _mainFrame.AddChild(_btSkillOverspeed);
            _mainFrame.AddChild(_btSkillLifeSteal);
            _mainFrame.AddChild(_btSkillBash);
        }

        public void SetCharacter(PlayerCharacter _char)
        {
            _character = _char;
            _character.LhSkillSelectionFrame = this;
        }

        public override void Update(GameTime gameTime)
        {
            if (_mainFrame.Motion != null)
            {
                if (!_mainFrame.Motion.IsStanding)
                {
                    _mainFrame.IsVisible = true;
                    _mainFrame.Motion.Move(new Vector2(_mainFrame.X, _mainFrame.Y));
                    if (_mainFrame.Motion.IsStanding)
                    {
                        Rectangle _testVisible = new Rectangle(0, 0, GlobalVariables.ScreenWidth, GlobalVariables.ScreenHeight);
                        Point _point1 = new Point((int)_mainFrame.X, (int)_mainFrame.Y);
                        Point _point2 = new Point((int)_mainFrame.X + (int)_mainFrame.Width, (int)_mainFrame.Y);
                        Point _point3 = new Point((int)_mainFrame.X, (int)_mainFrame.Y + (int)_mainFrame.Height);
                        Point _point4 = new Point((int)_mainFrame.X + (int)_mainFrame.Width, (int)_mainFrame.Y + (int)_mainFrame.Height);
                        if (_testVisible.Contains(_point1) || _testVisible.Contains(_point2) || _testVisible.Contains(_point3) || _testVisible.Contains(_point4))
                            _mainFrame.IsVisible = true;
                        else
                            _mainFrame.IsVisible = false;
                        _mainFrame.OnMove_Complete(this, null);
                    }
                }
                for (int i = 0; i < _mainFrame.Child.Count; i++)
                {
                    ((Button)_mainFrame.Child[i]).Update(gameTime);
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(_mainFrame._sprite[0].Texture2D[0], new Vector2(_mainFrame.X, _mainFrame.Y), Color.White);
            ((Button)_mainFrame.Child[0]).Draw(gameTime, sb);
            for (int i = 1; i < _mainFrame.Child.Count; i++)
            {
                if (((Skill)((Button)_mainFrame.Child[i]).Owner).Level > 0)
                    ((Button)_mainFrame.Child[i]).Draw(gameTime, sb);
            }

            if (((Skill)BtNormalAttack.Owner).CurrentButton == BtNormalAttack)
                ((Skill)BtNormalAttack.Owner).Draw(gameTime, sb);

            if (((Skill)BtSkillCleaving.Owner).Level > 0 && ((Skill)BtSkillCleaving.Owner).CurrentButton == BtSkillCleaving)
                ((Skill)BtSkillCleaving.Owner).Draw(gameTime, sb);

            if (((Skill)BtSkillCritical.Owner).Level > 0 && ((Skill)BtSkillCritical.Owner).CurrentButton == BtSkillCritical)
                ((Skill)BtSkillCritical.Owner).Draw(gameTime, sb);

            if (((Skill)BtSkillCurse.Owner).Level > 0 && ((Skill)BtSkillCurse.Owner).CurrentButton == BtSkillCurse)
                ((Skill)BtSkillCurse.Owner).Draw(gameTime, sb);

            if (((Skill)BtSkillOverspeed.Owner).Level > 0 && ((Skill)BtSkillOverspeed.Owner).CurrentButton == BtSkillOverspeed)
                ((Skill)BtSkillOverspeed.Owner).Draw(gameTime, sb);

            if (((Skill)BtSkillLifeSteal.Owner).Level > 0 && ((Skill)BtSkillLifeSteal.Owner).CurrentButton == BtSkillLifeSteal)
                ((Skill)BtSkillLifeSteal.Owner).Draw(gameTime, sb);

            if (((Skill)BtSkillBash.Owner).Level > 0 && ((Skill)BtSkillBash.Owner).CurrentButton == BtSkillBash)
                ((Skill)BtSkillBash.Owner).Draw(gameTime, sb);
        }

        public void CreateMotion_GoIn()
        {
            _motionGoIn = new MotionInfo();
            _motionGoIn.FirstDection = "Up";
            _motionGoIn.IsStanding = true;
            _motionGoIn.StandingGround = 449;
            _motionGoIn.Vel = new Vector2(0, 19);
            _motionGoIn.Accel = new Vector2(0, 1.06f);
            _motionGoIn.DecelerationRate = 0.6f;
        }

        public void CreateMotion_GoOut()
        {
            _motionGoOut = new MotionInfo();
            _motionGoOut.FirstDection = "Up";
            _motionGoOut.IsStanding = true;
            _motionGoOut.StandingGround = float.MinValue;
            _motionGoOut.Vel = new Vector2(0, 0);
            _motionGoOut.Accel = new Vector2(0, 1f);
            _motionGoOut.DecelerationRate = 0.6f;
        }

        #region SỰ kiện Click button
        public void NormalAttack_MouseClicked(object sender, EventArgs e)
        {
            ChangeSkill(0);
        }

        public void SkillCleaving_MouseClicked(object sender, EventArgs e)
        {
            ChangeSkill(1);
        }

        public void SkillCritical_MouseClicked(object sender, EventArgs e)
        {
            ChangeSkill(2);
        }

        public void SkillCurse_MouseClicked(object sender, EventArgs e)
        {
            ChangeSkill(3);
        }

        public void SkillOverspeed_MouseClicked(object sender, EventArgs e)
        {
            ChangeSkill(4);
        }

        public void SkillLifeSteal_MouseClicked(object sender, EventArgs e)
        {
            ChangeSkill(5);
        }

        public void SkillBash_MouseClicked(object sender, EventArgs e)
        {
            ChangeSkill(6);
        }
        #endregion

        #region Sự kiện Hover button
        public void NormalAttack_MouseHover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SkillCleaving_MouseHover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SkillCritical_MouseHover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SkillCurse_MouseHover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SkillOverSpeed_MouseHover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SkillLifeSteal_MouseHover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SkillBash_MouseHover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }
        #endregion

        #region Sự kiện Release button
        public void NormalAttack_MouseRelease(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

        public void SkillCleaving_MouseRelease(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

        public void SkillCritical_MouseRelease(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

        public void SkillCurse_MouseRelease(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

        public void SkillOverSpeed_MouseRelease(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

        public void SkillLifeSteal_MouseRelease(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

        public void SkillBash_MouseRelease(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }
        #endregion

        #region Hàm dùng chung
        public void MoveOut()
        {
            CreateMotion_GoOut();
            _mainFrame.Motion = MotionGoOut;
            _mainFrame.Motion.IsStanding = false;
        }

        public void ChangeSkill(int _skillIndex)
        {
            if (_character.ListLeftHandSkill[_skillIndex].Level == 0 && _skillIndex != 0)
                return;
            MoveOut();
            _character.ListLeftHandSkill[_character.LeftHandSkillIndex].Deactive();
            _character.LeftHandSkillIndex = _skillIndex;
            _character.ListLeftHandSkill[_character.LeftHandSkillIndex].Active();
            _character.Healthbar.BtLefthandSkill.Owner = (Skill)_character.ListLeftHandSkill[_character.LeftHandSkillIndex];
            ((Button)_character.Healthbar.BtLefthandSkill).GetNewIdleTexture(((Skill)_character.ListLeftHandSkill[_character.LeftHandSkillIndex]).IdleIcon);
            ((Button)_character.Healthbar.BtLefthandSkill).GetNewClickedTexture(((Skill)_character.ListLeftHandSkill[_character.LeftHandSkillIndex]).ClickedIcon);
        }

        
        public Vector2 GetSkillDetailLocation(Button _button, int _picWid, int _picHei)
        {
            Vector2 _result = new Vector2(_button.X + _button.Width, _button.Y - _picHei - 2);
            return _result;
        }

        public void ShowDetailSkill(Button _button)
        {
            ((Skill)_button.Owner).ToShowDetails = true;
            ((Skill)_button.Owner).CurrentButton = _button;
            Vector2 _location = GetSkillDetailLocation(_button, ((Skill)_button.Owner).LargeIcon.Width, ((Skill)_button.Owner).LargeIcon.Height);
            ((Skill)_button.Owner).X = _location.X;
            ((Skill)_button.Owner).Y = _location.Y;
        }

        public void HideDetailSkill(Button _button)
        {
            ((Skill)_button.Owner).ToShowDetails = false;
            ((Skill)_button.Owner).CurrentButton = null;
        }
        #endregion
    }
}