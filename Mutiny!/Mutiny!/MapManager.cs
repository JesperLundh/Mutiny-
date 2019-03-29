using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mutiny_
{
    //använd bitmap? hanterar den initiella skapelsen av vår värld och alla gameobjekt
    // ifall vi använder bitmap så måste vi skriva kod för att läsa av varje pixel, titta på dess färg, och sen använda
    // det för att ladda in en specific tile/fiende/spelare
    // man använder inte bitmap, man använder Texture2D, men det borde fungera likadant
    class MapManager
    {
        Texture2D islandMap;
        Texture2D mapSpriteSheet;
        public MapManager(Texture2D islandMap, Texture2D mapSpriteSheet)
        {
            this.islandMap = islandMap;
            this.mapSpriteSheet = mapSpriteSheet;
        }

        public Tile[,] Mapbuilder()
        {

        }
    }
}
