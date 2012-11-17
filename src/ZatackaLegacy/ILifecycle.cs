using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZatackaLegacy
{
    interface ILifecycle
    {
        bool ActiveCycle { get; set; }

        void Enter()
        {
            ActiveCycle = true;
        }
        void Execute()
        {
            ActiveCycle = true;
        }
        void Exit()
        {
            ActiveCycle = false;
        }
    }
    /*public enum Command
    {
        Enter,
        Execute,
        Exit
    }*/
}
