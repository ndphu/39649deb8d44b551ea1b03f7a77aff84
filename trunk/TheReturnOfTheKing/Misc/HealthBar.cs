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
        PlayerCharacter _character;
        public PlayerCharacter Character
        {
            get { return _character; }
            set { _character = value; }
        }

        GameFrame _healbarFrame;
        public GameFrame HealbarFrame
        {
            get { return _healbarFrame; }
            set { _healbarFrame = value; }
        }

        ProcessBar _bloodPro;
        public ProcessBar BloodPro
        {
            get { return _bloodPro; }
            set { _bloodPro = value; }
        }

        ProcessBar _manaPro;
        public ProcessBar ManaPro
        {
            get { return _manaPro; }
            set { _manaPro = value; }
        }

        Button _btLeftCommand;
        public Button BtLeftCommand
        {
            get { return _btLeftCommand; }
            set { _btLeftCommand = value; }
        }

        Button _btRightCommand;
        public Button BtRightCommand
        {
            get { return _btRightCommand; }
            set { _btRightCommand = value; }
        }

        Button _btLefthandSkill;
        public Button BtLefthandSkill
        {
            get { return _btLefthandSkill; }
            set { _btLefthandSkill = value; }
        }

        Button _btRighthandSkill;
        public Button BtRighthandSkill
        {
            get { return _btRighthandSkill; }
            set { _btRighthandSkill = value; }
        }

        ProcessBar _coolDownRightSkill;
        public ProcessBar CoolDownRightSkill
        {
            get { return _coolDownRightSkill; }
            set { _coolDownRightSkill = value; }
        }

        ProcessBar _coolDownLeftSkill;
        public ProcessBar CoolDownLeftSkill
        {
            get { return _coolDownLeftSkill; }
            set { _coolDownLeftSkill = value; }
        }

        //Button main Frame
        Button _btCMUpButton;
        public Button BtCMUpButton
        {
            get { return _btCMUpButton; }
            set { _btCMUpButton = value; }
        }

        //level process
        ProcessBar _levelProcess;

        public ProcessBar LevelProcess
        {
            get { return _levelProcess; }
            set { _levelProcess = value; }
        }

        GameFrame _itemFrame;

        public GameFrame ItemFrame
        {
            get { return _itemFrame; }
            set { _itemFrame = value; }
        }

        Button _btBlood;

        public Button BtBlood
        {
            get { return _btBlood; }
            set { _btBlood = value; }
        }

        Label _lbBlood;

        public Label LbBlood
        {
            get { return _lbBlood; }
            set { _lbBlood = value; }
        }

        Button _btMana;

        public Button BtMana
        {
            get { return _btMana; }
            set { _btMana = value; }
        }

        Label _lbMana;

        public Label LbMana
        {
            get { return _lbMana; }
            set { _lbMana = value; }
        }

        Button _btBloodNMana;

        public Button BtBloodNMana
        {
            get { return _btBloodNMana; }
            set { _btBloodNMana = value; }
        }

        Label _lbBloodNMana;

        public Label LbBloodNMana
        {
            get { return _lbBloodNMana; }
            set { _lbBloodNMana = value; }
        }
//------------------
        public void SetCharacter(PlayerCharacter _char)
        {
            _character = _char;
            _char.Healthbar = this;
        }

        public void GetResources(List<GameObjectManager> _resouces)
        {
            HealbarFrame = (GameFrame)_resouces[0].CreateObject(0);
            BloodPro = (ProcessBar)_resouces[1].CreateObject(0);
            ManaPro = (ProcessBar)_resouces[1].CreateObject(1);

            //Button left
            _btLeftCommand = (Button)_resouces[2].CreateObject(0);
            _btLeftCommand.Mouse_Click += new Button.OnMouseClickHandler(LeftCommandButon_Clicked);
            HealbarFrame.AddChild(_btLeftCommand);

            _btRightCommand = (Button)_resouces[2].CreateObject(1);
            _btRightCommand.Mouse_Click += new Button.OnMouseClickHandler(RightCommandButon_Clicked);
            HealbarFrame.AddChild(_btRightCommand);

            _btLefthandSkill = (Button)_resouces[2].CreateObject(14);
            _btLefthandSkill.Owner = _character.ListLeftHandSkill[0];
            _btLefthandSkill.GetNewIdleTexture(_character.ListLeftHandSkill[0].IdleIcon);
            _btLefthandSkill.GetNewClickedTexture(_character.ListLeftHandSkill[0].ClickedIcon);
            _btLefthandSkill.Mouse_Click += new Button.OnMouseClickHandler(LeftSkillButon_Clicked);
            _btLefthandSkill.Mouse_Hover += new Button.OnMouseHoverHandler(LeftSkillButon_Hover);
            _btLefthandSkill.Mouse_Released += new Button.OnMouseReleasedHandler(LeftSkillButon_Release);
            HealbarFrame.AddChild(_btLefthandSkill);

            //Button right
            _btRighthandSkill = (Button)_resouces[2].CreateObject(22);
            _btRighthandSkill.Owner = _character.ListRightHandSkill[0];
            _btRighthandSkill.GetNewIdleTexture(_character.ListRightHandSkill[0].IdleIcon);
            _btRighthandSkill.GetNewClickedTexture(_character.ListRightHandSkill[0].ClickedIcon);
            _btRighthandSkill.Mouse_Click += new Button.OnMouseClickHandler(RightSkillButon_Clicked);
            _btRighthandSkill.Mouse_Hover += new Button.OnMouseHoverHandler(RightSkillButon_Hover);
            _btRighthandSkill.Mouse_Released += new Button.OnMouseReleasedHandler(RightSkillButon_Release);
            HealbarFrame.AddChild(_btRighthandSkill);

            _coolDownRightSkill = (ProcessBar)_resouces[1].CreateObject(2);
            _healbarFrame.AddChild(_coolDownRightSkill);

            _coolDownLeftSkill = (ProcessBar)_resouces[1].CreateObject(3);
            _healbarFrame.AddChild(_coolDownLeftSkill);

            _levelProcess = (ProcessBar)_resouces[1].CreateObject(4);
            _healbarFrame.AddChild(_levelProcess);

            _btCMUpButton = (Button)_resouces[2].CreateObject(35);
            _btCMUpButton.Mouse_Click += new Button.OnMouseClickHandler(UpCommandbutton_Clicked);
            _healbarFrame.AddChild (_btCMUpButton);

            //item blood, mana, both
            _itemFrame = (GameFrame)_resouces[0].CreateObject(10);
            _itemFrame.X += _healbarFrame.X;
            _itemFrame.Y += _healbarFrame.Y;

            _btBlood = (Button)_resouces[2].CreateObject(47);
            _btBlood.Mouse_Click += new Button.OnMouseClickHandler(BloodButton_Clicked);

            _lbBlood = (Label)_resouces[3].CreateObject(16);
            _lbBlood.StringInfo = _character.HPPortion.Count.ToString();

            _itemFrame.AddChild(_btBlood);
            _itemFrame.AddChild(_lbBlood);
            //mana
            _btMana = (Button)_resouces[2].CreateObject(48);
            _btMana.Mouse_Click += new Button.OnMouseClickHandler(ManaButton_Clicked);

            _lbMana = (Label)_resouces[3].CreateObject(17);
            _lbMana.StringInfo = _character.MPPortion.Count.ToString();

            _itemFrame.AddChild(_btMana);
            _itemFrame.AddChild(_lbMana);

            //both
            _btBloodNMana = (Button)_resouces[2].CreateObject(49);
            _btBloodNMana.Mouse_Click += new Button.OnMouseClickHandler(BloodNManaButton_Clicked);

            _lbBloodNMana = (Label)_resouces[3].CreateObject(18);
            _lbBloodNMana.StringInfo = _character.RestorePortion.Count.ToString();

            _itemFrame.AddChild(_btBloodNMana);
            _itemFrame.AddChild(_lbBloodNMana);
            

            _rect = new Rectangle((int)_healbarFrame.X, (int)_healbarFrame.Y, (int)_healbarFrame.Width, (int)_healbarFrame.Height);
        }

        public override void Update(GameTime gameTime)
        {
            _healbarFrame.Update(gameTime);

            //Update của left button skill
            Skill _currentLeftSkill = (Skill)_btLefthandSkill.Owner;
            if ((_currentLeftSkill.ListLevel[_currentLeftSkill.Level].ListSkillInfo[0].Mp * -1) <= _character.Mp)
                _btLefthandSkill.ColorToDraw = Color.White;
            else
                _btLefthandSkill.ColorToDraw = new Color(0, 130, 185);

            if (_currentLeftSkill.CheckCoolDown != 0)
            {
                float _cooldownLeftRate = (float)_currentLeftSkill.CheckCoolDown / (float)_currentLeftSkill.CoolDownTime;
                _coolDownLeftSkill.UpdateDrawRect(_cooldownLeftRate);
            }
            else
                _coolDownLeftSkill.UpdateDrawRect(0);

            //Update cua tight button skill
            Skill _currentRightSkill = (Skill)_btRighthandSkill.Owner;
            if (_currentRightSkill != null)
            {
                if ((_currentRightSkill.ListLevel[_currentRightSkill.Level].ListSkillInfo[0].Mp * -1) <= _character.Mp)
                    _btRighthandSkill.ColorToDraw = Color.White;
                else
                    _btRighthandSkill.ColorToDraw = new Color(0, 130, 185);

                if (_currentRightSkill.CheckCoolDown != 0)
                {
                    float _cooldownRightRate = (float)_currentRightSkill.CheckCoolDown / (float)_currentRightSkill.CoolDownTime;
                    _coolDownRightSkill.UpdateDrawRect(_cooldownRightRate);
                }
                else
                    _coolDownRightSkill.UpdateDrawRect(0);
            }

            //Update của ống máu
            float _bloodRate = (float)_character.Hp / (float)_character.MaxHp;
            _bloodPro.UpdateDrawRect(_bloodRate);
            //update của ống mana
            float _manaRate = (float)_character.Mp / (float)_character.MaxMp;
            _manaPro.UpdateDrawRect(_manaRate);
            //update ống level
            float _levelRate = (float)_character.CurrentEXP / (float)_character.NextLevelEXP;
            _levelProcess.UpdateDrawRect(_levelRate);
            //Update so luong item
            _itemFrame.Update(gameTime); //trong cai update này co san~ cai update cua nhung button
            _lbBlood.StringInfo = _character.HPPortion.Count.ToString();
            _lbMana.StringInfo = _character.MPPortion.Count.ToString();
            _lbBloodNMana.StringInfo = _character.RestorePortion.Count.ToString();
            //update main rect
            _rect = new Rectangle((int)_healbarFrame.X, (int)_healbarFrame.Y, (int)_healbarFrame.Width, (int)_healbarFrame.Height);
            if (_rect.Contains(GlobalVariables.CurrentMouseState.X, GlobalVariables.CurrentMouseState.Y))
            {
                GlobalVariables.AlreadyUseLeftMouse = true;
                GlobalVariables.AlreadyUseRightMouse = true;
            }

            //Update chỗ này chỉ để chặn con chuột -> khá dỡ.
            _bloodPro.Update(gameTime);
            _manaPro.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _healbarFrame.Draw(gameTime, sb);

            //Itemframe khong duoc add vào trong healthbar frame de ve~ chung mà no tu ve~ -> do sai lam trong thiet ke :|
            sb.Draw(_itemFrame._sprite[0].Texture2D[0], new Vector2 (_itemFrame.X, _itemFrame.Y), Color.White);
            for (int i = 0; i < _itemFrame.Child.Count; i++)
            {
                _itemFrame.Child[i].Draw(gameTime, sb);
            }

            //Ve cac process bar
            _bloodPro.Draw(gameTime, sb);
            _manaPro.Draw(gameTime, sb);

            if (_character.Skillboard.BoardFrame.IsVisible)
            {
                switch (_character.Skillboard.ICurrentBoard)
                {
                    case 0:
                        {
                            if (((Skill)_character.Skillboard.BtSkillCleaving.Owner).CurrentButton == _character.Skillboard.BtSkillCleaving)
                                ((Skill)_character.Skillboard.BtSkillCleaving.Owner).Draw(gameTime, sb);

                            if (((Skill)_character.Skillboard.BtSkillCritical.Owner).CurrentButton == _character.Skillboard.BtSkillCritical)
                                ((Skill)_character.Skillboard.BtSkillCritical.Owner).Draw(gameTime, sb);

                            if (((Skill)_character.Skillboard.BtSkillCurse.Owner).CurrentButton == _character.Skillboard.BtSkillCurse)
                                ((Skill)_character.Skillboard.BtSkillCurse.Owner).Draw(gameTime, sb);

                            if (((Skill)_character.Skillboard.BtSkillOverSpeed.Owner).CurrentButton == _character.Skillboard.BtSkillOverSpeed)
                                ((Skill)_character.Skillboard.BtSkillOverSpeed.Owner).Draw(gameTime, sb);

                            if (((Skill)_character.Skillboard.BtSkillLifeSteal.Owner).CurrentButton == _character.Skillboard.BtSkillLifeSteal)
                                ((Skill)_character.Skillboard.BtSkillLifeSteal.Owner).Draw(gameTime, sb);

                            if (((Skill)_character.Skillboard.BtSkillBash.Owner).CurrentButton == _character.Skillboard.BtSkillBash)
                                ((Skill)_character.Skillboard.BtSkillBash.Owner).Draw(gameTime, sb);
                            break;
                        }
                    case 1:
                        {
                            if (((Skill)_character.Skillboard.BtDeadlyBeesSkill.Owner).CurrentButton == _character.Skillboard.BtDeadlyBeesSkill)
                                ((Skill)_character.Skillboard.BtDeadlyBeesSkill.Owner).Draw(gameTime, sb);

                            if (((Skill)_character.Skillboard.BtSoulRelease.Owner).CurrentButton == _character.Skillboard.BtSoulRelease)
                                ((Skill)_character.Skillboard.BtSoulRelease.Owner).Draw(gameTime, sb);

                            if (((Skill)_character.Skillboard.BtEathShakeSkill.Owner).CurrentButton == _character.Skillboard.BtEathShakeSkill)
                                ((Skill)_character.Skillboard.BtEathShakeSkill.Owner).Draw(gameTime, sb);

                            if (((Skill)_character.Skillboard.BtWaveFormSkill.Owner).CurrentButton == _character.Skillboard.BtWaveFormSkill)
                                ((Skill)_character.Skillboard.BtWaveFormSkill.Owner).Draw(gameTime, sb);

                            if (((Skill)_character.Skillboard.BtLightingField.Owner).CurrentButton == _character.Skillboard.BtLightingField)
                                ((Skill)_character.Skillboard.BtLightingField.Owner).Draw(gameTime, sb);

                            if (((Skill)_character.Skillboard.BtInvisible.Owner).CurrentButton == _character.Skillboard.BtInvisible)
                                ((Skill)_character.Skillboard.BtInvisible.Owner).Draw(gameTime, sb);
                            break;
                        }
                    case 2:
                        {
                            if (((Skill)_character.Skillboard.BtGreatFortitude.Owner).CurrentButton == _character.Skillboard.BtGreatFortitude)
                                ((Skill)_character.Skillboard.BtGreatFortitude.Owner).Draw(gameTime, sb);

                            if (((Skill)_character.Skillboard.BtGodStrength.Owner).CurrentButton == _character.Skillboard.BtGodStrength)
                                ((Skill)_character.Skillboard.BtGodStrength.Owner).Draw(gameTime, sb);

                            if (((Skill)_character.Skillboard.BtBlur.Owner).CurrentButton == _character.Skillboard.BtBlur)
                                ((Skill)_character.Skillboard.BtBlur.Owner).Draw(gameTime, sb);
                            break;
                        }
                }
            }

            //if (_btLefthandSkill.IsMouseHover)
            //    ((Skill)_btLefthandSkill.Owner).Draw(gameTime, sb);
        }

//---Su kien cho Left Command Button---
        public void LeftCommandButon_Clicked(object sender, EventArgs e)
        {

        }

//---Su kien cho Right Command Button---

        public void RightCommandButon_Clicked(object sender, EventArgs e)
        {
            if (_character.Skillboard.BoardFrame.IsVisible)
            {
                _character.Skillboard.CreateMotion_GoOut();
                _character.Skillboard.BoardFrame.Motion = _character.Skillboard.MotionGoOut;
                _character.Skillboard.BoardFrame.Motion.IsStanding = false;
            }
            else
            {
                _character.Skillboard.CreateMotion_GoIn();
                _character.Skillboard.BoardFrame.Motion = _character.Skillboard.MotionGoIn;
                _character.Skillboard.BoardFrame.Motion.IsStanding = false;
            }
        }
 //Su kien cho Item button

        public void BloodButton_Clicked(object sender, EventArgs e)
        {
            if (_character.HPPortion.Count > 0)
            {
                _character.HPPortion[0].DoEffect();
                _character.HPPortion.Remove(_character.HPPortion[0]);
            }
        }

        public void ManaButton_Clicked(object sender, EventArgs e)
        {
            if (_character.MPPortion.Count > 0)
            {
                _character.MPPortion[0].DoEffect();
                _character.MPPortion.Remove(_character.MPPortion[0]);
            }
        }

        public void BloodNManaButton_Clicked(object sender, EventArgs e)
        {
            if (_character.RestorePortion.Count > 0)
            {
                _character.RestorePortion[0].DoEffect();
                _character.RestorePortion.Remove(_character.RestorePortion[0]);
            }
        }
//---Su kien cho Left Button Skill---
        public void LeftSkillButon_Clicked(object sender, EventArgs e)
        {
            if (_character.LhSkillSelectionFrame.MainFrame.IsVisible)
            {
                _character.LhSkillSelectionFrame.CreateMotion_GoOut();
                _character.LhSkillSelectionFrame.MainFrame.Motion = _character.LhSkillSelectionFrame.MotionGoOut;
                _character.LhSkillSelectionFrame.MainFrame.Motion.IsStanding = false;
            }
            else
            {
                _character.LhSkillSelectionFrame.CreateMotion_GoIn();
                _character.LhSkillSelectionFrame.MainFrame.Motion = _character.LhSkillSelectionFrame.MotionGoIn;
                _character.LhSkillSelectionFrame.MainFrame.Motion.IsStanding = false;
            }
        }

        public void LeftSkillButon_Hover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void LeftSkillButon_Release(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

//Sự kiện cho Right button skill-----------------------
        public void RightSkillButon_Clicked(object sender, EventArgs e)
        {
            if (_character.RhSkillSelectionFrame.MainFrame.IsVisible)
            {
                _character.RhSkillSelectionFrame.CreateMotion_GoOut();
                _character.RhSkillSelectionFrame.MainFrame.Motion = _character.RhSkillSelectionFrame.MotionGoOut;
                _character.RhSkillSelectionFrame.MainFrame.Motion.IsStanding = false;
            }
            else
            {
                _character.RhSkillSelectionFrame.CreateMotion_GoIn();
                _character.RhSkillSelectionFrame.MainFrame.Motion = _character.RhSkillSelectionFrame.MotionGoIn;
                _character.RhSkillSelectionFrame.MainFrame.Motion.IsStanding = false;
            }
        }

        public void RightSkillButon_Hover(object sender, EventArgs e)
        {

        }

        public void RightSkillButon_Release(object sender, EventArgs e)
        {

        }

//Sư kiện cho main button
        public void UpCommandbutton_Clicked(object sender, EventArgs e)
        {
            GlobalVariables.IsPauseGame = true;
        }
//----Hàm dùng chung--------------
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
    }
}