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
    public class RHSkillSelectionFrame : Dialog
    {
        PlayerCharacter _character;

        public PlayerCharacter Character
        {
            get { return _character; }
            set { _character = value; }
        }

        //frame chính
        GameFrame _mainFrame;
        public GameFrame MainFrame
        {
            get { return _mainFrame; }
            set { _mainFrame = value; }
        }

        //basic
        Button _btLightingStrike;
        public Button BtLightingStrike
        {
            get { return _btLightingStrike; }
            set { _btLightingStrike = value; }
        }

        //bead bee
        Button _btDeadlyBees;
        public Button BtDeadlyBees
        {
            get { return _btDeadlyBees; }
            set { _btDeadlyBees = value; }
        }

        //release souls
        Button _btSoulsRelease;
        public Button BtSoulsRelease
        {
            get { return _btSoulsRelease; }
            set { _btSoulsRelease = value; }
        }

        //earth shake
        Button _btEathShake;
        public Button BtEathShake
        {
            get { return _btEathShake; }
            set { _btEathShake = value; }
        }

        //waveform
        Button _btWaveForm;
        public Button BtWaveForm
        {
            get { return _btWaveForm; }
            set { _btWaveForm = value; }
        }

        //lightin field
        Button _btLightingField;
        public Button BtLightingField
        {
            get { return _btLightingField; }
            set { _btLightingField = value; }
        }

        //Invisible
        Button _btInvisible;
        public Button BtInvisible
        {
            get { return _btInvisible; }
            set { _btInvisible = value; }
        }

        //Motion di chuyển
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
            _mainFrame = (GameFrame)_resources[0].CreateObject(6);
            _mainFrame.IsVisible = false;

            _btLightingStrike = (Button)_resources[1].CreateObject(29);
            _btLightingStrike.Owner = _character.ListRightHandSkill[0];
            _btLightingStrike.GetNewIdleTexture(_character.ListRightHandSkill[0].IdleIcon);
            _btLightingStrike.GetNewClickedTexture(_character.ListRightHandSkill[0].ClickedIcon);
            _btLightingStrike.Mouse_Click += new Button.OnMouseClickHandler(LightingStrike_Clicked);
            _btLightingStrike.Mouse_Hover += new Button.OnMouseHoverHandler(LightingStrike_Hover);
            _btLightingStrike.Mouse_Released += new Button.OnMouseReleasedHandler(LightingStrike_Release);

            _btDeadlyBees = (Button)_resources[1].CreateObject(30);
            _btDeadlyBees.Owner = _character.ListRightHandSkill[1];
            _btDeadlyBees.GetNewIdleTexture(_character.ListRightHandSkill[1].IdleIcon);
            _btDeadlyBees.GetNewClickedTexture(_character.ListRightHandSkill[1].ClickedIcon);
            _btDeadlyBees.Mouse_Click += new Button.OnMouseClickHandler(DeadlyBees_Clicked);
            _btDeadlyBees.Mouse_Hover += new Button.OnMouseHoverHandler(DeadlyBees_Hover);
            _btDeadlyBees.Mouse_Released += new Button.OnMouseReleasedHandler(DeadlyBees_Release);

            _btSoulsRelease = (Button)_resources[1].CreateObject(31);
            _btSoulsRelease.Owner = _character.ListRightHandSkill[2];
            _btSoulsRelease.GetNewIdleTexture(_character.ListRightHandSkill[2].IdleIcon);
            _btSoulsRelease.GetNewClickedTexture(_character.ListRightHandSkill[2].ClickedIcon);
            _btSoulsRelease.Mouse_Click += new Button.OnMouseClickHandler(SouldRelease_Clicked);
            _btSoulsRelease.Mouse_Hover += new Button.OnMouseHoverHandler(SouldRelease_Hover);
            _btSoulsRelease.Mouse_Released += new Button.OnMouseReleasedHandler(SouldRelease_Release);

            _btEathShake = (Button)_resources[1].CreateObject(32);
            _btEathShake.Owner = _character.ListRightHandSkill[3];
            _btEathShake.GetNewIdleTexture(_character.ListRightHandSkill[3].IdleIcon);
            _btEathShake.GetNewClickedTexture(_character.ListRightHandSkill[3].ClickedIcon);
            _btEathShake.Mouse_Click += new Button.OnMouseClickHandler(EarthShake_Clicked);
            _btEathShake.Mouse_Hover += new Button.OnMouseHoverHandler(EarthShake_Hover);
            _btEathShake.Mouse_Released += new Button.OnMouseReleasedHandler(EarthShake_Release);

            _btWaveForm = (Button)_resources[1].CreateObject(33);
            _btWaveForm.Owner = _character.ListRightHandSkill[4];
            _btWaveForm.GetNewIdleTexture(_character.ListRightHandSkill[4].IdleIcon);
            _btWaveForm.GetNewClickedTexture(_character.ListRightHandSkill[4].ClickedIcon);
            _btWaveForm.Mouse_Click += new Button.OnMouseClickHandler(WaveForm_Clicked);
            _btWaveForm.Mouse_Hover += new Button.OnMouseHoverHandler(WaveForm_Hover);
            _btWaveForm.Mouse_Released += new Button.OnMouseReleasedHandler(WaveForm_Release);

            _btLightingField = (Button)_resources[1].CreateObject(34);
            _btLightingField.Owner = _character.ListRightHandSkill[5];
            _btLightingField.GetNewIdleTexture(_character.ListRightHandSkill[5].IdleIcon);
            _btLightingField.GetNewClickedTexture(_character.ListRightHandSkill[5].ClickedIcon);
            _btLightingField.Mouse_Click += new Button.OnMouseClickHandler(LightingField_Clicked);
            _btLightingField.Mouse_Hover += new Button.OnMouseHoverHandler(LightingField_Hover);
            _btLightingField.Mouse_Released += new Button.OnMouseReleasedHandler(LightingField_Release);

            //Vì sửa lai XML nen thang cuối cùng bi nhảy lên 36
            _btInvisible = (Button)_resources[1].CreateObject(36);
            _btInvisible.Owner = _character.ListRightHandSkill[6];
            _btInvisible.GetNewIdleTexture(_character.ListRightHandSkill[6].IdleIcon);
            _btInvisible.GetNewClickedTexture(_character.ListRightHandSkill[6].ClickedIcon);
            _btInvisible.Mouse_Click += new Button.OnMouseClickHandler(InvisiblePoison_Clicked);
            _btInvisible.Mouse_Hover += new Button.OnMouseHoverHandler(InvisiblePoison_Hover);
            _btInvisible.Mouse_Released += new Button.OnMouseReleasedHandler(InvisiblePoison_Release);

            _mainFrame.AddChild(_btLightingStrike);
            _mainFrame.AddChild(_btDeadlyBees);
            _mainFrame.AddChild(_btSoulsRelease);
            _mainFrame.AddChild(_btEathShake);
            _mainFrame.AddChild(_btWaveForm);
            _mainFrame.AddChild(_btLightingField);
            _mainFrame.AddChild(_btInvisible);
        }

        public void SetCharacter(PlayerCharacter _char)
        {
            _character = _char;
            _character.RhSkillSelectionFrame = this;


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
            if (((Skill)BtLightingStrike.Owner).CurrentButton == BtLightingStrike)
                ((Skill)BtLightingStrike.Owner).Draw(gameTime, sb);

            if (((Skill)BtDeadlyBees.Owner).Level > 0 && ((Skill)BtDeadlyBees.Owner).CurrentButton == BtDeadlyBees)
                ((Skill)BtDeadlyBees.Owner).Draw(gameTime, sb);

            if (((Skill)BtSoulsRelease.Owner).Level > 0 && ((Skill)BtSoulsRelease.Owner).CurrentButton == BtSoulsRelease)
                ((Skill)BtSoulsRelease.Owner).Draw(gameTime, sb);

            if (((Skill)BtEathShake.Owner).Level > 0 && ((Skill)BtEathShake.Owner).CurrentButton == BtEathShake)
                ((Skill)BtEathShake.Owner).Draw(gameTime, sb);

            if (((Skill)BtWaveForm.Owner).Level > 0 && ((Skill)BtWaveForm.Owner).CurrentButton == BtWaveForm)
                ((Skill)BtWaveForm.Owner).Draw(gameTime, sb);

            if (((Skill)BtLightingField.Owner).Level > 0 && ((Skill)BtLightingField.Owner).CurrentButton == BtLightingField)
                ((Skill)BtLightingField.Owner).Draw(gameTime, sb);

            if (((Skill)BtInvisible.Owner).Level > 0 && ((Skill)BtInvisible.Owner).CurrentButton == BtInvisible)
                ((Skill)BtInvisible.Owner).Draw(gameTime, sb);
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

        #region Sự kiện Click cho Button
        public void LightingStrike_Clicked(object sender, EventArgs e)
        {
            ChangeSkill(0);
        }

        public void DeadlyBees_Clicked(object sender, EventArgs e)
        {
            ChangeSkill(1);
        }

        public void SouldRelease_Clicked(object sender, EventArgs e)
        {
            ChangeSkill(2);
        }

        public void EarthShake_Clicked(object sender, EventArgs e)
        {
            ChangeSkill(3);
        }

        public void WaveForm_Clicked(object sender, EventArgs e)
        {
            ChangeSkill(4);
        }

        public void LightingField_Clicked(object sender, EventArgs e)
        {
            ChangeSkill(5);
        }

        public void InvisiblePoison_Clicked(object sender, EventArgs e)
        {
            ChangeSkill(6);
        }
        #endregion

        #region Sự kiện Hover button
        public void LightingStrike_Hover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void DeadlyBees_Hover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SouldRelease_Hover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void EarthShake_Hover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void WaveForm_Hover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void LightingField_Hover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void InvisiblePoison_Hover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }
        #endregion

        #region Sự kiện Release button
        public void LightingStrike_Release(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

        public void DeadlyBees_Release(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

        public void SouldRelease_Release(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

        public void EarthShake_Release(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

        public void WaveForm_Release(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

        public void LightingField_Release(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }

        public void InvisiblePoison_Release(object sender, EventArgs e)
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
            if (_character.ListRightHandSkill[_skillIndex].Level == 0)
                return;
            MoveOut();
            _character.ListRightHandSkill[_character.RightHandSkillIndex].Deactive();
            _character.RightHandSkillIndex = _skillIndex;
            _character.ListRightHandSkill[_character.RightHandSkillIndex].Active();
            _character.Healthbar.BtRighthandSkill.Owner = (Skill)_character.ListRightHandSkill[_character.RightHandSkillIndex];
            ((Button)_character.Healthbar.BtRighthandSkill).GetNewIdleTexture(((Skill)_character.ListRightHandSkill[_character.RightHandSkillIndex]).IdleIcon);
            ((Button)_character.Healthbar.BtRighthandSkill).GetNewClickedTexture(((Skill)_character.ListRightHandSkill[_character.RightHandSkillIndex]).ClickedIcon);
        }


        public Vector2 GetSkillDetailLocation(Button _button, int _picWid, int _picHei)
        {
            float _temp = _button.X + _button.Width;
            if (_temp + _picWid> GlobalVariables.ScreenWidth)
            {
                float _tempOffset = _temp + _picWid - GlobalVariables.ScreenWidth + 2;
                _temp -= _tempOffset;
            }
            Vector2 _result = new Vector2(_temp, _button.Y - _picHei - 2);
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
