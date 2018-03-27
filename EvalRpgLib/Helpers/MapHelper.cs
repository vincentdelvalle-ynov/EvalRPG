using EvalRpgLib.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Helpers
{
    public static class MapHelper
    {
        
        /// <summary>
        /// Retourne le décalage sur X et Y en fonction d'une direction
        /// </summary>
        /// <param name="direction">Une direction</param>
        /// <returns>un tableau d'entier avec : 0 => X, 1 => Y</returns>
        public static int[] GetDirectionOffset(DirectionEnum direction)
        {
            switch (direction)
            {
                case (DirectionEnum.North):
                    return new int[] { 0, -1 };
                    break;
                case (DirectionEnum.West):
                    return new int[] { -1, 0 };
                    break;
                case (DirectionEnum.South):
                    return new int[] { 0, 1 };
                    break;
                case (DirectionEnum.Est):
                    return new int[] { 1, 0 };
                    break;


            }
            // TODO
            return new int[] { 0, 0 };
        }



    }
}
