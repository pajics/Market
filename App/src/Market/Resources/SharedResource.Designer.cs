﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Market.Resources {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SharedResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal SharedResource() {
        }
        
        /// <summary>
        ///    Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Market.Resources.SharedResource", typeof(SharedResource).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    Overrides the current thread's CurrentUICulture property for all
        ///    resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to loading....
        /// </summary>
        internal static string Loader {
            get {
                return ResourceManager.GetString("Loader", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Company working hours.
        /// </summary>
        internal static string WorkingHours_Header {
            get {
                return ResourceManager.GetString("WorkingHours_Header", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Saturday:.
        /// </summary>
        internal static string WorkingHours_Saturday {
            get {
                return ResourceManager.GetString("WorkingHours_Saturday", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Sunday:.
        /// </summary>
        internal static string WorkingHours_Sunday {
            get {
                return ResourceManager.GetString("WorkingHours_Sunday", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Monday-Friday:.
        /// </summary>
        internal static string WorkingHours_Week {
            get {
                return ResourceManager.GetString("WorkingHours_Week", resourceCulture);
            }
        }
    }
}