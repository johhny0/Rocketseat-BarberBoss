﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class PaymentMethodResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PaymentMethodResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Domain.Resources.PaymentMethodResource", typeof(PaymentMethodResource).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bank Slip.
        /// </summary>
        internal static string BANK_SLIP {
            get {
                return ResourceManager.GetString("BANK_SLIP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Credit Card.
        /// </summary>
        internal static string CREDIT_CARD {
            get {
                return ResourceManager.GetString("CREDIT_CARD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debit Card.
        /// </summary>
        internal static string DEBIT_CARD {
            get {
                return ResourceManager.GetString("DEBIT_CARD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FedNow.
        /// </summary>
        internal static string FEDNOW {
            get {
                return ResourceManager.GetString("FEDNOW", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Money.
        /// </summary>
        internal static string MONEY {
            get {
                return ResourceManager.GetString("MONEY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to On Credit.
        /// </summary>
        internal static string ON_CREDIT {
            get {
                return ResourceManager.GetString("ON_CREDIT", resourceCulture);
            }
        }
    }
}
