﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameJRPG_Ver._2.TwoDGameEngine
{
    /// <summary>
    /// Utility class for storing and loading Textures and SpriteFonts.
    /// </summary>
    public static class Contents
    {
        #region Texture2Ds
    
        #region BackgroundImages

        public static Texture2D blueBackground;
        public static Texture2D ff15Background;
        public static Texture2D blackBackground;
        public static Texture2D whiteBackground;

        #endregion
        #region MenuComponents

        public static Texture2D redButtonNoHover;
        public static Texture2D redButtonHover;
        public static Texture2D btnNewGame;
        public static Texture2D glowingButton;
        public static Texture2D discoButton;
        public static Texture2D heart;
        public static Texture2D xboxButtons_A;

        #endregion
        #region Characters

        public static Texture2D warrior;
        public static Texture2D bowlingBall;
        public static Texture2D swordsman;
        public static Texture2D adventurer;

        #endregion
        #region Other

        public static Texture2D rectangleTex;
        public static Texture2D paddle;
        public static Texture2D ball;

        #endregion

        #endregion
        #region SpriteFonts

        public static SpriteFont arial12;
        public static SpriteFont arial15;
        public static SpriteFont arial18;
        public static SpriteFont arial20;
        public static SpriteFont arial30;
        public static SpriteFont arial35;

        public static SpriteFont vecna22;
        public static SpriteFont vecnaBold22;

        public static SpriteFont manaSpace18;
        public static SpriteFont manaSpace19;
        public static SpriteFont manaSpace20;
        public static SpriteFont manaSpace21;
        public static SpriteFont manaSpace22;
        public static SpriteFont manaSpace23;
        public static SpriteFont manaSpace24;
        public static SpriteFont manaSpace25;
        public static SpriteFont manaSpace26;
        public static SpriteFont manaSpace27;
        public static SpriteFont manaSpace28;

        #endregion
        #region Methods
        /// <summary>
        /// Uses given ContentManager and GraphicsDevice to load all Content declared inside Contents class.
        /// </summary>
        /// <param name="c"></param>
        public static void LoadAll(ContentManager c, GraphicsDevice g)
        {
            rectangleTex = new Texture2D(g, 1, 1, false, SurfaceFormat.Color);
            rectangleTex.SetData(new[] { Color.White });

            paddle = c.Load<Texture2D>("Paddle");
            ball = c.Load<Texture2D>("Ball");
        }

        /// <summary>
        /// Uses given ContentManager to load all Character related Textures.
        /// </summary>
        /// <param name="c"></param>
        public static void LoadCharacters(ContentManager c)
        {
            warrior = c.Load<Texture2D>("Characters/warrior");
            bowlingBall = c.Load<Texture2D>("Characters/BowlingBall");
            swordsman = c.Load<Texture2D>("Characters/Swordsman");
        }
        #endregion
    }
}