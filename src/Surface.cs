using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDL_Sharp
{
    public class Surface
    {
        internal IntPtr InternalSurface;
        internal Surface(IntPtr internalSerface)
        {
            InternalSurface = internalSerface;
        }
        public static Surface LoadBitmap(string file)
        {
            IntPtr rv = SDL.SDL_LoadBMP(file);
            if (rv == IntPtr.Zero)
            {
                throw new SDLException(SDL.SDL_GetError());
            }
            return new Surface(rv);
        }
        public void BlitTo(Rect rSrc, Surface surface, Rect rDest)
        {
            SDL.SDL_Rect rSrcInt = (SDL.SDL_Rect)rSrc;
            SDL.SDL_Rect rDestInt = (SDL.SDL_Rect)rDest;
            if (SDL.SDL_BlitSurface(InternalSurface, ref rSrcInt, surface.InternalSurface, ref rDestInt) < 0)
            {
                throw new SDLException(SDL.SDL_GetError());
            }
        }
        public void BlitFrom(Surface surface, ref Rect rSrc, ref Rect rDest)=>surface.BlitTo(rSrc, this, rDest);
    }
}
