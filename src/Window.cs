using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDL_Sharp
{
    public class Window
    {
        public const int WINDOWPOS_CENTERED = SDL.SDL_WINDOWPOS_CENTERED;
        internal IntPtr InternalWindow;
        public int Width;
        public int Height;
        public string Title;
        internal Window(IntPtr internalWindow)
        {
            InternalWindow = internalWindow;
            SDL.SDL_GetWindowSize(InternalWindow,out Width, out Height);
            Title = SDL.SDL_GetWindowTitle(InternalWindow);
        }

        public Window(string title, int width, int height)
        {
            SDL.SDL_SetHint(SDL.SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING, "1");
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                throw new SDLException(SDL.SDL_GetError());
            }
            Title = title;
            Width = width;
            Height = height;
        }
        ~Window()
        {
            SDL.SDL_DestroyWindow(InternalWindow);
            SDL.SDL_Quit();
        }
        public void CreateWindow(int x = WINDOWPOS_CENTERED, int y = WINDOWPOS_CENTERED)
        {
            InternalWindow = SDL.SDL_CreateWindow(
                "Test",
                x, y,
                Width, Height,
                (SDL.SDL_WindowFlags)WindowFlags.SHOWN
            );
            if (InternalWindow == IntPtr.Zero)
            {
                throw new SDLException(SDL.SDL_GetError());
            }
            SDL.SDL_UpdateWindowSurface(InternalWindow);
        }
        public void Render()
        {
            if (SDL.SDL_UpdateWindowSurface(InternalWindow) < 0)
            {
                throw new SDLException(SDL.SDL_GetError());
            }
        }
        public Surface GetSurface()
        {
            IntPtr surface = SDL.SDL_GetWindowSurface(InternalWindow);
            if (surface == IntPtr.Zero)
            {
                throw new SDLException(SDL.SDL_GetError());
            }
            return new Surface(surface);
        }
        public Window FixBrokenWindow() => new Window(InternalWindow);
        public enum WindowFlags : uint
        {
            FULLSCREEN = SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN,
            OPENGL = SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL,
            SHOWN = SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN,
            HIDDEN = SDL.SDL_WindowFlags.SDL_WINDOW_HIDDEN,
            BORDERLESS = SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS,
            RESIZABLE = SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE,
            MINIMIZED = SDL.SDL_WindowFlags.SDL_WINDOW_MINIMIZED,
            MAXIMIZED = SDL.SDL_WindowFlags.SDL_WINDOW_MAXIMIZED,
            MOUSE_GRABBED = SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_GRABBED,
            INPUT_FOCUS = SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS,
            MOUSE_FOCUS = SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS,
            FULLSCREEN_DESKTOP = SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP,
            FOREIGN = SDL.SDL_WindowFlags.SDL_WINDOW_FOREIGN,
            ALLOW_HIGHDPI = SDL.SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI,
            MOUSE_CAPTURE = SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_CAPTURE,
            ALWAYS_ON_TOP = SDL.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP,
            SKIP_TASKBAR = SDL.SDL_WindowFlags.SDL_WINDOW_SKIP_TASKBAR,
            UTILITY = SDL.SDL_WindowFlags.SDL_WINDOW_UTILITY,
            TOOLTIP = SDL.SDL_WindowFlags.SDL_WINDOW_TOOLTIP,
            POPUP_MENU = SDL.SDL_WindowFlags.SDL_WINDOW_POPUP_MENU,
            KEYBOARD_GRABBED = SDL.SDL_WindowFlags.SDL_WINDOW_KEYBOARD_GRABBED,
            VULKAN = SDL.SDL_WindowFlags.SDL_WINDOW_VULKAN,
            METAL = SDL.SDL_WindowFlags.SDL_WINDOW_METAL,
            INPUT_GRABBED = SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_GRABBED
        }
    }
}