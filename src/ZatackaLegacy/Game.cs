using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy
{
    abstract class Game : StateMachine
    {
        public long Time { get; private set; }
        public double CurveRadius { get; protected set; }
        public double SteeringSensitivity { get; protected set; }
        public double MovementSpeed { get; protected set; }
        public Pool Pool { get; protected set; }
        public Log Log { get; private set; }
        public List<Player> Players { get; private set; }
        public bool Running { get; private set; }

        private IState current;
        private List<IState> states;

        public IState Current
        {
            get { return current; }
            set { current = value; }
        }
        public List<IState> States
        {
            get { return states; }
            set { states = value; }
        }

        public Game(IState Current, List<IState> States, Size Size) : base(Current,States)
        {
            Time = 0;
            CurveRadius = 3;
            SteeringSensitivity = 5;
            MovementSpeed = 3;
            Running = false;

            Pool = new Pool(this, Size);
            Players = new List<Player>();

            Log = new Log(this);
            Pool.AddUnit(Log);
        }

        protected void Start()
        {
            Running = true;
        }

        protected void Stop()
        {
            Running = false;
        }

        public void Tick()
        {
            if (!Running) { return; }
            Time++;
            Pool.CheckCollision();
            Update();
        }

        public abstract void Initialize();
        protected abstract void Update();

        public void Input(Action Action) { Input(null, Action); }
        public abstract void Input(Player Player, Action Action);




        public override void Enter()
        {
            base.Enter();
        }
        public override void Execute()
        {
            base.Execute();
        }
        public override void Exit()
        {
            base.Exit();
        }
        public override void Active()
        {
             base.Active();
        }
        public override void Inactive()
        {
            base.Inactive();
        }
        public override void Paused()
        {
            base.Paused();
        }
        public override void Terminated()
        {
            base.Terminated();
        }
    }
}