using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZatackaLegacy
{
    interface ILifecycle
    {
        void Enter();
        void Execute();
        void Exit();
    }
}