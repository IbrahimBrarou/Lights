using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semestre1project
{
    class Park
    {
        LightPole[,] area;
        public Park(int width, int height, int NumberOfLightPoles, int[] LightsArray,int range)
        {
            area = new LightPole[height, width];
            LightPositions(NumberOfLightPoles, LightsArray, range);
        }
        private void LightPositions(int NumberOfLightPoles, int[] LightsArray, int range)
        {
            int Xindexer = 0;
            int Yindexer = 1;
            for (int i = 0; i < NumberOfLightPoles; i++)
            {
                LightPole lightpole;
                lightpole = new LightPole(range, LightsArray[Xindexer], LightsArray[Yindexer]);
                area[lightpole.Xposition-1, lightpole.Ypostion-1] = lightpole;
                Xindexer = Xindexer + 2;
                Yindexer = Yindexer + 2;
                for (int j = 1; j < (range/2)+1; j++)
                {
                    int a = lightpole.Xposition-1;
                    int b = lightpole.Ypostion-1;
                    int c = area.GetLength(0);
                    int d = area.GetLength(1);

                    for (int k = 1; k < (range / 2) + 1; k++)
                    {
                        if (b+j < d)
                        {
                            area[a, b + j] = lightpole;
                        }
                        if (b-j >= 0)
                        {
                            area[a, b - j] = lightpole;
                        }
                        if (a-k >= 0)
                        {
                            area[a-k, b] = lightpole;
                        }
                        if (a+k < c)
                        {
                            area[a + k, b] = lightpole;
                        }
                        if (a-k >= 0 && b+j < d)
                        {
                            area[a - k, b + j] = lightpole;
                        }
                        if (a - k >= 0 && b - j >= 0)
                        {
                            area[a - k, b - j] = lightpole;
                        }
                        
                        if (a + k < c  && b + j < d)
                        {
                            area[a + k, b + j] = lightpole;
                        }
                        if (a + k < c && b - j >= 0)
                        {
                            area[a + k, b - j] = lightpole;
                        }
                    }
                }
                
            }
        }
        public char[,] ChangerToChar()
        {
            char[,] resul = new char[area.GetLength(0), area.GetLength(1)];
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    if (area[i, j] == null)
                    {
                        resul[i, j] = 'U';
                    }
                    else
                    {
                        resul[i, j] = 'S';
                    }

                }
            }

            return resul;
        }
    }
}
