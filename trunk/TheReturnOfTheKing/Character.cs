using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;

namespace TheReturnOfTheKing
{
    public class Character : VisibleGameEntity
    {
        List<Projectile> _additionnalEffect = new List<Projectile>();

        public List<Projectile> AdditionnalEffect
        {
            get { return _additionnalEffect; }
            set { _additionnalEffect = value; }
        }

        int _bashTime;

        public int BashTime
        {
            get { return _bashTime; }
            set { _bashTime = value; }
        }

        StateMainGame _owner;

        public StateMainGame Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        int _damage;

        public int Damage
        {
            get { return _damage; }
            set 
            { 
                _damage = value;
                _displayDamageTime = 30;
            }
        }

        int _displayDamageTime;

        public int DisplayDamageTime
        {
            get { return _displayDamageTime; }
            set { _displayDamageTime = value; }
        }

        /// <summary>
        /// Máu
        /// </summary>
        int _hp;

        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        /// <summary>
        /// Máu tối đa
        /// </summary>
        int _maxHp;

        public int MaxHp
        {
            get { return _maxHp; }
            set { _maxHp = value; }
        }

        /// <summary>
        /// Mana
        /// </summary>
        int _mp;

        public int Mp
        {
            get { return _mp; }
            set { _mp = value; }
        }
        /// <summary>
        /// Mana tối đa
        /// </summary>
        int _maxMp;

        public int MaxMp
        {
            get { return _maxMp; }
            set { _maxMp = value; }
        }
        /// <summary>
        /// Tỉ lệ né đòn
        /// </summary>
        int _changeToDodge;

        public int ChangeToDodge
        {
            get { return _changeToDodge; }
            set { _changeToDodge = value; }
        }
        /// <summary>
        /// Luong mau bi mat
        /// </summary>
        int _recentHPLost;

        public int RecentHPLost
        {
            get { return _recentHPLost; }
            set { _recentHPLost = value; }
        }

        

        /// <summary>
        /// Bán kính tấn công
        /// </summary>
        int _range;

        public int Range
        {
            get { return _range; }
            set { _range = value; }
        }
        /// <summary>
        /// Tốc độ đánh
        /// Tính từ lúc bắt đầu nhận lệnh tấn công cho đến lúc thực sự gây ra sát thương
        /// </summary>
        int _attackSpeed;

        public int AttackSpeed
        {
            get { return _attackSpeed; }
            set { _attackSpeed = value; }
        }
        /// <summary>
        /// Sát thương thấp nhất
        /// </summary>
        int _minDamage;

        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }
        /// <summary>
        /// Sát thương cao nhất
        /// </summary>
        int _maxDamage;

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        /// <summary>
        /// Phòng thủ
        /// </summary>
        int _defense;

        public int Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }
        /// <summary>
        /// Tỉ lệ tấn công chí mạng (tính theo %)
        /// </summary>
        int _criticalRate;

        public int CriticalRate
        {
            get { return _criticalRate; }
            set { _criticalRate = value; }
        }
        /// <summary>
        /// Vị trí khung hình tấn công
        /// </summary>
        int _hitFrame;

        public int HitFrame
        {
            get { return _hitFrame; }
            set { _hitFrame = value; }
        }
        /// <summary>
        /// Vị trí khung hình cast phép
        /// </summary>
        int _castFrame;

        public int CastFrame
        {
            get { return _castFrame; }
            set { _castFrame = value; }
        }

        /// <summary>
        /// Hình chữ nhật để click vào con quái
        /// </summary>
        Rectangle _focusRect;

        public Rectangle FocusRect
        {
            get { return _focusRect; }
            set { _focusRect = value; }
        }

        /// <summary>
        /// Bản đồ nhân vật ở trên đó
        /// </summary>
        Map _map;

        public Map Map
        {
            get { return _map; }
            set { _map = value; }
        }

        /// <summary>
        /// X
        /// </summary>
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
                CollisionRect = new Rectangle((int)X, (int)Y, (int)GlobalVariables.MapCollisionDim, (int)GlobalVariables.MapCollisionDim);
                FocusRect = new Rectangle((int)(X), (int)(Y - GlobalVariables.MapCollisionDim), (int)GlobalVariables.MapCollisionDim, (int)GlobalVariables.MapCollisionDim * 2);
            }
        }
        /// <summary>
        /// Y
        /// </summary>
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
                CollisionRect = new Rectangle((int)X, (int)Y, (int)GlobalVariables.MapCollisionDim, (int)GlobalVariables.MapCollisionDim);
                FocusRect = new Rectangle((int)(X), (int)(Y - GlobalVariables.MapCollisionDim), (int)GlobalVariables.MapCollisionDim, (int)GlobalVariables.MapCollisionDim * 2);
            }
        }
        /// <summary>
        /// Danh sách các ô còn phải di chuyển tiếp theo
        /// </summary>
        List<Point> cellToMove;

        public List<Point> CellToMove
        {
            get { return cellToMove; }
            set { cellToMove = value; }
        }
        
        /// <summary>
        /// Đang trong trạng thái đứng yên
        /// </summary>
        bool _isStanding = true;

        public virtual bool IsStanding
        {
            get { return _isStanding; }
            set 
            { 
                _isStanding = value;
                if (value)
                {                    
                    IsAttacking = false;
                    IsMoving = false;
                    IsDyed = false;
                    IsDying = false;
                    IsCasting = false;
                }
            }
        }
        /// <summary>
        /// Đang trong trạng thái di chuyển
        /// </summary>
        bool _isMoving = false;

        public virtual bool IsMoving
        {
            get { return _isMoving; }
            set
            {
                _isMoving = value;
                if (value)
                {
                    
                    IsStanding = false;
                    IsAttacking = false;
                    IsDyed = false;
                    IsDying = false;
                    IsCasting = false;
                }
            }

        }
        /// <summary>
        /// Đang trong trạng thái tấn công
        /// </summary>
        bool _isAttacking = false;

        public virtual bool IsAttacking
        {
            get { return _isAttacking; }
            set 
            { 
                _isAttacking = value;
                if (value)
                {
                    
                    IsStanding = false;
                    IsMoving = false;
                    IsDyed = false;
                    IsDying = false;
                    IsCasting = false;
                }
            }
        }
        /// <summary>
        /// Đang chết
        /// </summary>
        bool _isDying = false;

        public virtual bool IsDying
        {
            get { return _isDying; }
            set 
            { 
                _isDying = value;
                if (value)
                {
                                       
                    IsStanding = false;
                    IsMoving = false;
                    IsDyed = false;
                    IsAttacking = false;
                    IsCasting = false;
                }
            }
        }
        /// <summary>
        /// Đã chết
        /// </summary>
        bool _isDyed = false;

        public virtual bool IsDyed
        {
            get { return _isDyed; }
            set 
            {
                _isDyed = value;
                if (value)
                {           
                    IsStanding = false; 
                    IsMoving = false;
                    IsAttacking = false;
                    IsDying = false;
                    IsCasting = false;
                }
            }
        }

        /// <summary>
        /// Đang dùng skill
        /// </summary>
        bool _isCasting;

        public virtual bool IsCasting
        {
            get { return _isCasting; }
            set
            {
                _isCasting = value;
                if (value == true)
                {
                    IsAttacking = false;
                    IsMoving = false;
                    IsStanding = false;
                    IsDyed = false;
                    IsDying = false;                    
                }
            }
        }


        /// <summary>
        /// Tốc độ di chuyển
        /// </summary>
        int _speed;

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        /// <summary>
        // Tầm ảnh hưởng
        /// </summary>
        int _sight;

        public int Sight
        {
            get { return _sight; }
            set { _sight = value; }
        }

        /// <summary>
        /// Hướng hiện tại
        /// </summary>
        int _dir = 0;

        public int Dir
        {
            get { return _dir; }
            set 
            { 
                _dir = value;                
            }
        }
        /// <summary>
        /// Offset của bộ sprite thể hiện trạng thái
        /// </summary>
        int _state;

        public int State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// Đích đến
        /// </summary>
        Point _destPoint;

        public Point DestPoint
        {
            get { return _destPoint; }
            set { _destPoint = value; }
        }
        
        /// <summary>
        /// Gán nhân vật với bản đồ
        /// </summary>
        /// <param name="map">Bản đồ cần gán</param>
        public virtual void SetMap(Map map)
        {
            _map = map;
            cellToMove = new List<Point>();
            IsStanding = true;
            _destPoint = new Point((int)X, (int)Y);
        }
        /// <summary>
        /// Mục tiêu tấn công
        /// </summary>
        Character _target;

        public Character Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            for (int i = 0; i < AdditionnalEffect.Count; ++i)
                AdditionnalEffect[i].Draw(gameTime, sb);
            _sprite[_dir].Draw(gameTime, sb);
            if (_displayDamageTime > 0 && Math.Abs(_damage) > 0)
            {
                _displayDamageTime -= 1;
                sb.DrawString(GlobalVariables.Sf, _damage.ToString(), new Vector2(X + GlobalVariables.dX , Y + _displayDamageTime + GlobalVariables.dY + _sprite[Dir].Yoffset - 20), Color.Red);
            }
            
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < AdditionnalEffect.Count; ++i)
            {
                AdditionnalEffect[i].Update(gameTime);
                if (AdditionnalEffect[i]._sprite[0].Itexture2D == AdditionnalEffect[i]._sprite[0].Ntexture2D - 1)
                    AdditionnalEffect.Remove(AdditionnalEffect[i]);
            }
            if (BashTime > 0)
            {
                --BashTime;
                return;
            }

            _sprite[Dir].Update(gameTime);

            if (this.Hp <= 0 && !IsDying && !IsDyed)
                IsDying = true;
            
            if (IsDying)
            {
                if (Target != null)
                {
                    UpdateDirection(_target.X, _target.Y);
                    Target = null;
                }
                if (_sprite[Dir].Itexture2D == _sprite[Dir].Ntexture2D - 1)
                {
                    IsDyed = true;
                    UpdateDirection(X, Y);
                }
                return;
            }

            if (IsDyed)
            {
                return;
            }
            if (_target != null && IsAttacking && this.IsCollisionWith(_target))
            {
                UpdateDirection(_target.X, _target.Y);
                return;
            }
            if (_target == null)
            {
                if (!IsCasting)
                {
                    Move();
                    UpdateDirection(DestPoint.X, DestPoint.Y);
                }
            }
            else
            {
                if (this.IsCollisionWith(_target))
                {
                    if (!IsAttacking)
                    {
                        IsAttacking = true;
                        UpdateDirection(_target.X, _target.Y);
                        DestPoint = new Point((int)X, (int)Y);
                        CellToMove = new List<Point>();
                    }
                }
                else
                {
                    CellToMove = Utility.FindPath(Map.Matrix, Map.PointToCell(new Point((int)X, (int)Y)), Map.PointToCell(new Point((int)Target.X, (int)Target.Y)));
                    if (CellToMove.Count >= 1)
                    {
                        IsMoving = true;                        
                        Move();
                        UpdateDirection(DestPoint.X, DestPoint.Y);
                    }
                    else
                    {
                        IsAttacking = true;
                        UpdateDirection(_target.X, _target.Y);
                        CellToMove = new List<Point>();                        
                    }
                }
            }

            if (Hp <= 0 && !(IsDying || IsDyed))
            {
                IsDying = true;
                UpdateDirection(this.X, this.Y);
            }
        }

        private void Move()
        {
            if (!IsMoving || IsStanding)
                return;
            if (CellToMove.Count != 0 && X == DestPoint.X && Y == DestPoint.Y)
            {
                DestPoint = new Point(CellToMove[CellToMove.Count - 1].X * Map.CollisionDim, CellToMove[CellToMove.Count - 1].Y * Map.CollisionDim);
                CellToMove.RemoveAt(CellToMove.Count - 1);
                IsMoving = true;
            }
            //float oX = this.X;
            //float oY = this.Y;
            if (this.Y == DestPoint.Y && this.X < DestPoint.X)
            {
                this.X += Speed;
            }
            else
                if (this.Y > DestPoint.Y && this.X < DestPoint.X)
                {
                    this.X += (float)(Speed / Math.Sqrt(2));
                    this.Y -= (float)(Speed / Math.Sqrt(2));
                }
                else
                    if (this.Y > DestPoint.Y && this.X == DestPoint.X)
                    {
                        this.Y -= Speed;

                    }
                    else
                        if (this.Y > DestPoint.Y && this.X > DestPoint.X)
                        {
                            this.X -= (float)(Speed / Math.Sqrt(2));
                            this.Y -= (float)(Speed / Math.Sqrt(2));

                        }
                        else
                            if (this.Y == DestPoint.Y && this.X > DestPoint.X)
                            {
                                this.X -= Speed;
                            }
                            else
                                if (this.Y < DestPoint.Y && this.X > DestPoint.X)
                                {
                                    this.X -= (float)(Speed / Math.Sqrt(2));
                                    this.Y += (float)(Speed / Math.Sqrt(2));

                                }
                                else
                                    if (this.Y < DestPoint.Y && this.X == DestPoint.X)
                                    {
                                        this.Y += Speed;
                                    }
                                    else
                                        if (this.Y < DestPoint.Y && this.X < DestPoint.X)
                                        {
                                            this.X += (float)(Speed / Math.Sqrt(2));
                                            this.Y += (float)(Speed / Math.Sqrt(2));

                                        }
        

            
            //for (int i = 0; i < Owner._listToDraw.Count; ++i)
            //    if (!this.Equals(Owner._listToDraw[i]) && this.IsCollisionWith(Owner._listToDraw[i]))
            //    {
            //        this.X = oX;
            //        this.Y = oY;
            //    }


            if (Math.Abs(this.X - DestPoint.X) < Speed / Math.Sqrt(2) && Math.Abs(this.Y - DestPoint.Y) < Speed / Math.Sqrt(2))
            {
                this.X = DestPoint.X;
                this.Y = DestPoint.Y;
                if (CellToMove.Count == 0 && IsMoving)
                {   
                    IsStanding = true;
                }
            }
            
        }
       
        public virtual void UpdateDirection(float x, float y)
        {
            if (BashTime > 0)
            {
                IsStanding = true;
                CellToMove = new List<Point>();
            }
            int oldDir = _dir;
            x += GlobalVariables.MapCollisionDim / 2;
            y += GlobalVariables.MapCollisionDim / 2;
            float tX = X + GlobalVariables.MapCollisionDim / 2;
            float tY = Y + GlobalVariables.MapCollisionDim / 2;

            if (Math.Abs(tX - x) < 1)
                this.X = (float)x - GlobalVariables.MapCollisionDim / 2;
            if (Math.Abs(tY - y) < 1)
                this.Y = (float)y - GlobalVariables.MapCollisionDim / 2;
            Vector2 _v1, _v2, _v3;
            _v1 = new Vector2(x - tX, y - tY);
            _v2 = new Vector2(1, 0);
            _v3 = _v1 * _v2;
            float _angle = MathHelper.ToDegrees((float)Math.Acos(_v3.Length() / (_v1.Length() * _v2.Length())));

            if (0 <= _angle && _angle < 22.5)
                if (x < tX)
                    Dir = 4;
                else
                    Dir = 0;
            if (22.5 <= _angle && _angle < 67.5)
            {
                if (x > tX && y < tY)
                    Dir = 1;
                if (x < tX && y < tY)
                    Dir = 3;
                if (x < tX && y > tY)
                    Dir = 5;
                if (x > tX && y > tY)
                    Dir = 7;
            }
            if (67.5 < _angle && _angle <= 90)
                if (y < tY)
                    Dir = 2;
                else
                    Dir = 6;
            Dir = Dir % 8;
            Dir += State;  
            
            if (_dir != oldDir)
                _sprite[oldDir].Itexture2D = 0;
        }

       
        
        public virtual void Hit()
        {
            if (Target == null)
                return;
            Random r = new Random((int)DateTime.Now.Ticks);
            int Damage = r.Next(MinDamage, MaxDamage);            
            if (r.Next(0, 100) < this.CriticalRate)
                Target.BeHit(Damage * 2);
            else
                Target.BeHit(Damage);
        }

        public virtual void BeHit(int damage)
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            if (r.Next(0, 100) >= this.ChangeToDodge)
            {
                Damage = Math.Min(-(damage - this.Defense), 0);
                Hp += Damage;
                _recentHPLost = Damage;
            }
            
        }
    }
}
