using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJRPG_Ver._2.TwoDGameEngine.Graphics.Sprites;
using MonoGameJRPG_Ver._2.TwoDGameEngine.Input;

namespace Pong
{
    public class Ball
    {
        private Sprite _sprite;
        private int _screenWidth;
        private int _screenHeight;
        private Vector2 _velocity;
        private bool _forward = true;

        /// <summary>
        /// Used to check if Ball is still in screen bounds.
        /// </summary>
        private Rectangle _screenRec;

        public Sprite Sprite => _sprite;

        public bool Forward
        {
            get => _forward;
            set => _forward = value;
        }

        public Ball(Texture2D texture, Vector2 position, int screenWidth,
            int screenHeight)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _screenRec = new Rectangle(0, 0, screenWidth, screenHeight);
            _velocity = new Vector2((float)(screenWidth * 0.0025), 0);

            _sprite = new Sprite("Ball", texture, position, false, null);
        }

        public void Update(GameTime gameTime)
        {
            _sprite.Update(gameTime);

            if (!_screenRec.Contains(_sprite._position))
                _sprite._position.X = 0;

            if (_forward)
            {
                _sprite._position.X += _velocity.X * gameTime.ElapsedGameTime.Milliseconds;
                _sprite._position.Y += _velocity.Y * gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                _sprite._position.X -= _velocity.X * gameTime.ElapsedGameTime.Milliseconds; ;
                _sprite._position.Y -= _velocity.Y * gameTime.ElapsedGameTime.Milliseconds; ;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }
    }
}
