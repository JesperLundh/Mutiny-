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
    //använd bitmap? hanterar den initiella skapelsen av vår värld och alla gameobjekt
    // ifall vi använder bitmap så måste vi skriva kod för att läsa av varje pixel, titta på dess färg, och sen använda
    // det för att ladda in en specific tile/fiende/spelare
    // man använder inte bitmap, man använder Texture2D, men det borde fungera likadant
    class MapManager

    {
        Rectangle tile_a, tile_b, tile_c, tile_d, tile_e;
        Texture2D islandTiles;
        public MapManager(Texture2D islandTiles)
        {
            this.islandTiles = islandTiles;

            SetMapVariables();
        }
#region Loading Variables for Tiles
        void SetMapVariables()
        {
            tile_a = new Rectangle(0, 0, 64, 64);
            tile_b = new Rectangle(64, 0, 64, 64);
            tile_c = new Rectangle(128, 0, 64, 64);
            tile_d = new Rectangle(192, 0, 64, 64);
            tile_e = new Rectangle(256, 0, 64, 64);
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

            for (int i = 0; i < tiles.GetLength(1); i++)
            {
                for (int j = 0; j < tiles.GetLength(0); j++)
                {
                    if (strings[i][j] == 'a')
                    {
                        tiles[j, i] = new Tile(tile_a, islandTiles, new Vector2(32 * j, 32 * i));
                    }
                    else if (strings[i][j] == 'b')
                    {
                        tiles[j, i] = new Tile(tile_b, islandTiles, new Vector2(32 * j, 32 * i));
                    }
                    else if (strings[i][j] == 'c')
                    {
                        tiles[j, i] = new Tile(tile_c, islandTiles, new Vector2(32 * j, 32 * i));
                    }
                    else if (strings[i][j] == 'd')
                    {
                        tiles[j, i] = new Tile(tile_d, islandTiles, new Vector2(32 * j, 32 * i));
                    }
                    else if (strings[i][j] == 'e')
                    {
                        tiles[j, i] = new Tile(tile_e, islandTiles, new Vector2(32 * j, 32 * i));
                    }
                }
            }
            return tiles;
        }
        #endregion
    }
}
