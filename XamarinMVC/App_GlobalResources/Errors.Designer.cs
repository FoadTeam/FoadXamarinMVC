﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XamarinMVC.App_GlobalResources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Errors {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Errors() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("XamarinMVC.App_GlobalResources.Errors", typeof(Errors).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your Entry Code Is Not Valid.
        /// </summary>
        public static string ActivationCodeError {
            get {
                return ResourceManager.GetString("ActivationCodeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your Mobile Number Is Invalid.
        /// </summary>
        public static string CheckMobile {
            get {
                return ResourceManager.GetString("CheckMobile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password and Confirm Password Should be match.
        /// </summary>
        public static string ComparePassword {
            get {
                return ResourceManager.GetString("ComparePassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please Enter {0} in Currect Type.
        /// </summary>
        public static string CurrectType {
            get {
                return ResourceManager.GetString("CurrectType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed Login.
        /// </summary>
        public static string FailedLogin {
            get {
                return ResourceManager.GetString("FailedLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not more than {1} character.
        /// </summary>
        public static string MaxLength {
            get {
                return ResourceManager.GetString("MaxLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Old Password Is Incurrect.
        /// </summary>
        public static string OldPasswordIsIncurrect {
            get {
                return ResourceManager.GetString("OldPasswordIsIncurrect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This Mobile is already registered.
        /// </summary>
        public static string RepeatMobile {
            get {
                return ResourceManager.GetString("RepeatMobile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please Enter {0} field.
        /// </summary>
        public static string Required {
            get {
                return ResourceManager.GetString("Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have no registered address.
        /// </summary>
        public static string YouHaveNoRegisteredAddress {
            get {
                return ResourceManager.GetString("YouHaveNoRegisteredAddress", resourceCulture);
            }
        }
    }
}
