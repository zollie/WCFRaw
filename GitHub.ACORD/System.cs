
/* Hack to get Xsd bindings to compile
 * for SL
 */
#if SILVERLIGHT
namespace System
{
    using Diagnostics;

    [Conditional("THIS_IS_NEVER_TRUE")]
    public class SerializableAttribute : Attribute {}

    [Conditional("THIS_IS_NEVER_TRUE")]
    public class NonSerializedAttribute : Attribute {}
}
#endif
