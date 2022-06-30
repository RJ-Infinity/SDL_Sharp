using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDL_Sharp
{
    public struct Rect
    {
        public int x;

        public int y;

        public int w;

        public int h;
        public static explicit operator Rect(SDL.SDL_Rect r)
        {
            Rect rv = new Rect();
            rv.x = r.x;
            rv.y = r.y;
            rv.w = r.w;
            rv.h = r.h;
            return rv;
        }
        public static explicit operator SDL.SDL_Rect(Rect r)
        {
            SDL.SDL_Rect rv = new SDL.SDL_Rect();
            rv.x = r.x;
            rv.y = r.y;
            rv.w = r.w;
            rv.h = r.h;
            return rv;
        }
    }
}
