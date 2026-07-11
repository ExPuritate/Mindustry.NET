using Arc.Files;

namespace Arc
{
    /// <summary>
    /// <p>
    /// An <code>IApplicationListener</code> is called when the <see cref="IApplication"/> is created, resumed, rendering, paused or destroyed.
    /// All methods are called in a thread that has the OpenGL context current. You can thus safely create and manipulate graphics
    /// resources.
    /// </p>
    /// 
    /// <p>
    /// The <code>ApplicationListener</code> interface follows the standard Android activity life-cycle and is emulated on the desktop
    /// accordingly.
    /// </p>
    /// </summary>
    public interface IApplicationListener
    {

        /// <summary>
        /// Called when the <see cref="IApplication" /> is first created.
        /// Only gets called if the application is created before the listener is added.
        /// </summary>
        void Init()
        {
        }

        /// <summary>
        /// Called when the <see cref="IApplication" /> is resized. This can happen at any point during a non-paused state but will never happen
        /// before a call to <see cref="Init" />.
        /// </summary>
        /// 
        /// <param name="width">the new width in pixels</param>
        /// <param name="height">the new height in pixels</param>
        void Resize(int width, int height)
        {
        }

        /// <summary>
        /// Called when the <see cref="IApplication" /> should update itself.
        /// </summary>
        void Update()
        {
        }

        /// <summary>
        /// Called when the <see cref="IApplication" /> is paused, usually when it's not active or visible on screen. An Application is also
        /// paused before it is destroyed.
        /// </summary>
        void Pause()
        {
        }

        /// Called when the <see cref="IApplication" /> is resumed from a paused state, usually when it regains focus.
        void Resume()
        {
        }

        /// Called when the <see cref="IApplication" /> is destroyed. Preceded by a call to <see cref="Pause"/>.
        void Dispose()
        {
        }

        /// <summary>
        /// Called when the applications exits gracefully, either through <code>Core.app.exit()</code> or through a window closing.
        /// Never called after a crash, unlike dispose().
        /// </summary>
        void Exit()
        {

        }

        /// <summary>
        /// Called when an external file is dropped into the window, e.g from the desktop.
        /// </summary>
        void FileDropped(Fi file)
        {
        }
    }
}
