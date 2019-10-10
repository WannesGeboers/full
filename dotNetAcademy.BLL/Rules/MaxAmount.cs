using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace dotNetAcademy.BLL.Rules
{
    public static class MaxAmount
    {

        //rule max 100 participants allowed in system
        public static int MaxParticipantsInSystem = 100;

        public static bool IsReached(int allowedNumber,int tryNumber)
        {
            return allowedNumber < tryNumber;
        }

        public static void ChangeMaxParticipantsInSystemTo(int number)
        {
            MaxParticipantsInSystem = number;
        }
    }
}
