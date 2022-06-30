using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDL_Sharp
{
    public class Event
    {
        public SDL.SDL_Event SDLEvent;
        internal Event(SDL.SDL_Event e)
        {
            Type = (EventType)e.type;
            SDLEvent = e;
        }
        public static Event Poll()
        {
            SDL.SDL_Event e = new SDL.SDL_Event();
            if (SDL.SDL_PollEvent(out e) == 0)
            {
                return null;
            }
            return new Event(e);
        }
        public enum EventType : uint
        {
            FIRSTEVENT = SDL.SDL_EventType.SDL_FIRSTEVENT,
            QUIT = SDL.SDL_EventType.SDL_QUIT,
            APP_TERMINATING = SDL.SDL_EventType.SDL_APP_TERMINATING,
            APP_LOWMEMORY = SDL.SDL_EventType.SDL_APP_LOWMEMORY,
            APP_WILLENTERBACKGROUND = SDL.SDL_EventType.SDL_APP_WILLENTERBACKGROUND,
            APP_DIDENTERBACKGROUND = SDL.SDL_EventType.SDL_APP_DIDENTERBACKGROUND,
            APP_WILLENTERFOREGROUND = SDL.SDL_EventType.SDL_APP_WILLENTERFOREGROUND,
            APP_DIDENTERFOREGROUND = SDL.SDL_EventType.SDL_APP_DIDENTERFOREGROUND,
            LOCALECHANGED = SDL.SDL_EventType.SDL_LOCALECHANGED,
            DISPLAYEVENT = SDL.SDL_EventType.SDL_DISPLAYEVENT,
            WINDOWEVENT = SDL.SDL_EventType.SDL_WINDOWEVENT,
            SYSWMEVENT = SDL.SDL_EventType.SDL_SYSWMEVENT,
            KEYDOWN = SDL.SDL_EventType.SDL_KEYDOWN,
            KEYUP = SDL.SDL_EventType.SDL_KEYUP,
            TEXTEDITING = SDL.SDL_EventType.SDL_TEXTEDITING,
            TEXTINPUT = SDL.SDL_EventType.SDL_TEXTINPUT,
            KEYMAPCHANGED = SDL.SDL_EventType.SDL_KEYMAPCHANGED,
            TEXTEDITING_EXT = SDL.SDL_EventType.SDL_TEXTEDITING_EXT,
            MOUSEMOTION = SDL.SDL_EventType.SDL_MOUSEMOTION,
            MOUSEBUTTONDOWN = SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN,
            MOUSEBUTTONUP = SDL.SDL_EventType.SDL_MOUSEBUTTONUP,
            MOUSEWHEEL = SDL.SDL_EventType.SDL_MOUSEWHEEL,
            JOYAXISMOTION = SDL.SDL_EventType.SDL_JOYAXISMOTION,
            JOYBALLMOTION = SDL.SDL_EventType.SDL_JOYBALLMOTION,
            JOYHATMOTION = SDL.SDL_EventType.SDL_JOYHATMOTION,
            JOYBUTTONDOWN = SDL.SDL_EventType.SDL_JOYBUTTONDOWN,
            JOYBUTTONUP = SDL.SDL_EventType.SDL_JOYBUTTONUP,
            JOYDEVICEADDED = SDL.SDL_EventType.SDL_JOYDEVICEADDED,
            JOYDEVICEREMOVED = SDL.SDL_EventType.SDL_JOYDEVICEREMOVED,
            CONTROLLERAXISMOTION = SDL.SDL_EventType.SDL_CONTROLLERAXISMOTION,
            CONTROLLERBUTTONDOWN = SDL.SDL_EventType.SDL_CONTROLLERBUTTONDOWN,
            CONTROLLERBUTTONUP = SDL.SDL_EventType.SDL_CONTROLLERBUTTONUP,
            CONTROLLERDEVICEADDED = SDL.SDL_EventType.SDL_CONTROLLERDEVICEADDED,
            CONTROLLERDEVICEREMOVED = SDL.SDL_EventType.SDL_CONTROLLERDEVICEREMOVED,
            CONTROLLERDEVICEREMAPPED = SDL.SDL_EventType.SDL_CONTROLLERDEVICEREMAPPED,
            CONTROLLERTOUCHPADDOWN = SDL.SDL_EventType.SDL_CONTROLLERTOUCHPADDOWN,
            CONTROLLERTOUCHPADMOTION = SDL.SDL_EventType.SDL_CONTROLLERTOUCHPADMOTION,
            CONTROLLERTOUCHPADUP = SDL.SDL_EventType.SDL_CONTROLLERTOUCHPADUP,
            CONTROLLERSENSORUPDATE = SDL.SDL_EventType.SDL_CONTROLLERSENSORUPDATE,
            FINGERDOWN = SDL.SDL_EventType.SDL_FINGERDOWN,
            FINGERUP = SDL.SDL_EventType.SDL_FINGERUP,
            FINGERMOTION = SDL.SDL_EventType.SDL_FINGERMOTION,
            DOLLARGESTURE = SDL.SDL_EventType.SDL_DOLLARGESTURE,
            DOLLARRECORD = SDL.SDL_EventType.SDL_DOLLARRECORD,
            MULTIGESTURE = SDL.SDL_EventType.SDL_MULTIGESTURE,
            CLIPBOARDUPDATE = SDL.SDL_EventType.SDL_CLIPBOARDUPDATE,
            DROPFILE = SDL.SDL_EventType.SDL_DROPFILE,
            DROPTEXT = SDL.SDL_EventType.SDL_DROPTEXT,
            DROPBEGIN = SDL.SDL_EventType.SDL_DROPBEGIN,
            DROPCOMPLETE = SDL.SDL_EventType.SDL_DROPCOMPLETE,
            AUDIODEVICEADDED = SDL.SDL_EventType.SDL_AUDIODEVICEADDED,
            AUDIODEVICEREMOVED = SDL.SDL_EventType.SDL_AUDIODEVICEREMOVED,
            SENSORUPDATE = SDL.SDL_EventType.SDL_SENSORUPDATE,
            RENDER_TARGETS_RESET = SDL.SDL_EventType.SDL_RENDER_TARGETS_RESET,
            RENDER_DEVICE_RESET = SDL.SDL_EventType.SDL_RENDER_DEVICE_RESET,
            POLLSENTINEL = SDL.SDL_EventType.SDL_POLLSENTINEL,
            USEREVENT = SDL.SDL_EventType.SDL_USEREVENT,
            LASTEVENT = SDL.SDL_EventType.SDL_LASTEVENT
        }
        public EventType Type;
        public SDL.SDL_DisplayEvent display;
        public SDL.SDL_WindowEvent window;
        public SDL.SDL_KeyboardEvent key;
        public SDL.SDL_TextEditingEvent edit;
        public SDL.SDL_TextEditingExtEvent editExt;
        public SDL.SDL_TextInputEvent text;
        public SDL.SDL_MouseMotionEvent motion;
        public SDL.SDL_MouseButtonEvent button;
        public SDL.SDL_MouseWheelEvent wheel;
        public SDL.SDL_JoyAxisEvent jaxis;
        public SDL.SDL_JoyBallEvent jball;
        public SDL.SDL_JoyHatEvent jhat;
        public SDL.SDL_JoyButtonEvent jbutton;
        public SDL.SDL_JoyDeviceEvent jdevice;
        public SDL.SDL_ControllerAxisEvent caxis;
        public SDL.SDL_ControllerButtonEvent cbutton;
        public SDL.SDL_ControllerDeviceEvent cdevice;
        public SDL.SDL_ControllerTouchpadEvent ctouchpad;
        public SDL.SDL_ControllerSensorEvent csensor;
        public SDL.SDL_AudioDeviceEvent adevice;
        public SDL.SDL_SensorEvent sensor;
        public SDL.SDL_QuitEvent quit;
        public SDL.SDL_UserEvent user;
        public SDL.SDL_SysWMEvent syswm;
        public SDL.SDL_TouchFingerEvent tfinger;
        public SDL.SDL_MultiGestureEvent mgesture;
        public SDL.SDL_DollarGestureEvent dgesture;
        public SDL.SDL_DropEvent drop;
    }
}
