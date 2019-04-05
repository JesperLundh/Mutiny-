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
        Rectangle drawRectangle_a, drawRectangle_b, drawRectangle_c, drawRectangle_d, drawRectangle_e;
        Texture2D islandTiles;
        int tileSize, tileAmountWidth, tileAmountHeight;
        public MapManager(Texture2D islandTiles, int tileSize, int tileAmountWidth, int tileAmountHeight)
        {
            this.islandTiles = islandTiles;
            this.tileSize = tileSize;
            this.tileAmountWidth = tileAmountWidth;
            this.tileAmountHeight = tileAmountHeight;
            SetMapVariables();
        }
#region Loading Variables for Tiles
        void SetMapVariables()
        {
            drawRectangle_a = new Rectangle(0, 0, tileSize, tileSize);
            drawRectangle_b = new Rectangle(tileSize, 0, tileSize, tileSize);
            drawRectangle_c = new Rectangle(tileSize*2, 0, tileSize, tileSize);
            drawRectangle_d = new Rectangle(tileSize*3, 0, tileSize, tileSize);
            drawRectangle_e = new Rectangle(tileSize*4, 0, tileSize, tileSize);
        }
        #endregion

 #region Mapbuilder
        // vid namngivning av en ny Tile, bokstäver för terräng, siffror för fiender, symboler för spelare/interaktiva tiles
        public Tile[,] Mapbuilder()
        {
            List<string> strings = new List<string>();
            StreamReader sr = new StreamReader("OverWorldMap.txt");
            while (!sr.EndOfStream)
            {
                strings.Add(sr.ReadLine());
            }
            sr.Close();
            Tile[,] tiles = new Tile[strings[0].Length, strings.Count];
            //försökte effektivisera detta arbete, finns en övning på detta i supermario projektet, ska titta på det
            for (int i = 0; i < tiles.GetLength(1); i++)
            {
                for (int j = 0; j < tiles.GetLength(0); j++)
                {
                    if (strings[i][j] == 'a')
                    {
                        Rectangler(drawRectangle_a, i, j, tiles);
                    }
                    else if (strings[i][j] == 'b')
                    {
                        Rectangler(drawRectangle_b, i, j, tiles);
                    }
                    else if (strings[i][j] == 'c')
                    {
                        Rectangler(drawRectangle_c, i, j, tiles);
                    }
                    else if (strings[i][j] == 'd')
                    {
                        Rectangler(drawRectangle_d, i, j, tiles);
                    }
                    else if (strings[i][j] == 'e')
                    {
                        Rectangler(drawRectangle_e, i, j, tiles);
                    }
                }
            }
            return tiles;
        }
        #endregion       

        private void Rectangler(Rectangle drawRectangle, int i, int j, Tile[,] tiles)
        {
            tiles[j, i] = new Tile(drawRectangle, islandTiles, new Vector2(tileSize * j, tileSize * i), tileSize);
        }
    }
}
