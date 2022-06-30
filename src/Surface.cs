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
        ~Surface()
        {
            SDL.SDL_FreeSurface(InternalSurface);
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
            if (rSrc == new Rect { x = 0, y = 0, w = 0, h = 0 } && rDest == new Rect { x = 0, y = 0, w = 0, h = 0 })
            {
                if (SDL.SDL_BlitSurface(InternalSurface, IntPtr.Zero, surface.InternalSurface, IntPtr.Zero) < 0)
                {
                    throw new SDLException(SDL.SDL_GetError());
                }
                return;
            }
            SDL.SDL_Rect rSrcInt = (SDL.SDL_Rect)rSrc;
            SDL.SDL_Rect rDestInt = (SDL.SDL_Rect)rDest;
            if (rSrc == new Rect { x = 0, y = 0, w = 0, h = 0 })
            {
                if (SDL.SDL_BlitSurface(InternalSurface, IntPtr.Zero, surface.InternalSurface, ref rDestInt) < 0)
                {
                    throw new SDLException(SDL.SDL_GetError());
                }
                return;
            }
            if (rDest == new Rect { x = 0, y = 0, w = 0, h = 0 })
            {
                if (SDL.SDL_BlitSurface(InternalSurface, ref rSrcInt, surface.InternalSurface, IntPtr.Zero) < 0)
                {
                    throw new SDLException(SDL.SDL_GetError());
                }
                return;
            }
            if (SDL.SDL_BlitSurface(InternalSurface, ref rSrcInt, surface.InternalSurface, ref rDestInt) < 0)
            {
                throw new SDLException(SDL.SDL_GetError());
            }
        }
        public void FillRect(Rect rect, Colour colour)
        {
            if (rect == new Rect { x=0, y=0, w=0, h=0})
            {
                if (SDL.SDL_FillRect(InternalSurface, IntPtr.Zero, (uint)colour) < 0)
                {
                    throw new SDLException(SDL.SDL_GetError());
                }
                return;
            }
            SDL.SDL_Rect rectInt = (SDL.SDL_Rect)rect;
            if (SDL.SDL_FillRect(InternalSurface, ref rectInt, (uint)colour) < 0)
            {
                throw new SDLException(SDL.SDL_GetError());
            }
        }
        public void BlitFrom(Surface surface, Rect rSrc, Rect rDest)=>surface.BlitTo(rSrc, this, rDest);
    }
}
