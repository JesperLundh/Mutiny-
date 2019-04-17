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
        Rectangle drawRectangle_a, drawRectangle_b, drawRectangle_c, drawRectangle_d, drawRectangle_e;
        Texture2D islandTiles;
        Tile[,] tileLayer;
        int tileSize, tileAmountWidth, tileAmountHeight, i, j;
        #endregion

        #region Constructor
        public MapManager(Texture2D islandTiles, int tileSize, int tileAmountWidth, int tileAmountHeight)
        {
            this.islandTiles = islandTiles;
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
                for (j = 0; j < tileLayer.GetLength(0); j++)
                {
                    if (strings[i][j] == 'a')
                    {
                        TileCreator(drawRectangle_a, false);
                    }
                    else if (strings[i][j] == 'b')
                    {
                        TileCreator(drawRectangle_b, false);
                    }
                    else if (strings[i][j] == 'c')
                    {
                        TileCreator(drawRectangle_c, false);
                    }
                    else if (strings[i][j] == 'd')
                    {
                        TileCreator(drawRectangle_d, false);
                    }
                    else if (strings[i][j] == 'e')
                    {
                        TileCreator(drawRectangle_e, false);
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
            tileLayer[j, i] = new Tile(drawRectangle, islandTiles, new Vector2(tileSize * j, tileSize * i), tileSize, wall);
        }
        
        private void TileRectangleLoader()
        {
            drawRectangle_a = new Rectangle(0, 0, tileSize, tileSize);
            drawRectangle_b = new Rectangle(tileSize, 0, tileSize, tileSize);
            drawRectangle_c = new Rectangle(tileSize * 2, 0, tileSize, tileSize);
            drawRectangle_d = new Rectangle(tileSize * 3, 0, tileSize, tileSize);
            drawRectangle_e = new Rectangle(tileSize * 4, 0, tileSize, tileSize);
        }
        #endregion
    }
}
