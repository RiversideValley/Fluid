using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Riverside.Fluid;

public static class Runtime
{
    public static string Location = System.IO.Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule!.FileName);
    public static string Extension = "py"; // Change this when support added for Fluid's own file extension.
}

/*
try
{
    using Riverside.Runtime;
}
catch (System.Exception)
{
    // Handle the exception if necessary
}

try
{
    using Riverside.UI;
}
catch (System.Exception)
{
    // Handle the exception if necessary
}
*/

public class Exception
{
    /// <summary>
    /// Exception thrown when an error occurs in the Fluid API, or when an error from the library is thrown.
    /// </summary>
    /// <remarks>
    /// Usually, derivatives are used instead of this class, to allow for easier handling of specific errors.
    /// </remarks>
    public class Error : System.Exception
    {
        private const string DefaultErrorMessage = "An unexpected error occurred.";

        /// <inheritdoc />
        public override string Message { get; }

        internal Error(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        internal Error() : this(DefaultErrorMessage)
        { }
    }

    /// <summary>
    /// Inexplicable error or one that is impossible to solve (an unrecoverable fatal error)
    /// </summary>
    /// <remarks>
    /// Use for easter eggs in applications.
    /// </remarks>
    public class Maloote()
        : Error("An application-internal exception occured.");

    /// <summary>
    /// There was a problem processing the function or class's request arguments.
    /// </summary>
    public class ArgumentError()
        : Error("There was a problem processing the function or class's request arguments.");

    public class FoundationCloneError()
        : Error("There was a problem cloning the Foundation package.");

    public class FrameworkArchitectureError()
        : Error("An error occured due to the way the Python and C-based Fluid backends were built which contradicts the code of the Fluid Runtime.");
}