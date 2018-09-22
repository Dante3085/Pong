using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class CollisionManager
    {
        private Paddle _paddleOne;
        private Paddle _paddleTwo;
        private Ball _ball;

        public CollisionManager(Paddle paddleOne, Paddle paddleTwo,
            Ball ball)
        {
            _paddleOne = paddleOne;
            _paddleTwo = paddleTwo;
            _ball = ball;
        }
    }
}
