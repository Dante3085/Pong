using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameJRPG_Ver._2.TwoDGameEngine.Graphics.Sprites;
using MonoGameJRPG_Ver._2.TwoDGameEngine.Input;

namespace Pong
{
    public class Paddle
    {
        private Sprite _sprite;
        private int _screenWidth;
        private int _screenHeight;

        public Sprite Sprite => _sprite;

        public Paddle(Texture2D texture, ESide side, int screenWidth, int screenHeight, 
            KeyboardInput keyboardInput = null, GamePadInput gamePadInput = null)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;

            Vector2 position = new Vector2();
            if (side == ESide.Left)
            {
                position.X = 0 + texture.Width;
                position.Y = screenHeight / 2;
            }
            else if (side == ESide.Right)
            {
                position.X = screenWidth - (texture.Width * 2);
                position.Y = screenHeight / 2;
            }

            _sprite = new Sprite("", texture, position, keyboardInput, gamePadInput);
        }

        public void Update(GameTime gameTime)
        {
            if (InputManager.GamePadConnected())
                HandleGamePadInput();
            else
                HandleKeyboardInput();

            CheckBounds();
            _sprite.Update(gameTime);
        }

        /// <summary>
        /// Makes sure that Paddle stays in screen bounds.
        /// </summary>
        private void CheckBounds()
        {
            if (_sprite._position.Y < 0)
                _sprite._position.Y = 0;
            else if ((_sprite._position.Y + _sprite.BoundingBox.Height) > _screenHeight)
                _sprite._position.Y = _screenHeight - _sprite.BoundingBox.Height;
        }

        /// <summary>
        /// Handles KeyboardInput.
        /// </summary>
        private void HandleKeyboardInput()
        {
            if (InputManager.IsKeyDown(_sprite.KeyboardInput.Up))
                _sprite._position.Y -= (float)(_screenHeight * 0.025);
            else if (InputManager.IsKeyDown(_sprite.KeyboardInput.Down))
                _sprite._position.Y += (float)(_screenHeight * 0.025);
        }

        /// <summary>
        /// Handles GamePadInput.
        /// </summary>
        public void HandleGamePadInput()
        {
            if (InputManager.IsButtonDown(_sprite.GamePadInput.Up) || 
                InputManager.IsButtonDown(Buttons.DPadUp))
                _sprite._position.Y -= (float)(_screenHeight * 0.025);
            else if (InputManager.IsButtonDown(_sprite.GamePadInput.Down) ||
                     InputManager.IsButtonDown(Buttons.DPadDown))
                _sprite._position.Y += (float)(_screenHeight * 0.025);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }
    }
}