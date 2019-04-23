using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;
using System.IO;

namespace Mutiny_
{
    // Jesper Lundhs arbete
    class MapManager
    {
        #region Declaring variables
        Rectangle drawRectangle_g1, drawRectangle_g2, drawRectangle_g3, drawRectangle_g4, drawRectangle_g5, 
            drawRectangle_g6, drawRectangle_g7, drawRectangle_g8, drawRectangle_g9, drawRectangle_b1, 
            drawRectangle_b2, drawRectangle_b3, drawRectangle_b4, drawRectangle_b5, drawRectangle_b6, 
            drawRectangle_b7, drawRectangle_b8, drawRectangle_b9, drawRectangle_t1, drawRectangle_t2, 
            drawRectangle_o1, drawRectangle_r1, drawRectangle_s1;
        Texture2D jungleTileSheet;
        Tile[,] tileLayer;
        int tileSize, tileAmountWidth, tileAmountHeight, i, j;
        #endregion

        #region Constructor
        public MapManager(Texture2D jungleTileSheet, int tileSize, int tileAmountWidth, int tileAmountHeight)
        {
            this.jungleTileSheet = jungleTileSheet;
            this.tileSize = tileSize;
            this.tileAmountWidth = tileAmountWidth;
            this.tileAmountHeight = tileAmountHeight;
            TileRectangleLoader();
        }
        #endregion

        #region Methods
        // vid namngivning av en ny Tile, bokstäver för terräng, siffror för fiender, symboler för spelare/interaktiva tiles
        public Tile[,] MapBackgroundBuilder()
        {
            List<string> strings = new List<string>();
            StreamReader sr = new StreamReader("BackgroundMap.txt");
            while (!sr.EndOfStream)
            {
                strings.Add(sr.ReadLine());
            }
            sr.Close();
            tileLayer = new Tile[strings[0].Length, strings.Count];
            for (i = 0; i < tileLayer.GetLength(1); i++)
            {
                for (j = 0; j < tileLayer.GetLength(0); j+=2)
                {
                    if (strings[i][j] == 'g' && strings[i][j + 1] == '1')
                    {
                        TileCreator(drawRectangle_g1, false);
                    }
                    else if (strings[i][j] == 'g' && strings[i][j + 1] == '2')
                    {
                        TileCreator(drawRectangle_g2, false);
                    }
                    else if (strings[i][j] == 'g' && strings[i][j + 1] == '3')
                    {
                        TileCreator(drawRectangle_g3, false);
                    }
                    else if (strings[i][j] == 'g' && strings[i][j + 1] == '4')
                    {
                        TileCreator(drawRectangle_g4, false);
                    }
                    else if (strings[i][j] == 'g' && strings[i][j + 1] == '5')
                    {
                        TileCreator(drawRectangle_g5, false);
                    }
                    else if (strings[i][j] == 'g' && strings[i][j + 1] == '6')
                    {
                        TileCreator(drawRectangle_g6, false);
                    }
                    else if (strings[i][j] == 'g' && strings[i][j + 1] == '7')
                    {
                        TileCreator(drawRectangle_g7, false);
                    }
                    else if (strings[i][j] == 'g' && strings[i][j + 1] == '8')
                    {
                        TileCreator(drawRectangle_g8, false);
                    }
                    else if (strings[i][j] == 'g' && strings[i][j + 1] == '9')
                    {
                        TileCreator(drawRectangle_g9, false);
                    }
                    else if (strings[i][j] == 'b' && strings[i][j + 1] == '1')
                    {
                        TileCreator(drawRectangle_b1, false);
                    }
                    else if (strings[i][j] == 'b' && strings[i][j + 1] == '2')
                    {
                        TileCreator(drawRectangle_b2, false);
                    }
                    else if (strings[i][j] == 'b' && strings[i][j + 1] == '3')
                    {
                        TileCreator(drawRectangle_b3, false);
                    }
                    else if (strings[i][j] == 'b' && strings[i][j + 1] == '4')
                    {
                        TileCreator(drawRectangle_b4, false);
                    }
                    else if (strings[i][j] == 'b' && strings[i][j + 1] == '5')
                    {
                        TileCreator(drawRectangle_b5, false);
                    }
                    else if (strings[i][j] == 'b' && strings[i][j + 1] == '6')
                    {
                        TileCreator(drawRectangle_b6, false);
                    }
                    else if (strings[i][j] == 'b' && strings[i][j + 1] == '7')
                    {
                        TileCreator(drawRectangle_b7, false);
                    }
                    else if (strings[i][j] == 'b' && strings[i][j + 1] == '8')
                    {
                        TileCreator(drawRectangle_b8, false);
                    }
                    else if (strings[i][j] == 'b' && strings[i][j + 1] == '9')
                    {
                        TileCreator(drawRectangle_b9, false);
                    }
                    else if (strings[i][j] == 't' && strings[i][j + 1] == '1')
                    {
                        TileCreator(drawRectangle_t1, false);
                    }
                    else if (strings[i][j] == 't' && strings[i][j + 1] == '2')
                    {
                        TileCreator(drawRectangle_t2, true);
                    }
                    else if (strings[i][j] == 'o' && strings[i][j + 1] == '1')
                    {
                        TileCreator(drawRectangle_o1, true);
                    }
                    else if (strings[i][j] == 'r' && strings[i][j + 1] == '1')
                    {
                        TileCreator(drawRectangle_r1, true);
                    }
                    else if (strings[i][j] == 's' && strings[i][j + 1] == '1')
                    {
                        TileCreator(drawRectangle_s1, true);
                    }
                }
            }
            return tileLayer;
        }

        public Tile[,] MapForegroundBuilder()
        {
            List<string> strings = new List<string>();
            StreamReader sr = new StreamReader("ForegroundMap.txt");
            while (!sr.EndOfStream)
            {
                strings.Add(sr.ReadLine());
            }
            sr.Close();
            Tile[,] tileLayer = new Tile[strings[0].Length, strings.Count];
            for (int i = 0; i < tileLayer.GetLength(1); i++)
            {
                for (int j = 0; j < tileLayer.GetLength(0); j++)
                {
                    if (strings[i][j] == '-')
                    {
                        continue;
                    }
                    if (strings[i][j] == 'A')
                    {

                    }
                }
            }            
            return tileLayer;
        }


        private void TileCreator(Rectangle drawRectangle, bool wall)
        {
            tileLayer[j, i] = new Tile(drawRectangle, jungleTileSheet, new Vector2(tileSize * j, tileSize * i), tileSize, wall);
        }
        
        private void TileRectangleLoader()
        {
            drawRectangle_g1 = new Rectangle(0, 0, tileSize, tileSize);
            drawRectangle_g2 = new Rectangle(tileSize, 0, tileSize, tileSize);
            drawRectangle_g3 = new Rectangle(tileSize * 2, 0, tileSize, tileSize);
            drawRectangle_g4 = new Rectangle(0, tileSize, tileSize, tileSize);
            drawRectangle_g5 = new Rectangle(tileSize, tileSize, tileSize, tileSize);
            drawRectangle_g6 = new Rectangle(tileSize * 2, tileSize, tileSize, tileSize);
            drawRectangle_g7 = new Rectangle(0, tileSize * 2, tileSize, tileSize);
            drawRectangle_g8 = new Rectangle(tileSize, tileSize * 2, tileSize, tileSize);
            drawRectangle_g9 = new Rectangle(tileSize * 2, tileSize * 2, tileSize, tileSize);

            drawRectangle_b1 = new Rectangle(tileSize * 3, 0, tileSize, tileSize);
            drawRectangle_b2 = new Rectangle(tileSize * 4, 0, tileSize, tileSize);
            drawRectangle_b3 = new Rectangle(tileSize * 5, 0, tileSize, tileSize);
            drawRectangle_b4 = new Rectangle(tileSize * 3, tileSize, tileSize, tileSize);
            drawRectangle_b5 = new Rectangle(tileSize * 4, tileSize, tileSize, tileSize);
            drawRectangle_b6 = new Rectangle(tileSize * 5, tileSize, tileSize, tileSize);
            drawRectangle_b7 = new Rectangle(tileSize * 3, tileSize * 2, tileSize, tileSize);
            drawRectangle_b8 = new Rectangle(tileSize * 4, tileSize * 2, tileSize, tileSize);
            drawRectangle_b9 = new Rectangle(tileSize * 5, tileSize * 2, tileSize, tileSize);

            drawRectangle_t1 = new Rectangle(tileSize * 6, 0, tileSize, tileSize);
            drawRectangle_t2 = new Rectangle(tileSize * 6, tileSize, tileSize, tileSize);
            drawRectangle_o1 = new Rectangle(tileSize * 6, tileSize * 2, tileSize, tileSize);
            drawRectangle_r1 = new Rectangle(0, tileSize * 3, tileSize, tileSize);
            drawRectangle_s1 = new Rectangle(tileSize, tileSize * 3, tileSize, tileSize);
        }
        #endregion
    }
}
