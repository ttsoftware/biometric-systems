//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8009
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Neurotec.Samples.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int ConnectionType {
            get {
                return ((int)(this["ConnectionType"]));
            }
            set {
                this["ConnectionType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("localhost")]
        public string HostName {
            get {
                return ((string)(this["HostName"]));
            }
            set {
                this["HostName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("24932")]
        public int AdminPort {
            get {
                return ((int)(this["AdminPort"]));
            }
            set {
                this["AdminPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("25452")]
        public int ClientPort {
            get {
                return ((int)(this["ClientPort"]));
            }
            set {
                this["ClientPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1=What is your grandmother\'s name?;2=Where and when have you been born?;3=What is" +
            " your favourite meal and drink?")]
        public string Phrases {
            get {
                return ((string)(this["Phrases"]));
            }
            set {
                this["Phrases"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string FingerScanner {
            get {
                return ((string)(this["FingerScanner"]));
            }
            set {
                this["FingerScanner"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string IrisScanner {
            get {
                return ((string)(this["IrisScanner"]));
            }
            set {
                this["IrisScanner"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string PalmScanner {
            get {
                return ((string)(this["PalmScanner"]));
            }
            set {
                this["PalmScanner"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string VoiceCaptureDevice {
            get {
                return ((string)(this["VoiceCaptureDevice"]));
            }
            set {
                this["VoiceCaptureDevice"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string FaceCaptureDevice {
            get {
                return ((string)(this["FaceCaptureDevice"]));
            }
            set {
                this["FaceCaptureDevice"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"Fingers.DeterminePatternClass=True;Fingers.CalculateNfiq=True;Fingers.ReturnBinarizedImage=True;Faces.CreateThumbnailImage=True;Faces.DetectAllFeaturePoints=True;Faces.DetermineGender=True;Faces.DetermineAge=True;Faces.DetectProperties=True;Faces.RecognizeExpression=True;Faces.RecognizeEmotion=True;Palms.ReturnBinarizedImage=True;Matching.WithDetails=True;Fingers.CheckForDuplicatesWhenCapturing=True")]
        public string ClientProperties {
            get {
                return ((string)(this["ClientProperties"]));
            }
            set {
                this["ClientProperties"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Subjects")]
        public string TableName {
            get {
                return ((string)(this["TableName"]));
            }
            set {
                this["TableName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string OdbcConnectionString {
            get {
                return ((string)(this["OdbcConnectionString"]));
            }
            set {
                this["OdbcConnectionString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int FingersGeneralizationRecordCount {
            get {
                return ((int)(this["FingersGeneralizationRecordCount"]));
            }
            set {
                this["FingersGeneralizationRecordCount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int FacesGeneralizationRecordCount {
            get {
                return ((int)(this["FacesGeneralizationRecordCount"]));
            }
            set {
                this["FacesGeneralizationRecordCount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int PalmsGeneralizationRecordCount {
            get {
                return ((int)(this["PalmsGeneralizationRecordCount"]));
            }
            set {
                this["PalmsGeneralizationRecordCount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Id IN (</string>
  <string>Id=</string>
  <string>Country=</string>
  <string>City=</string>
  <string>FirstName=</string>
  <string>LastName=</string>
  <string>YearOfBirth &gt;</string>
  <string>GenderString='Male'</string>
  <string>GenderString='Female'</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection QueryAutoComplete {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["QueryAutoComplete"]));
            }
            set {
                this["QueryAutoComplete"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool WarnHasSchema {
            get {
                return ((bool)(this["WarnHasSchema"]));
            }
            set {
                this["WarnHasSchema"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Sample db schema#(FirstName string , LastName string , YearOfBirth int , GenderString string, Country string, City string)#(Thumbnail blob, EnrollData blob)#Gender=GenderString#Thumbnail=Thumbnail#EnrollData=EnrollData</string>
  <string>Remote server schema#(FirstName string , LastName string , YearOfBirth int , GenderString string, Country string, City string)##Gender=GenderString#Thumbnail=#EnrollData=</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection Schemas {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["Schemas"]));
            }
            set {
                this["Schemas"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int CurrentScema {
            get {
                return ((int)(this["CurrentScema"]));
            }
            set {
                this["CurrentScema"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int LocalOperations {
            get {
                return ((int)(this["LocalOperations"]));
            }
            set {
                this["LocalOperations"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool FacesMirrorHorizontally {
            get {
                return ((bool)(this["FacesMirrorHorizontally"]));
            }
            set {
                this["FacesMirrorHorizontally"] = value;
            }
        }
    }
}
