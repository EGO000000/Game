using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;

namespace Game.Actors
{
    public class LivingState : ICharacterState
    {
        // TODO: transfer here functionality from Player.Update

        private AbstractCharacter actor;
        private ICommand moveRight;
        private ICommand moveLeft;
        private Jump jump;
        private int timer_jump = 0;
        private int timer_fight = 0;
        private readonly int JUMP_TIME;
        private readonly int FALL_TIME;
        private bool is_jump = false;
        private bool first = true;
        private bool first_fight = true;

        public LivingState(AbstractCharacter actor, double speed)
        {
            this.actor = actor;
            this.actor.SetOrientation(ActorOrientation.FacingRight);
            this.moveRight = new Move(this.actor, 1, 0);
            this.moveLeft = new Move(this.actor, -1, 0);
            this.jump = new Jump();
            JUMP_TIME = 20;
            FALL_TIME = 40;
            //this.jumpLeft = new Jump(this.actor, 3, -1, -4);
            //this.lastMove = this.actor.GetOrientation();
        }

        public void Update()
        {   
            if(timer_jump > 0 && timer_jump < JUMP_TIME && is_jump)
            {
                jump.Execute(this.actor);
                timer_jump++;
                //Console.WriteLine(this.actor.GetAnimation().GetDuration());
            }
            else if(timer_jump > 0 && timer_jump < FALL_TIME && is_jump)
            {
                timer_jump++;
                if (first)
                {
                    this.actor.SetAnimation("jump");
                    this.actor.GetAnimation().Stop();
                    first = false;
                }                               
            }
            else 
            {
                timer_jump = 0;
                is_jump = false;
                first = true;
                this.actor.GetAnimation().StopAt(0);
            }
            if (timer_fight > 0 && timer_fight < JUMP_TIME+6)
            {
                timer_fight++;
                Console.WriteLine(this.actor.GetAnimation().GetDuration());
            }
            else if (timer_fight > 0 && timer_fight < FALL_TIME+5)
            {
                timer_fight++;
                if (first_fight)
                {
                    this.actor.SetAnimation("fight");
                    this.actor.GetAnimation().Stop();
                    first_fight = false;
                }
            }
            else
            {
                timer_fight = 0;
                first_fight = true;
                //this.actor.GetAnimation().Start();
            }
            if (Input.GetInstance().IsKeyDown(Input.Key.D))
            {                
                if (this.actor.GetOrientation() == ActorOrientation.FacingLeft)
                {
                    this.actor.SetAnimation("run");
                    this.actor.GetAnimation().FlipAnimation();
                    this.actor.SetAnimation("fight");
                    this.actor.GetAnimation().FlipAnimation();
                    this.actor.SetAnimation("fight_run");
                    this.actor.GetAnimation().FlipAnimation();
                    this.actor.SetAnimation("jump");
                    this.actor.GetAnimation().FlipAnimation();
                    this.actor.SetAnimation("stay");
                    this.actor.GetAnimation().FlipAnimation();
                }
                this.actor.SetAnimation("run");
                this.actor.SetOrientation(ActorOrientation.FacingRight);
                this.actor.GetAnimation().Start();
                this.moveRight.Execute();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.A))
            {
                this.actor.SetAnimation("run");
                if (this.actor.GetOrientation() == ActorOrientation.FacingRight)
                {
                    this.actor.SetAnimation("run");
                    this.actor.GetAnimation().FlipAnimation();
                    this.actor.SetAnimation("fight");
                    this.actor.GetAnimation().FlipAnimation();
                    this.actor.SetAnimation("fight_run");
                    this.actor.GetAnimation().FlipAnimation();
                    this.actor.SetAnimation("jump");
                    this.actor.GetAnimation().FlipAnimation();
                    this.actor.SetAnimation("stay");
                    this.actor.GetAnimation().FlipAnimation();
                }
                this.actor.SetAnimation("run");
                this.actor.SetOrientation(ActorOrientation.FacingLeft);
                this.actor.GetAnimation().Start();
                this.moveLeft.Execute();
            }
            else if (!is_jump && Input.GetInstance().IsKeyDown(Input.Key.W))
            {
                this.actor.SetAnimation("jump");
                this.actor.GetAnimation().Start();
                timer_jump++;
                is_jump= true;
            }
            else if (Input.GetInstance().IsKeyPressed(Input.Key.KP_6))
            {
                this.actor.SetAnimation("fight");
                this.actor.GetAnimation().Start();
                timer_fight++;
            }
            /*
            else if (Input.GetInstance().IsKeyPressed(Input.Key.E))
            {
                this.Use(this.actor);
            }*/
            else
            { 
                if(timer_jump == 0 && timer_fight == 0)
                {
                    this.actor.SetAnimation("stay");
                    this.actor.GetAnimation().Start();
                }
                    
            }
        }
    }
}
