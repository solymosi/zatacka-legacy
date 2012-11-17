using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZatackaLegacy
{
    interface IState : ILifecycle
    {
        string StateName { get; set; }
        
        void Active()
        {
        }
        void Inactive()
        {
        }
        void Paused()
        {
        }
        void Terminated()
        {
        }
    }

    /*public enum States
    {
        Active,
        Inactive,
        Paused,
        Terminated
    }*/
}
