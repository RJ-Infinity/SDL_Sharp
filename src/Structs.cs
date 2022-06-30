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
    public struct Colour
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;
        public static explicit operator uint(Colour c) =>
            (uint) (c.r | (c.g << 8) | (c.b << 16) | (c.a << 24));
        public static explicit operator Colour(uint n)
        {
            Colour c = new Colour();
            c.r =(byte)n;
            c.g = (byte)(n >> 8);
            c.b = (byte)(n >> 16);
            c.a = (byte)(n >> 24);
            return c;
        }
    }
}
