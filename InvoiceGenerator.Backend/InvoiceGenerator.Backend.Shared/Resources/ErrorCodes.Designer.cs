﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InvoiceGenerator.Backend.Shared.Resources {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorCodes {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorCodes() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("InvoiceGenerator.Backend.Shared.Resources.ErrorCodes", typeof(ErrorCodes).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string ERROR_UNEXPECTED {
            get {
                return ResourceManager.GetString("ERROR_UNEXPECTED", resourceCulture);
            }
        }
        
        public static string VAT_NUM_INCORRECT_LENGTH {
            get {
                return ResourceManager.GetString("VAT_NUM_INCORRECT_LENGTH", resourceCulture);
            }
        }
        
        public static string VAT_NUM_ALL_DIGITS_ARE_SAME {
            get {
                return ResourceManager.GetString("VAT_NUM_ALL_DIGITS_ARE_SAME", resourceCulture);
            }
        }
        
        public static string VAT_NUM_INCORRECT_SIGN {
            get {
                return ResourceManager.GetString("VAT_NUM_INCORRECT_SIGN", resourceCulture);
            }
        }
        
        public static string VAT_NUM_INCORRECT_FORMAT {
            get {
                return ResourceManager.GetString("VAT_NUM_INCORRECT_FORMAT", resourceCulture);
            }
        }
        
        public static string VAT_NUM_ZERO_AT_FIRST_OR_THIRD_POSSITION {
            get {
                return ResourceManager.GetString("VAT_NUM_ZERO_AT_FIRST_OR_THIRD_POSSITION", resourceCulture);
            }
        }
        
        public static string VAT_NUM_INCORRECT_CHECK_SUM {
            get {
                return ResourceManager.GetString("VAT_NUM_INCORRECT_CHECK_SUM", resourceCulture);
            }
        }
        
        public static string VAT_NUM_LENGTH_NINE {
            get {
                return ResourceManager.GetString("VAT_NUM_LENGTH_NINE", resourceCulture);
            }
        }
        
        public static string INVALID_PROCESSING_BATCH_KEY {
            get {
                return ResourceManager.GetString("INVALID_PROCESSING_BATCH_KEY", resourceCulture);
            }
        }
        
        public static string INVALID_TEMPLATE_ID {
            get {
                return ResourceManager.GetString("INVALID_TEMPLATE_ID", resourceCulture);
            }
        }
        
        public static string INVALID_TEMPLATE_NAME {
            get {
                return ResourceManager.GetString("INVALID_TEMPLATE_NAME", resourceCulture);
            }
        }
        
        public static string INVALID_CONTENT_TYPE {
            get {
                return ResourceManager.GetString("INVALID_CONTENT_TYPE", resourceCulture);
            }
        }
        
        public static string INVALID_INVOICE_NUMBER {
            get {
                return ResourceManager.GetString("INVALID_INVOICE_NUMBER", resourceCulture);
            }
        }
        
        public static string INVALID_PRIVATE_KEY {
            get {
                return ResourceManager.GetString("INVALID_PRIVATE_KEY", resourceCulture);
            }
        }
        
        public static string INVALID_ASSOCIATED_USER {
            get {
                return ResourceManager.GetString("INVALID_ASSOCIATED_USER", resourceCulture);
            }
        }
        
        public static string DATE_TYPE_MISMATCH {
            get {
                return ResourceManager.GetString("DATE_TYPE_MISMATCH", resourceCulture);
            }
        }
    }
}
