﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime : 15.0.0.0
//  
//     Les changements apportés à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Kinetix.ClassGenerator.JavascriptGenerator
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class TypescriptTemplate : TypescriptTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("/*\r\n    Ce fichier a été généré automatiquement.\r\n    Toute modification sera per" +
                    "due.\r\n*/\r\n\r\nimport {");
            
            #line 11 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FocusImport));
            
            #line default
            #line hidden
            this.Write("} from \"focus4/entity\";\r\nimport {");
            
            #line 12 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Join(", ", GetDomainList())));
            
            #line default
            #line hidden
            this.Write("} from \"../../domains\";\r\n");
            
            #line 13 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 var imports = GetImportList();
   foreach (var import in imports) { 

            
            #line default
            #line hidden
            this.Write("\r\nimport {");
            
            #line 17 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(import.Item1));
            
            #line default
            #line hidden
            this.Write("} from \"");
            
            #line 17 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(import.Item2));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 17 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(import.Item3));
            
            #line default
            #line hidden
            this.Write("\";");
            
            #line 17 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 
} if (imports.Any()) { 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 20 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\nexport interface ");
            
            #line 22 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            
            #line 22 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 if (Model.ParentClass != null) { 
            
            #line default
            #line hidden
            this.Write(" extends ");
            
            #line 22 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.ParentClass.Name));
            
            #line default
            #line hidden
            
            #line 22 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(" {\r\n");
            
            #line 23 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 foreach (var property in Model.PropertyList) { 
            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 24 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToFirstLower(property.Name)));
            
            #line default
            #line hidden
            
            #line 24 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.DataMember.IsRequired && !property.IsPrimaryKey || property.DataType != "int?" && property.IsPrimaryKey || IsArray(property) || property.IsFromComposition ? string.Empty : "?"));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 24 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ToTSType(property)));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 25 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("}\r\n\r\nexport interface ");
            
            #line 28 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("Node extends ");
            
            #line 28 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 if (Model.ParentClass == null) { 
            
            #line default
            #line hidden
            this.Write("StoreNode<");
            
            #line 28 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(">");
            
            #line 28 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            
            #line 28 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.ParentClass.Name));
            
            #line default
            #line hidden
            this.Write("Node");
            
            #line 28 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(" {\r\n");
            
            #line 29 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 foreach (var property in Model.PropertyList) { 
            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 30 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToFirstLower(property.Name)));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 30 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 
        if (IsArray(property)) { 
            
            
            #line default
            #line hidden
            this.Write("StoreListNode<");
            
            #line 32 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 
        } else if (!property.IsFromComposition) {
            
            
            #line default
            #line hidden
            this.Write("EntityField<");
            
            #line 34 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 
        } 
            
            #line default
            #line hidden
            
            #line 35 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ToTSType(property, true)));
            
            #line default
            #line hidden
            
            #line 35 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetReferencedType(property) != null ? "Node" : string.Empty));
            
            #line default
            #line hidden
            
            #line 35 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"

        if (GetDomain(property) != null) { 
                
            
            #line default
            #line hidden
            this.Write(", typeof ");
            
            #line 37 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetDomain(property)));
            
            #line default
            #line hidden
            
            #line 37 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 }
        
            
            #line default
            #line hidden
            
            #line 38 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 
        if (IsArray(property) || !property.IsFromComposition) { 
            
            
            #line default
            #line hidden
            this.Write(">");
            
            #line 40 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 
        } 
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 42 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } 
            
            #line default
            #line hidden
            
            #line 42 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"

    if (Model.ParentClass != null) {
    
            
            #line default
            #line hidden
            this.Write("    set(config: Partial<");
            
            #line 44 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(">): void;\r\n");
            
            #line 45 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 }

            
            #line default
            #line hidden
            this.Write("}\r\n\r\nexport const ");
            
            #line 49 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("Entity = {\r\n    name: \"");
            
            #line 50 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToFirstLower(Model.Name)));
            
            #line default
            #line hidden
            this.Write("\",\r\n    fields: {\r\n");
            
            #line 52 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 if (Model.ParentClass != null) { 
            
            #line default
            #line hidden
            this.Write("        ...");
            
            #line 53 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.ParentClass.Name));
            
            #line default
            #line hidden
            this.Write("Entity.fields,\r\n");
            
            #line 54 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } 
            
            #line default
            #line hidden
            
            #line 55 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 foreach (var property in Model.PropertyList) { 
            
            #line default
            #line hidden
            this.Write("        ");
            
            #line 56 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToFirstLower(property.Name)));
            
            #line default
            #line hidden
            this.Write(": {\r\n            ");
            
            #line 57 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 if (!IsArray(property) && !property.IsFromComposition) { 
            
            #line default
            #line hidden
            this.Write("name: \"");
            
            #line 57 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToFirstLower(property.Name)));
            
            #line default
            #line hidden
            this.Write("\",\r\n            ");
            
            #line 58 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("type: ");
            
            #line 58 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 if (IsArray(property)) { 
            
            #line default
            #line hidden
            this.Write("\"list\" as \"list\"");
            
            #line 58 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } else if (property.IsFromComposition) { 
            
            #line default
            #line hidden
            this.Write("\"object\" as \"object\"");
            
            #line 58 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("\"field\" as \"field\"");
            
            #line 58 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(",\r\n            ");
            
            #line 59 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 if (GetDomain(property) != null) { 
                 
            
            #line default
            #line hidden
            this.Write("domain: ");
            
            #line 60 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetDomain(property)));
            
            #line default
            #line hidden
            this.Write(",\r\n            ");
            
            #line 61 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } else {
                 
            
            #line default
            #line hidden
            this.Write("entityName: \"");
            
            #line 62 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToFirstLower(GetReferencedType(property))));
            
            #line default
            #line hidden
            this.Write("\"");
            
            #line 62 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 
                 if (!IsArray(property) && !property.IsFromComposition) { 
            
            #line default
            #line hidden
            this.Write(",\r\n            ");
            
            #line 64 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
    } else { 
            
            #line default
            #line hidden
            this.Write("\r\n        ");
            
            #line 66 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
        }
               } if (!IsArray(property) && !property.IsFromComposition) { 
                 
            
            #line default
            #line hidden
            this.Write("isRequired: ");
            
            #line 68 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToFirstLower((property.DataMember.IsRequired && (!property.IsPrimaryKey || property.DataType != "int?")).ToString())));
            
            #line default
            #line hidden
            this.Write(",\r\n            ");
            
            #line 69 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } 
            
            #line default
            #line hidden
            
            #line 69 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 if (!IsArray(property) && !property.IsFromComposition) { 
                 
            
            #line default
            #line hidden
            this.Write("label: \"");
            
            #line 70 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToNamespace(Model.Namespace.Name)));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 70 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToFirstLower(Model.Name)));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 70 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToFirstLower(property.Name)));
            
            #line default
            #line hidden
            this.Write("\"\r\n        ");
            
            #line 71 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("}");
            
            #line 71 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 if (property != Model.PropertyList.Last()) { 
            
            #line default
            #line hidden
            this.Write(",");
            
            #line 71 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 }

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 74 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"

} 
            
            #line default
            #line hidden
            this.Write("    }\r\n};\r\n");
            
            #line 78 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 if (Model.IsReference) { 
            
            #line default
            #line hidden
            this.Write(" \r\nexport const ");
            
            #line 79 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToFirstLower(Model.Name)));
            
            #line default
            #line hidden
            this.Write(" = {type: {} as ");
            
            #line 79 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(", valueKey: \"");
            
            #line 79 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToFirstLower(Model.PrimaryKey.First().Name)));
            
            #line default
            #line hidden
            this.Write("\", labelKey: \"");
            
            #line 79 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.ToFirstLower(Model.DefaultProperty ?? "Libelle")));
            
            #line default
            #line hidden
            this.Write("\"}; \r\n");
            
            #line 80 "D:\Projets\CINP_BIRD\Tools\Kinetix.ClassGenerator\JavascriptGenerator\TypescriptTemplate.tt"
 } 
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class TypescriptTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
